using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Drawing;
using System.IO;
using Screenshot_Util;
using System.Threading;

namespace Screenshot_Util
{
    public static class Main
    {
        public static DataTable GridDatasource;
        public static ImageCollection CurrentCollection;
        public static Thumbnail ActiveThumbnail;
        private static Thread _DeleteTempImageThread;

        public static DataTable GetFilesList()
        {
            GridDatasource = new DataTable();
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "Name" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "Info" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "NumberPhotos" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "Size" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "DateCreated" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "DateModified" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "Directory" });

            var dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Snips");
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                GridDatasource.Rows.Add(GridDatasource.NewRow());
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Name"] = dir.Name;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Info"] = GetCollectionInfo(dir);
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["NumberPhotos"] = dir.GetFiles("*.png").Length;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Size"] = GetDirectorySize(dir);
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["DateCreated"] = dir.CreationTime;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["DateModified"] = dir.LastWriteTime;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Directory"] = dir.FullName;
            }

            return GridDatasource;
        }



        public static string GetCollectionInfo(DirectoryInfo dirInfo)
        {
            var fInfo = dirInfo.GetFiles().FirstOrDefault<FileInfo>(f => f.Name == "info.txt");
            if (fInfo == null)
                return null;
            else
                return File.ReadAllLines(fInfo.FullName)[0];
        }



        public static string GetDirectorySize(DirectoryInfo dirInfo)
        {
            double numBytes = 0;
            foreach (FileInfo f in dirInfo.GetFiles())
                numBytes += f.Length;

            numBytes = numBytes / 1024;
            return numBytes.ToString("N2") + " GB";     // change this
        }



        public static void OpenCollection(System.Windows.Forms.DataGridViewRow currentRow)
        {
            CurrentCollection = new ImageCollection(currentRow);
        }



        public static string GetRandomFileName()
        {
            string randomName = CurrentCollection.Path + "\\" + Path.GetRandomFileName();
            return randomName.Remove(randomName.LastIndexOf('.')) + ".png";
        }



        public static bool NewCollection()
        {
            bool result = false;
            using (frmNewCollection frm = new frmNewCollection())
            {
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    string dirName = frm.txtName.Text;
                    Directory.CreateDirectory("C:\\Users\\tkirk\\Pictures\\Snips\\" + dirName);
                    GridDatasource.Rows.Add(GridDatasource.NewRow());
                    GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Name"] = dirName;
                    GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Directory"] = "C:\\Users\\tkirk\\Pictures\\Snips\\" + dirName;
                    GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Size"] = 0;
                    GridDatasource.Rows[GridDatasource.Rows.Count - 1]["NumberPhotos"] = 0;
                    GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Info"] = frm.txtDescription.Text;
                    GridDatasource.Rows[GridDatasource.Rows.Count - 1]["DateCreated"] = DateTime.Now;
                    GridDatasource.Rows[GridDatasource.Rows.Count - 1]["DateModified"] = DateTime.Now;

                    result = true;
                }
            }
            return result;
        }



        public static bool NewScreenshot(string filePath = null)
        {
            bool result = false;
            if (filePath == null)
            {
                using (frmScreenshot frm = new frmScreenshot())
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        result = true;
                    }
                }
            }
            else
            {
                CurrentCollection.Images.Add(new Thumbnail()
                {
                    FileName = CopyFileToDirectory(filePath),
                    DateCreated = DateTime.Now.ToString(),
                    DateModified = DateTime.Now.ToString(),
                });
                result = true;
            }

            return result;
        }



        private static string CopyFileToDirectory(string filePath)
        {
            string newFile = GetRandomFileName();
            File.Move(filePath, newFile);

            return newFile;
        }





        public static bool SaveCollection()
        {
            string writeToFile = "";

            writeToFile += CurrentCollection.Name + "|" + CurrentCollection.Info + Environment.NewLine;
            foreach (Thumbnail thumb in CurrentCollection.Images)
            {
                string contents = "{0}|{1}|{2}" + Environment.NewLine;
                writeToFile += string.Format(contents, thumb.FileName, thumb.ImageName, thumb.Info);
            }

            File.WriteAllText(CurrentCollection.Path + @"\info.txt",
                              writeToFile);

            return false;
        }



        public static string[] GetFileDates(string fileName)
        {
            string[] dates = new string[2];
            FileInfo fInfo = new FileInfo(fileName);
            dates[0] = fInfo.CreationTime.ToString();
            dates[1] = fInfo.LastWriteTime.ToString();

            return dates;
        }



        public static void SaveTempImage(Image img)
        {
            string tempFolder = ActiveThumbnail.FileName;
            tempFolder = tempFolder.Remove(tempFolder.LastIndexOf(".")).Substring(tempFolder.LastIndexOf(@"\") + 1);
            string tempPath = CurrentCollection.Path + @"\temp"
                + tempFolder;
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            int fileName = 0;
            foreach (string file in Directory.GetFiles(tempPath))
                fileName++;
            img.Save(tempPath + @"\" + fileName.ToString() + ".png");
        }



        public static string RestorePreviousImage()
        {
            string result = null;
            string tempFolder = ActiveThumbnail.FileName;
            tempFolder = tempFolder.Remove(tempFolder.LastIndexOf(".")).Substring(tempFolder.LastIndexOf(@"\") + 1);
            string tempPath = CurrentCollection.Path + @"\temp"
                + tempFolder;
            if (!Directory.Exists(tempPath))
                return result;

            List<int> files = new List<int>();
            foreach(string file in Directory.GetFiles(tempPath))
            {
                int currentFile;
                string path = file.Remove(file.LastIndexOf(".")).Substring(file.LastIndexOf(@"\") + 1);
                if (int.TryParse(path, out currentFile))
                    files.Add(currentFile);
            }

            files = files.OrderByDescending(i => i).ToList();
            string fileName;

            if (files.Count > 0)
            {
                fileName = files[0].ToString() + ".png";

                // good for now, needs to be replaced
                _DeleteTempImageThread = new Thread(() =>
                {
                    for (int i = 0; i < 20; i++)
                    {
                        try
                        {
                            File.Delete(tempPath + @"\" + fileName);
                            i = 20;
                        }
                        catch (Exception ex)
                        {
                            Thread.Sleep(500);
                        }
                    }
                });
                _DeleteTempImageThread.Start();

                files.RemoveAt(0);
                fileName = null;
                if (files.Count > 0)
                {
                    fileName = files[0].ToString() + ".png";
                    result = tempPath + @"\" + fileName;
                }
            }
            else
            {
                if (Directory.Exists(tempPath))
                    Directory.Delete(tempPath);
                result = CurrentCollection.Path + @"\" + ActiveThumbnail.FileName;
            }

            return result;
        }

    }
}
