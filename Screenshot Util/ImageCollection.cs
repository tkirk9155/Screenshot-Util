using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Screenshot_Util
{
    public class ImageCollection
    {
        public string Name;
        public string Path;
        public string Size;
        public int Files;
        public string Info;
        public DateTime Created;
        public DateTime Modified;
        public List<Thumbnail> Images;
        public Dictionary<String, String> SaveStrings;
        //private ImageCollection _imageCollection;

        public ImageCollection(System.Windows.Forms.DataGridViewRow gridRow)
        {
            Name = gridRow.Cells["Name"].Value.ToString();
            Path = gridRow.Cells["Directory"].Value.ToString();
            Size = gridRow.Cells["Size"].Value.ToString();
            Files = Convert.ToInt32(gridRow.Cells["NumberPhotos"].Value);
            Info = gridRow.Cells["Info"].Value.ToString();
            Created = Convert.ToDateTime(gridRow.Cells["DateCreated"].Value);
            Modified = Convert.ToDateTime(gridRow.Cells["DateModified"].Value);
            Images = new List<Thumbnail>();
            SaveStrings = new Dictionary<string, string>();

            string infoPath = Path + @"\" + "info.txt";
            if (!File.Exists(infoPath))
            {
                File.WriteAllText(infoPath, "");
                System.Threading.Thread.Sleep(500);
            }

            string[] fileContents = File.ReadAllLines(infoPath);
            for (int i = 1; i < fileContents.Length; i++)
            {
                string[] line = fileContents[i].Split('|');
                string[] dates = GetFileDates(line[0]);

                this.Images.Add(new Thumbnail
                {
                    FileName = line[0],
                    ImageName = line[1],
                    Info = line[2],
                    DateCreated = dates[0],
                    DateModified = dates[1]
                });
            }
        }



        public void NewScreenshot(string fileName)
        {
            this.Images.Add(new Thumbnail
            {
                DateCreated = DateTime.Now.ToString(),
                DateModified = DateTime.Now.ToString(),
                FileName = fileName
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



        public void RemoveDeletedImages()
        {
            string[] saveImages = this.Images.Select(x => x.FileName).ToArray();
            foreach(string file in Directory.GetFiles(this.Path))
            {
                if (!saveImages.Contains(file))
                    File.Delete(this.Path + @"\" + file);
            }
        }



        public void RemovePendingImages()
        {
            string[] saveImages = File.ReadAllLines(this.Path + @"\info.txt");
            for(int i = 1; i < saveImages.Length; i++)
                saveImages[i] = saveImages[i].Remove(saveImages[i].IndexOf("|"));

            foreach(string file in Directory.GetFiles(this.Path))
            {
                if (!saveImages.Contains(file))
                    File.Delete(this.Path + @"\" + file);
            }
        }


        //public class ThumbInfo
        //{
        //    public string FileName;
        //    public string ImageName;
        //    public string Info;
        //    public string DateCreated;
        //    public string DateModified;
        //}

    }
}
