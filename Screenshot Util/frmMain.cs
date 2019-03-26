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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }



        private void FillDataGrid()
        {
            grdBrowseFiles.DataSource = Main.GetFilesList();
            grdBrowseFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }



        private void grdBrowseFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Main.OpenCollection(grdBrowseFiles.CurrentRow);
            //tabMain.SelectTab(tabOpen);
            //foreach (Thumbnail thumb in Main.CurrentCollection.Images)
            //{
            //    flowPanel.Controls.Add(thumb);
            //}
            OpenCollection();
        }



        private void barMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToLower())
            {
                case "tsbnew":
                    NewCollection();
                    break;

                case "tsbopen":
                    OpenCollection();
                    break;

                case "tsbscreenshot":
                    NewScreenshot();
                    break;
            }
        }


        public void NewCollection()
        {
            if (Main.NewCollection())
                OpenCollection();
        }


        public void NewScreenshot()
        {
            if (Main.NewScreenshot())
            {
                flowPanel.Controls.Add(Main.CurrentCollection.Images.Last());
            }
        }



        public void OpenCollection()
        {
            //if(grdBrowseFiles.Rows.Count != Main.GridDatasource.Rows.Count)
            //{
            //    grdBrowseFiles.DataSource = null;
            //    grdBrowseFiles.DataSource = Main.GridDatasource;
            //    grdBrowseFiles.Refresh();
            //}
            Main.OpenCollection(grdBrowseFiles.CurrentRow);
            //Main.OpenCollection(grdBrowseFiles.Rows[grdBrowseFiles.Rows.Count - 1]);
            foreach (Thumbnail thumb in Main.CurrentCollection.Images)
            {
                flowPanel.Controls.Add(thumb);
            }

            tabMain.SelectTab(tabOpen);
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            tabMain.Appearance = TabAppearance.FlatButtons;
            tabMain.ItemSize = new Size(0, 1);
            tabMain.SizeMode = TabSizeMode.Fixed;

            FillDataGrid();
        }

        private void flowPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType() == typeof(Thumbnail))
                Main.CurrentCollection.Images.Last<Thumbnail>().picThumbnail.Click += Thumbnail_Click;
                Main.CurrentCollection.Images.Last<Thumbnail>().lblDescription.Click += Thumbnail_Click;
        }


        private void DisposeImage()
        {
            if (picDisplay.Image != null)
            {
                picDisplay.Image.Dispose();
                picDisplay.Image = null;
            }
        }

        private void Thumbnail_Click(object sender, EventArgs e)
        {
            DisposeImage();

            PictureBox pic;
            Label lbl;
            Thumbnail inf;

            if (sender.GetType() == typeof(PictureBox))
            {
                pic = (PictureBox)sender;
                inf = (Thumbnail)pic.Parent;
            }
            else
            {
                lbl = (Label)sender;
                inf = (Thumbnail)lbl.Parent;
            }

            txtName.Text = inf.Name;
            txtDescription.Text = inf.Info;
            picDisplay.Image = Image.FromFile(inf.FileName);
            if (inf.DateModified == null || inf.DateCreated == null)
            {
                string[] dates = Main.GetFileDates(inf.FileName);
                inf.DateCreated = dates[0];
                inf.DateModified = dates[1];
            }
            lblDateCreated.Text = inf.DateCreated;
            lblDateModified.Text = inf.DateModified;

            Main.ActiveThumbnail = inf;
            txtDescription.TextChanged += (o, i) => { Main.ActiveThumbnail.Info = txtDescription.Text; };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Main.SaveImageInfo();
        }


        private void Description_Changed(object sender, EventArgs e)
        {
            Main.ActiveThumbnail.Info = txtDescription.Text;
        }
    }
}
