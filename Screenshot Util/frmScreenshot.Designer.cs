namespace Screenshot_Util
{
    partial class frmScreenshot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picScreenshot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // picScreenshot
            // 
            this.picScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picScreenshot.Location = new System.Drawing.Point(0, 0);
            this.picScreenshot.Name = "picScreenshot";
            this.picScreenshot.Size = new System.Drawing.Size(800, 450);
            this.picScreenshot.TabIndex = 0;
            this.picScreenshot.TabStop = false;
            this.picScreenshot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picScreenshot_MouseDown);
            this.picScreenshot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picScreenshot_MouseMove);
            this.picScreenshot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picScreenshot_MouseUp);
            this.picScreenshot.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picScreenshot_PreviewKeyDown);
            // 
            // frmScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.picScreenshot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScreenshot";
            this.Text = "frmScreenshot";
            this.Shown += new System.EventHandler(this.frmScreenshot_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmScreenshot_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picScreenshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picScreenshot;
    }
}