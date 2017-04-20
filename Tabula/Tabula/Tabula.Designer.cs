namespace Tabula
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
            this.printButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.editButton = new System.Windows.Forms.ToolStripMenuItem();
            this.undoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.redoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.cutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.copyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.transformButton = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaEffect = new System.Windows.Forms.ToolStripMenuItem();
            this.invertEffect = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.penToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolButton = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectButton = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fillColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.baseCanvas = new System.Windows.Forms.PictureBox();
            this.availableColors = new System.Windows.Forms.ColorDialog();
            this.MousePos = new System.Windows.Forms.Label();
            this.BrushSizeBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.topMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrushSizeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenuBar
            // 
            this.topMenuBar.BackColor = System.Drawing.SystemColors.WindowFrame;
            resources.ApplyResources(this.topMenuBar, "topMenuBar");
            this.topMenuBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.topMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.editButton,
            this.effectsButton,
            this.toolsButton});
            this.topMenuBar.Name = "topMenuBar";
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
            resources.ApplyResources(this.fileButton, "fileButton");
            // 
            // newFileButton
            // 
            this.newFileButton.Name = "newFileButton";
            resources.ApplyResources(this.newFileButton, "newFileButton");
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Name = "openFileButton";
            resources.ApplyResources(this.openFileButton, "openFileButton");
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // saveFileSave
            // 
            this.saveFileSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsJPEG,
            this.saveAsBitmap,
            this.saveAsPNG});
            this.saveFileSave.Name = "saveFileSave";
            resources.ApplyResources(this.saveFileSave, "saveFileSave");
            // 
            // saveAsJPEG
            // 
            this.saveAsJPEG.Name = "saveAsJPEG";
            resources.ApplyResources(this.saveAsJPEG, "saveAsJPEG");
            this.saveAsJPEG.Click += new System.EventHandler(this.saveAsJPEG_Click);
            // 
            // saveAsBitmap
            // 
            this.saveAsBitmap.Name = "saveAsBitmap";
            resources.ApplyResources(this.saveAsBitmap, "saveAsBitmap");
            this.saveAsBitmap.Click += new System.EventHandler(this.saveAsBitmap_Click);
            // 
            // saveAsPNG
            // 
            this.saveAsPNG.Name = "saveAsPNG";
            resources.ApplyResources(this.saveAsPNG, "saveAsPNG");
            this.saveAsPNG.Click += new System.EventHandler(this.saveAsPNG_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Name = "optionsButton";
            resources.ApplyResources(this.optionsButton, "optionsButton");
            // 
            // aboutButton
            // 
            this.aboutButton.Name = "aboutButton";
            resources.ApplyResources(this.aboutButton, "aboutButton");
            // 
            // printButton
            // 
            this.printButton.Name = "printButton";
            resources.ApplyResources(this.printButton, "printButton");
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Name = "exitButton";
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // editButton
            // 
            this.editButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.redoButton,
            this.cutButton,
            this.copyButton,
            this.pasteButton,
            this.transformButton,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem});
            this.editButton.Name = "editButton";
            resources.ApplyResources(this.editButton, "editButton");
            // 
            // undoButton
            // 
            this.undoButton.Name = "undoButton";
            resources.ApplyResources(this.undoButton, "undoButton");
            this.undoButton.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoButton
            // 
            this.redoButton.Name = "redoButton";
            resources.ApplyResources(this.redoButton, "redoButton");
            this.redoButton.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // cutButton
            // 
            this.cutButton.Name = "cutButton";
            resources.ApplyResources(this.cutButton, "cutButton");
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Name = "copyButton";
            resources.ApplyResources(this.copyButton, "copyButton");
            this.copyButton.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.Name = "pasteButton";
            resources.ApplyResources(this.pasteButton, "pasteButton");
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // transformButton
            // 
            this.transformButton.Name = "transformButton";
            resources.ApplyResources(this.transformButton, "transformButton");
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            resources.ApplyResources(this.zoomInToolStripMenuItem, "zoomInToolStripMenuItem");
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            resources.ApplyResources(this.zoomOutToolStripMenuItem, "zoomOutToolStripMenuItem");
            // 
            // effectsButton
            // 
            this.effectsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sepiaEffect,
            this.invertEffect,
            this.transparencyToolStripMenuItem,
            this.bWToolStripMenuItem,
            this.hueToolStripMenuItem,
            this.brightnessToolStripMenuItem});
            this.effectsButton.Name = "effectsButton";
            resources.ApplyResources(this.effectsButton, "effectsButton");
            this.effectsButton.Click += new System.EventHandler(this.effectsButton_Click);
            // 
            // sepiaEffect
            // 
            this.sepiaEffect.Name = "sepiaEffect";
            resources.ApplyResources(this.sepiaEffect, "sepiaEffect");
            this.sepiaEffect.Click += new System.EventHandler(this.sepiaEffect_Click);
            // 
            // invertEffect
            // 
            this.invertEffect.Name = "invertEffect";
            resources.ApplyResources(this.invertEffect, "invertEffect");
            this.invertEffect.Click += new System.EventHandler(this.invertEffect_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            this.transparencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseToolStripMenuItem,
            this.decreaseToolStripMenuItem});
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            resources.ApplyResources(this.transparencyToolStripMenuItem, "transparencyToolStripMenuItem");
            // 
            // increaseToolStripMenuItem
            // 
            this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
            resources.ApplyResources(this.increaseToolStripMenuItem, "increaseToolStripMenuItem");
            this.increaseToolStripMenuItem.Click += new System.EventHandler(this.increaseToolStripMenuItem_Click);
            // 
            // decreaseToolStripMenuItem
            // 
            this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
            resources.ApplyResources(this.decreaseToolStripMenuItem, "decreaseToolStripMenuItem");
            this.decreaseToolStripMenuItem.Click += new System.EventHandler(this.decreaseToolStripMenuItem_Click);
            // 
            // bWToolStripMenuItem
            // 
            this.bWToolStripMenuItem.Name = "bWToolStripMenuItem";
            resources.ApplyResources(this.bWToolStripMenuItem, "bWToolStripMenuItem");
            this.bWToolStripMenuItem.Click += new System.EventHandler(this.bWToolStripMenuItem_Click);
            // 
            // hueToolStripMenuItem
            // 
            this.hueToolStripMenuItem.Name = "hueToolStripMenuItem";
            resources.ApplyResources(this.hueToolStripMenuItem, "hueToolStripMenuItem");
            this.hueToolStripMenuItem.Click += new System.EventHandler(this.hueToolStripMenuItem_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseToolStripMenuItem1,
            this.decreaseToolStripMenuItem1});
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            resources.ApplyResources(this.brightnessToolStripMenuItem, "brightnessToolStripMenuItem");
            // 
            // increaseToolStripMenuItem1
            // 
            this.increaseToolStripMenuItem1.Name = "increaseToolStripMenuItem1";
            resources.ApplyResources(this.increaseToolStripMenuItem1, "increaseToolStripMenuItem1");
            this.increaseToolStripMenuItem1.Click += new System.EventHandler(this.increaseToolStripMenuItem1_Click);
            // 
            // decreaseToolStripMenuItem1
            // 
            this.decreaseToolStripMenuItem1.Name = "decreaseToolStripMenuItem1";
            resources.ApplyResources(this.decreaseToolStripMenuItem1, "decreaseToolStripMenuItem1");
            this.decreaseToolStripMenuItem1.Click += new System.EventHandler(this.decreaseToolStripMenuItem1_Click);
            // 
            // toolsButton
            // 
            this.toolsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolButton,
            this.penToolButton,
            this.shapesToolButton,
            this.deselectButton,
            this.moveToolStripMenuItem,
            this.memeToolStripMenuItem,
            this.flipToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.selectColorToolStripMenuItem,
            this.fillColorToolStripMenuItem,
            this.textBoxToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.toolsButton.Name = "toolsButton";
            resources.ApplyResources(this.toolsButton, "toolsButton");
            // 
            // selectToolButton
            // 
            this.selectToolButton.Name = "selectToolButton";
            resources.ApplyResources(this.selectToolButton, "selectToolButton");
            this.selectToolButton.Click += new System.EventHandler(this.selectToolButton_Click);
            // 
            // penToolButton
            // 
            this.penToolButton.Name = "penToolButton";
            resources.ApplyResources(this.penToolButton, "penToolButton");
            this.penToolButton.Click += new System.EventHandler(this.penToolButton_Click);
            // 
            // shapesToolButton
            // 
            this.shapesToolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolButton,
            this.squareToolButton,
            this.lineToolButton,
            this.triangleToolButton});
            this.shapesToolButton.Name = "shapesToolButton";
            resources.ApplyResources(this.shapesToolButton, "shapesToolButton");
            this.shapesToolButton.Click += new System.EventHandler(this.shapesToolButton_Click);
            // 
            // circleToolButton
            // 
            this.circleToolButton.Name = "circleToolButton";
            resources.ApplyResources(this.circleToolButton, "circleToolButton");
            this.circleToolButton.Click += new System.EventHandler(this.circleToolButton_Click);
            // 
            // squareToolButton
            // 
            this.squareToolButton.Name = "squareToolButton";
            resources.ApplyResources(this.squareToolButton, "squareToolButton");
            this.squareToolButton.Click += new System.EventHandler(this.squareToolButton_Click);
            // 
            // lineToolButton
            // 
            this.lineToolButton.Name = "lineToolButton";
            resources.ApplyResources(this.lineToolButton, "lineToolButton");
            this.lineToolButton.Click += new System.EventHandler(this.lineToolButton_Click);
            // 
            // triangleToolButton
            // 
            this.triangleToolButton.Name = "triangleToolButton";
            resources.ApplyResources(this.triangleToolButton, "triangleToolButton");
            this.triangleToolButton.Click += new System.EventHandler(this.triangleToolButton_Click);
            // 
            // deselectButton
            // 
            this.deselectButton.Name = "deselectButton";
            resources.ApplyResources(this.deselectButton, "deselectButton");
            this.deselectButton.Click += new System.EventHandler(this.deselectButton_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            resources.ApplyResources(this.moveToolStripMenuItem, "moveToolStripMenuItem");
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // memeToolStripMenuItem
            // 
            this.memeToolStripMenuItem.Name = "memeToolStripMenuItem";
            resources.ApplyResources(this.memeToolStripMenuItem, "memeToolStripMenuItem");
            this.memeToolStripMenuItem.Click += new System.EventHandler(this.memeToolStripMenuItem_Click);
            // 
            // flipToolStripMenuItem
            // 
            this.flipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
            resources.ApplyResources(this.flipToolStripMenuItem, "flipToolStripMenuItem");
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            resources.ApplyResources(this.verticalToolStripMenuItem, "verticalToolStripMenuItem");
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            resources.ApplyResources(this.horizontalToolStripMenuItem, "horizontalToolStripMenuItem");
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forwardToolStripMenuItem,
            this.backwardToolStripMenuItem});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            resources.ApplyResources(this.rotateToolStripMenuItem, "rotateToolStripMenuItem");
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            resources.ApplyResources(this.forwardToolStripMenuItem, "forwardToolStripMenuItem");
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // backwardToolStripMenuItem
            // 
            this.backwardToolStripMenuItem.Name = "backwardToolStripMenuItem";
            resources.ApplyResources(this.backwardToolStripMenuItem, "backwardToolStripMenuItem");
            this.backwardToolStripMenuItem.Click += new System.EventHandler(this.backwardToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            resources.ApplyResources(this.resizeToolStripMenuItem, "resizeToolStripMenuItem");
            // 
            // selectColorToolStripMenuItem
            // 
            this.selectColorToolStripMenuItem.Name = "selectColorToolStripMenuItem";
            resources.ApplyResources(this.selectColorToolStripMenuItem, "selectColorToolStripMenuItem");
            this.selectColorToolStripMenuItem.Click += new System.EventHandler(this.selectColorToolStripMenuItem_Click);
            // 
            // fillColorToolStripMenuItem
            // 
            this.fillColorToolStripMenuItem.Name = "fillColorToolStripMenuItem";
            resources.ApplyResources(this.fillColorToolStripMenuItem, "fillColorToolStripMenuItem");
            this.fillColorToolStripMenuItem.Click += new System.EventHandler(this.fillColorToolStripMenuItem_Click);
            // 
            // textBoxToolStripMenuItem
            // 
            this.textBoxToolStripMenuItem.Name = "textBoxToolStripMenuItem";
            resources.ApplyResources(this.textBoxToolStripMenuItem, "textBoxToolStripMenuItem");
            this.textBoxToolStripMenuItem.Click += new System.EventHandler(this.textBoxToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectColorToolStripMenuItem1,
            this.fillColorToolStripMenuItem1});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            resources.ApplyResources(this.colorToolStripMenuItem, "colorToolStripMenuItem");
            // 
            // selectColorToolStripMenuItem1
            // 
            this.selectColorToolStripMenuItem1.Name = "selectColorToolStripMenuItem1";
            resources.ApplyResources(this.selectColorToolStripMenuItem1, "selectColorToolStripMenuItem1");
            // 
            // fillColorToolStripMenuItem1
            // 
            this.fillColorToolStripMenuItem1.Name = "fillColorToolStripMenuItem1";
            resources.ApplyResources(this.fillColorToolStripMenuItem1, "fillColorToolStripMenuItem1");
            // 
            // baseCanvas
            // 
            this.baseCanvas.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.baseCanvas, "baseCanvas");
            this.baseCanvas.Name = "baseCanvas";
            this.baseCanvas.TabStop = false;
            this.baseCanvas.Click += new System.EventHandler(this.baseCanvas_Click);
            this.baseCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseCanvas_MouseDown);
            this.baseCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.baseCanvas_MouseMove);
            this.baseCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.baseCanvas_MouseUp);
            // 
            // MousePos
            // 
            resources.ApplyResources(this.MousePos, "MousePos");
            this.MousePos.BackColor = System.Drawing.Color.Transparent;
            this.MousePos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MousePos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MousePos.Name = "MousePos";
            // 
            // BrushSizeBar
            // 
            resources.ApplyResources(this.BrushSizeBar, "BrushSizeBar");
            this.BrushSizeBar.Maximum = 50;
            this.BrushSizeBar.Name = "BrushSizeBar";
            this.BrushSizeBar.TickFrequency = 2;
            this.BrushSizeBar.Scroll += new System.EventHandler(this.BrushSizeBar_Scroll);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // Tabula
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrushSizeBar);
            this.Controls.Add(this.MousePos);
            this.Controls.Add(this.baseCanvas);
            this.Controls.Add(this.topMenuBar);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.MainMenuStrip = this.topMenuBar;
            this.Name = "Tabula";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Tabula_Load);
            this.topMenuBar.ResumeLayout(false);
            this.topMenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrushSizeBar)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem deselectButton;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memeToolStripMenuItem;
        private System.Windows.Forms.Label MousePos;
        private System.Windows.Forms.TrackBar BrushSizeBar;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem decreaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectColorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fillColorToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
    }
}

