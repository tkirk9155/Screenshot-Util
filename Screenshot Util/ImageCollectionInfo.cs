using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Screenshot_Util
{
    public class ImageCollectionInfo
    {
        public string Name;
        public string Path;
        public string Size;
        public int Files;
        public string Description;

        public DateTime DateCreated;
        public DateTime DateModified;



        public ImageCollectionInfo(string folderPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            string fileContents = File.ReadAllLines(folderPath + @"\info.txt")[0];
            if (fileContents.Contains('|'))
            {
                string[] info = fileContents.Split('|');
                Description = info.Length > 1 ? info[1] : "";
            }

            Name = dirInfo.Name;
            FileInfo[] getFiles = dirInfo.GetFiles("*.png");
            Files = getFiles.Length;
            Size = GetDirectorySize(getFiles);
            SetDates(dirInfo);
            Path = folderPath;
        }



        private string GetDirectorySize(FileInfo[] getFiles)
        {
            double numBytes = 0;
            foreach (FileInfo f in getFiles)
                numBytes += f.Length;

            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = numBytes;
            for (i = 0; i < Suffix.Length && numBytes >= 1024; i++, numBytes /= 1024)
                dblSByte = numBytes / 1024.0;

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }



        public async void Rename(string newFolderName)
        {
            Path = await Main.RenameFolderAsync(Path, newFolderName);
            Name = newFolderName;
            SetDates();
        }



        private void SetDates(DirectoryInfo dirInfo = null)
        {
            if (dirInfo == null)
                dirInfo = new DirectoryInfo(Path);
            DateCreated = dirInfo.CreationTime;
            DateModified = dirInfo.LastWriteTime;
        }


        public void SetDescription(string description)
        {
            Description = description;

            string infoPath = Main.GetPath(Path, "info.txt");
            string[] fileContents = File.ReadAllLines(infoPath);
            fileContents[0] = Name + "|" + Description;
            File.WriteAllLines(infoPath, fileContents);
        }

    }
}
