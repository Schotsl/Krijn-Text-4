using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SharpUpdate
{
    public class SharpUpdater
    {

        private Form ParentForm;

        private Assembly ParentAssembly;

        private string ParentPath;

        private SharpUpdateLocalAppInfo[] LocalApplicationInfos;

        private SharpUpdateXml[] JobsFromXML;

        private int Num_Jobs = 0;

        private List<string> tempFilePaths = new List<string>();
        private List<string> currentPaths = new List<string>();
        private List<string> newPaths = new List<string>();
        private List<string> launchArgss = new List<string>();
        private List<JobType> jobtypes = new List<JobType>();

        private int acceptJobs = 0;

        private BackgroundWorker BgWorker;

        private Uri UpdateXmlLocation;

        public SharpUpdater(Assembly a, Form owner, Uri XMLOnServer)
        {
            ParentForm = owner;
            ParentAssembly = a;
            ParentPath = a.Location;

            UpdateXmlLocation = XMLOnServer;

            // Set up backgroundworker
            BgWorker = new BackgroundWorker();
            BgWorker.DoWork += new DoWorkEventHandler(BgWorker_DoWork);
            BgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BgWorker_RunWorkerCompleted);
        }

        /// Checks for an update for the files passed.
        /// If there is an update, a dialog asking to download will appear
        public void DoUpdate()
        {
            if (!BgWorker.IsBusy)
                BgWorker.RunWorkerAsync();
        }

        /// Checks for/parses update.xml on server
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Check for update on server
            if (!SharpUpdateXml.ExistsOnServer(UpdateXmlLocation))
                e.Cancel = true;
            else // Parse update xml
                e.Result = SharpUpdateXml.Parse(UpdateXmlLocation);
        }

        /// After the background worker is done, prompt to update if there is one
        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // If there is a file on the server
			if (!e.Cancelled)
			{
                JobsFromXML = (SharpUpdateXml[])e.Result;

				// Check if the update is not null and is a newer version than the current application
				if (JobsFromXML != null)
				{
                    Console.WriteLine("Number of updates from XML: " + JobsFromXML.Length);

                    // create local app info according to update xml
                    Num_Jobs = JobsFromXML.Length;
                    LocalApplicationInfos = new SharpUpdateLocalAppInfo[Num_Jobs];
                    for (int i = 0; i < Num_Jobs; ++i)
                    {
                        if (Path.GetFileName(ParentPath).CompareTo(Path.GetFileName(JobsFromXML[i].FilePath)) == 0)
                        {
                            LocalApplicationInfos[i] = new SharpUpdateLocalAppInfo(JobsFromXML[i], ParentAssembly, ParentForm);
                        }
                        else
                        {
                            LocalApplicationInfos[i] = new SharpUpdateLocalAppInfo(JobsFromXML[i]);
                        }
                        LocalApplicationInfos[i].Print();
                    }

                    // validate all update jobs
                    List<int> validJobs = new List<int>();
                    for (int i = 0; i < Num_Jobs; ++i)
                    {
                        if (JobsFromXML[i].Tag == JobType.UPDATE)
                        {
                            if (!JobsFromXML[i].IsNewerThan(LocalApplicationInfos[i].Version))
                                continue;
                        }
                        validJobs.Add(i);
                    }

                    // let user choose to accept update jobs
                    bool showMsgBox = true;
                    int count = 0;
                    foreach (int i in validJobs)
                    {
                        count++;
                        showMsgBox = false;

                        // Ask to accept the update
                        if (new SharpUpdateAcceptForm(LocalApplicationInfos[i], JobsFromXML[i], count, validJobs.Count).ShowDialog(LocalApplicationInfos[0].Context) == DialogResult.Yes)
                        {
                            acceptJobs++;
                            DownloadUpdate(JobsFromXML[i], LocalApplicationInfos[i]); // Do the update
                        }
                    }

                    if (showMsgBox)
                    {
                        MessageBoxEx.Show(ParentForm, "The lastest version of Krijn is already installed!");
                    }
                    else
                    {
                        if (acceptJobs > 0)
                            InstallUpdate();
                    }
                }
				else
					MessageBoxEx.Show(ParentForm, "The lastest version of Krijn is already installed!");
			}
			else
				MessageBoxEx.Show(ParentForm, "No update information found!");
        }

        /// Download the update
        private void DownloadUpdate(SharpUpdateXml update, SharpUpdateLocalAppInfo applicationInfo)
        {
            if (update.Tag == JobType.REMOVE)
            {
                tempFilePaths.Add("");
                currentPaths.Add("");
                newPaths.Add(Path.GetFullPath(applicationInfo.ApplicationPath));
                launchArgss.Add(update.LaunchArgs);
                jobtypes.Add(update.Tag);
                return;
            }

            SharpUpdateDownloadForm form = new SharpUpdateDownloadForm(update.Uri, update.MD5, applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(applicationInfo.Context);

            if (result == DialogResult.OK)
            {
                string currentPath = (update.Tag == JobType.UPDATE) ? applicationInfo.ApplicationAssembly.Location : "";
                string newPath = (update.Tag == JobType.UPDATE) ? Path.GetFullPath(Path.GetDirectoryName(currentPath).ToString() + update.FilePath) : Path.GetFullPath(applicationInfo.ApplicationPath);
                Directory.CreateDirectory(Path.GetDirectoryName(newPath));

                tempFilePaths.Add(form.TempFilePath);
                currentPaths.Add(currentPath);
                newPaths.Add(newPath);
                launchArgss.Add(update.LaunchArgs);
                jobtypes.Add(update.Tag);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBoxEx.Show(ParentForm, "The update download was cancelled.\nThis program has not been modified.", "Update Download Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(ParentForm, "There was a problem downloading the update.\nPlease try again later.", "Update Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// Install all the updates
        private void InstallUpdate()
        {
            MessageBoxEx.Show(ParentForm, "Application restarts in 5 seconds", "Success", 5000);
            UpdateApplications();
            Application.Exit();
        }

        /// Closes program, delete original, move the new one to that location
        private void UpdateApplications()
        {
            string argument_start = "/C choice /C Y /N /D Y /T 4 & Start \"\" /D \"{0}\" \"{1}\"";
            string argument_update = "/C choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & choice /C Y /N /D Y /T 2 & Move /Y \"{1}\" \"{2}\"";
            string argument_update_start = argument_update + " & Start \"\" /D \"{3}\" \"{4}\" {5}";
            string argument_add = "/C choice /C Y /N /D Y /T 4 & Move /Y \"{0}\" \"{1}\"";
            string argument_remove = "/C choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\"";
            string argument_complete = "";

            int curAppidx = -1;
            for (int i = 0; i < acceptJobs; ++i)
            {
                string curName = Path.GetFileName(currentPaths[i]);
                if (curName.CompareTo("") != 0 && Path.GetFileName(ParentPath).CompareTo(curName) == 0)
                {
                    curAppidx = i;
                    continue;
                }

                if (jobtypes[i] == JobType.ADD)
                {
                    argument_complete = string.Format(argument_add, tempFilePaths[i], newPaths[i]);
                    Console.WriteLine("add: " + argument_complete);
                }
                else if (jobtypes[i] == JobType.UPDATE)
                {
                    argument_complete = string.Format(argument_update, currentPaths[i], tempFilePaths[i], newPaths[i]);
                    Console.WriteLine("update: " + argument_complete);
                }
                else
                {
                    argument_complete = string.Format(argument_remove, newPaths[i]);
                    Console.WriteLine("remove: " + argument_complete);
                }

                ProcessStartInfo cmd = new ProcessStartInfo
                {
                    Arguments = argument_complete,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                };
                Process.Start(cmd);
            }

            if (curAppidx > -1)
            {
                argument_complete = string.Format(argument_update_start, currentPaths[curAppidx], tempFilePaths[curAppidx], newPaths[curAppidx], Path.GetDirectoryName(newPaths[curAppidx]), Path.GetFileName(newPaths[curAppidx]), launchArgss[curAppidx]);
                Console.WriteLine("Update and run main app: " + argument_complete);
            }
            else
            {
                argument_complete = string.Format(argument_start, Path.GetDirectoryName(ParentPath), Path.GetFileName(ParentPath));
                Console.WriteLine("Run main app: " + argument_complete);
            }

            ProcessStartInfo cmd_main = new ProcessStartInfo
            {
                Arguments = argument_complete,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(cmd_main);
        }
    }
}
