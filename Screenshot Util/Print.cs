using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace Screenshot_Util
{
    public static class Print
    {
        private static PrintDocument _printDoc;
        private static List<Thumbnail> _images;

        public static void PrintImages(List<Thumbnail> images)
        {
            _printDoc = new PrintDocument();
            PrintDialog printDialog = new PrintDialog()
            {
                Document = _printDoc
            };
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                _printDoc.PrintPage += SetupPrintDocument;
                _images = images;
                _printDoc.Print();
                _printDoc.PrintPage -= SetupPrintDocument;
            }
        }


        private static void SetupPrintDocument(object sender, PrintPageEventArgs e)
        {
            foreach (Thumbnail thumb in _images)
            {
                float pX = e.PageSettings.PrintableArea.Width;
                float pY = e.PageSettings.PrintableArea.Height;
                float newX = 0f;
                float newY = 0f;
                float posX = 0f;
                float posY = 0f;

                using (Bitmap bmp = new Bitmap(thumb.picThumbnail.Image))
                {
                    if (bmp.Width > bmp.Height)
                    {
                        if (bmp.Width > pX)
                        {
                            newX = bmp.Width - (bmp.Width - pX);
                            newY = newX / bmp.Width * bmp.Height;
                        }
                        else
                        {
                            newX = bmp.Width;
                            newY = bmp.Height;
                        }
                        if (newY > pY)
                        {
                            newY -= (newY - pY);
                            //newX = newY / newY * newX;
                        }
                    }
                    else
                    {
                        if (bmp.Height > pY)
                        {
                            newY = bmp.Height - (bmp.Height - pY);
                            newX = newY / bmp.Height * bmp.Width;
                        }
                        else
                        {
                            newY = bmp.Height;
                            newX = bmp.Width;
                        }
                        if (newX > pX)
                        {
                            newX -= (newX - pX);
                            //newY = newX / newX * newY;
                        }
                    }

                    posX = (pX - newX) / 2;
                    posY = (pY - newY) / 2;

                    using (Bitmap b = new Bitmap((int)newX, (int)newY))
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.DrawImage(bmp, 0, 0, newX, newY);
                        e.Graphics.DrawImage(bmp, posX, posY);
                    }
                }
            }
        }
    }
}
