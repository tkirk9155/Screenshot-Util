using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;

namespace Screenshot_Util
{
    public class ImageCollection : ImageCollectionInfo
    {
        private string _originalName;
        private string _originalInfo;

        public string OriginalName
        {
            get
            {
                return _originalName;
            }
        }

        public string OriginalInfo
        {
            get
            {
                return _originalInfo;
            }
        }

        public List<Thumbnail> Thumbnails;



        public ImageCollection(string folderPath) 
            : base(folderPath)
        {
            Thumbnails = new List<Thumbnail>();

            string infoPath = Path + @"\" + "info.txt";
            if (!File.Exists(infoPath))
            {
                File.WriteAllText(infoPath, "");
                System.Threading.Thread.Sleep(500);
            }

            string[] fileContents = File.ReadAllLines(infoPath).Where(f => f.Trim().Length > 0).ToArray();
            for (int i = 1; i < fileContents.Length; i++)
            {
                string[] line = fileContents[i].Split('|');
                string[] dates = GetFileDates(line[0]);

                Thumbnails.Add(new Thumbnail
                {
                    FilePath = Main.GetPath(this.Path, line[0]),
                    ImageName = line[1],
                    Info = line[2],
                    DateCreated = dates[0],
                    DateModified = dates[1],
                });
            }

            _originalName = Name;
            _originalInfo = Description;
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



        public static string[] GetFileDates(string fileName)
        {
            string[] dates = new string[2];
            FileInfo fInfo = new FileInfo(fileName);
            dates[0] = fInfo.CreationTime.ToString();
            dates[1] = fInfo.LastWriteTime.ToString();

            return dates;
        }



        public async void Save()
        {

            string writeToFile = Name + "|" + Description + Environment.NewLine;
            string formatString = "{0}|{1}|{2}" + Environment.NewLine;

            foreach (Thumbnail thumb in Thumbnails)
            {
                if(thumb.TempFileName != null)
                {
                    await Main.DeleteFileAsync(thumb.FilePath);
                    File.Move(Main.GetPath(thumb.TempFilePath, thumb.TempFileName), thumb.FilePath);
                }
                writeToFile += string.Format(formatString, thumb.FileName, thumb.ImageName, thumb.Info);
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
                thumb.picThumbnail.Image.Dispose();
                thumb.picThumbnail.Image = null;
            }
        }


    }
}
