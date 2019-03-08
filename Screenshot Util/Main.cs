using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.IO;

namespace Screenshot_Util
{
    class Main
    {
        public DataTable GridDatasource;
        public SnipsCollection OpenCollection;

        public bool ThumbnailCallback() { return false; }

        public DataTable GetFilesList()
        {
            GridDatasource = new DataTable();
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "Name" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "Info" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "NumberPhotos" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "Size" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "DateCreated" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "DateModified" });
            GridDatasource.Columns.Add(new DataColumn { ColumnName = "Directory" });

            var dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                GridDatasource.Rows.Add(GridDatasource.NewRow());
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Name"] = dir.Name;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Info"] = GetCollectionInfo(dir);
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["NumberPhotos"] = dir.Name;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Size"] = dir.Name;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["DateCreated"] = dir.Name;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["DateModified"] = dir.Name;
                GridDatasource.Rows[GridDatasource.Rows.Count - 1]["Directory"] = dir.Name;


            }

            return null;
        }

    }
}
