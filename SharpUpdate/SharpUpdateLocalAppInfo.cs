using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SharpUpdate
{
    /// The class that holds all application's information
    public class SharpUpdateLocalAppInfo
    {
        /// The path of your application
        public string ApplicationPath { get; }

        /// The name of your application as you want it displayed on the update form
        public string ApplicationName { get; }

        /// The current assembly
        public Assembly ApplicationAssembly { get; }

        /// The application's icon to be displayed in the top left
        public Icon ApplicationIcon { get; }

        /// The context of the program.
        public Form Context { get; }

        /// The version of your application
        public Version Version { get; }

        /// Tag to distinguish types of updates
        public JobType Tag;

        public SharpUpdateLocalAppInfo(SharpUpdateXml job, Assembly ass, Form f)
        {
            ApplicationPath = job.FilePath;
            ApplicationName = Path.GetFileNameWithoutExtension(ApplicationPath);
            ApplicationAssembly = ass;
            ApplicationIcon = f.Icon;
            Context = f;
            Version = (job.Tag == JobType.UPDATE) ? ApplicationAssembly.GetName().Version : job.Version;
            Tag = job.Tag;
        }

        public SharpUpdateLocalAppInfo(SharpUpdateXml job)
        {
            ApplicationPath = job.FilePath;
            ApplicationName = Path.GetFileNameWithoutExtension(ApplicationPath);
            ApplicationAssembly = (job.Tag == JobType.UPDATE) ? Assembly.Load(ApplicationName) : null;
            ApplicationIcon = null;
            Context = null;
            Version = (job.Tag == JobType.UPDATE) ? ApplicationAssembly.GetName().Version : job.Version;
            Tag = job.Tag;
        }

        public void Print()
        {
            string head = "========== SharpUpdateLocalAppInfo ==========";
            string tail = "=============================================";
            string toPrint = string.Format("{0}\nJob type: {1}\nApplicationPath: {2}\nApplicationName: {3}\nAssemblyName: {4}\nFormName: {5}\nVersion: {6}\n{7}", 
                head, Tag.ToString(), ApplicationPath == null ? "null" : ApplicationPath,
                ApplicationName == null ? "null" : ApplicationName, 
                ApplicationAssembly == null ? "null" : ApplicationAssembly.FullName, 
                Context == null ? "null" : Context.Name, 
                Version == null ? "null" : Version.ToString(), tail);
            Console.WriteLine(toPrint);
        }
    }
}