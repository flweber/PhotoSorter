using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            string Url = args[0];
            string Zip = args[1];
            string ApplicationPath = args[2];
            string Executable = args[3];
            string ProcessID = args[4];

            Process.GetProcessById(Convert.ToInt32(ProcessID)).Kill();
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(Url + Zip, ApplicationPath + "\\" + Zip);
                    ZipFile.ExtractToDirectory(Path.Combine(ApplicationPath, Zip), Path.Combine(ApplicationPath, Zip.Split('.')[0]));
                    string[] files = Directory.GetFiles(Path.Combine(ApplicationPath, Executable.Split('.')[0]) + ".*");
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                    files = Directory.GetFiles(Path.Combine(ApplicationPath, Zip.Split('.')[0], Executable.Split('.')[0]) + ".*");
                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        File.Move(file, Path.Combine(ApplicationPath, fileInfo.Name));
                    }
                    Directory.Delete(Path.Combine(ApplicationPath, Zip.Split('.')[0]));
                    Process.Start(Path.Combine(ApplicationPath, Executable));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Leider gab es einen Fehler bei dem Update der Software " + Executable.Split('.')[0]);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
