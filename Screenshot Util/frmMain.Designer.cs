﻿namespace Screenshot_Util
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
            this.tsbOpen = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveCollection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDeleteCollection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBrowse = new System.Windows.Forms.TabPage();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tabOpen = new System.Windows.Forms.TabPage();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCModified = new System.Windows.Forms.Label();
            this.lblCCreated = new System.Windows.Forms.Label();
            this.tsbScreenshot = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteScreenshot = new System.Windows.Forms.ToolStripButton();
            this.barMenuOpen = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBrowse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClipboard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbColor = new System.Windows.Forms.ToolStripButton();
            this.tsbDrawMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbPen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbHighlight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExitCollection = new System.Windows.Forms.ToolStripButton();
            this.tabSidePanel = new System.Windows.Forms.TabControl();
            this.tabSideBrowse = new System.Windows.Forms.TabPage();
            this.tabSideOpen = new System.Windows.Forms.TabPage();
            this.CInfoPanel = new System.Windows.Forms.GroupBox();
            this.lblCName = new System.Windows.Forms.Label();
            this.btnCReset = new System.Windows.Forms.Button();
            this.lblCDescription = new System.Windows.Forms.Label();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.txtCDescription = new System.Windows.Forms.RichTextBox();
            this.infoPanel = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblDateModified = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.barMenu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabBrowse.SuspendLayout();
            this.tabOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.barMenuOpen.SuspendLayout();
            this.tabSidePanel.SuspendLayout();
            this.tabSideBrowse.SuspendLayout();
            this.tabSideOpen.SuspendLayout();
            this.CInfoPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // barMenu
            // 
            this.barMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.toolStripSeparator2,
            this.tsbNew,
            this.toolStripSeparator1,
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
            // tsbOpen
            // 
            this.tsbOpen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(200, 25);
            this.tsbOpen.SelectedIndexChanged += new System.EventHandler(this.tsbOpen_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.tabMain.Location = new System.Drawing.Point(251, 50);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(814, 630);
            this.tabMain.TabIndex = 1;
            // 
            // tabBrowse
            // 
            this.tabBrowse.Controls.Add(this.lblInfo);
            this.tabBrowse.Location = new System.Drawing.Point(4, 22);
            this.tabBrowse.Name = "tabBrowse";
            this.tabBrowse.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowse.Size = new System.Drawing.Size(806, 604);
            this.tabBrowse.TabIndex = 0;
            this.tabBrowse.Text = "tabPage1";
            this.tabBrowse.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(719, 521);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(81, 80);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label1";
            // 
            // tabOpen
            // 
            this.tabOpen.AutoScroll = true;
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
            this.picDisplay.Location = new System.Drawing.Point(3, 145);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(800, 456);
            this.picDisplay.TabIndex = 1;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseDown);
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
            // lblCModified
            // 
            this.lblCModified.AutoSize = true;
            this.lblCModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCModified.Location = new System.Drawing.Point(0, 218);
            this.lblCModified.Name = "lblCModified";
            this.lblCModified.Size = new System.Drawing.Size(0, 15);
            this.lblCModified.TabIndex = 9;
            // 
            // lblCCreated
            // 
            this.lblCCreated.AutoSize = true;
            this.lblCCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCreated.Location = new System.Drawing.Point(0, 190);
            this.lblCCreated.Name = "lblCCreated";
            this.lblCCreated.Size = new System.Drawing.Size(0, 15);
            this.lblCCreated.TabIndex = 10;
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
            this.tsbClipboard,
            this.toolStripSeparator12,
            this.tsbDeleteScreenshot,
            this.toolStripSeparator6,
            this.tsbColor,
            this.tsbDrawMode,
            this.toolStripSeparator7,
            this.tsbUndo,
            this.toolStripSeparator8,
            this.tsbCopy,
            this.toolStripSeparator11,
            this.tsbPrint,
            this.toolStripSeparator10,
            this.tsbExitCollection});
            this.barMenuOpen.Location = new System.Drawing.Point(0, 25);
            this.barMenuOpen.Name = "barMenuOpen";
            this.barMenuOpen.Size = new System.Drawing.Size(1068, 25);
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
            // tsbClipboard
            // 
            this.tsbClipboard.Image = ((System.Drawing.Image)(resources.GetObject("tsbClipboard.Image")));
            this.tsbClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClipboard.Name = "tsbClipboard";
            this.tsbClipboard.Size = new System.Drawing.Size(77, 22);
            this.tsbClipboard.Text = "clipboard";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbColor
            // 
            this.tsbColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbColor.Name = "tsbColor";
            this.tsbColor.Size = new System.Drawing.Size(23, 22);
            this.tsbColor.Text = "     ";
            // 
            // tsbDrawMode
            // 
            this.tsbDrawMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPen,
            this.tsbHighlight});
            this.tsbDrawMode.Image = ((System.Drawing.Image)(resources.GetObject("tsbDrawMode.Image")));
            this.tsbDrawMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDrawMode.Name = "tsbDrawMode";
            this.tsbDrawMode.Size = new System.Drawing.Size(96, 22);
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
            // tsbCopy
            // 
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(53, 22);
            this.tsbCopy.Text = "copy";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(52, 22);
            this.tsbPrint.Text = "print";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExitCollection
            // 
            this.tsbExitCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbExitCollection.Image")));
            this.tsbExitCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExitCollection.Name = "tsbExitCollection";
            this.tsbExitCollection.Size = new System.Drawing.Size(45, 22);
            this.tsbExitCollection.Text = "exit";
            this.tsbExitCollection.Visible = false;
            // 
            // tabSidePanel
            // 
            this.tabSidePanel.Controls.Add(this.tabSideBrowse);
            this.tabSidePanel.Controls.Add(this.tabSideOpen);
            this.tabSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabSidePanel.Location = new System.Drawing.Point(0, 50);
            this.tabSidePanel.Name = "tabSidePanel";
            this.tabSidePanel.SelectedIndex = 0;
            this.tabSidePanel.Size = new System.Drawing.Size(252, 630);
            this.tabSidePanel.TabIndex = 9;
            // 
            // tabSideBrowse
            // 
            this.tabSideBrowse.Controls.Add(this.lblCCreated);
            this.tabSideBrowse.Controls.Add(this.lblCModified);
            this.tabSideBrowse.Location = new System.Drawing.Point(4, 22);
            this.tabSideBrowse.Name = "tabSideBrowse";
            this.tabSideBrowse.Size = new System.Drawing.Size(244, 604);
            this.tabSideBrowse.TabIndex = 0;
            this.tabSideBrowse.Text = "tabPage1";
            this.tabSideBrowse.UseVisualStyleBackColor = true;
            // 
            // tabSideOpen
            // 
            this.tabSideOpen.Controls.Add(this.CInfoPanel);
            this.tabSideOpen.Controls.Add(this.infoPanel);
            this.tabSideOpen.Location = new System.Drawing.Point(4, 22);
            this.tabSideOpen.Name = "tabSideOpen";
            this.tabSideOpen.Size = new System.Drawing.Size(244, 604);
            this.tabSideOpen.TabIndex = 1;
            this.tabSideOpen.Text = "tabPage2";
            this.tabSideOpen.UseVisualStyleBackColor = true;
            // 
            // CInfoPanel
            // 
            this.CInfoPanel.Controls.Add(this.lblCName);
            this.CInfoPanel.Controls.Add(this.btnCReset);
            this.CInfoPanel.Controls.Add(this.lblCDescription);
            this.CInfoPanel.Controls.Add(this.txtCName);
            this.CInfoPanel.Controls.Add(this.txtCDescription);
            this.CInfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CInfoPanel.Location = new System.Drawing.Point(0, 320);
            this.CInfoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CInfoPanel.Name = "CInfoPanel";
            this.CInfoPanel.Size = new System.Drawing.Size(244, 284);
            this.CInfoPanel.TabIndex = 19;
            this.CInfoPanel.TabStop = false;
            this.CInfoPanel.Text = "Collection Info";
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCName.Location = new System.Drawing.Point(6, 21);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(41, 15);
            this.lblCName.TabIndex = 15;
            this.lblCName.Text = "Name";
            // 
            // btnCReset
            // 
            this.btnCReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCReset.Location = new System.Drawing.Point(6, 190);
            this.btnCReset.Name = "btnCReset";
            this.btnCReset.Size = new System.Drawing.Size(75, 30);
            this.btnCReset.TabIndex = 17;
            this.btnCReset.Text = "Reset";
            this.btnCReset.UseVisualStyleBackColor = true;
            // 
            // lblCDescription
            // 
            this.lblCDescription.AutoSize = true;
            this.lblCDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCDescription.Location = new System.Drawing.Point(6, 74);
            this.lblCDescription.Name = "lblCDescription";
            this.lblCDescription.Size = new System.Drawing.Size(69, 15);
            this.lblCDescription.TabIndex = 16;
            this.lblCDescription.Text = "Description";
            // 
            // txtCName
            // 
            this.txtCName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCName.Location = new System.Drawing.Point(0, 39);
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(244, 21);
            this.txtCName.TabIndex = 13;
            // 
            // txtCDescription
            // 
            this.txtCDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCDescription.Location = new System.Drawing.Point(0, 92);
            this.txtCDescription.Name = "txtCDescription";
            this.txtCDescription.Size = new System.Drawing.Size(244, 92);
            this.txtCDescription.TabIndex = 14;
            this.txtCDescription.Text = "";
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.txtName);
            this.infoPanel.Controls.Add(this.txtDescription);
            this.infoPanel.Controls.Add(this.lblName);
            this.infoPanel.Controls.Add(this.btnReset);
            this.infoPanel.Controls.Add(this.lblDateModified);
            this.infoPanel.Controls.Add(this.lblDateCreated);
            this.infoPanel.Controls.Add(this.lblDescription);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(244, 289);
            this.infoPanel.TabIndex = 18;
            this.infoPanel.TabStop = false;
            this.infoPanel.Text = "Image Info";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(0, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(244, 21);
            this.txtName.TabIndex = 13;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(0, 86);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(244, 117);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.Text = "";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(117, 229);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // lblDateModified
            // 
            this.lblDateModified.AutoSize = true;
            this.lblDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateModified.Location = new System.Drawing.Point(6, 218);
            this.lblDateModified.Name = "lblDateModified";
            this.lblDateModified.Size = new System.Drawing.Size(82, 15);
            this.lblDateModified.TabIndex = 9;
            this.lblDateModified.Text = "date modified";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCreated.Location = new System.Drawing.Point(6, 190);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(75, 15);
            this.lblDateCreated.TabIndex = 10;
            this.lblDateCreated.Text = "date created";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(6, 68);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(69, 15);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 680);
            this.Controls.Add(this.tabSidePanel);
            this.Controls.Add(this.barMenuOpen);
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
            this.barMenuOpen.ResumeLayout(false);
            this.barMenuOpen.PerformLayout();
            this.tabSidePanel.ResumeLayout(false);
            this.tabSideBrowse.ResumeLayout(false);
            this.tabSideBrowse.PerformLayout();
            this.tabSideOpen.ResumeLayout(false);
            this.CInfoPanel.ResumeLayout(false);
            this.CInfoPanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
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
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.ToolStripButton tsbDeleteCollection;
        private System.Windows.Forms.ToolStripButton tsbSaveCollection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbScreenshot;
        private System.Windows.Forms.ToolStripButton tsbDeleteScreenshot;
        private System.Windows.Forms.ToolStrip barMenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbBrowse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbExitCollection;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ToolStripDropDownButton tsbDrawMode;
        private System.Windows.Forms.ToolStripMenuItem tsbPen;
        private System.Windows.Forms.ToolStripMenuItem tsbHighlight;
        private System.Windows.Forms.Label lblCModified;
        private System.Windows.Forms.Label lblCCreated;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton tsbClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.TabControl tabSidePanel;
        private System.Windows.Forms.TabPage tabSideBrowse;
        private System.Windows.Forms.TabPage tabSideOpen;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblDateModified;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ToolStripComboBox tsbOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.Button btnCReset;
        private System.Windows.Forms.Label lblCDescription;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.RichTextBox txtCDescription;
        private System.Windows.Forms.GroupBox CInfoPanel;
        private System.Windows.Forms.GroupBox infoPanel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.ToolStripButton tsbColor;
    }
}

