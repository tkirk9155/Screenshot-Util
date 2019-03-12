namespace Screenshot_Util
{
    partial class Thumbnail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // picThumbnail
            // 
            this.picThumbnail.Location = new System.Drawing.Point(0, 0);
            this.picThumbnail.Margin = new System.Windows.Forms.Padding(0);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(119, 119);
            this.picThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picThumbnail.TabIndex = 0;
            this.picThumbnail.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(0, 119);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(119, 21);
            this.lblDescription.TabIndex = 1;
            // 
            // Thumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.picThumbnail);
            this.Name = "Thumbnail";
            this.Size = new System.Drawing.Size(119, 140);
            this.Load += new System.EventHandler(this.Thumbnail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picThumbnail;
        public System.Windows.Forms.Label lblDescription;
    }
}
