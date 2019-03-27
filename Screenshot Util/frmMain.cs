using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Screenshot_Util
{
    public partial class frmMain : Form
    {
        private System.Nullable<Point> _prevPoint;
        private Pen _pen;
        private DrawMode _drawMode;


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

                case "tsbdeletescreenshot":
                    
                    break;

                case "tsbbrowse":
                    BrowseForImage();
                    break;

                case "tsbsavecollection":
                    Main.SaveCollection();
                    break;

                case "tsbundo":
                    UndoChangesToImage();
                    break;
            }
        }



        private void UndoChangesToImage()
        {
            string img = Main.RestorePreviousImage();
            if (img != null)
            {
                DisposeImage();
                picDisplay.Image = Image.FromFile(img);
                picDisplay.Invalidate();
            }
        }


        private void NewCollection()
        {
            if (Main.NewCollection())
                OpenCollection();
        }



        private void NewScreenshot(string filePath = null)
        {
            if (Main.NewScreenshot(filePath))
            {
                flowPanel.Controls.Add(Main.CurrentCollection.Images.Last());
            }
        }



        private int BrowseForImage()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                dlg.RestoreDirectory = true;
                dlg.Filter = "Images (*.png, *.jpg)|*.png;*.jpg";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (!dlg.FileName.Contains(".png") && !dlg.FileName.Contains(".jpg"))
                        return 1;
                    else
                        NewScreenshot(dlg.FileName);
                }
            }

            return 0;
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
            FlowPanel_SelectFirst();
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
                ((Thumbnail)e.Control).picThumbnail.Click += Thumbnail_Click;
                ((Thumbnail)e.Control).lblDescription.Click += Thumbnail_Click;
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

            txtDescription.TextChanged -= Description_Changed;
            txtName.TextChanged -= Name_Changed;
            if (Main.ActiveThumbnail != null)
                Main.ActiveThumbnail.BorderStyle = BorderStyle.FixedSingle;

            Main.ActiveThumbnail = (Thumbnail)((Control)sender).Parent;
            Main.ActiveThumbnail.BorderStyle = BorderStyle.Fixed3D;

            txtName.Text = Main.ActiveThumbnail.ImageName;
            txtDescription.Text = Main.ActiveThumbnail.Info;
            picDisplay.Image = Image.FromFile(Main.ActiveThumbnail.FileName);

            lblDateCreated.Text = "Created: " + Main.ActiveThumbnail.DateCreated;
            lblDateModified.Text = "Modified: " + Main.ActiveThumbnail.DateModified;

            txtDescription.TextChanged += Description_Changed;
            txtName.TextChanged += Name_Changed;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            //Main.SaveCollection();
        }



        private void FlowPanel_SelectFirst()
        {
            if (flowPanel.Controls.Count > 0)
                Thumbnail_Click(flowPanel.Controls.OfType<Thumbnail>().FirstOrDefault<Thumbnail>().picThumbnail,
                                new EventArgs());
        }


        private void DeleteScreenshot()
        {
            flowPanel.Controls.Remove(Main.ActiveThumbnail);
            Main.CurrentCollection.Images.Remove(Main.ActiveThumbnail);
            FlowPanel_SelectFirst();
        }



        private void Description_Changed(object sender, EventArgs e)
        {
            Main.ActiveThumbnail.Info = txtDescription.Text;
        }

        private void Name_Changed(object sender, EventArgs e)
        {
            Main.ActiveThumbnail.ImageName = txtName.Text;
            Main.ActiveThumbnail.lblDescription.Text = Main.ActiveThumbnail.ImageName;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = Main.ActiveThumbnail.OriginalName;
            txtDescription.Text = Main.ActiveThumbnail.OriginalInfo;
        }



        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_drawMode)
            {
                case DrawMode.Pen:
                    _pen = new Pen(Color.Red, 3);
                    break;

                case DrawMode.Highlight:
                    _pen = new Pen(Color.FromArgb(48, 255, 255, 0), 30);
                    break;
            }

            _prevPoint = e.Location;
            picDisplay_MouseMove(sender, e);
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if(picDisplay.Image != null)
            {
                if(_prevPoint != null)
                {
                    using (Graphics g = Graphics.FromImage(picDisplay.Image))
                        g.DrawLine(_pen, _prevPoint.Value, e.Location);
                    picDisplay.Invalidate();
                    _prevPoint = e.Location;
                }
            }
        }

        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            _prevPoint = null;
            _pen.Dispose();
            _pen = null;
            Main.SaveTempImage(picDisplay.Image);
        }

        private void tsbDrawMode_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToLower())
            {
                case "tsbpen":
                    _drawMode = DrawMode.Pen;
                    break;

                case "tsbhighlight":
                    _drawMode = DrawMode.Highlight;
                    break;
            }
        }

        private enum DrawMode
        {
            Pen = 0,
            Highlight = 1
        }
    }
}
