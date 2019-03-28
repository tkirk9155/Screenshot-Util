using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Drawing;
using System.IO;
using Screenshot_Util;

namespace Screenshot_Util
{
    public static class Main
    {
        public static ImageCollection CurrentCollection;
        public static Thumbnail ActiveThumbnail;


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
                    //GridDatasource.Rows.Add(GridDatasource.NewRow());
                    //GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Name"] = dirName;
                    //GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Directory"] = "C:\\Users\\tkirk\\Pictures\\Snips\\" + dirName;
                    //GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Size"] = 0;
                    //GridDatasource.Rows[GridDatasource.Rows.Count - 1]["NumberPhotos"] = 0;
                    //GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Info"] = frm.txtDescription.Text;
                    //GridDatasource.Rows[GridDatasource.Rows.Count - 1]["DateCreated"] = DateTime.Now;
                    //GridDatasource.Rows[GridDatasource.Rows.Count - 1]["DateModified"] = DateTime.Now;

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
            File.Copy(filePath, newFile);

            return newFile;
        }



        public static async void SaveCollection()
        {
            // rename folder, reset Path properties on objects
            if (CurrentCollection.Name != CurrentCollection.OriginalName)
            {
                string oldName = CurrentCollection.OriginalName;
                string newName = CurrentCollection.Name;

                await RenameFolderAsync(CurrentCollection.Path, newName);
                foreach (Thumbnail thumb in CurrentCollection.Images)
                {
                    thumb.FileName = thumb.FileName.Replace(oldName, newName);
                    if (thumb.TempFile != null)
                        thumb.TempFile = thumb.TempFile.Replace(oldName, newName);
                }

                CurrentCollection.Name = newName;
                CurrentCollection.Path = CurrentCollection.Path.Replace(oldName, newName);
            }

            string writeToFile = "";

            writeToFile += CurrentCollection.Name + "|" + CurrentCollection.Description + Environment.NewLine;
            string[] saveImages = CurrentCollection.Images.Select(x => x.FileName).ToArray();

            foreach (Thumbnail thumb in CurrentCollection.Images)
            {
                if (thumb.TempFile != null)
                {
                    await DeleteFileAsync(thumb.FileName);
                    File.Move(thumb.TempFile, thumb.FileName);
                }

                string contents = "{0}|{1}|{2}" + Environment.NewLine;
                writeToFile += string.Format(contents, thumb.FileName, thumb.ImageName, thumb.Info);
            }

            File.WriteAllText(CurrentCollection.Path + @"\info.txt",
                              writeToFile);

            foreach (string folder in Directory.GetDirectories(CurrentCollection.Path))
                await DeleteFolderAsync(folder);

            foreach (string file in Directory.GetFiles(CurrentCollection.Path, "*.png"))
            {
                if (!saveImages.Contains(file))
                    await DeleteFileAsync(file);
            }

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

            string tempFile = tempPath + @"\" + fileName.ToString() + ".png";
            img.Save(tempFile);
            Main.ActiveThumbnail.TempFile = tempFile;
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

                DeleteFileAsync(tempPath + @"\" + fileName);

                files.RemoveAt(0);
                fileName = null;
            }

            if (files.Count > 0)
            {
                fileName = files[0].ToString() + ".png";
                result = tempPath + @"\" + fileName;
            }
            else
            {
                if (Directory.Exists(tempPath))
                    DeleteFolderAsync(tempPath);

                result = ActiveThumbnail.FileName;
            }

            return result;
        }



        private static async Task<int> DeleteFileAsync(string filePath)
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

        private static async Task<int> RenameFolderAsync(string oldPath, string newFolderName)
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
            return i;
        }

    }
}
