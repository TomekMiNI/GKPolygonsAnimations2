using System;
using System.Drawing;
using System.Windows.Forms;

namespace GKProjekt2
{
    partial class Polygons
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel _table;
        private PictureBox _drawPanel;
        private GroupBox _IlBox;
        private GroupBox _IoBox;
        private GroupBox _LBox;
        private GroupBox _NBox;
        private GroupBox _PBox;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Polygons));
            this._LBox = new System.Windows.Forms.GroupBox();
            this._VLStextbox = new System.Windows.Forms.TextBox();
            this._VLSconstR = new System.Windows.Forms.RadioButton();
            this._VLStextR = new System.Windows.Forms.RadioButton();
            this._VLSlabel = new System.Windows.Forms.Label();
            this._IlBox = new System.Windows.Forms.GroupBox();
            this._ILbutton = new System.Windows.Forms.Button();
            this._ILcolor = new System.Windows.Forms.Label();
            this._ILlabel = new System.Windows.Forms.Label();
            this._NBox = new System.Windows.Forms.GroupBox();
            this._NsphereR = new System.Windows.Forms.RadioButton();
            this._Nlabel = new System.Windows.Forms.Label();
            this._NconstR = new System.Windows.Forms.RadioButton();
            this._NtextR = new System.Windows.Forms.RadioButton();
            this._Ncolor = new System.Windows.Forms.Label();
            this._Nbutton = new System.Windows.Forms.Button();
            this._Plabel = new System.Windows.Forms.Label();
            this._PBox = new System.Windows.Forms.GroupBox();
            this._fButton = new System.Windows.Forms.Button();
            this._fTextBox = new System.Windows.Forms.TextBox();
            this._Pnone = new System.Windows.Forms.RadioButton();
            this._PtextR = new System.Windows.Forms.RadioButton();
            this._Pcolor = new System.Windows.Forms.Label();
            this._Pbutton = new System.Windows.Forms.Button();
            this._IoBox = new System.Windows.Forms.GroupBox();
            this._IOconstR = new System.Windows.Forms.RadioButton();
            this._IOtextR = new System.Windows.Forms.RadioButton();
            this._IOconstBtn = new System.Windows.Forms.Button();
            this._IOlabel = new System.Windows.Forms.Label();
            this._IOtextBtn = new System.Windows.Forms.Button();
            this._IOtextC = new System.Windows.Forms.Label();
            this._IOconstC = new System.Windows.Forms.Label();
            this._drawPanel = new System.Windows.Forms.PictureBox();
            this._table = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.drawPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePolygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeVerticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCommonPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findCommonPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._LBox.SuspendLayout();
            this._IlBox.SuspendLayout();
            this._NBox.SuspendLayout();
            this._PBox.SuspendLayout();
            this._IoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._drawPanel)).BeginInit();
            this._table.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _LBox
            // 
            this._LBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._LBox.Controls.Add(this._VLStextbox);
            this._LBox.Controls.Add(this._VLSconstR);
            this._LBox.Controls.Add(this._VLStextR);
            this._LBox.Controls.Add(this._VLSlabel);
            this._LBox.Location = new System.Drawing.Point(6, 176);
            this._LBox.Name = "_LBox";
            this._LBox.Size = new System.Drawing.Size(423, 91);
            this._LBox.TabIndex = 0;
            this._LBox.TabStop = false;
            // 
            // _VLStextbox
            // 
            this._VLStextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._VLStextbox.Location = new System.Drawing.Point(195, 53);
            this._VLStextbox.Name = "_VLStextbox";
            this._VLStextbox.Size = new System.Drawing.Size(69, 20);
            this._VLStextbox.TabIndex = 28;
            this._VLStextbox.Text = "50";
            // 
            // _VLSconstR
            // 
            this._VLSconstR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._VLSconstR.AutoSize = true;
            this._VLSconstR.Checked = true;
            this._VLSconstR.Location = new System.Drawing.Point(7, 19);
            this._VLSconstR.Name = "_VLSconstR";
            this._VLSconstR.Size = new System.Drawing.Size(99, 17);
            this._VLSconstR.TabIndex = 17;
            this._VLSconstR.TabStop = true;
            this._VLSconstR.Text = "constant [0,0,1]";
            this._VLSconstR.UseVisualStyleBackColor = true;
            this._VLSconstR.CheckedChanged += new System.EventHandler(this.selectVLSconstR);
            // 
            // _VLStextR
            // 
            this._VLStextR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._VLStextR.AutoSize = true;
            this._VLStextR.Location = new System.Drawing.Point(10, 53);
            this._VLStextR.Name = "_VLStextR";
            this._VLStextR.Size = new System.Drawing.Size(160, 17);
            this._VLStextR.TabIndex = 18;
            this._VLStextR.Text = "animated light at sphere, R= ";
            this._VLStextR.UseVisualStyleBackColor = true;
            this._VLStextR.CheckedChanged += new System.EventHandler(this.selectR);
            // 
            // _VLSlabel
            // 
            this._VLSlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._VLSlabel.AutoSize = true;
            this._VLSlabel.Location = new System.Drawing.Point(11, 0);
            this._VLSlabel.Name = "_VLSlabel";
            this._VLSlabel.Size = new System.Drawing.Size(98, 13);
            this._VLSlabel.TabIndex = 23;
            this._VLSlabel.Text = "Light source vector";
            // 
            // _IlBox
            // 
            this._IlBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IlBox.Controls.Add(this._ILbutton);
            this._IlBox.Controls.Add(this._ILcolor);
            this._IlBox.Controls.Add(this._ILlabel);
            this._IlBox.Location = new System.Drawing.Point(3, 29);
            this._IlBox.Name = "_IlBox";
            this._IlBox.Size = new System.Drawing.Size(430, 47);
            this._IlBox.TabIndex = 4;
            this._IlBox.TabStop = false;
            // 
            // _ILbutton
            // 
            this._ILbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._ILbutton.Location = new System.Drawing.Point(310, 14);
            this._ILbutton.Name = "_ILbutton";
            this._ILbutton.Size = new System.Drawing.Size(73, 23);
            this._ILbutton.TabIndex = 6;
            this._ILbutton.Text = "Change";
            this._ILbutton.UseVisualStyleBackColor = true;
            this._ILbutton.Click += new System.EventHandler(this.changeColorIL);
            // 
            // _ILcolor
            // 
            this._ILcolor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._ILcolor.BackColor = System.Drawing.Color.White;
            this._ILcolor.Location = new System.Drawing.Point(155, 16);
            this._ILcolor.Name = "_ILcolor";
            this._ILcolor.Size = new System.Drawing.Size(65, 21);
            this._ILcolor.TabIndex = 5;
            // 
            // _ILlabel
            // 
            this._ILlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._ILlabel.AutoSize = true;
            this._ILlabel.Location = new System.Drawing.Point(6, 0);
            this._ILlabel.Name = "_ILlabel";
            this._ILlabel.Size = new System.Drawing.Size(103, 13);
            this._ILlabel.TabIndex = 4;
            this._ILlabel.Text = "Light source color IL";
            // 
            // _NBox
            // 
            this._NBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._NBox.Controls.Add(this._NsphereR);
            this._NBox.Controls.Add(this._Nlabel);
            this._NBox.Controls.Add(this._NconstR);
            this._NBox.Controls.Add(this._NtextR);
            this._NBox.Controls.Add(this._Ncolor);
            this._NBox.Controls.Add(this._Nbutton);
            this._NBox.Location = new System.Drawing.Point(7, 273);
            this._NBox.Name = "_NBox";
            this._NBox.Size = new System.Drawing.Size(422, 101);
            this._NBox.TabIndex = 0;
            this._NBox.TabStop = false;
            // 
            // _NsphereR
            // 
            this._NsphereR.AutoSize = true;
            this._NsphereR.Location = new System.Drawing.Point(5, 66);
            this._NsphereR.Name = "_NsphereR";
            this._NsphereR.Size = new System.Drawing.Size(109, 17);
            this._NsphereR.TabIndex = 26;
            this._NsphereR.TabStop = true;
            this._NsphereR.Text = "on sphere moving";
            this._NsphereR.UseVisualStyleBackColor = true;
            this._NsphereR.CheckedChanged += new System.EventHandler(this._NsphereR_CheckedChanged);
            // 
            // _Nlabel
            // 
            this._Nlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._Nlabel.AutoSize = true;
            this._Nlabel.Location = new System.Drawing.Point(10, 0);
            this._Nlabel.Name = "_Nlabel";
            this._Nlabel.Size = new System.Drawing.Size(63, 13);
            this._Nlabel.TabIndex = 16;
            this._Nlabel.Text = "Normal map";
            // 
            // _NconstR
            // 
            this._NconstR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._NconstR.AutoSize = true;
            this._NconstR.Location = new System.Drawing.Point(6, 19);
            this._NconstR.Name = "_NconstR";
            this._NconstR.Size = new System.Drawing.Size(99, 17);
            this._NconstR.TabIndex = 24;
            this._NconstR.Text = "constant [0,0,1]";
            this._NconstR.UseVisualStyleBackColor = true;
            this._NconstR.CheckedChanged += new System.EventHandler(this._NconstR_CheckedChanged);
            // 
            // _NtextR
            // 
            this._NtextR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._NtextR.AutoSize = true;
            this._NtextR.Checked = true;
            this._NtextR.Location = new System.Drawing.Point(5, 42);
            this._NtextR.Name = "_NtextR";
            this._NtextR.Size = new System.Drawing.Size(57, 17);
            this._NtextR.TabIndex = 25;
            this._NtextR.TabStop = true;
            this._NtextR.Text = "texture";
            this._NtextR.UseVisualStyleBackColor = true;
            // 
            // _Ncolor
            // 
            this._Ncolor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._Ncolor.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this._Ncolor.Location = new System.Drawing.Point(191, 30);
            this._Ncolor.Name = "_Ncolor";
            this._Ncolor.Size = new System.Drawing.Size(72, 29);
            this._Ncolor.TabIndex = 20;
            // 
            // _Nbutton
            // 
            this._Nbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._Nbutton.Location = new System.Drawing.Point(304, 36);
            this._Nbutton.Name = "_Nbutton";
            this._Nbutton.Size = new System.Drawing.Size(75, 23);
            this._Nbutton.TabIndex = 15;
            this._Nbutton.Text = "Change";
            this._Nbutton.UseVisualStyleBackColor = true;
            this._Nbutton.Click += new System.EventHandler(this.changeNormalMap);
            // 
            // _Plabel
            // 
            this._Plabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._Plabel.AutoSize = true;
            this._Plabel.Location = new System.Drawing.Point(6, 0);
            this._Plabel.Name = "_Plabel";
            this._Plabel.Size = new System.Drawing.Size(64, 13);
            this._Plabel.TabIndex = 29;
            this._Plabel.Text = "Perturbation";
            // 
            // _PBox
            // 
            this._PBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._PBox.Controls.Add(this._fButton);
            this._PBox.Controls.Add(this._fTextBox);
            this._PBox.Controls.Add(this._Plabel);
            this._PBox.Controls.Add(this._Pnone);
            this._PBox.Controls.Add(this._PtextR);
            this._PBox.Controls.Add(this._Pcolor);
            this._PBox.Controls.Add(this._Pbutton);
            this._PBox.Location = new System.Drawing.Point(8, 383);
            this._PBox.Name = "_PBox";
            this._PBox.Size = new System.Drawing.Size(419, 73);
            this._PBox.TabIndex = 0;
            this._PBox.TabStop = false;
            // 
            // _fButton
            // 
            this._fButton.Location = new System.Drawing.Point(305, 21);
            this._fButton.Name = "_fButton";
            this._fButton.Size = new System.Drawing.Size(75, 23);
            this._fButton.TabIndex = 37;
            this._fButton.Text = "Introduce f";
            this._fButton.UseVisualStyleBackColor = true;
            this._fButton.Click += new System.EventHandler(this._fButton_Click);
            // 
            // _fTextBox
            // 
            this._fTextBox.Location = new System.Drawing.Point(305, 50);
            this._fTextBox.Name = "_fTextBox";
            this._fTextBox.Size = new System.Drawing.Size(73, 20);
            this._fTextBox.TabIndex = 36;
            // 
            // _Pnone
            // 
            this._Pnone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._Pnone.AutoSize = true;
            this._Pnone.Checked = true;
            this._Pnone.Location = new System.Drawing.Point(8, 22);
            this._Pnone.Name = "_Pnone";
            this._Pnone.Size = new System.Drawing.Size(82, 17);
            this._Pnone.TabIndex = 30;
            this._Pnone.TabStop = true;
            this._Pnone.Text = "none [0,0,0]";
            this._Pnone.UseVisualStyleBackColor = true;
            // 
            // _PtextR
            // 
            this._PtextR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._PtextR.AutoSize = true;
            this._PtextR.Location = new System.Drawing.Point(8, 53);
            this._PtextR.Name = "_PtextR";
            this._PtextR.Size = new System.Drawing.Size(135, 17);
            this._PtextR.TabIndex = 31;
            this._PtextR.Text = "from texture HeightMap";
            this._PtextR.UseVisualStyleBackColor = true;
            this._PtextR.CheckedChanged += new System.EventHandler(this._PtextR_CheckedChanged);
            // 
            // _Pcolor
            // 
            this._Pcolor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._Pcolor.BackColor = System.Drawing.SystemColors.ControlDark;
            this._Pcolor.Location = new System.Drawing.Point(446, 36);
            this._Pcolor.Name = "_Pcolor";
            this._Pcolor.Size = new System.Drawing.Size(63, 21);
            this._Pcolor.TabIndex = 34;
            // 
            // _Pbutton
            // 
            this._Pbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._Pbutton.Location = new System.Drawing.Point(193, 50);
            this._Pbutton.Name = "_Pbutton";
            this._Pbutton.Size = new System.Drawing.Size(69, 23);
            this._Pbutton.TabIndex = 35;
            this._Pbutton.Text = "Change";
            this._Pbutton.UseVisualStyleBackColor = true;
            this._Pbutton.Click += new System.EventHandler(this.changePerturbation);
            // 
            // _IoBox
            // 
            this._IoBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IoBox.Controls.Add(this._IOconstR);
            this._IoBox.Controls.Add(this._IOtextR);
            this._IoBox.Controls.Add(this._IOconstBtn);
            this._IoBox.Controls.Add(this._IOlabel);
            this._IoBox.Controls.Add(this._IOtextBtn);
            this._IoBox.Controls.Add(this._IOtextC);
            this._IoBox.Controls.Add(this._IOconstC);
            this._IoBox.Location = new System.Drawing.Point(3, 89);
            this._IoBox.Name = "_IoBox";
            this._IoBox.Size = new System.Drawing.Size(430, 77);
            this._IoBox.TabIndex = 41;
            this._IoBox.TabStop = false;
            // 
            // _IOconstR
            // 
            this._IOconstR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IOconstR.AutoSize = true;
            this._IOconstR.Location = new System.Drawing.Point(3, 27);
            this._IOconstR.Name = "_IOconstR";
            this._IOconstR.Size = new System.Drawing.Size(66, 17);
            this._IOconstR.TabIndex = 8;
            this._IOconstR.Text = "constant";
            this._IOconstR.UseVisualStyleBackColor = true;
            this._IOconstR.CheckedChanged += new System.EventHandler(this.selectIOconstR);
            // 
            // _IOtextR
            // 
            this._IOtextR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IOtextR.AutoSize = true;
            this._IOtextR.Checked = true;
            this._IOtextR.Location = new System.Drawing.Point(5, 54);
            this._IOtextR.Name = "_IOtextR";
            this._IOtextR.Size = new System.Drawing.Size(80, 17);
            this._IOtextR.TabIndex = 9;
            this._IOtextR.TabStop = true;
            this._IOtextR.Text = "from texture";
            this._IOtextR.UseVisualStyleBackColor = true;
            this._IOtextR.CheckedChanged += new System.EventHandler(this._IOtextR_CheckedChanged);
            // 
            // _IOconstBtn
            // 
            this._IOconstBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IOconstBtn.Location = new System.Drawing.Point(308, 26);
            this._IOconstBtn.Name = "_IOconstBtn";
            this._IOconstBtn.Size = new System.Drawing.Size(75, 23);
            this._IOconstBtn.TabIndex = 14;
            this._IOconstBtn.Text = "Change";
            this._IOconstBtn.UseVisualStyleBackColor = true;
            this._IOconstBtn.Click += new System.EventHandler(this.changeColorIO);
            // 
            // _IOlabel
            // 
            this._IOlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IOlabel.AutoSize = true;
            this._IOlabel.Location = new System.Drawing.Point(6, 0);
            this._IOlabel.Name = "_IOlabel";
            this._IOlabel.Size = new System.Drawing.Size(67, 13);
            this._IOlabel.TabIndex = 7;
            this._IOlabel.Text = "Object color ";
            // 
            // _IOtextBtn
            // 
            this._IOtextBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IOtextBtn.Location = new System.Drawing.Point(308, 54);
            this._IOtextBtn.Name = "_IOtextBtn";
            this._IOtextBtn.Size = new System.Drawing.Size(75, 23);
            this._IOtextBtn.TabIndex = 22;
            this._IOtextBtn.Text = "Change";
            this._IOtextBtn.UseVisualStyleBackColor = true;
            this._IOtextBtn.Click += new System.EventHandler(this._IOtextBtn_Click);
            // 
            // _IOtextC
            // 
            this._IOtextC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IOtextC.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._IOtextC.Location = new System.Drawing.Point(152, 53);
            this._IOtextC.Name = "_IOtextC";
            this._IOtextC.Size = new System.Drawing.Size(68, 24);
            this._IOtextC.TabIndex = 11;
            // 
            // _IOconstC
            // 
            this._IOconstC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._IOconstC.BackColor = System.Drawing.Color.White;
            this._IOconstC.Location = new System.Drawing.Point(152, 16);
            this._IOconstC.Name = "_IOconstC";
            this._IOconstC.Size = new System.Drawing.Size(68, 28);
            this._IOconstC.TabIndex = 10;
            // 
            // _drawPanel
            // 
            this._drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._drawPanel.BackColor = System.Drawing.Color.White;
            this._drawPanel.Image = ((System.Drawing.Image)(resources.GetObject("_drawPanel.Image")));
            this._drawPanel.Location = new System.Drawing.Point(439, 3);
            this._drawPanel.Name = "_drawPanel";
            this._table.SetRowSpan(this._drawPanel, 6);
            this._drawPanel.Size = new System.Drawing.Size(542, 455);
            this._drawPanel.TabIndex = 0;
            this._drawPanel.TabStop = false;
            this._drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.refreshPanel);
            this._drawPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.addVerticle);
            this._drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawing);
            this._drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.swaping);
            this._drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stopSwaping);
            // 
            // _table
            // 
            this._table.ColumnCount = 2;
            this._table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 436F));
            this._table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this._table.Controls.Add(this._drawPanel, 1, 0);
            this._table.Controls.Add(this._IlBox, 0, 1);
            this._table.Controls.Add(this.menuStrip1, 0, 0);
            this._table.Controls.Add(this._IoBox, 0, 2);
            this._table.Controls.Add(this._LBox, 0, 3);
            this._table.Controls.Add(this._PBox, 0, 5);
            this._table.Controls.Add(this._NBox, 0, 4);
            this._table.Dock = System.Windows.Forms.DockStyle.Fill;
            this._table.Location = new System.Drawing.Point(0, 0);
            this._table.Name = "_table";
            this._table.RowCount = 6;
            this._table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this._table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this._table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this._table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this._table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this._table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this._table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._table.Size = new System.Drawing.Size(984, 461);
            this._table.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawPolygonToolStripMenuItem,
            this.removePolygonToolStripMenuItem,
            this.fillPolygonToolStripMenuItem,
            this.findCommonPartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(436, 24);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // drawPolygonToolStripMenuItem
            // 
            this.drawPolygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staticToolStripMenuItem,
            this.moveableToolStripMenuItem});
            this.drawPolygonToolStripMenuItem.Name = "drawPolygonToolStripMenuItem";
            this.drawPolygonToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.drawPolygonToolStripMenuItem.Text = "Draw polygon";
            // 
            // staticToolStripMenuItem
            // 
            this.staticToolStripMenuItem.Name = "staticToolStripMenuItem";
            this.staticToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.staticToolStripMenuItem.Text = "Static";
            this.staticToolStripMenuItem.Click += new System.EventHandler(this.staticDrawClick);
            // 
            // moveableToolStripMenuItem
            // 
            this.moveableToolStripMenuItem.Name = "moveableToolStripMenuItem";
            this.moveableToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.moveableToolStripMenuItem.Text = "Moveable";
            this.moveableToolStripMenuItem.Click += new System.EventHandler(this.moveableDrawClick);
            // 
            // removePolygonToolStripMenuItem
            // 
            this.removePolygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removePolygonsToolStripMenuItem,
            this.removeVerticleToolStripMenuItem,
            this.removeCommonPartToolStripMenuItem});
            this.removePolygonToolStripMenuItem.Name = "removePolygonToolStripMenuItem";
            this.removePolygonToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.removePolygonToolStripMenuItem.Text = "Remove";
            // 
            // removePolygonsToolStripMenuItem
            // 
            this.removePolygonsToolStripMenuItem.Name = "removePolygonsToolStripMenuItem";
            this.removePolygonsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.removePolygonsToolStripMenuItem.Text = "Remove polygons";
            this.removePolygonsToolStripMenuItem.Click += new System.EventHandler(this.removePolygonsBtn);
            // 
            // removeVerticleToolStripMenuItem
            // 
            this.removeVerticleToolStripMenuItem.Name = "removeVerticleToolStripMenuItem";
            this.removeVerticleToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.removeVerticleToolStripMenuItem.Text = "Remove verticle";
            this.removeVerticleToolStripMenuItem.Click += new System.EventHandler(this.removeVerticle);
            // 
            // removeCommonPartToolStripMenuItem
            // 
            this.removeCommonPartToolStripMenuItem.Name = "removeCommonPartToolStripMenuItem";
            this.removeCommonPartToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.removeCommonPartToolStripMenuItem.Text = "Remove common part";
            this.removeCommonPartToolStripMenuItem.Click += new System.EventHandler(this.removeCommonPartToolStripMenuItem_Click);
            // 
            // fillPolygonToolStripMenuItem
            // 
            this.fillPolygonToolStripMenuItem.Name = "fillPolygonToolStripMenuItem";
            this.fillPolygonToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.fillPolygonToolStripMenuItem.Text = "Fill polygons";
            this.fillPolygonToolStripMenuItem.Click += new System.EventHandler(this.fillPolygonsBtn);
            // 
            // findCommonPartToolStripMenuItem
            // 
            this.findCommonPartToolStripMenuItem.Name = "findCommonPartToolStripMenuItem";
            this.findCommonPartToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.findCommonPartToolStripMenuItem.Text = "Find common part";
            this.findCommonPartToolStripMenuItem.Click += new System.EventHandler(this.findCommonPart);
            // 
            // Polygons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this._table);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "Polygons";
            this.Text = "KindOfMagic";
            this._LBox.ResumeLayout(false);
            this._LBox.PerformLayout();
            this._IlBox.ResumeLayout(false);
            this._IlBox.PerformLayout();
            this._NBox.ResumeLayout(false);
            this._NBox.PerformLayout();
            this._PBox.ResumeLayout(false);
            this._PBox.PerformLayout();
            this._IoBox.ResumeLayout(false);
            this._IoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._drawPanel)).EndInit();
            this._table.ResumeLayout(false);
            this._table.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }




        #endregion
        private Label _ILcolor;
        private Button _ILbutton;
        private Label _ILlabel;
        private Label _IOlabel;
        private RadioButton _IOconstR;
        private RadioButton _IOtextR;
        private Label _IOconstC;
        private Label _IOtextC;
        private Label _Nlabel;
        private RadioButton _VLSconstR;
        private RadioButton _VLStextR;
        private Label _Ncolor;
        private Label _VLSlabel;
        private RadioButton _NconstR;
        private RadioButton _NtextR;
        private Label _Plabel;
        private RadioButton _Pnone;
        private RadioButton _PtextR;
        private Button _IOconstBtn;
        private Button _Nbutton;
        private TextBox _VLStextbox;
        private Label _Pcolor;
        private Button _Pbutton;
        private Button _IOtextBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem drawPolygonToolStripMenuItem;
        private ToolStripMenuItem staticToolStripMenuItem;
        private ToolStripMenuItem moveableToolStripMenuItem;
        private ToolStripMenuItem fillPolygonToolStripMenuItem;
        private ToolStripMenuItem findCommonPartToolStripMenuItem;
        private ToolStripMenuItem removePolygonToolStripMenuItem;
        private ToolStripMenuItem removePolygonsToolStripMenuItem;
        private ToolStripMenuItem removeVerticleToolStripMenuItem;
        private ToolStripMenuItem removeCommonPartToolStripMenuItem;
        private TextBox _fTextBox;
        private Button _fButton;
        private RadioButton _NsphereR;
    }
}

