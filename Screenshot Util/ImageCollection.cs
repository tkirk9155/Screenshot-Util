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

            string infoPath = Path.Remove(Path.LastIndexOf("\\") + 1) + "info.txt";
            if (!File.Exists(infoPath))
            {
                File.WriteAllText(infoPath, Name + "|" + Info);
                System.Threading.Thread.Sleep(500);
            }

            string[] fileContents = File.ReadAllLines(infoPath);
            for (int i = 1; i < fileContents.Length; i++)
            {
                string[] line = fileContents[i].Split('|');
                Images.Add(new Thumbnail
                {
                    FileName = line[0],
                    ImageName = line[1],
                    Info = line[2],
                    DateCreated = line[3],
                    DateModified = line[4]
                });
            }
        }


        public void NewScreenshot(string fileName)
        {
            Images.Add(new Thumbnail
            {
                DateCreated = DateTime.Now.ToString(),
                DateModified = DateTime.Now.ToString(),
                FileName = fileName
            });
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
