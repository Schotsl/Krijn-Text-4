using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            string updateDownload = "https://krijn.serialpowered.com/Krijn-Text-4.exe";

            string updatePath, updateFileName, processID;

            updatePath = args[0].ToString();
            updateFileName = args[1].ToString();
            processID = args[2].ToString();

            //Kills exising .exe if running
            Process.GetProcessById(Convert.ToInt32(processID)).Kill();

            //Writes variable outcomes in command line (Unecessary)
            Console.WriteLine(updatePath);
            Console.WriteLine(updateFileName);
            Console.WriteLine(processID);

            //Uses webclient to download new .exe
            using (WebClient updaterWC = new WebClient())
            {
                updaterWC.DownloadFile(updateDownload, updatePath + "\\KrijnText4.exe");
            }

            //Deletes old .exe
            File.Delete(updatePath + "\\" + updateFileName);

            //Renames downloaded exe
            File.Move(updatePath + "KrijnText4.exe", updatePath + "\\" + updateFileName);

            //Starts the updated program
            Process.Start(updatePath + "\\" + updateFileName);
        }
    }
}
