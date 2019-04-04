// icon images from icons8.com

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

        private Dictionary<string, ImageCollectionInfo> _listFiles;
        private bool Unsaved;

        private struct Draw
        {
            internal static System.Nullable<Point> PreviousPoint;
            internal static Pen Pen;
            internal static DrawMode Mode = DrawMode.Pen;
            internal static Color Color = Color.Red;
            internal static int X;
            internal static int Y;
        }

        private enum DrawMode
        {
            Pen = 0,
            Highlight = 1
        }




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

            tsbNew.Image = new Bitmap(Properties.Resources.icons8_plus_16);
            tsbOpen.Image = new Bitmap(Properties.Resources.icons8_opened_folder_16);
            tsbSaveCollection.Image = new Bitmap(Properties.Resources.icons8_save_as_16);
            tsbDeleteCollection.Image = new Bitmap(Properties.Resources.icons8_trash_can_16);
            tsbExit.Image = new Bitmap(Properties.Resources.icons8_shutdown_16);
            tsbScreenshot.Image = new Bitmap(Properties.Resources.icons8_camera_16);
            tsbBrowse.Image = new Bitmap(Properties.Resources.icons8_pictures_folder_16);
            tsbClipboard.Image = new Bitmap(Properties.Resources.icons8_image_file_16);
            tsbDeleteScreenshot.Image = new Bitmap(Properties.Resources.icons8_delete_16);
            tsbDrawMode.Image = new Bitmap(Properties.Resources.icons8_edit_16);
            tsbUndo.Image = new Bitmap(Properties.Resources.icons8_available_updates_16);
            tsbCopy.Image = new Bitmap(Properties.Resources.icons8_copy_to_clipboard_16);
            tsbPrint.Image = new Bitmap(Properties.Resources.icons8_print_16);
            tsbExitCollection.Image = new Bitmap(Properties.Resources.icons8_exit_sign_16);

            tsbDrawMode.ForeColor = Draw.Color;

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
            string result = Main.NewCollection();
            if (result != null)
            {
                GetFilesList();
                OpenCollection(result);
            }
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
            if (lstFiles.SelectedIndex < 0 && path == null) { return; }

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



        // move this to Main
        private void GetFilesList()
        {
            lstFiles.SelectedIndexChanged -= lstFiles_SelectedIndexChanged;

            _listFiles = new Dictionary<string, ImageCollectionInfo>();
            lstFiles.Items.Clear();
            if (!Directory.Exists(Main.Root)) { Directory.CreateDirectory(Main.Root); }
            foreach(string folder in Directory.GetDirectories(Main.Root))
            {
                ImageCollectionInfo file = new ImageCollectionInfo(folder);
                _listFiles.Add(file.Name, file);
                lstFiles.Items.Add(file.Name);
            }

            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;

            if (lstFiles.Items.Count > 0) { lstFiles.SelectedIndex = 0; }
        }




        private void flowPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType() == typeof(Thumbnail))
            {
                Thumbnail thumb = (Thumbnail)e.Control;
                thumb.ThumbnailClicked += Thumbnail_Click;
                Thumbnail_Click(thumb, new EventArgs());
            }
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

            Main.ActiveThumbnail = (Thumbnail)((Control)sender);
            thumb = Main.ActiveThumbnail;
            //thumb = (Thumbnail)((Control)sender).Parent;
            thumb.BorderStyle = BorderStyle.Fixed3D;

            txtName.Text = thumb.ImageName;
            txtDescription.Text = thumb.Description;
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
                Thumbnail_Click(flowPanel.Controls.OfType<Thumbnail>().FirstOrDefault<Thumbnail>(),
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
            Main.ActiveThumbnail.Description = txtDescription.Text;
        }

        private void ImageName_Changed(object sender, EventArgs e)
        {
            Main.ActiveThumbnail.ImageName = txtName.Text;
            Main.ActiveThumbnail.lblDescription.Text = Main.ActiveThumbnail.ImageName;
        }
        


        private void btnReset_Click(object sender, EventArgs e)
        {
            Thumbnail thumb = Main.ActiveThumbnail;
            txtName.Text = thumb.OriginalName;
            txtDescription.Text = thumb.OriginalInfo;
            string folder = thumb.TempFilePath.Remove(thumb.TempFilePath.LastIndexOf(@"\"));
            Main.DeleteFolderAsync(folder);
            thumb.TempFilePath = null;
            Thumbnail_Click(thumb, new EventArgs());
        }



        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            switch (Draw.Mode)
            {
                case DrawMode.Pen:
                    Draw.Pen = new Pen(Draw.Color, 3);
                    picDisplay.MouseMove += picDisplay_MouseMove_Pen;
                    break;

                case DrawMode.Highlight:
                    Draw.Pen = new Pen(Color.FromArgb(80, Draw.Color), 30);
                    Draw.X = e.X;
                    Draw.Y = e.Y;
                    picDisplay.MouseMove += picDisplay_MouseMove_Highlight;
                    break;
            }

            Draw.PreviousPoint = e.Location;
            picDisplay_MouseMove_Pen(sender, e);
        }



        private void picDisplay_MouseMove_Pen(object sender, MouseEventArgs e)
        {
            if (picDisplay.Image != null)
            {
                if (Draw.PreviousPoint != null)
                {
                    using (Graphics g = Graphics.FromImage(picDisplay.Image))
                        g.DrawLine(Draw.Pen, Draw.PreviousPoint.Value, e.Location);
                    picDisplay.Invalidate();
                    Draw.PreviousPoint = e.Location;
                }
            }
        }



        private void picDisplay_MouseMove_Highlight(object sender, MouseEventArgs e)
        {
            if(picDisplay.Image != null)
            {
                picDisplay.Refresh();

                if (Draw.PreviousPoint != null)
                {
                    picDisplay.CreateGraphics().DrawLine(Draw.Pen, Draw.X, Draw.Y, e.X, e.Y);
                }
            }
        }



        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (Draw.PreviousPoint != null)
            {
                if (Draw.Mode == DrawMode.Highlight)
                {
                    using (Graphics g = Graphics.FromImage(picDisplay.Image))
                        g.DrawLine(Draw.Pen, Draw.PreviousPoint.Value, e.Location);
                    picDisplay.Invalidate();
                }

                Draw.PreviousPoint = null;
                Draw.Pen.Dispose();
                Draw.Pen = null;
                Main.ActiveThumbnail.SaveTempImage(picDisplay.Image);
                picDisplay.MouseMove -= picDisplay_MouseMove_Highlight;
                picDisplay.MouseMove -= picDisplay_MouseMove_Pen;
            }
        }



        private void tsbDrawMode_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToLower())
            {
                case "tsbpen":
                    Draw.Mode = DrawMode.Pen;
                    tsbDrawMode.Image = new Bitmap(Properties.Resources.icons8_edit_16);
                    break;

                case "tsbhighlight":
                    Draw.Mode = DrawMode.Highlight;
                    tsbDrawMode.Image = new Bitmap(Properties.Resources.icons8_tube_16);
                    break;
            }
            GetDrawPen(Draw.Mode);
            tsbDrawMode.ForeColor = Draw.Color;
        }



        private void GetDrawPen(DrawMode mode)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Draw.Color = colorDialog.Color;
                }
                else
                {
                    if (mode == DrawMode.Pen)
                        Draw.Color = Color.Red;
                    else
                        Draw.Color = Color.Yellow;
                }
            }
        }


        
        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenCollection();
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
