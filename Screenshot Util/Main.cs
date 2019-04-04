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
        public static string Root = GetPath(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Snips");



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



        public static string[] GetFilesList()
        {
            if (!Directory.Exists(Root)) { Directory.CreateDirectory(Root); }

            return Directory.GetDirectories(Root).Select(f => f.Substring(f.LastIndexOf('\\') + 1)).ToArray();
        }




        private static string GetFolder(string path)
        {
            if (path.Contains("."))
            {
                path = path.Remove(path.LastIndexOf("."));
                path = path.Remove(path.LastIndexOf('\\'));
            }
            while (path.Last() == '\\') { path = path.Remove(path.Length - 1); }
            path = path.Substring(path.LastIndexOf('\\') + 1);

            return path;
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
                System.Threading.Thread.Sleep(150);
                using (frmScreenshot frm = new frmScreenshot())
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        result = true;
                    }
                }
            }
            else
            {
                FileInfo fInfo = new FileInfo(filePath);
                CurrentCollection.Thumbnails.Add(new Thumbnail()
                {   // if file is in another folder ? copy it : already exists in folder aka screenshot
                    FilePath = GetFolder(filePath) != GetFolder(CurrentCollection.Path) ? CopyFileToDirectory(filePath) : filePath,
                    //DateCreated = fInfo.CreationTime.ToString(),
                    //DateModified = DateTime.Now.ToString(),
                });
                result = true;
            }

            if (result)
            {
                File.AppendAllText(GetPath(CurrentCollection.Path, "info.txt"),
                                   Environment.NewLine + CurrentCollection.Thumbnails.Last().FileName + "||");
            }

            return result;
        }



        public static void PrintImages()
        {
            if (Type.GetTypeFromProgID("Word.Application") == null)
            {
                MessageBox.Show("Printing is currently only available in Microsoft Word.");
            }
            else
            {
                using (frmPrint frm = new frmPrint()) { frm.ShowDialog(); }
            }
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
            CurrentCollection.Exit();
            CurrentCollection = null;
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
                // do something?
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

            bool flag = false;
            int i;
            for (i = 0; i < 20; i++)
            {
                try
                {
                    Directory.Move(oldPath, newFolderName);
                    await Task.Delay(500);
                    if (Directory.Exists(newFolderName) && !Directory.Exists(oldPath))
                    {
                        flag = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    await Task.Delay(500);
                }
            }
            if (!flag) { newFolderName = null; }
            return newFolderName;
        }

    }
}
