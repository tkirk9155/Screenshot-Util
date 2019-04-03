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
        private Pen _drawPen;
        private DrawMode _drawMode = DrawMode.Pen;
        private Color _drawColor = Color.Red;
        private Dictionary<string, ImageCollectionInfo> _listFiles;
        private bool Unsaved;


        public frmMain()
        {
            InitializeComponent();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            tabMain.Appearance = TabAppearance.FlatButtons;
            tabMain.ItemSize = new Size(0, 1);
            tabMain.SizeMode = TabSizeMode.Fixed;

            tabSidePanel.Appearance = TabAppearance.FlatButtons;
            tabSidePanel.ItemSize = new Size(0, 1);
            tabSidePanel.SizeMode = TabSizeMode.Fixed;

            //FillDataGrid();
            ExitControls();
            GetFilesList();
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
                    DeleteScreenshot();
                    break;

                case "tsbdeletecollection":
                    DeleteCollection();
                    break;

                case "tsbbrowse":
                    BrowseForImage();
                    break;

                case "tsbsavecollection":
                    Main.SaveCollection();
                    break;

                case "tsbcopy":
                    if (picDisplay.Image != null) { Clipboard.SetImage(picDisplay.Image); }
                    break;

                case "tsbclipboard":
                    GetImageFromClipboard();
                    break;

                case "tsbprint":
                    Main.PrintImages();
                    break;

                case "tsbundo":
                    UndoChangesToImage();
                    break;

                case "tsbexit":
                    ExitProgram();
                    break;

                case "tsbexitcollection":
                    ExitCollection();
                    break;
            }
        }



        private async void DeleteCollection()
        {
            string deletePath = null;
            if (Main.CurrentCollection != null)
                deletePath = Main.CurrentCollection.Path;
            else if (lstFiles.SelectedIndex >= 0)
                deletePath = _listFiles[lstFiles.SelectedItem.ToString()].Path;

            if (deletePath != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this collection?", null, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await Main.DeleteFolderAsync(deletePath);
                    ExitCollection(checkSave:false);
                }
            }
        }


        private void UndoChangesToImage()
        {
            Thumbnail thumb = Main.ActiveThumbnail;

            thumb.RestorePreviousImage();

            DisposeImage();
            using (var bmp = new Bitmap(thumb.TempFileName != null ? Main.GetPath(thumb.TempFilePath, thumb.TempFileName) : thumb.FilePath))
            {
                picDisplay.Image = new Bitmap(bmp);
            }
        }



        private void ExitProgram()
        {
            if (Main.CurrentCollection != null) { ExitCollection(); }
            this.Close();
        }



        private void ExitCollection(bool checkSave = true)
        {
            //if(this.Unsaved)
            if (Main.CurrentCollection != null)
            {
                if (checkSave && MessageBox.Show("Save any changes?", "",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Main.SaveCollection();
                }
                Main.ExitCollection();
            }
            
            ExitControls();
            GetFilesList();
            // exit
        }



        private void NewCollection()
        {
            //if (Main.NewCollection())
            //    OpenCollection();
            OpenCollection(Main.NewCollection());
        }



        private void NewScreenshot(string filePath = null)
        {
            Visible = false;

            if (Main.NewScreenshot(filePath))
            {
                flowPanel.Controls.Add(Main.CurrentCollection.Thumbnails.Last());
            }

            Visible = true;
        }



        private void ExitControls()
        {
            tsbNew.Enabled = true;
            tsbOpen.Enabled = true;
            tsbSaveCollection.Enabled = false;

            tsbScreenshot.Enabled = false;
            tsbBrowse.Enabled = false;
            tsbDeleteScreenshot.Enabled = false;
            tsbDrawMode.Enabled = false;
            tsbUndo.Enabled = false;
            tsbExitCollection.Enabled = false;
            tsbClipboard.Enabled = false;
            tsbCopy.Enabled = false;
            tsbPrint.Enabled = false;

            flowPanel.Controls.Clear();

            this.Size = new Size(710, 719);
            tabSidePanel.SelectTab(tabSideBrowse);

            txtCDescription.Clear();
            txtCName.Clear();
            lblCCreated.Text = null;
            lblCModified.Text = null;

            lblInfo.Text = null;

            this.Unsaved = false;

            DisposeImage();

            GetFilesList();
            tabMain.SelectTab(tabBrowse);

        }



        private void OpenControls()
        {
            tsbNew.Enabled = false;
            tsbOpen.Enabled = false;
            tsbSaveCollection.Enabled = true;

            tsbScreenshot.Enabled = true;
            tsbBrowse.Enabled = true;
            tsbDeleteScreenshot.Enabled = true;
            tsbDrawMode.Enabled = true;
            tsbUndo.Enabled = true;
            tsbExitCollection.Enabled = true;
            tsbClipboard.Enabled = true;
            tsbCopy.Enabled = true;
            tsbPrint.Enabled = true;

            this.Size = new Size(1084, 719);
            tabSidePanel.SelectTab(tabSideOpen);

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



        private void GetImageFromClipboard()
        {
            string fileName = Main.GetImageFromClipboard();
            if (fileName != null)
            {
                NewScreenshot(fileName);
            }
            else
            {
                MessageBox.Show("Clipboard empty");
            }
        }



        public void OpenCollection(string path = null)
        {
            if (lstFiles.SelectedIndex < 0) { return; }

            if (path == null)
                path = _listFiles[lstFiles.SelectedItem.ToString()].Path;

            Main.OpenCollection(path);
            foreach (Thumbnail thumb in Main.CurrentCollection.Thumbnails)
            {
                flowPanel.Controls.Add(thumb);
            }

            tabMain.SelectTab(tabOpen);
            FlowPanel_SelectFirst();

            OpenControls();

        }



        private void GetFilesList()
        {
            lstFiles.SelectedIndexChanged -= lstFiles_SelectedIndexChanged;

            _listFiles = new Dictionary<string, ImageCollectionInfo>();
            lstFiles.Items.Clear();
            foreach(string folder in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Snips"))
            {
                ImageCollectionInfo file = new ImageCollectionInfo(folder);
                _listFiles.Add(file.Name, file);
                lstFiles.Items.Add(file.Name);
            }

            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
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

            Thumbnail thumb = Main.ActiveThumbnail;

            txtDescription.TextChanged -= ImageDescription_Changed;
            txtName.TextChanged -= ImageName_Changed;
            if (thumb != null)
                thumb.BorderStyle = BorderStyle.FixedSingle;

            Main.ActiveThumbnail = (Thumbnail)((Control)sender).Parent;
            thumb = Main.ActiveThumbnail;
            //thumb = (Thumbnail)((Control)sender).Parent;
            thumb.BorderStyle = BorderStyle.Fixed3D;

            txtName.Text = thumb.ImageName;
            txtDescription.Text = thumb.Info;
            using (var bmp = new Bitmap(thumb.TempFileName != null ? Main.GetPath(thumb.TempFilePath, thumb.TempFileName) : thumb.FilePath))     // need to clear TempFilePath
                picDisplay.Image = new Bitmap(bmp);

            lblDateCreated.Text = "Created: " + thumb.DateCreated;
            lblDateModified.Text = "Modified: " + thumb.DateModified;

            txtDescription.TextChanged += ImageDescription_Changed;
            txtName.TextChanged += ImageName_Changed;

            picDisplay.Size = new Size(picDisplay.Image.Width, picDisplay.Image.Height);
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
            Main.CurrentCollection.Thumbnails.Remove(Main.ActiveThumbnail);
            FlowPanel_SelectFirst();
        }



        private void ImageDescription_Changed(object sender, EventArgs e)
        {
            Main.ActiveThumbnail.Info = txtDescription.Text;
        }

        private void ImageName_Changed(object sender, EventArgs e)
        {
            Main.ActiveThumbnail.ImageName = txtName.Text;
            Main.ActiveThumbnail.lblDescription.Text = Main.ActiveThumbnail.ImageName;
        }
        


        private void btnReset_Click(object sender, EventArgs e)
        {
            Thumbnail a = Main.ActiveThumbnail;
            txtName.Text = a.OriginalName;
            txtDescription.Text = a.OriginalInfo;
            string folder = a.TempFilePath.Remove(a.TempFilePath.LastIndexOf(@"\"));
            Main.DeleteFolderAsync(folder);
            a.TempFilePath = null;
            Thumbnail_Click(a.picThumbnail, new EventArgs());
        }



        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_drawMode)
            {
                case DrawMode.Pen:
                    _drawPen = new Pen(_drawColor, 3);
                    break;

                case DrawMode.Highlight:
                    _drawPen = new Pen(Color.FromArgb(48, _drawColor), 30);
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
                        g.DrawLine(_drawPen, _prevPoint.Value, e.Location);
                    picDisplay.Invalidate();
                    _prevPoint = e.Location;
                }
            }
        }



        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (_prevPoint != null)
            {
                _prevPoint = null;
                _drawPen.Dispose();
                _drawPen = null;
                Main.ActiveThumbnail.SaveTempImage(picDisplay.Image);
            }
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
            GetDrawPen(_drawMode);
        }



        private void GetDrawPen(DrawMode mode)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _drawColor = colorDialog.Color;
                }
                else
                {
                    if (mode == DrawMode.Pen)
                        _drawColor = Color.Red;
                    else
                        _drawColor = Color.Yellow;
                }
            }
        }


        
        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenCollection();
        }



        private enum DrawMode
        {
            Pen = 0,
            Highlight = 1
        }



        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstFiles.SelectedIndex >= 0)
            {
                ImageCollectionInfo info = _listFiles[lstFiles.SelectedItem.ToString()];
                txtCName.Text = info.Name;
                txtCDescription.Text = info.Description;
                lblCCreated.Text = "Created: " + info.DateCreated.ToString();
                lblCModified.Text = "Modified: " + info.DateModified.ToString();
            }
        }



        private void Form_Changed(object sender, EventArgs e)
        {
            Unsaved = true;
        }



        private async void btnCSave_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex >= 0)
            {
                ImageCollectionInfo info = _listFiles[lstFiles.SelectedItem.ToString()];

                if (txtCName.Text != info.Name)
                {
                    bool result = await info.Rename(txtCName.Text);
                    if (!result)
                    {
                        MessageBox.Show("Couldn't rename; do you have the folder open?");
                        return;
                    }

                    GetFilesList();
                    lstFiles.SelectedItem = txtCName.Text;
                }

                if (txtCDescription.Text != info.Description)
                    info.SetDescription(txtCDescription.Text);
            }
        }


    }
}
