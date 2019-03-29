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
    public partial class frmScreenshot : Form
    {
        private int _selectX;
        private int _selectY;
        private int _selectWidth;
        private int _selectHeight;
        private bool _mouseDown;

        public frmScreenshot()
        {
            InitializeComponent();
            
        }

        private void frmScreenshot_Shown(object sender, EventArgs e)
        {
            Size = SystemInformation.VirtualScreen.Size;
            Location = SystemInformation.VirtualScreen.Location;
            Visible = false;

            using (Bitmap printScreen = new Bitmap(Size.Width, Size.Height))
            {
                using (Graphics g = Graphics.FromImage(printScreen))
                {
                    g.CopyFromScreen(SystemInformation.VirtualScreen.Left, 
                        SystemInformation.VirtualScreen.Top, 
                        0, 0, printScreen.Size);
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        printScreen.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
                        picScreenshot.Image = Image.FromStream(mStream);
                    }
                }
            }
            Visible = true;

        }

        private void picScreenshot_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_mouseDown && e.Button == MouseButtons.Left)
            {
                _selectX = e.X;
                _selectY = e.Y;
                _mouseDown = true;
            }
        }

        private void picScreenshot_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                picScreenshot.Refresh();

                using (Pen selectPen = new Pen(Color.Red, 1))
                {
                    if (e.X > _selectX && e.Y <= _selectY)
                    {
                        _selectWidth = e.X - _selectX;
                        _selectHeight = _selectY - e.Y;
                        picScreenshot.CreateGraphics().DrawRectangle(selectPen, _selectX, e.Y, _selectWidth, _selectHeight);
                    }
                    else if (e.X <= _selectX && e.Y > _selectY)
                    {
                        _selectWidth = _selectX - e.X;
                        _selectHeight = e.Y - _selectY;
                        picScreenshot.CreateGraphics().DrawRectangle(selectPen, e.X, _selectY, _selectWidth, _selectHeight);
                    }
                    else if (e.X > _selectX && e.Y > _selectY)
                    {
                        _selectWidth = e.X - _selectX;
                        _selectHeight = e.Y - _selectY;
                        picScreenshot.CreateGraphics().DrawRectangle(selectPen, _selectX, _selectY, _selectWidth, _selectHeight);
                    }
                    else
                    {
                        _selectWidth = _selectX - e.X;
                        _selectHeight = _selectY - e.Y;
                        picScreenshot.CreateGraphics().DrawRectangle(selectPen, e.X, e.Y, _selectWidth, _selectHeight);
                    }
                }
            }
        }

        private void picScreenshot_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mouseDown &&
                e.Button == MouseButtons.Left &&
                _selectWidth > 0 &&
                _selectHeight > 0)
            {
                string fileName = Main.GetRandomFileName();
                int saveX, saveY;

                if (e.X > _selectX && e.Y <= _selectY)
                {
                    _selectWidth = e.X - _selectX;
                    _selectHeight = _selectY - e.Y;
                    saveX = _selectX;
                    saveY = e.Y;
                }
                else if (e.X <= _selectX && e.Y > _selectY)
                {
                    _selectWidth = _selectX - e.X;
                    _selectHeight = e.Y - _selectY;
                    saveX = e.X;
                    saveY = _selectY;
                }
                else if (e.X > _selectX && e.Y > _selectY)
                {
                    _selectWidth = e.X - _selectX;
                    _selectHeight = e.Y - _selectY;
                    saveX = _selectX;
                    saveY = _selectY;
                }
                else
                {
                    _selectWidth = _selectX - e.X;
                    _selectHeight = _selectY - e.Y;
                    saveX = e.X;
                    saveY = e.Y;
                }

                Rectangle rect = new Rectangle(saveX, saveY, _selectWidth, _selectHeight);
                using (Bitmap oldImg = new Bitmap(picScreenshot.Image, picScreenshot.Width, picScreenshot.Height))
                {
                    using (Bitmap newImg = new Bitmap(_selectWidth, _selectHeight))
                    {
                        using (Graphics g = Graphics.FromImage(newImg))
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            g.DrawImage(oldImg, 0, 0, rect, GraphicsUnit.Pixel);

                            newImg.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                            System.Threading.Thread.Sleep(200);
                        }
                    }
                }
                DialogResult = DialogResult.OK;
                Main.CurrentCollection.Images.Add(new Thumbnail()
                {
                    //FileName = fileName.Substring(fileName.LastIndexOf(@"\")),
                    FilePath = fileName,
                    DateCreated = DateTime.Now.ToString(),
                    DateModified = DateTime.Now.ToString(),
                });
                Close();
            }
        }

        private void frmScreenshot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void picScreenshot_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
