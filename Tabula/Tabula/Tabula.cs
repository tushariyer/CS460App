using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/**
 * Enum for usable tools
 */
enum ETools {
    None,
    Select,
    Shapes,
    Pen,
    Move
};
namespace Tabula {
    public partial class Tabula : Form {
        public static Stack<Image> GlobalUndoStack = new Stack<Image>(); //Global Stacks
        public static Stack<Image> GlobalRedoStack = new Stack<Image>();

        private Color selectedColor = Color.Black; //Currently selected color, defaults to black

        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Black, 2); //Global pen tool

        public static int[] BeginningMousePos = { 0, 0 }; //Coordinate variables
        private int[] EndMousePos = { 0, 0 };
        public static int[] CurrentMosusePos = { 0, 0 };
        public int[] BeforeLocation = { 0, 0 };

        public Bitmap CopiedImage; //Temp var for copied image

        public Graphics SelectionArea; //Form Graphic Tools
        private PictureBox SelectLayer = new PictureBox();
        Rectangle SelectRect;

        private ETools CurrentTool; //Current tool/shape selected
        private EShapes shapeSelected;

        private bool bInSelectedRect; //Checking booleans
        public bool bSelected;
        public bool bCanDraw;
        public bool bCanDrawShape;

        /**
         * App Constructor
         **/
        public Tabula() {
            InitializeComponent();
            setFalse();
        }

        private void setFalse() {
            effectsButton.Enabled = false;
            toolsButton.Enabled = false;
            editButton.Enabled = false;
        }

        private void setTrue() {
            effectsButton.Enabled = true;
            toolsButton.Enabled = true;
            editButton.Enabled = true;
        }

        /**--------------------------
         * File operations start here
         ---------------------------*/
        private void defaultSelect() {
            try {
                SelectRect = new Rectangle(0, 0, baseCanvas.Image.Width, baseCanvas.Image.Height);
            }
            catch (NullReferenceException) {

            }
        }

        /**
         * New File Button
         */
        private void newFileButton_Click(object sender, EventArgs e) {
            if (baseCanvas.Image != null) {
                savePrevImage();
                DialogResult check = MessageBox.Show("Do you want to save?", "Warning!", MessageBoxButtons.YesNo);
                if (check == DialogResult.Yes) {
                    saveAsPNG_Click(sender, e);
                }
                else if (check == DialogResult.No) {
                    NewCreation newBlank = new NewCreation(baseCanvas);
                    defaultSelect();
                    baseCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
                    baseCanvas.Refresh();
                    setTrue();
                }
            }
            else {
                NewCreation newBlank = new NewCreation(baseCanvas);
                defaultSelect();
                baseCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
                baseCanvas.Refresh();
                setTrue();
            }
        }

        /**
         * File Import Object created here. Redirects to Open.cs
         */
        private void openFileButton_Click(object sender, EventArgs e) {
            if (baseCanvas.Image != null) {
                savePrevImage();
                DialogResult check = MessageBox.Show("Do you want to save?", "Warning!", MessageBoxButtons.YesNo);
                if (check == DialogResult.Yes) {
                    saveAsPNG_Click(sender, e);
                }
                else if (check == DialogResult.No) {
                    Open newPic = new Open(); //Create new Open Object
                    baseCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
                    baseCanvas.Refresh();
                    newPic.importImage(baseCanvas); //Use the importImage method to assign a picture to the PictureBox
                    defaultSelect();
                    setTrue();
                }
            }
            else {
                Open newPic = new Open(); //Create new Open Object
                baseCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
                baseCanvas.Refresh();
                newPic.importImage(baseCanvas); //Use the importImage method to assign a picture to the PictureBox
                defaultSelect();
                setTrue();
            }
        }

        /**
         * Print Button
         */
        private void printButton_Click(object sender, EventArgs e) {
            Print printer = new Print(baseCanvas.Image);
        }

        /**
         * Click on Quit
         */
        private void exitButton_Click(object sender, EventArgs e) {
            if (baseCanvas.Image != null) {
                savePrevImage();
                DialogResult check = MessageBox.Show("Do you want to save?", "Warning!", MessageBoxButtons.YesNo);
                if (check == DialogResult.Yes) {
                    saveAsPNG_Click(sender, e);
                }
                else if (check == DialogResult.No) {
                    QuitApp die = new QuitApp();
                    die.beginQuit(baseCanvas);
                }
            }
            else {
                QuitApp die = new QuitApp();
                die.beginQuit(baseCanvas);
            }
        }

        /**-----------------------
         * Save methods start here
         -----------------------*/

        /**
         * Save File as JPEG
         */
        private void saveAsJPEG_Click(object sender, EventArgs e) {
            if (baseCanvas.Image != null) {
                SavePicture jpeg = new SavePicture(); //New SavePicture Object
                jpeg.saveJpeg(baseCanvas.Image);
            }
            else {
                MessageBox.Show("There's nothing to save.");
            }
        }

        /**
         * Save File as Bitmap
         */
        private void saveAsBitmap_Click(object sender, EventArgs e) {
            if (baseCanvas.Image != null) {
                SavePicture bmp = new SavePicture(); //New SavePicture Object
                bmp.saveBitmap(baseCanvas.Image);
            }
            else {
                MessageBox.Show("There's nothing to save.");
            }
        }

        /**
         * Save File as PNG
         */
        private void saveAsPNG_Click(object sender, EventArgs e) {
            if (baseCanvas.Image != null) {
                SavePicture png = new SavePicture(); //New SavePicture Object
                png.savePng(baseCanvas.Image);
            }
            else {
                MessageBox.Show("There's nothing to save.");
            }

        }

        /**-----------------------
         * Edit methods start here
         -----------------------*/

        /**
         * Cut
         */
        public void CutImage() {
            if (baseCanvas.Image != null) {
                CropImage();
                if (SelectRect.Width < 0 && SelectRect.Height < 0) { //Bottom-Right to Top-Left
                    using (Graphics g = Graphics.FromImage(baseCanvas.Image)) {
                        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(SelectRect.Right, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else if (SelectRect.Width >= 0 && SelectRect.Height >= 0) {  //Top-Left to Bottom-Right
                    using (Graphics g = Graphics.FromImage(baseCanvas.Image)) {
                        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(SelectRect.Left, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else if (SelectRect.Width < 0 && SelectRect.Height >= 0) { //Top-Right to Bottom-Left
                    using (Graphics g = Graphics.FromImage(baseCanvas.Image)) {
                        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(SelectRect.Right, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else { //Bottom-Left - Top-Right
                    using (Graphics g = Graphics.FromImage(baseCanvas.Image)) {
                        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(SelectRect.Left, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                baseCanvas.Refresh();
            }
            else {
                MessageBox.Show("Nothing to Cut!");
            }
        }

        /**
         * Copy
         */
        public void CropImage() {
            if (baseCanvas.Image != null) {
                savePrevImage();
                Bitmap bmp = (Bitmap)baseCanvas.Image.Clone();
                if (SelectRect.Width < 0 && SelectRect.Height < 0) { //Bottom-Right to Top-Left
                    CopiedImage = bmp.Clone(new Rectangle(SelectRect.Right, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)), bmp.PixelFormat);
                }
                else if (SelectRect.Width >= 0 && SelectRect.Height >= 0) { //Top-Left to Bottom-Right
                    CopiedImage = bmp.Clone(new Rectangle(SelectRect.Left, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)), bmp.PixelFormat);
                }
                else if (SelectRect.Width < 0 && SelectRect.Height >= 0) { //Top-Right to Bottom-Left
                    CopiedImage = bmp.Clone(new Rectangle(SelectRect.Right, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)), bmp.PixelFormat);
                }
                else { //Bottom-Left to Top-Right
                    CopiedImage = bmp.Clone(new Rectangle(SelectRect.Left, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)), bmp.PixelFormat);
                }
            }
            else {
                MessageBox.Show("Nothing to Copy!");
            }
        }

        /**
         * Paste
         */
        public void Paste(Bitmap ImageToPaste, Image SourceImage) {
            if (baseCanvas.Image != null) {
                savePrevImage();
                if (SelectRect.Width < 0 && SelectRect.Height < 0) { //Bottom-Right to Top-Left
                    using (Graphics g = Graphics.FromImage(SourceImage)) {
                        g.DrawImage(ImageToPaste, new Rectangle(SelectRect.Right, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else if (SelectRect.Width >= 0 && SelectRect.Height >= 0) {  //Top-Left to Bottom-Right
                    using (Graphics g = Graphics.FromImage(SourceImage)) {
                        g.DrawImage(ImageToPaste, new Rectangle(SelectRect.Left, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else if (SelectRect.Width < 0 && SelectRect.Height >= 0) { //Top-Right to Bottom-Left
                    using (Graphics g = Graphics.FromImage(SourceImage)) {
                        g.DrawImage(ImageToPaste, new Rectangle(SelectRect.Right, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else { //Bottom-Left - Top-Right
                    using (Graphics g = Graphics.FromImage(SourceImage)) {
                        g.DrawImage(ImageToPaste, new Rectangle(SelectRect.Left, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                baseCanvas.Refresh();
            }
            else {
                MessageBox.Show("Nothing to Paste!");
            }
        }

        /**
         * Paste [Overloaded]
         */
        public void Paste(Bitmap ImageToPaste, Image SourceImage, int X, int Y) {
            if (baseCanvas.Image != null) {
                savePrevImage();
                if (SelectRect.Width < 0 && SelectRect.Height < 0) { //Bottom-Right to Top-Left
                    using (Graphics g = Graphics.FromImage(SourceImage)) {
                        g.DrawImage(ImageToPaste, new Rectangle(X, Y, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else if (SelectRect.Width >= 0 && SelectRect.Height >= 0) {  //Top-Left to Bottom-Right
                    using (Graphics g = Graphics.FromImage(SourceImage)) {
                        g.DrawImage(ImageToPaste, new Rectangle(X, Y, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else if (SelectRect.Width < 0 && SelectRect.Height >= 0) { //Top-Right to Bottom-Left
                    using (Graphics g = Graphics.FromImage(SourceImage)) {
                        g.DrawImage(ImageToPaste, new Rectangle(X, Y, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                else { //Bottom-Left - Top-Right
                    using (Graphics g = Graphics.FromImage(SourceImage)) {
                        g.DrawImage(ImageToPaste, new Rectangle(X, Y, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                    }
                }
                baseCanvas.Refresh();
            }
            else {
                MessageBox.Show("Nothing to Paste!");
            }
        }

        /**
         * Button for Undo
         */
        private void undoToolStripMenuItem_Click(object sender, EventArgs e) {
            if (GlobalUndoStack.Count == 0) {
                MessageBox.Show("There's nothing to undo.");
            }
            else {
                GlobalRedoStack.Push((Image)baseCanvas.Image.Clone());
                baseCanvas.Image = GlobalUndoStack.Pop();
            }
        }

        /**
         * Redo Button
         */
        private void redoToolStripMenuItem_Click(object sender, EventArgs e) {
            if (GlobalRedoStack.Count == 0) {
                MessageBox.Show("There's nothing to redo.");
            }
            else {
                GlobalUndoStack.Push((Image)baseCanvas.Image.Clone());
                baseCanvas.Image = GlobalRedoStack.Pop();
            }
        }

        /**
         * Click on Cut
         */
        private void cutButton_Click(object sender, EventArgs e) {
            CutImage();
        }

        /**
         * Click on Copy
         */
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            CropImage();
        }

        /**
         * Click on Paste
         */
        private void pasteButton_Click(object sender, EventArgs e) {
            Paste(CopiedImage, baseCanvas.Image);
        }

        /**
         * BrushSizeBar methods
         */
        private void BrushSizeBar_Scroll(object sender, EventArgs e) { }

        /**
         * Zoom in
         */
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e) {
            Zoom zoo = new Zoom();
            Paste((Bitmap)zoo.Scale(baseCanvas.Image, new Rectangle(SelectRect.Left, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height))), baseCanvas.Image);
        }

        /**
         * Save Previous Image
         * Use this whenever a tool is called to make sure the undo stack always gets updated
         */
        private void savePrevImage() {
            if (baseCanvas.Image == null) {

            }
            else {
                GlobalUndoStack.Push((Image)baseCanvas.Image.Clone());
            }
        }

        /**-----------------------
         * Canvas methods start here
         -----------------------*/

        /**
         * Canvas Click Method should do nothing
         */
        private void baseCanvas_Click(object sender, EventArgs e) { }

        /**
         * Canvas Click and hold Button
         */
        private void baseCanvas_MouseDown(object sender, MouseEventArgs e) {
            BeginningMousePos[0] = e.Location.X;
            BeginningMousePos[1] = e.Location.Y;
            switch (CurrentTool) {
                case (ETools.Select):
                    bSelected = true;
                    break;
                case (ETools.Pen):
                    bCanDraw = true;
                    savePrevImage();
                    break;
                case (ETools.Shapes):
                    bCanDrawShape = true;
                    break;
                case (ETools.Move):
                    if (SelectRect.Contains(new Point(e.X, e.Y))) {
                        bInSelectedRect = true;
                        Cursor.Position = new Point(e.X, e.Y); //sets the mouse position to the "origin" of the selected rectangle
                    }
                    else {
                        bInSelectedRect = false;
                    }
                    break;
                default:
                    break;
            }
        }

        /**
         * Canvas release-click Button
         */
        private void baseCanvas_MouseUp(object sender, MouseEventArgs e) {
            EndMousePos[0] = e.Location.X;
            EndMousePos[1] = e.Location.Y;

            if (bSelected) {
                bSelected = false;
                DrawSelectArea(e.X, e.Y);
            }

            if (bCanDraw) {
                bCanDraw = false;
            }
            if (CurrentTool == ETools.Move) {

                CutImage(); //Copied the selected image to the "clipboard"

                //undoToolStripMenuItem_Click(sender, e);
                Paste(CopiedImage, baseCanvas.Image, e.X, e.Y); //set the current copied image to the mouse position.
                SelectRect.Location = new Point(e.X, e.Y);

                CurrentTool = ETools.None; //clear the tool to stop the constant repasting.
                //SelectRect = new Rectangle(0, 0, 0, 0);
            }
            else if (CurrentTool == ETools.None) {
                defaultSelect();
            }
            else if (CurrentTool == ETools.Shapes) {
                savePrevImage();
                bCanDrawShape = false;
                switch (shapeSelected) {
                    case (EShapes.Line):
                        Equations.DrawLine(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, false);
                        break;
                    case (EShapes.Circle):
                        Equations.DrawCircle(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, false);
                        break;
                    case (EShapes.Square):
                        Equations.DrawSquare(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, false);
                        break;
                    case (EShapes.Triangle):
                        Equations.DrawTriangle(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, false);
                        break;
                    default:
                        break;
                }
            }
        }

        /**
         * Canvas drag Button
         */
        private void baseCanvas_MouseMove(object sender, MouseEventArgs e) {
            MousePos.Text = e.X + ", " + e.Y; //mouse cords indicator on the screen

            CurrentMosusePos[0] = e.X;
            CurrentMosusePos[1] = e.Y;

            if (bSelected) {
                DrawSelectArea(e.X, e.Y);
                baseCanvas.Invalidate();
            }
            if (bCanDrawShape) {
                switch (shapeSelected) {
                    case (EShapes.Line):
                        Equations.DrawLine(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, true);
                        break;
                    case (EShapes.Circle):
                        Equations.DrawCircle(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, true);
                        break;
                    case (EShapes.Square):
                        DrawSelectArea(e.X, e.Y);
                        //Equations.DrawSquare(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, true);
                        baseCanvas.Invalidate();
                        SelectRect = new Rectangle(0, 0, 0, 0);
                        break;
                    case (EShapes.Triangle):
                        Equations.DrawTriangle(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, true);
                        break;
                    default:
                        break;
                }
            }

            if (bCanDraw) {
                Pen p = new Pen(selectedColor);
                p.Draw(BeforeLocation, e.X, e.Y, BrushSizeBar.Value, baseCanvas, baseCanvas.Image);
            }

            if (bInSelectedRect && CurrentTool == ETools.Move) {
                TranslateMedia TempMoving = new TranslateMedia(); //create a moving object
                TempMoving.Move(baseCanvas, SelectRect, pen, e.X, e.Y); //move the object based on the mouse
                baseCanvas.Invalidate(); //clear the base can
            }
            //if (CurrentTool != ETools.None) {

            //}
            BeforeLocation[0] = e.X;
            BeforeLocation[1] = e.Y;
        }

        /**-----------------------
         * Shape methods start here
         -----------------------*/

        /**
         * Click on Shapes
         */
        private void shapesToolButton_Click(object sender, EventArgs e) {
            if (baseCanvas == null) {
                MessageBox.Show("Load a canvas.");
            }
            if (SelectRect == null) {
                defaultSelect();
            }
            switch (shapeSelected) {
                case (EShapes.Line):
                    CurrentTool = ETools.Shapes;
                    BrushSizeBar.Visible = false; //Hide the bar if its not in use
                    break;
                case (EShapes.Circle):
                    break;
            }
        }

        /**
         * Click on Line
         */
        private void lineToolButton_Click(object sender, EventArgs e) {
            if (SelectRect == null) {
                defaultSelect();
            }
            if (baseCanvas.Image != null) {
                CurrentTool = ETools.Shapes;
                shapeSelected = EShapes.Line;
                BrushSizeBar.Visible = false; //Hide the bar if its not in use
            }
            else {
                MessageBox.Show("No Canvas to draw upon.");
            }
        }

        /**
         * Click on Circle
         */
        private void circleToolButton_Click(object sender, EventArgs e) {
            if (SelectRect == null) {
                defaultSelect();
            }
            if (baseCanvas.Image != null) {
                CurrentTool = ETools.Shapes;
                shapeSelected = EShapes.Circle;
                BrushSizeBar.Visible = false; //Hide the bar if its not in use
            }
            else {
                MessageBox.Show("No Canvas to draw upon.");
            }
        }

        /**
         * Shape - Square
         */
        private void squareToolButton_Click(object sender, EventArgs e) {
            if (SelectRect == null) {
                defaultSelect();
            }
            if (baseCanvas.Image != null) {
                CurrentTool = ETools.Shapes;
                shapeSelected = EShapes.Square;
                BrushSizeBar.Visible = false; //Hide the bar if its not in use
            }
            else {
                MessageBox.Show("No Canvas to draw upon.");
            }
        }

        /**
         * Shape - Triangle
         */
        private void triangleToolButton_Click(object sender, EventArgs e) {
            if (SelectRect == null) {
                defaultSelect();
            }
            if (baseCanvas.Image != null) {
                CurrentTool = ETools.Shapes;
                shapeSelected = EShapes.Triangle;
                BrushSizeBar.Visible = false; //Hide the bar if its not in use
            }
            else {
                MessageBox.Show("No Canvas to draw upon.");
            }
        }

        /**-----------------------
         * Image effects start here
         -----------------------*/

        /**
         * Inverse
         */
        private void invertEffect_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects inv = new ImageEffects(baseCanvas);
            inv.useInverse(SelectRect);
        }

        /**
         * Flip Vertically
         */
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects flipV = new ImageEffects(baseCanvas);
            flipV.useFlip(SelectRect, "Y");
        }

        /**
         * Flip Horizontally
         */
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects flipH = new ImageEffects(baseCanvas);
            flipH.useFlip(SelectRect, "X");
        }

        /**
         * Increase Transparency
         */
        private void increaseToolStripMenuItem_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects seeThru = new ImageEffects(baseCanvas);
            seeThru.lessOpaque(SelectRect);
        }

        /**
         * Decrease Transparency
         */
        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects seeThru = new ImageEffects(baseCanvas);
            seeThru.moreOpaque(SelectRect);
        }

        /**
         * Click on Sepia
         */
        private void sepiaEffect_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects sepia = new ImageEffects(baseCanvas);
            sepia.useSepia(SelectRect);
        }

        /**
         * Effect - Black & White
         */
        private void bWToolStripMenuItem_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects bw = new ImageEffects(baseCanvas);
            bw.useBW(SelectRect);
        }

        /**
         * Effect - Hue
         */
        private void hueToolStripMenuItem_Click(object sender, EventArgs e) {
            savePrevImage();
            selectColorToolStripMenuItem_Click(sender, e);
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects hue = new ImageEffects(baseCanvas);
            hue.useHue(SelectRect, selectedColor);
        }

        /**
         * Effect - Increase Brightness
         */
        private void increaseToolStripMenuItem1_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects brightUp = new ImageEffects(baseCanvas);
            brightUp.useBright("up", SelectRect);
        }

        /**
         * Effect - Decrease Brightness
         */
        private void decreaseToolStripMenuItem1_Click(object sender, EventArgs e) {
            savePrevImage();
            if (SelectRect == null) {
                defaultSelect();
            }
            ImageEffects brightUp = new ImageEffects(baseCanvas);
            brightUp.useBright("down", SelectRect);
        }

        /**-----------------------
         * Tool methods start here
         -----------------------*/

        /**
         * TextBox Tool
         */
        private void textBoxToolStripMenuItem_Click(object sender, EventArgs e) {
            TextInput.placeText(baseCanvas, SelectRect);
        }

        /**
         * Fill Color
         */
        private void fillColorToolStripMenuItem_Click(object sender, EventArgs e) {
            selectColorToolStripMenuItem_Click(sender, e);
            savePrevImage();

            ImageEffects phil = new ImageEffects(baseCanvas);

            phil.useFill(SelectRect, selectedColor);
        }

        /**
         * Click on Move
         */
        private void moveToolStripMenuItem_Click(object sender, EventArgs e) {
            CurrentTool = ETools.Move;
            BrushSizeBar.Visible = false; //Hide the bar if its not in use
        }

        /**
         * Click on Meme
         */
        private void memeToolStripMenuItem_Click(object sender, EventArgs e) {
            savePrevImage();
            Meme meme = new Meme(baseCanvas);
        }

        /**
         * Draw Tool Button
         */
        private void DrawSelectArea(int X, int Y) {
            int[] CurrentPos = { X, Y };
            using (SelectionArea = this.baseCanvas.CreateGraphics()) {
                if (CurrentPos[0] > BeginningMousePos[0] && CurrentPos[1] > BeginningMousePos[1]) {  //Quadrant [+ -]
                    SelectRect = new Rectangle(CurrentPos[0], BeginningMousePos[1], BeginningMousePos[0] - CurrentPos[0], CurrentPos[1] - BeginningMousePos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
                else if (CurrentPos[0] < BeginningMousePos[0] && CurrentPos[1] < BeginningMousePos[1]) {  //Quadrant [- +]
                    SelectRect = new Rectangle(CurrentPos[0], CurrentPos[1], BeginningMousePos[0] - CurrentPos[0], BeginningMousePos[1] - CurrentPos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
                else if (CurrentPos[0] > BeginningMousePos[0] && CurrentPos[1] < BeginningMousePos[1]) {  //Quadrant [+ +]
                    SelectRect = new Rectangle(BeginningMousePos[0], CurrentPos[1], CurrentPos[0] - BeginningMousePos[0], BeginningMousePos[1] - CurrentPos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
                else {  //Quadrant [- -]
                    SelectRect = new Rectangle(CurrentPos[0], BeginningMousePos[1], BeginningMousePos[0] - CurrentPos[0], CurrentPos[1] - BeginningMousePos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
                SelectRect = new Rectangle(BeginningMousePos[0], BeginningMousePos[1], CurrentPos[0] - BeginningMousePos[0], CurrentPos[1] - BeginningMousePos[1]);
                SelectionArea.DrawRectangle(pen, SelectRect);
            }
        }

        /**
         * Click on Pen
         */
        private void penToolButton_Click(object sender, EventArgs e) {
            if (baseCanvas.Image == null) {
                MessageBox.Show("Cannot write on an empty canvas.");
            }
            else {
                selectColorToolStripMenuItem_Click(sender, e);
                CurrentTool = ETools.Pen;
                BrushSizeBar.Visible = true;
            }
        }

        /**
         * Click on Deselect
         */
        private void deselectButton_Click(object sender, EventArgs e) {
            defaultSelect();
            CurrentTool = ETools.None; //No tool selected
            BrushSizeBar.Visible = false; //Hide the bar if its not in use
        }

        /**
         * Select Button
         */
        private void selectToolButton_Click(object sender, EventArgs e) {
            CurrentTool = ETools.Select;
        }

        /**
         * Set Mouse Position
         */
        public void SetMousePoss(int[] DesiredArray, int x, int y) {
            DesiredArray[0] = x;
            DesiredArray[1] = y;
        }

        /**
         * Rotate Tool
         */
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e) { } //Should now call the methods based on the arrow keys. Don't delete this methos

        /**
         * Rotate Forward
         */
        private void forwardToolStripMenuItem_Click(object sender, EventArgs e) {
            ImageEffects rotator = new ImageEffects(baseCanvas);
            rotator.rotatePrep(SelectRect, selectedColor, 5.0f);
        }

        /**
         * Rotate Backward
         */
        private void backwardToolStripMenuItem_Click(object sender, EventArgs e) {
            ImageEffects rotator = new ImageEffects(baseCanvas);
            rotator.rotatePrep(SelectRect, selectedColor, -5.0f);
        }

        /**
         * Colour button.
         * Passes the ColorDialog from the form to ColorSelector so it can allow the user to choose. Stores the value in selectedColor. Other methods can use it.
         */
        private void selectColorToolStripMenuItem_Click(object sender, EventArgs e) {
            ColorSelector colorGrid = new ColorSelector();
            selectedColor = colorGrid.displayShades(availableColors);
        }

        private void effectsButton_Click(object sender, EventArgs e) {
            //Keep empty
        }

        private void Tabula_Load(object sender, EventArgs e) {

        }
    }
}