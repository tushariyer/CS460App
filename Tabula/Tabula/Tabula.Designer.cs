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
            this.topMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrushSizeBar)).BeginInit();
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
            this.toolsButton});
            this.topMenuBar.Location = new System.Drawing.Point(0, 0);
            this.topMenuBar.Name = "topMenuBar";
            this.topMenuBar.Size = new System.Drawing.Size(1653, 37);
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
            this.newFileButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileButton.Size = new System.Drawing.Size(281, 38);
            this.newFileButton.Text = "New File";
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileButton.Size = new System.Drawing.Size(281, 38);
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
            this.saveFileSave.Size = new System.Drawing.Size(281, 38);
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
            this.optionsButton.Size = new System.Drawing.Size(281, 38);
            this.optionsButton.Text = "Options";
            // 
            // aboutButton
            // 
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(281, 38);
            this.aboutButton.Text = "About";
            // 
            // printButton
            // 
            this.printButton.Name = "printButton";
            this.printButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printButton.Size = new System.Drawing.Size(281, 38);
            this.printButton.Text = "Print";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Name = "exitButton";
            this.exitButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitButton.Size = new System.Drawing.Size(281, 38);
            this.exitButton.Text = "Exit";
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
            this.editButton.Size = new System.Drawing.Size(64, 33);
            this.editButton.Text = "Edit";
            // 
            // undoButton
            // 
            this.undoButton.Name = "undoButton";
            this.undoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoButton.Size = new System.Drawing.Size(282, 38);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoButton
            // 
            this.redoButton.Name = "redoButton";
            this.redoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoButton.Size = new System.Drawing.Size(282, 38);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // cutButton
            // 
            this.cutButton.Name = "cutButton";
            this.cutButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutButton.Size = new System.Drawing.Size(282, 38);
            this.cutButton.Text = "Cut";
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Name = "copyButton";
            this.copyButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyButton.Size = new System.Drawing.Size(282, 38);
            this.copyButton.Text = "Copy";
            this.copyButton.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteButton.Size = new System.Drawing.Size(282, 38);
            this.pasteButton.Text = "Paste";
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // transformButton
            // 
            this.transformButton.Name = "transformButton";
            this.transformButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.transformButton.Size = new System.Drawing.Size(282, 38);
            this.transformButton.Text = "Transform";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
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
            this.effectsButton.Size = new System.Drawing.Size(88, 33);
            this.effectsButton.Text = "Effects";
            // 
            // sepiaEffect
            // 
            this.sepiaEffect.Name = "sepiaEffect";
            this.sepiaEffect.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.sepiaEffect.Size = new System.Drawing.Size(338, 38);
            this.sepiaEffect.Text = "Sepia";
            this.sepiaEffect.Click += new System.EventHandler(this.sepiaEffect_Click);
            // 
            // invertEffect
            // 
            this.invertEffect.Name = "invertEffect";
            this.invertEffect.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.invertEffect.Size = new System.Drawing.Size(338, 38);
            this.invertEffect.Text = "Invert";
            this.invertEffect.Click += new System.EventHandler(this.invertEffect_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            this.transparencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseToolStripMenuItem,
            this.decreaseToolStripMenuItem});
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            this.transparencyToolStripMenuItem.Size = new System.Drawing.Size(338, 38);
            this.transparencyToolStripMenuItem.Text = "Transparency";
            // 
            // increaseToolStripMenuItem
            // 
            this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
            this.increaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D1)));
            this.increaseToolStripMenuItem.Size = new System.Drawing.Size(330, 38);
            this.increaseToolStripMenuItem.Text = "Increase";
            this.increaseToolStripMenuItem.Click += new System.EventHandler(this.increaseToolStripMenuItem_Click);
            // 
            // decreaseToolStripMenuItem
            // 
            this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
            this.decreaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D2)));
            this.decreaseToolStripMenuItem.Size = new System.Drawing.Size(330, 38);
            this.decreaseToolStripMenuItem.Text = "Decrease";
            this.decreaseToolStripMenuItem.Click += new System.EventHandler(this.decreaseToolStripMenuItem_Click);
            // 
            // bWToolStripMenuItem
            // 
            this.bWToolStripMenuItem.Name = "bWToolStripMenuItem";
            this.bWToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.bWToolStripMenuItem.Size = new System.Drawing.Size(338, 38);
            this.bWToolStripMenuItem.Text = "Grayscale";
            this.bWToolStripMenuItem.Click += new System.EventHandler(this.bWToolStripMenuItem_Click);
            // 
            // hueToolStripMenuItem
            // 
            this.hueToolStripMenuItem.Name = "hueToolStripMenuItem";
            this.hueToolStripMenuItem.Size = new System.Drawing.Size(338, 38);
            this.hueToolStripMenuItem.Text = "Hue";
            this.hueToolStripMenuItem.Click += new System.EventHandler(this.hueToolStripMenuItem_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseToolStripMenuItem1,
            this.decreaseToolStripMenuItem1});
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(338, 38);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            // 
            // increaseToolStripMenuItem1
            // 
            this.increaseToolStripMenuItem1.Name = "increaseToolStripMenuItem1";
            this.increaseToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D3)));
            this.increaseToolStripMenuItem1.Size = new System.Drawing.Size(330, 38);
            this.increaseToolStripMenuItem1.Text = "Increase";
            this.increaseToolStripMenuItem1.Click += new System.EventHandler(this.increaseToolStripMenuItem1_Click);
            // 
            // decreaseToolStripMenuItem1
            // 
            this.decreaseToolStripMenuItem1.Name = "decreaseToolStripMenuItem1";
            this.decreaseToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D4)));
            this.decreaseToolStripMenuItem1.Size = new System.Drawing.Size(330, 38);
            this.decreaseToolStripMenuItem1.Text = "Decrease";
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
            this.toolsButton.Size = new System.Drawing.Size(76, 33);
            this.toolsButton.Text = "Tools";
            // 
            // selectToolButton
            // 
            this.selectToolButton.Name = "selectToolButton";
            this.selectToolButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.selectToolButton.Size = new System.Drawing.Size(294, 38);
            this.selectToolButton.Text = "Select";
            this.selectToolButton.Click += new System.EventHandler(this.selectToolButton_Click);
            // 
            // penToolButton
            // 
            this.penToolButton.Name = "penToolButton";
            this.penToolButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.penToolButton.Size = new System.Drawing.Size(294, 38);
            this.penToolButton.Text = "Pen";
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
            this.shapesToolButton.Size = new System.Drawing.Size(294, 38);
            this.shapesToolButton.Text = "Shapes";
            this.shapesToolButton.Click += new System.EventHandler(this.shapesToolButton_Click);
            // 
            // circleToolButton
            // 
            this.circleToolButton.Name = "circleToolButton";
            this.circleToolButton.Size = new System.Drawing.Size(190, 38);
            this.circleToolButton.Text = "Circle";
            this.circleToolButton.Click += new System.EventHandler(this.circleToolButton_Click);
            // 
            // squareToolButton
            // 
            this.squareToolButton.Name = "squareToolButton";
            this.squareToolButton.Size = new System.Drawing.Size(190, 38);
            this.squareToolButton.Text = "Square";
            this.squareToolButton.Click += new System.EventHandler(this.squareToolButton_Click);
            // 
            // lineToolButton
            // 
            this.lineToolButton.Name = "lineToolButton";
            this.lineToolButton.Size = new System.Drawing.Size(190, 38);
            this.lineToolButton.Text = "Line";
            this.lineToolButton.Click += new System.EventHandler(this.lineToolButton_Click);
            // 
            // triangleToolButton
            // 
            this.triangleToolButton.Name = "triangleToolButton";
            this.triangleToolButton.Size = new System.Drawing.Size(190, 38);
            this.triangleToolButton.Text = "Triangle";
            this.triangleToolButton.Click += new System.EventHandler(this.triangleToolButton_Click);
            // 
            // deselectButton
            // 
            this.deselectButton.Name = "deselectButton";
            this.deselectButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.deselectButton.Size = new System.Drawing.Size(294, 38);
            this.deselectButton.Text = "Deselect All";
            this.deselectButton.Click += new System.EventHandler(this.deselectButton_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // memeToolStripMenuItem
            // 
            this.memeToolStripMenuItem.Name = "memeToolStripMenuItem";
            this.memeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.memeToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.memeToolStripMenuItem.Text = "Meme";
            this.memeToolStripMenuItem.Click += new System.EventHandler(this.memeToolStripMenuItem_Click);
            // 
            // flipToolStripMenuItem
            // 
            this.flipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.flipToolStripMenuItem.Name = "flipToolStripMenuItem";
            this.flipToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.flipToolStripMenuItem.Text = "Flip";
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(345, 38);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(345, 38);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forwardToolStripMenuItem,
            this.backwardToolStripMenuItem});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // backwardToolStripMenuItem
            // 
            this.backwardToolStripMenuItem.Name = "backwardToolStripMenuItem";
            this.backwardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.backwardToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.backwardToolStripMenuItem.Text = "Backward";
            this.backwardToolStripMenuItem.Click += new System.EventHandler(this.backwardToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.resizeToolStripMenuItem.Text = "Resize";
            // 
            // selectColorToolStripMenuItem
            // 
            this.selectColorToolStripMenuItem.Name = "selectColorToolStripMenuItem";
            this.selectColorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.selectColorToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.selectColorToolStripMenuItem.Text = "Select Color";
            this.selectColorToolStripMenuItem.Click += new System.EventHandler(this.selectColorToolStripMenuItem_Click);
            // 
            // fillColorToolStripMenuItem
            // 
            this.fillColorToolStripMenuItem.Name = "fillColorToolStripMenuItem";
            this.fillColorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fillColorToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.fillColorToolStripMenuItem.Text = "Fill Color";
            this.fillColorToolStripMenuItem.Click += new System.EventHandler(this.fillColorToolStripMenuItem_Click);
            // 
            // textBoxToolStripMenuItem
            // 
            this.textBoxToolStripMenuItem.Name = "textBoxToolStripMenuItem";
            this.textBoxToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.textBoxToolStripMenuItem.Text = "Text Box";
            this.textBoxToolStripMenuItem.Click += new System.EventHandler(this.textBoxToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectColorToolStripMenuItem1,
            this.fillColorToolStripMenuItem1});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // selectColorToolStripMenuItem1
            // 
            this.selectColorToolStripMenuItem1.Name = "selectColorToolStripMenuItem1";
            this.selectColorToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.selectColorToolStripMenuItem1.Size = new System.Drawing.Size(294, 38);
            this.selectColorToolStripMenuItem1.Text = "Select Color";
            // 
            // fillColorToolStripMenuItem1
            // 
            this.fillColorToolStripMenuItem1.Name = "fillColorToolStripMenuItem1";
            this.fillColorToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fillColorToolStripMenuItem1.Size = new System.Drawing.Size(294, 38);
            this.fillColorToolStripMenuItem1.Text = "Fill Color";
            // 
            // baseCanvas
            // 
            this.baseCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseCanvas.InitialImage = ((System.Drawing.Image)(resources.GetObject("baseCanvas.InitialImage")));
            this.baseCanvas.Location = new System.Drawing.Point(0, 37);
            this.baseCanvas.MaximumSize = new System.Drawing.Size(1653, 992);
            this.baseCanvas.Name = "baseCanvas";
            this.baseCanvas.Size = new System.Drawing.Size(1653, 992);
            this.baseCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.baseCanvas.TabIndex = 1;
            this.baseCanvas.TabStop = false;
            this.baseCanvas.Click += new System.EventHandler(this.baseCanvas_Click);
            this.baseCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.baseCanvas_MouseDown);
            this.baseCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.baseCanvas_MouseMove);
            this.baseCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.baseCanvas_MouseUp);
            // 
            // MousePos
            // 
            this.MousePos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MousePos.AutoSize = true;
            this.MousePos.BackColor = System.Drawing.Color.Transparent;
            this.MousePos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MousePos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MousePos.Location = new System.Drawing.Point(1589, 8);
            this.MousePos.Name = "MousePos";
            this.MousePos.Size = new System.Drawing.Size(64, 26);
            this.MousePos.TabIndex = 2;
            this.MousePos.Text = "label1";
            // 
            // BrushSizeBar
            // 
            this.BrushSizeBar.Location = new System.Drawing.Point(1427, 27);
            this.BrushSizeBar.Maximum = 50;
            this.BrushSizeBar.Name = "BrushSizeBar";
            this.BrushSizeBar.Size = new System.Drawing.Size(226, 90);
            this.BrushSizeBar.TabIndex = 3;
            this.BrushSizeBar.TickFrequency = 2;
            this.BrushSizeBar.Visible = false;
            this.BrushSizeBar.Scroll += new System.EventHandler(this.BrushSizeBar_Scroll);
            // 
            // Tabula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1653, 1029);
            this.Controls.Add(this.BrushSizeBar);
            this.Controls.Add(this.MousePos);
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
    }
}

