using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshot_Util
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }



        private void FillDataGrid()
        {
            grdBrowseFiles.DataSource = GetFilesList();
        }

        private void grdBrowseFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenCollection(grdBrowseFiles.CurrentRow);
            
        }
    }
}
