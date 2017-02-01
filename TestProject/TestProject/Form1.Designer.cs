namespace TestProject
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseEffectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightStrip = new System.Windows.Forms.MenuStrip();
            this.leftStrip = new System.Windows.Forms.MenuStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bottomStrip = new System.Windows.Forms.MenuStrip();
            this.MouseCords = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorSelected = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.topStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topStrip
            // 
            this.topStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.topStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.topStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.centerToolStripMenuItem,
            this.baseEffectsToolStripMenuItem,
            this.formColor,
            this.toolsToolStripMenuItem});
            resources.ApplyResources(this.topStrip, "topStrip");
            this.topStrip.Name = "topStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jPEGToolStripMenuItem,
            this.bitmapToolStripMenuItem,
            this.pNGToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            // 
            // jPEGToolStripMenuItem
            // 
            this.jPEGToolStripMenuItem.Name = "jPEGToolStripMenuItem";
            resources.ApplyResources(this.jPEGToolStripMenuItem, "jPEGToolStripMenuItem");
            this.jPEGToolStripMenuItem.Click += new System.EventHandler(this.jPEGToolStripMenuItem_Click);
            // 
            // bitmapToolStripMenuItem
            // 
            this.bitmapToolStripMenuItem.Name = "bitmapToolStripMenuItem";
            resources.ApplyResources(this.bitmapToolStripMenuItem, "bitmapToolStripMenuItem");
            this.bitmapToolStripMenuItem.Click += new System.EventHandler(this.bitmapToolStripMenuItem_Click);
            // 
            // pNGToolStripMenuItem
            // 
            this.pNGToolStripMenuItem.Name = "pNGToolStripMenuItem";
            resources.ApplyResources(this.pNGToolStripMenuItem, "pNGToolStripMenuItem");
            this.pNGToolStripMenuItem.Click += new System.EventHandler(this.pNGToolStripMenuItem_Click);
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            resources.ApplyResources(this.centerToolStripMenuItem, "centerToolStripMenuItem");
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // baseEffectsToolStripMenuItem
            // 
            this.baseEffectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sepiaToolStripMenuItem});
            this.baseEffectsToolStripMenuItem.Name = "baseEffectsToolStripMenuItem";
            resources.ApplyResources(this.baseEffectsToolStripMenuItem, "baseEffectsToolStripMenuItem");
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            resources.ApplyResources(this.sepiaToolStripMenuItem, "sepiaToolStripMenuItem");
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // formColor
            // 
            this.formColor.Name = "formColor";
            resources.ApplyResources(this.formColor, "formColor");
            this.formColor.Click += new System.EventHandler(this.selectColorToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.penToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            resources.ApplyResources(this.selectToolStripMenuItem, "selectToolStripMenuItem");
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // penToolStripMenuItem
            // 
            this.penToolStripMenuItem.Name = "penToolStripMenuItem";
            resources.ApplyResources(this.penToolStripMenuItem, "penToolStripMenuItem");
            this.penToolStripMenuItem.Click += new System.EventHandler(this.penToolStripMenuItem_Click);
            // 
            // rightStrip
            // 
            this.rightStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.rightStrip, "rightStrip");
            this.rightStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.rightStrip.Name = "rightStrip";
            this.rightStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // leftStrip
            // 
            this.leftStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.leftStrip, "leftStrip");
            this.leftStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.leftStrip.Name = "leftStrip";
            this.leftStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseExit);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // bottomStrip
            // 
            this.bottomStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.bottomStrip, "bottomStrip");
            this.bottomStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.bottomStrip.Name = "bottomStrip";
            this.bottomStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // MouseCords
            // 
            resources.ApplyResources(this.MouseCords, "MouseCords");
            this.MouseCords.BackColor = System.Drawing.Color.White;
            this.MouseCords.Name = "MouseCords";
            // 
            // colorSelected
            // 
            resources.ApplyResources(this.colorSelected, "colorSelected");
            this.colorSelected.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorSelected.Name = "colorSelected";
            this.colorSelected.Click += new System.EventHandler(this.colorSelected_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.colorSelected);
            this.Controls.Add(this.MouseCords);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bottomStrip);
            this.Controls.Add(this.leftStrip);
            this.Controls.Add(this.topStrip);
            this.Controls.Add(this.rightStrip);
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.MainMenuStrip = this.topStrip;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.topStrip.ResumeLayout(false);
            this.topStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.MenuStrip rightStrip;
        private System.Windows.Forms.MenuStrip leftStrip;
        private System.Windows.Forms.ToolStripMenuItem jPEGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitmapToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseEffectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.MenuStrip bottomStrip;
        private System.Windows.Forms.Label MouseCords;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label colorSelected;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

