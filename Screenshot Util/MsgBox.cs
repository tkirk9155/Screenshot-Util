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
    public partial class MsgBox : Form
    {

        public MsgBox()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = Cursor.Position;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
