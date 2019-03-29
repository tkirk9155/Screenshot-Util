using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Drawing;
using System.IO;
using Screenshot_Util;
using System.Windows.Forms;

namespace Screenshot_Util
{
    public static class Main
    {
        public static ImageCollection CurrentCollection;
        public static Thumbnail ActiveThumbnail;
        public static string Root = GetPath(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Snips");



        public static string GetCollectionInfo(DirectoryInfo dirInfo)
        {
            string result = null;
            var fInfo = dirInfo.GetFiles().FirstOrDefault<FileInfo>(f => f.Name == "info.txt");
            if (fInfo == null)
                return result;
            else
            {
                string[] lines = File.ReadAllLines(fInfo.FullName);
                if (lines.Length > 0 && lines[0].Contains("|"))
                {
                    string[] info = lines[0].Split('|');
                    if (info.Length > 1)
                        result = info[1];
                }
            }

            return result;
        }



        public static string GetDirectorySize(DirectoryInfo dirInfo)
        {
            double numBytes = 0;
            foreach (FileInfo f in dirInfo.GetFiles())
                numBytes += f.Length;

            numBytes = numBytes / 1024;
            return numBytes.ToString("N2") + " GB";     // change this
        }



        public static void OpenCollection(string folderName)
        {
            CurrentCollection = new ImageCollection(folderName);
        }



        public static string GetRandomFileName()
        {
            string randomName = CurrentCollection.Path + "\\" + Path.GetRandomFileName();
            return randomName.Remove(randomName.LastIndexOf('.')) + ".png";
        }



        public static string GetPath(string path, string file)
        {
            while (path.Trim().Last() == '\\')
                path = path.Remove(path.Last());
            path += @"\";

            while (file.Trim().First() == '\\')
                file = file.Substring(1);

            return path + file;
        }



        public static string NewCollection()
        {
            string result = null;
            using (frmNewCollection frm = new frmNewCollection())
            {
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    result = frm.NewDirectory;
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
                FileInfo fInfo = new FileInfo(filePath);
                CurrentCollection.Images.Add(new Thumbnail()
                {
                    FilePath = CopyFileToDirectory(filePath),
                    DateCreated = fInfo.CreationTime.ToString(),
                    DateModified = DateTime.Now.ToString(),
                });
                result = true;
            }

            return result;
        }


        public static void PrintImages()
        {
            Print.PrintImages(new List<Thumbnail> { CurrentCollection.Images[1] });
        }


        private static string CopyFileToDirectory(string filePath)
        {
            string newFile = GetRandomFileName();
            File.Copy(filePath, newFile);

            return newFile;
        }



        public static void SaveCollection()
        {
            CurrentCollection.Save();
        }



        public static void ExitCollection()
        {
            foreach(Thumbnail thumb in CurrentCollection.Images)
            {
                thumb.picThumbnail.Image.Dispose();
                thumb.picThumbnail.Image = null;
            }
            CurrentCollection = null;
        }



        public static string[] GetFileDates(string fileName)
        {
            string[] dates = new string[2];
            FileInfo fInfo = new FileInfo(fileName);
            dates[0] = fInfo.CreationTime.ToString();
            dates[1] = fInfo.LastWriteTime.ToString();

            return dates;
        }



        public static string GetImageFromClipboard()
        {
            string result = null;

            try
            {
                using (Bitmap bmp = new Bitmap(Clipboard.GetImage()))
                {
                    result = GetRandomFileName();
                    bmp.Save(result);
                }

            }
            catch (Exception ex)
            {

            }

            return result;
        }



        public static void SaveTempImage(Image img)
        {
            string tempFolder = ActiveThumbnail.FilePath;
            tempFolder = tempFolder.Remove(tempFolder.LastIndexOf(".")).Substring(tempFolder.LastIndexOf(@"\") + 1);
            string tempPath = CurrentCollection.Path + @"\temp"
                + tempFolder;

            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            int fileName = 0;
            foreach (string file in Directory.GetFiles(tempPath))
                fileName++;

            string tempFile = tempPath + @"\" + fileName.ToString() + ".png";
            img.Save(tempFile);
            Main.ActiveThumbnail.TempFilePath = tempFile;
        }



        public static string RestorePreviousImage()
        {
            string result = null;
            string tempPath;
            if (ActiveThumbnail.TempFilePath != null)
            {
                tempPath = ActiveThumbnail.TempFilePath;
                tempPath = tempPath.Remove(tempPath.LastIndexOf('\\'));
            }
            else
            {
                return null;
            }

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

                DeleteFileAsync(GetPath(tempPath, fileName));
                //DeleteFileAsync(tempPath + @"\" + fileName);

                files.RemoveAt(0);
                fileName = null;
            }

            if (files.Count > 0)
            {
                fileName = files[0].ToString() + ".png";
                result = GetPath(tempPath, fileName);
                ActiveThumbnail.TempFilePath = null;
            }
            else
            {
                if (Directory.Exists(tempPath))
                {
                    DeleteFolderAsync(tempPath);
                }

                result = ActiveThumbnail.FilePath;
                ActiveThumbnail.TempFilePath = null;
            }

            return result;
        }



        public static async Task<int> DeleteFileAsync(string filePath)
        {
            int i;
            for (i = 0; i < 20; i++)
            {
                try
                {
                    File.Delete(filePath);
                    break;
                }
                catch (Exception ex)
                {
                    await Task.Delay(500);
                }
            }
            return i;
        }

        public static async Task<int> DeleteFolderAsync(string directoryPath)
        {
            int i;
            for (i = 0; i < 20; i++)
            {
                try
                {
                    Directory.Delete(directoryPath, true);
                    await Task.Delay(500);
                    if (!Directory.Exists(directoryPath))
                        break;
                }
                catch (Exception ex)
                {
                    await Task.Delay(500);
                }
            }
            return i;
        }

        public static async Task<string> RenameFolderAsync(string oldPath, string newFolderName)
        {
            newFolderName = oldPath.Remove(oldPath.LastIndexOf(@"\") + 1) + newFolderName;

            int i;
            for (i = 0; i < 20; i++)
            {
                try
                {
                    Directory.Move(oldPath, newFolderName);
                    await Task.Delay(500);
                    if (Directory.Exists(newFolderName) && !Directory.Exists(oldPath))
                        break;
                }
                catch (Exception ex)
                {
                    await Task.Delay(500);
                }
            }
            return newFolderName;
        }

    }
}
