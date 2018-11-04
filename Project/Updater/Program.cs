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
            string Executable = Path.GetFileName(args[3]);
            string ProcessID = args[4];

            Process.GetProcessById(Convert.ToInt32(ProcessID)).Kill();

            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(Url + Zip, ApplicationPath + "\\" + Zip);
                    ZipFile.ExtractToDirectory(Path.Combine(ApplicationPath, Zip), Path.Combine(ApplicationPath, Zip.Split('.')[0]));
                    DirectoryInfo SearchDir = new DirectoryInfo(ApplicationPath);
                    FileInfo[] files = SearchDir.GetFiles(Executable.Split('.')[0] + ".*");
                    foreach (FileInfo file in files)
                    {
                        File.Delete(file.FullName);
                    }
                    SearchDir = new DirectoryInfo(Path.Combine(ApplicationPath, Zip.Split('.')[0]));
                    files = SearchDir.GetFiles(Executable.Split('.')[0] + ".*");
                    foreach (FileInfo file in files)
                    {
                        File.Move(file.FullName, Path.Combine(ApplicationPath, file.Name));
                    }
                    Directory.Delete(Path.Combine(ApplicationPath, Zip.Split('.')[0]), true);
                    File.Delete(Path.Combine(ApplicationPath, Zip));
                    Process.Start(Path.Combine(ApplicationPath, Executable));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Leider gab es einen Fehler bei dem Update der Software " + Executable.Split('.')[0]);
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
