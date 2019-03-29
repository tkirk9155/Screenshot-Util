using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshot_Util
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            List<Thumbnail> printImages = new List<Thumbnail>();
            foreach(var item in lstPrint.Items)
            {
                printImages.Add(Main.CurrentCollection.Thumbnails.FirstOrDefault(t => t.ImageName == item.ToString()));
            }
            Print.PrintImages(printImages);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            int i = 1;
            foreach (Thumbnail thumb in Main.CurrentCollection.Thumbnails)
            {
                if (thumb.ImageName.Length <= 0)
                {
                    lstPrint.Items.Add("unnamed" + 1.ToString());
                    i++;
                }
                else { lstPrint.Items.Add(thumb.ImageName); }
            }
        }
    }
}
