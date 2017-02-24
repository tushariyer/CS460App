﻿namespace Tabula
{
    partial class Tabula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tabula));
            this.topMenuBar = new System.Windows.Forms.MenuStrip();
            this.fileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsJPEG = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsBitmap = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsPNG = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.editButton = new System.Windows.Forms.ToolStripMenuItem();
            this.undoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.redoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.cutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.copyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.transformButton = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaEffect = new System.Windows.Forms.ToolStripMenuItem();
            this.invertEffect = new System.Windows.Forms.ToolStripMenuItem();
            this.colorButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.penToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.baseCanvas = new System.Windows.Forms.PictureBox();
            this.availableColors = new System.Windows.Forms.ColorDialog();
            this.shapesToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.printButton = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenuBar
            // 
            this.topMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.topMenuBar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topMenuBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.topMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.editButton,
            this.effectsButton,
            this.colorButton,
            this.toolsButton});
            this.topMenuBar.Location = new System.Drawing.Point(0, 0);
            this.topMenuBar.Name = "topMenuBar";
            this.topMenuBar.Size = new System.Drawing.Size(1830, 37);
            this.topMenuBar.TabIndex = 0;
            this.topMenuBar.Text = "topMenuBar";
            // 
            // fileButton
            // 
            this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileButton,
            this.openFileButton,
            this.saveFileSave,
            this.optionsButton,
            this.aboutButton,
            this.printButton,
            this.exitButton});
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(60, 33);
            this.fileButton.Text = "File";
            // 
            // newFileButton
            // 
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(269, 38);
            this.newFileButton.Text = "New File";
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(269, 38);
            this.openFileButton.Text = "Open File";
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // saveFileSave
            // 
            this.saveFileSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsJPEG,
            this.saveAsBitmap,
            this.saveAsPNG});
            this.saveFileSave.Name = "saveFileSave";
            this.saveFileSave.Size = new System.Drawing.Size(269, 38);
            this.saveFileSave.Text = "Save File";
            // 
            // saveAsJPEG
            // 
            this.saveAsJPEG.Name = "saveAsJPEG";
            this.saveAsJPEG.Size = new System.Drawing.Size(182, 38);
            this.saveAsJPEG.Text = "JPEG";
            this.saveAsJPEG.Click += new System.EventHandler(this.saveAsJPEG_Click);
            // 
            // saveAsBitmap
            // 
            this.saveAsBitmap.Name = "saveAsBitmap";
            this.saveAsBitmap.Size = new System.Drawing.Size(182, 38);
            this.saveAsBitmap.Text = "Bitmap";
            this.saveAsBitmap.Click += new System.EventHandler(this.saveAsBitmap_Click);
            // 
            // saveAsPNG
            // 
            this.saveAsPNG.Name = "saveAsPNG";
            this.saveAsPNG.Size = new System.Drawing.Size(182, 38);
            this.saveAsPNG.Text = "PNG";
            this.saveAsPNG.Click += new System.EventHandler(this.saveAsPNG_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(269, 38);
            this.optionsButton.Text = "Options";
            // 
            // aboutButton
            // 
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(269, 38);
            this.aboutButton.Text = "About";
            // 
            // exitButton
            // 
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(269, 38);
            this.exitButton.Text = "Exit";
            // 
            // editButton
            // 
            this.editButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.redoButton,
            this.cutButton,
            this.copyButton,
            this.pasteButton,
            this.transformButton});
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(64, 33);
            this.editButton.Text = "Edit";
            // 
            // undoButton
            // 
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(210, 38);
            this.undoButton.Text = "Undo";
            // 
            // redoButton
            // 
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(210, 38);
            this.redoButton.Text = "Redo";
            // 
            // cutButton
            // 
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(210, 38);
            this.cutButton.Text = "Cut";
            // 
            // copyButton
            // 
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(210, 38);
            this.copyButton.Text = "Copy";
            // 
            // pasteButton
            // 
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(210, 38);
            this.pasteButton.Text = "Paste";
            // 
            // transformButton
            // 
            this.transformButton.Name = "transformButton";
            this.transformButton.Size = new System.Drawing.Size(210, 38);
            this.transformButton.Text = "Transform";
            // 
            // effectsButton
            // 
            this.effectsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sepiaEffect,
            this.invertEffect});
            this.effectsButton.Name = "effectsButton";
            this.effectsButton.Size = new System.Drawing.Size(88, 33);
            this.effectsButton.Text = "Effects";
            // 
            // sepiaEffect
            // 
            this.sepiaEffect.Name = "sepiaEffect";
            this.sepiaEffect.Size = new System.Drawing.Size(169, 38);
            this.sepiaEffect.Text = "Sepia";
            // 
            // invertEffect
            // 
            this.invertEffect.Name = "invertEffect";
            this.invertEffect.Size = new System.Drawing.Size(169, 38);
            this.invertEffect.Text = "Invert";
            // 
            // colorButton
            // 
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(78, 33);
            this.colorButton.Text = "Color";
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // toolsButton
            // 
            this.toolsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolButton,
            this.penToolButton,
            this.shapesToolButton});
            this.toolsButton.Name = "toolsButton";
            this.toolsButton.Size = new System.Drawing.Size(76, 33);
            this.toolsButton.Text = "Tools";
            // 
            // selectToolButton
            // 
            this.selectToolButton.Name = "selectToolButton";
            this.selectToolButton.Size = new System.Drawing.Size(269, 38);
            this.selectToolButton.Text = "Select";
            // 
            // penToolButton
            // 
            this.penToolButton.Name = "penToolButton";
            this.penToolButton.Size = new System.Drawing.Size(269, 38);
            this.penToolButton.Text = "Pen";
            // 
            // baseCanvas
            // 
            this.baseCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseCanvas.InitialImage = ((System.Drawing.Image)(resources.GetObject("baseCanvas.InitialImage")));
            this.baseCanvas.Location = new System.Drawing.Point(0, 37);
            this.baseCanvas.Name = "baseCanvas";
            this.baseCanvas.Size = new System.Drawing.Size(1830, 1173);
            this.baseCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.baseCanvas.TabIndex = 1;
            this.baseCanvas.TabStop = false;
            this.baseCanvas.Click += new System.EventHandler(this.baseCanvas_Click);
            // 
            // shapesToolButton
            // 
            this.shapesToolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolButton,
            this.squareToolButton,
            this.lineToolButton,
            this.triangleToolButton});
            this.shapesToolButton.Name = "shapesToolButton";
            this.shapesToolButton.Size = new System.Drawing.Size(269, 38);
            this.shapesToolButton.Text = "Shapes";
            // 
            // circleToolButton
            // 
            this.circleToolButton.Name = "circleToolButton";
            this.circleToolButton.Size = new System.Drawing.Size(269, 38);
            this.circleToolButton.Text = "Circle";
            // 
            // squareToolButton
            // 
            this.squareToolButton.Name = "squareToolButton";
            this.squareToolButton.Size = new System.Drawing.Size(269, 38);
            this.squareToolButton.Text = "Square";
            // 
            // lineToolButton
            // 
            this.lineToolButton.Name = "lineToolButton";
            this.lineToolButton.Size = new System.Drawing.Size(269, 38);
            this.lineToolButton.Text = "Line";
            // 
            // triangleToolButton
            // 
            this.triangleToolButton.Name = "triangleToolButton";
            this.triangleToolButton.Size = new System.Drawing.Size(269, 38);
            this.triangleToolButton.Text = "Triangle";
            // 
            // printButton
            // 
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(269, 38);
            this.printButton.Text = "Print";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // Tabula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1830, 1210);
            this.Controls.Add(this.baseCanvas);
            this.Controls.Add(this.topMenuBar);
            this.Font = new System.Drawing.Font("Calibri", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MainMenuStrip = this.topMenuBar;
            this.Name = "Tabula";
            this.Text = "Tabula";
            this.topMenuBar.ResumeLayout(false);
            this.topMenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileButton;
        private System.Windows.Forms.ToolStripMenuItem newFileButton;
        private System.Windows.Forms.ToolStripMenuItem openFileButton;
        private System.Windows.Forms.ToolStripMenuItem saveFileSave;
        private System.Windows.Forms.ToolStripMenuItem optionsButton;
        private System.Windows.Forms.ToolStripMenuItem aboutButton;
        private System.Windows.Forms.ToolStripMenuItem exitButton;
        private System.Windows.Forms.ToolStripMenuItem editButton;
        private System.Windows.Forms.ToolStripMenuItem effectsButton;
        private System.Windows.Forms.ToolStripMenuItem colorButton;
        private System.Windows.Forms.ToolStripMenuItem toolsButton;
        private System.Windows.Forms.ToolStripMenuItem selectToolButton;
        private System.Windows.Forms.ToolStripMenuItem penToolButton;
        private System.Windows.Forms.ToolStripMenuItem saveAsJPEG;
        private System.Windows.Forms.ToolStripMenuItem saveAsBitmap;
        private System.Windows.Forms.ToolStripMenuItem saveAsPNG;
        private System.Windows.Forms.ToolStripMenuItem undoButton;
        private System.Windows.Forms.ToolStripMenuItem redoButton;
        private System.Windows.Forms.ToolStripMenuItem cutButton;
        private System.Windows.Forms.ToolStripMenuItem copyButton;
        private System.Windows.Forms.ToolStripMenuItem pasteButton;
        private System.Windows.Forms.ToolStripMenuItem transformButton;
        private System.Windows.Forms.ToolStripMenuItem sepiaEffect;
        private System.Windows.Forms.ToolStripMenuItem invertEffect;
        private System.Windows.Forms.PictureBox baseCanvas;
        private System.Windows.Forms.ColorDialog availableColors;
        private System.Windows.Forms.ToolStripMenuItem shapesToolButton;
        private System.Windows.Forms.ToolStripMenuItem circleToolButton;
        private System.Windows.Forms.ToolStripMenuItem squareToolButton;
        private System.Windows.Forms.ToolStripMenuItem lineToolButton;
        private System.Windows.Forms.ToolStripMenuItem triangleToolButton;
        private System.Windows.Forms.ToolStripMenuItem printButton;
    }
}

