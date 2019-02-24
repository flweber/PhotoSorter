using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotoSorter
{
    class PhotoSorter
    {
        internal string Destination { get; private set; }
        internal string Source { get; private set; }
        internal string SortFolder { get; private set; }

        internal int NumberOfSourceFiles
        {
            get { return SourceFiles.Count; }
        }

        private List<string> SourceFiles;

        public PhotoSorter(string DestFolder, string SrcFolder, string SortFolder)
        {
            this.Destination = DestFolder;
            this.Source = SrcFolder;
            this.SortFolder = SortFolder;
            SourceFiles = new List<string>();
        }

        internal void CheckIfDirExists()
        {
            // Sicherheit um dafür zu sorgen, dass der Ordner nicht überschrieben wird,
            // falls dieser bereits existiert
            int n = 1;
            string check_folder = this.SortFolder;

            while (Directory.Exists(this.Destination + "\\" + check_folder))
            {
                check_folder = this.SortFolder + "-" + n++;
            }

            this.SortFolder = this.Destination + "\\" + check_folder;
        }

        internal void CreateNewDirectory(string Dir)
        {
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }
        }

        internal void ReadSourceDir()
        {
            SourceFiles = Directory.GetFiles(this.Source).ToList();
        }

        internal void SortPicture(int Pic, bool byCreationDate, bool byModifiedatDate, bool AllImages, bool Copy, DateTime From, DateTime To)
        {
            string file = SourceFiles[Pic];
            // Nur wenn es ein Bild ist
            if (file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".jpg")
                || file.ToLower().EndsWith(".jpeg") || file.ToLower().EndsWith(".tif")
                || file.ToLower().EndsWith(".bmp") || file.ToLower().EndsWith(".gif")
                || file.ToLower().EndsWith(".raw"))
            {
                // Bildinformationen lesen
                FileInfo fileInfo = new FileInfo(file);

                // Nur wenn es im Datumsbereich liegt oder alle Bilder kopiert werden sollen
                if ((byCreationDate && fileInfo.CreationTime.Date >= From.Date && fileInfo.CreationTime.Date <= To.Date)
                    || (byModifiedatDate && fileInfo.LastWriteTime.Date >= From.Date && fileInfo.LastWriteTime.Date <= To.Date)
                    || AllImages)
                {
                    // Erstellen des kompletten Zielpfades für das Bild
                    string fullfilepath = String.Empty;

                    if (byCreationDate)
                    {
                        fullfilepath += Path.Combine(this.SortFolder, fileInfo.CreationTime.ToString("dd-MM-yyyy"));
                    }
                    else if (byModifiedatDate)
                    {
                        fullfilepath += Path.Combine(this.SortFolder, fileInfo.LastWriteTime.ToString("dd-MM-yyyy"));
                    }

                    this.CreateNewDirectory(fullfilepath);

                    fullfilepath = CheckFileName(fullfilepath, fileInfo);

                    // Bild kopieren oder verschieben, wird anhand der Usereinstellungen gewählt
                    if (Copy)
                    {
                        File.Copy(file, fullfilepath);
                    }
                    else
                    {
                        File.Move(file, fullfilepath);
                    }
                }
            }
        }

        private string CheckFileName(string fullfilepath, FileInfo file)
        {
            fullfilepath = Path.Combine(fullfilepath, file.Name);
            string DateString = fullfilepath.Split('\\')[1];
            // Falls das Bild bereits existiert, soll der Name mit einer Nummer ergänzt werden
            int n = 1;
            while (File.Exists(fullfilepath))
            {
                string Filename = file.Name.Split('.')[0] + "-" + n + "." + file.Extension;
                fullfilepath = Path.Combine(this.SortFolder, DateString, Filename);
                n++;
            }
            return fullfilepath;
        }
    }
}
