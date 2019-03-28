namespace Screenshot_Util
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.barMenu = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveCollection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDeleteCollection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBrowse = new System.Windows.Forms.TabPage();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.tabOpen = new System.Windows.Forms.TabPage();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblDateModified = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.infoPanelImg = new System.Windows.Forms.GroupBox();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.infoPanelMain = new System.Windows.Forms.GroupBox();
            this.lblNameCollect = new System.Windows.Forms.Label();
            this.btnResetCollect = new System.Windows.Forms.Button();
            this.txtNameCollect = new System.Windows.Forms.TextBox();
            this.txtDescriptionCollect = new System.Windows.Forms.RichTextBox();
            this.lblModifiedCollect = new System.Windows.Forms.Label();
            this.lblCreatedCollect = new System.Windows.Forms.Label();
            this.lblDescriptionCollect = new System.Windows.Forms.Label();
            this.tsbScreenshot = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteScreenshot = new System.Windows.Forms.ToolStripButton();
            this.barMenuOpen = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBrowse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDrawMode = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbPen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbHighlight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExitCollection = new System.Windows.Forms.ToolStripButton();
            this.lblInfo = new System.Windows.Forms.Label();
            this.barMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabBrowse.SuspendLayout();
            this.tabOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.infoPanelImg.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.infoPanelMain.SuspendLayout();
            this.barMenuOpen.SuspendLayout();
            this.SuspendLayout();
            // 
            // barMenu
            // 
            this.barMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbOpen,
            this.toolStripSeparator2,
            this.tsbSaveCollection,
            this.toolStripSeparator3,
            this.tsbDeleteCollection,
            this.toolStripSeparator9,
            this.tsbExit});
            this.barMenu.Location = new System.Drawing.Point(0, 0);
            this.barMenu.Name = "barMenu";
            this.barMenu.Size = new System.Drawing.Size(1068, 25);
            this.barMenu.TabIndex = 0;
            this.barMenu.Text = "toolStrip1";
            this.barMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.barMenu_ItemClicked);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(104, 22);
            this.tsbNew.Text = "new collection";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(109, 22);
            this.tsbOpen.Text = "open collection";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSaveCollection
            // 
            this.tsbSaveCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveCollection.Image")));
            this.tsbSaveCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveCollection.Name = "tsbSaveCollection";
            this.tsbSaveCollection.Size = new System.Drawing.Size(105, 22);
            this.tsbSaveCollection.Text = "save collection";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDeleteCollection
            // 
            this.tsbDeleteCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteCollection.Image")));
            this.tsbDeleteCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteCollection.Name = "tsbDeleteCollection";
            this.tsbDeleteCollection.Size = new System.Drawing.Size(114, 22);
            this.tsbDeleteCollection.Text = "delete collection";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(45, 22);
            this.tsbExit.Text = "exit";
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabBrowse);
            this.tabMain.Controls.Add(this.tabOpen);
            this.tabMain.Location = new System.Drawing.Point(0, 50);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(814, 630);
            this.tabMain.TabIndex = 1;
            // 
            // tabBrowse
            // 
            this.tabBrowse.Controls.Add(this.lblInfo);
            this.tabBrowse.Controls.Add(this.lstFiles);
            this.tabBrowse.Location = new System.Drawing.Point(4, 22);
            this.tabBrowse.Name = "tabBrowse";
            this.tabBrowse.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowse.Size = new System.Drawing.Size(806, 604);
            this.tabBrowse.TabIndex = 0;
            this.tabBrowse.Text = "tabPage1";
            this.tabBrowse.UseVisualStyleBackColor = true;
            // 
            // lstFiles
            // 
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 16;
            this.lstFiles.Location = new System.Drawing.Point(3, 3);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(424, 598);
            this.lstFiles.TabIndex = 1;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstFiles.DoubleClick += new System.EventHandler(this.lstFiles_DoubleClick);
            // 
            // tabOpen
            // 
            this.tabOpen.Controls.Add(this.picDisplay);
            this.tabOpen.Controls.Add(this.flowPanel);
            this.tabOpen.Location = new System.Drawing.Point(4, 22);
            this.tabOpen.Name = "tabOpen";
            this.tabOpen.Padding = new System.Windows.Forms.Padding(3);
            this.tabOpen.Size = new System.Drawing.Size(806, 604);
            this.tabOpen.TabIndex = 1;
            this.tabOpen.Text = "tabPage2";
            this.tabOpen.UseVisualStyleBackColor = true;
            // 
            // picDisplay
            // 
            this.picDisplay.BackColor = System.Drawing.Color.White;
            this.picDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDisplay.Location = new System.Drawing.Point(3, 145);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(800, 456);
            this.picDisplay.TabIndex = 1;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseDown);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            this.picDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseUp);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.BackColor = System.Drawing.Color.White;
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPanel.Location = new System.Drawing.Point(3, 3);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(800, 142);
            this.flowPanel.TabIndex = 0;
            this.flowPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowPanel_ControlAdded);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(245, 21);
            this.txtName.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(4, 104);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(244, 92);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCreated.Location = new System.Drawing.Point(2, 211);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(75, 15);
            this.lblDateCreated.TabIndex = 4;
            this.lblDateCreated.Text = "date created";
            // 
            // lblDateModified
            // 
            this.lblDateModified.AutoSize = true;
            this.lblDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateModified.Location = new System.Drawing.Point(2, 239);
            this.lblDateModified.Name = "lblDateModified";
            this.lblDateModified.Size = new System.Drawing.Size(82, 15);
            this.lblDateModified.TabIndex = 4;
            this.lblDateModified.Text = "date modified";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(3, 286);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(2, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(2, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(69, 15);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description";
            // 
            // infoPanelImg
            // 
            this.infoPanelImg.Controls.Add(this.lblName);
            this.infoPanelImg.Controls.Add(this.btnReset);
            this.infoPanelImg.Controls.Add(this.txtName);
            this.infoPanelImg.Controls.Add(this.txtDescription);
            this.infoPanelImg.Controls.Add(this.lblDateModified);
            this.infoPanelImg.Controls.Add(this.lblDateCreated);
            this.infoPanelImg.Controls.Add(this.lblDescription);
            this.infoPanelImg.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanelImg.Location = new System.Drawing.Point(0, 0);
            this.infoPanelImg.Name = "infoPanelImg";
            this.infoPanelImg.Padding = new System.Windows.Forms.Padding(0);
            this.infoPanelImg.Size = new System.Drawing.Size(254, 319);
            this.infoPanelImg.TabIndex = 6;
            this.infoPanelImg.TabStop = false;
            this.infoPanelImg.Text = "Current Image";
            // 
            // sidePanel
            // 
            this.sidePanel.AutoScroll = true;
            this.sidePanel.Controls.Add(this.infoPanelMain);
            this.sidePanel.Controls.Add(this.infoPanelImg);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sidePanel.Location = new System.Drawing.Point(814, 25);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(254, 655);
            this.sidePanel.TabIndex = 7;
            // 
            // infoPanelMain
            // 
            this.infoPanelMain.Controls.Add(this.lblNameCollect);
            this.infoPanelMain.Controls.Add(this.btnResetCollect);
            this.infoPanelMain.Controls.Add(this.txtNameCollect);
            this.infoPanelMain.Controls.Add(this.txtDescriptionCollect);
            this.infoPanelMain.Controls.Add(this.lblModifiedCollect);
            this.infoPanelMain.Controls.Add(this.lblCreatedCollect);
            this.infoPanelMain.Controls.Add(this.lblDescriptionCollect);
            this.infoPanelMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoPanelMain.Location = new System.Drawing.Point(0, 336);
            this.infoPanelMain.Name = "infoPanelMain";
            this.infoPanelMain.Padding = new System.Windows.Forms.Padding(0);
            this.infoPanelMain.Size = new System.Drawing.Size(254, 319);
            this.infoPanelMain.TabIndex = 7;
            this.infoPanelMain.TabStop = false;
            this.infoPanelMain.Text = "Collection";
            // 
            // lblNameCollect
            // 
            this.lblNameCollect.AutoSize = true;
            this.lblNameCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameCollect.Location = new System.Drawing.Point(2, 21);
            this.lblNameCollect.Name = "lblNameCollect";
            this.lblNameCollect.Size = new System.Drawing.Size(41, 15);
            this.lblNameCollect.TabIndex = 4;
            this.lblNameCollect.Text = "Name";
            // 
            // btnResetCollect
            // 
            this.btnResetCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetCollect.Location = new System.Drawing.Point(3, 286);
            this.btnResetCollect.Name = "btnResetCollect";
            this.btnResetCollect.Size = new System.Drawing.Size(75, 30);
            this.btnResetCollect.TabIndex = 5;
            this.btnResetCollect.Text = "Reset";
            this.btnResetCollect.UseVisualStyleBackColor = true;
            // 
            // txtNameCollect
            // 
            this.txtNameCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameCollect.Location = new System.Drawing.Point(3, 42);
            this.txtNameCollect.Name = "txtNameCollect";
            this.txtNameCollect.Size = new System.Drawing.Size(245, 21);
            this.txtNameCollect.TabIndex = 2;
            // 
            // txtDescriptionCollect
            // 
            this.txtDescriptionCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescriptionCollect.Location = new System.Drawing.Point(4, 104);
            this.txtDescriptionCollect.Name = "txtDescriptionCollect";
            this.txtDescriptionCollect.Size = new System.Drawing.Size(244, 92);
            this.txtDescriptionCollect.TabIndex = 3;
            this.txtDescriptionCollect.Text = "";
            // 
            // lblModifiedCollect
            // 
            this.lblModifiedCollect.AutoSize = true;
            this.lblModifiedCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifiedCollect.Location = new System.Drawing.Point(2, 239);
            this.lblModifiedCollect.Name = "lblModifiedCollect";
            this.lblModifiedCollect.Size = new System.Drawing.Size(82, 15);
            this.lblModifiedCollect.TabIndex = 4;
            this.lblModifiedCollect.Text = "date modified";
            // 
            // lblCreatedCollect
            // 
            this.lblCreatedCollect.AutoSize = true;
            this.lblCreatedCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedCollect.Location = new System.Drawing.Point(2, 211);
            this.lblCreatedCollect.Name = "lblCreatedCollect";
            this.lblCreatedCollect.Size = new System.Drawing.Size(75, 15);
            this.lblCreatedCollect.TabIndex = 4;
            this.lblCreatedCollect.Text = "date created";
            // 
            // lblDescriptionCollect
            // 
            this.lblDescriptionCollect.AutoSize = true;
            this.lblDescriptionCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionCollect.Location = new System.Drawing.Point(2, 83);
            this.lblDescriptionCollect.Name = "lblDescriptionCollect";
            this.lblDescriptionCollect.Size = new System.Drawing.Size(69, 15);
            this.lblDescriptionCollect.TabIndex = 4;
            this.lblDescriptionCollect.Text = "Description";
            // 
            // tsbScreenshot
            // 
            this.tsbScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("tsbScreenshot.Image")));
            this.tsbScreenshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScreenshot.Name = "tsbScreenshot";
            this.tsbScreenshot.Size = new System.Drawing.Size(109, 22);
            this.tsbScreenshot.Text = "new screenshot";
            // 
            // tsbDeleteScreenshot
            // 
            this.tsbDeleteScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteScreenshot.Image")));
            this.tsbDeleteScreenshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteScreenshot.Name = "tsbDeleteScreenshot";
            this.tsbDeleteScreenshot.Size = new System.Drawing.Size(119, 22);
            this.tsbDeleteScreenshot.Text = "delete screenshot";
            // 
            // barMenuOpen
            // 
            this.barMenuOpen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbScreenshot,
            this.toolStripSeparator4,
            this.tsbBrowse,
            this.toolStripSeparator5,
            this.tsbDeleteScreenshot,
            this.toolStripSeparator6,
            this.tsbDrawMode,
            this.toolStripSeparator7,
            this.tsbUndo,
            this.toolStripSeparator8,
            this.tsbExitCollection});
            this.barMenuOpen.Location = new System.Drawing.Point(0, 25);
            this.barMenuOpen.Name = "barMenuOpen";
            this.barMenuOpen.Size = new System.Drawing.Size(814, 25);
            this.barMenuOpen.TabIndex = 8;
            this.barMenuOpen.Text = "toolStrip1";
            this.barMenuOpen.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.barMenu_ItemClicked);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBrowse
            // 
            this.tsbBrowse.Image = ((System.Drawing.Image)(resources.GetObject("tsbBrowse.Image")));
            this.tsbBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBrowse.Name = "tsbBrowse";
            this.tsbBrowse.Size = new System.Drawing.Size(101, 22);
            this.tsbBrowse.Text = "browse image";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDrawMode
            // 
            this.tsbDrawMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPen,
            this.tsbHighlight});
            this.tsbDrawMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbDrawMode.Image")));
            this.tsbDrawMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDrawMode.Name = "tsbDrawMode";
            this.tsbDrawMode.Size = new System.Drawing.Size(99, 22);
            this.tsbDrawMode.Text = "draw mode";
            this.tsbDrawMode.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbDrawMode_DropDownItemClicked);
            // 
            // tsbPen
            // 
            this.tsbPen.Name = "tsbPen";
            this.tsbPen.Size = new System.Drawing.Size(124, 22);
            this.tsbPen.Text = "Pen";
            // 
            // tsbHighlight
            // 
            this.tsbHighlight.Name = "tsbHighlight";
            this.tsbHighlight.Size = new System.Drawing.Size(124, 22);
            this.tsbHighlight.Text = "Highlight";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUndo
            // 
            this.tsbUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsbUndo.Image")));
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(55, 22);
            this.tsbUndo.Text = "undo";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExitCollection
            // 
            this.tsbExitCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbExitCollection.Image")));
            this.tsbExitCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExitCollection.Name = "tsbExitCollection";
            this.tsbExitCollection.Size = new System.Drawing.Size(45, 22);
            this.tsbExitCollection.Text = "exit";
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(433, 101);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(367, 326);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 680);
            this.Controls.Add(this.barMenuOpen);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.barMenu);
            this.Name = "frmMain";
            this.Text = "Screenshot Util";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.barMenu.ResumeLayout(false);
            this.barMenu.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabBrowse.ResumeLayout(false);
            this.tabOpen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.infoPanelImg.ResumeLayout(false);
            this.infoPanelImg.PerformLayout();
            this.sidePanel.ResumeLayout(false);
            this.infoPanelMain.ResumeLayout(false);
            this.infoPanelMain.PerformLayout();
            this.barMenuOpen.ResumeLayout(false);
            this.barMenuOpen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barMenu;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabBrowse;
        private System.Windows.Forms.TabPage tabOpen;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblDateModified;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.ToolStripButton tsbDeleteCollection;
        private System.Windows.Forms.ToolStripButton tsbSaveCollection;
        private System.Windows.Forms.GroupBox infoPanelImg;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.GroupBox infoPanelMain;
        private System.Windows.Forms.Label lblNameCollect;
        private System.Windows.Forms.Button btnResetCollect;
        private System.Windows.Forms.TextBox txtNameCollect;
        private System.Windows.Forms.RichTextBox txtDescriptionCollect;
        private System.Windows.Forms.Label lblModifiedCollect;
        private System.Windows.Forms.Label lblCreatedCollect;
        private System.Windows.Forms.Label lblDescriptionCollect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbScreenshot;
        private System.Windows.Forms.ToolStripButton tsbDeleteScreenshot;
        private System.Windows.Forms.ToolStrip barMenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbBrowse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton tsbDrawMode;
        private System.Windows.Forms.ToolStripMenuItem tsbPen;
        private System.Windows.Forms.ToolStripMenuItem tsbHighlight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbExitCollection;
        private System.Windows.Forms.Label lblInfo;
    }
}

