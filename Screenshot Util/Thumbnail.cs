using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Screenshot_Util;

namespace Screenshot_Util
{
    public partial class Thumbnail : UserControl
    {
        public string FileName;
        public string ImageName;
        public string Info;
        public string DateCreated;
        public string DateModified;
        public string TempFile;

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

        private bool _thumbnailCallback() { return false; }

        public Thumbnail()
        {
            InitializeComponent();
        }


        private void Thumbnail_Load(object sender, EventArgs e)
        {
            var imgCallback = new Image.GetThumbnailImageAbort(_thumbnailCallback);
            //Image img = Bitmap.FromFile(FileName);
            using (var img = new Bitmap(this.FileName))
            {
                img.GetThumbnailImage(Width, Height, imgCallback, IntPtr.Zero);
                picThumbnail.Image = new Bitmap(img);
            }
            lblDescription.Text = ImageName;
            lblDescription.BackColor = Color.Transparent;
            _originalName = this.ImageName;
            _originalInfo = this.Info;
        }
    }
}
