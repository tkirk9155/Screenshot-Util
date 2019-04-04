using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;

namespace Screenshot_Util
{
    public class ImageCollection
    {

        public string OriginalName { get; private set; }
        public string OriginalInfo { get; private set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Size { get; set; }
        public int Files { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public List<Thumbnail> Thumbnails;



        public ImageCollection(string folderPath) 
        {
            Path = folderPath;
            string infoPath = Main.GetPath(Path, "info.txt");
            if (!File.Exists(infoPath))
            {
                File.WriteAllText(infoPath, "");
                System.Threading.Thread.Sleep(500);
            }


            string[] fileContents = File.ReadAllLines(infoPath).Where(f => f.Trim().Length > 0).ToArray();
            if (fileContents[0].Contains('|'))
            {
                string[] info = fileContents[0].Split('|');
                Description = info.Length > 1 ? info[1] : "";
            }

            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            Name = dirInfo.Name;
            FileInfo[] getFiles = dirInfo.GetFiles("*.png");
            Files = getFiles.Length;
            Size = GetDirectorySize(getFiles);
            SetDates(dirInfo);

            Thumbnails = new List<Thumbnail>();

            for (int i = 1; i < fileContents.Length; i++)
            {
                string[] line = fileContents[i].Split('|');

                Thumbnails.Add(new Thumbnail
                {
                    FilePath = Main.GetPath(this.Path, line[0]),
                    ImageName = line[1],
                    Description = line[2],
                });
            }

            OriginalName = Name;
            OriginalInfo = Description;
        }



        public void NewScreenshot(string fileName)
        {
            this.Thumbnails.Add(new Thumbnail
            {
                DateCreated = DateTime.Now.ToString(),
                DateModified = DateTime.Now.ToString(),
                FilePath = fileName
            });
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



        public async Task<bool> Rename(string newFolderName)
        {
            string newPath = await Main.RenameFolderAsync(Path, newFolderName);
            if (newPath == null) { return false; }
            Path = newPath;
            Name = newFolderName;
            SetDates();
            return true;
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


        public async void Save()
        {

            string writeToFile = Name + "|" + Description + Environment.NewLine;
            string formatString = "{0}|{1}|{2}" + Environment.NewLine;

            foreach (Thumbnail thumb in Thumbnails)
            {
                if(thumb.TempFileName != null)
                {
                    // set temp file (now the new image)'s creation date to the original image's
                    DateTime creationDate = new FileInfo(thumb.FilePath).CreationTime;
                    await Main.DeleteFileAsync(thumb.FilePath);
                    File.Move(Main.GetPath(thumb.TempFilePath, thumb.TempFileName), thumb.FilePath);
                    File.SetCreationTime(thumb.FilePath, creationDate);
                }

                if(thumb.OriginalInfo != thumb.Description || thumb.ImageName != thumb.OriginalName)
                {
                    File.SetLastWriteTime(thumb.FilePath, DateTime.Now);
                }

                writeToFile += string.Format(formatString, thumb.FileName, thumb.ImageName, thumb.Description);
            }

            File.WriteAllText(Main.GetPath(Path, "info.txt"), writeToFile);

            foreach (string folder in Directory.GetDirectories(Path))
                await Main.DeleteFolderAsync(folder);

            string[] saveImages = Thumbnails.Select(x => x.FilePath).ToArray();
            foreach (string file in Directory.GetFiles(Path, "*.png"))
            {
                if (!saveImages.Contains(file))
                    await Main.DeleteFileAsync(file);
            }
        }



        public void Exit()
        {
            foreach (Thumbnail thumb in Thumbnails)
            {
                if (Directory.Exists(thumb.TempFilePath))
                    Directory.Delete(thumb.TempFilePath, true);

                thumb.picThumbnail.Image.Dispose();
                thumb.picThumbnail.Image = null;
            }
        }


    }
}
