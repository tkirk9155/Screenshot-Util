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
            for (int i = 0; i < lstPrint.Items.Count; i++)
            {
                if(lstPrint.GetItemChecked(i))
                {
                    printImages.Add(Main.CurrentCollection.Thumbnails.FirstOrDefault(t =>
                    {
                        bool result = false;
                        if (t.ImageName == lstPrint.Items[i].ToString()
                            || t.FileName == lstPrint.Items[i].ToString())
                        {
                            result = true;
                        }

                        return result;
                    }));
                }

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
                    lstPrint.Items.Add(thumb.FileName);
                    i++;
                }
                else { lstPrint.Items.Add(thumb.ImageName); }
                lstPrint.SetItemChecked(lstPrint.Items.Count - 1, true);
            }
        }
    }
}
