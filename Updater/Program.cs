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

            Process.GetProcessById(Convert.ToInt32(processID)).Kill();

            Console.WriteLine(updatePath);
            Console.WriteLine(updateFileName);
            Console.WriteLine(processID);

            using (WebClient updaterWC = new WebClient())
            {
                updaterWC.DownloadFile(updateDownload, updatePath + "\\KrijnText4.exe");
            }

            File.Delete(updatePath + "\\" + updateFileName);

            File.Move(updatePath + "KrijnText4.exe", updatePath + "\\" + updateFileName);
            File.Move("KrijnText4-1", "KrijnText4-2");

            Process.Start(updatePath + "\\" + updateFileName);
        }
    }
}
