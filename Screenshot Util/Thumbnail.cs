using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using Screenshot_Util;

namespace Screenshot_Util
{
    public partial class Thumbnail : UserControl
    {
        //public string FileName;
        public string FilePath;
        public string ImageName;
        public string Description;
        public string DateCreated;
        public string DateModified;
        public string TempFileName;
        public string TempFilePath;
        //public string TempFilePath;

        public delegate void ThumbnailClickedHandler(object sender, EventArgs e);
        public event ThumbnailClickedHandler ThumbnailClicked;


        //private bool _tempFile;
        private string _originalName;
        private string _originalInfo;

        //public string TempFilePath
        //{
        //    get
        //    {
        //        return TempFilePath.Remove(TempFilePath.LastIndexOf(@"\")).Insert(TempFilePath.LastIndexOf(@"\") + 1, "temp");
        //    }
        //}

        public string FileName
        {
            get { return FilePath.Substring(FilePath.LastIndexOf('\\') + 1); }
        }

        public string OriginalName { get; private set; }

        public string OriginalInfo { get; private set; }

        private bool _thumbnailCallback() { return false; }

        public Thumbnail()
        {
            InitializeComponent();
        }


        private void Thumbnail_Load(object sender, EventArgs e)
        {
            var imgCallback = new Image.GetThumbnailImageAbort(_thumbnailCallback);
            //Image img = Bitmap.FromFile(FileName);
            using (var img = new Bitmap(this.FilePath))
            {
                img.GetThumbnailImage(Width, Height, imgCallback, IntPtr.Zero);
                picThumbnail.Image = new Bitmap(img);
            }
            lblDescription.Text = ImageName;
            lblDescription.BackColor = Color.Transparent;
            OriginalName = this.ImageName;
            OriginalInfo = this.Description;
            TempFilePath = FilePath.Insert(FilePath.LastIndexOf(@"\") + 1, "temp"); ;
            TempFilePath = TempFilePath.Remove(TempFilePath.LastIndexOf("."));

            FileInfo fInfo = new FileInfo(this.FilePath);
            if (fInfo.LastWriteTime < fInfo.CreationTime)
            {
                File.SetLastWriteTime(FilePath, fInfo.CreationTime);
                fInfo.Refresh();
            }

            DateCreated = fInfo.CreationTime.ToString();
            DateModified = fInfo.LastWriteTime.ToString();
        }




        public void SaveTempImage(Image img)
        {
            if (!Directory.Exists(TempFilePath))
                Directory.CreateDirectory(TempFilePath);

            int fileName = 0;
            foreach (string file in Directory.GetFiles(TempFilePath))
                fileName++;
            TempFileName = fileName.ToString() + ".png";
            string tempFile = Main.GetPath(TempFilePath, TempFileName);
            img.Save(tempFile);

        }



        public void RestorePreviousImage()
        {
            string tempPath;

            if (TempFileName == null) { return; }

            if (!Directory.Exists(TempFilePath)) { return; }

            List<int> files = new List<int>();
            foreach (string file in Directory.GetFiles(TempFilePath))
            {
                int currentFile;
                string path = file.Remove(file.LastIndexOf(".")).Substring(file.LastIndexOf(@"\") + 1);
                if (int.TryParse(path, out currentFile))
                    files.Add(currentFile);
            }

            files = files.OrderByDescending(i => i).ToList();

            if (files.Count > 0)
            {
                TempFileName = files[0].ToString() + ".png";

                Main.DeleteFileAsync(Main.GetPath(TempFilePath, TempFileName));

                files.RemoveAt(0);
                TempFileName = null;
            }

            if (files.Count > 0)
            {
                TempFileName = files[0].ToString() + ".png";
            }
            else
            {
                if (Directory.Exists(TempFilePath))
                {
                    Main.DeleteFolderAsync(TempFilePath);
                }

                TempFileName = null;
            }

        }

        private void picThumbnail_Click(object sender, EventArgs e)
        {
            ThumbnailClicked(this, new EventArgs());
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            ThumbnailClicked(this, new EventArgs());
        }
    }



    //public class ThumbnailEventArgs : EventArgs
    //{
    //    public string FilePath { get; private set; }
    //    public string ImageName { get; private set; }
    //    public string Description { get; private set; }
    //    public string DateCreated { get; private set; }
    //    public string DateModified { get; private set; }
    //    public string TempFileName { get; private set; }
    //    public string TempFilePath { get; private set; }
        
    //    public ThumbnailEventArgs(Thumbnail thumb)
    //    {
    //        FilePath = thumb.FilePath;
    //        ImageName = thumb.ImageName;
    //        Description = thumb.Description;
    //        DateCreated = thumb.DateCreated;
    //        FilePath = thumb.FilePath;
    //        TempFileName = thumb.TempFileName;
    //        TempFilePath = thumb.TempFilePath;
    //    }

    //}

}
