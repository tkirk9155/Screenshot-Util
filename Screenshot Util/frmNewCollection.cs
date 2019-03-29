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
    public partial class frmNewCollection : Form
    {
        public string NewDirectory;

        public frmNewCollection()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CreateCollection())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                NewDirectory = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewDirectory = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private bool CreateCollection()
        {
            NewDirectory = Main.GetPath(Main.Root, txtName.Text);
            if(Directory.Exists(NewDirectory))
            {
                MessageBox.Show("A collection with that name already exists.");
                return false;
            }
            else
            {
                Directory.CreateDirectory(NewDirectory);
                File.WriteAllText(Main.GetPath(NewDirectory, "info.txt"), 
                                  txtName.Text + "|" + txtDescription.Text + Environment.NewLine);
                return true;
            }
        }

    }

}
