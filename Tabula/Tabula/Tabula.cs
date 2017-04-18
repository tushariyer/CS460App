using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

enum ETools
{
    None,
    Select,
    Shapes,
    Pen,
    Move
};
namespace Tabula
{
    public partial class Tabula : Form
    {
        //Global Stacks
        public static Stack<Image> GlobalUndoStack = new Stack<Image>();
        public static Stack<Image> GlobalRedoStack = new Stack<Image>();

        //Colour currently selected
        private Color selectedColor = Color.Black; //Default Colour

        //Global pen tool
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Black, 2); //Default pen tool for all

        //Coordinate variables
        public static int[] BeginningMousePos = { 0, 0 };
        private int[] EndMousePos = { 0, 0 };
        public static int[] CurrentMosusePos = { 0, 0 };
        public int[] BeforeLocation = { 0, 0 };

        //Temp var for copied image
        public Bitmap CopiedImage;
        
        //Form Graphic Tools
        public Graphics SelectionArea;
        private PictureBox SelectLayer = new PictureBox();
        Rectangle SelectRect;

        //Current tool/shape selected
        private ETools CurrentTool;
        private EShapes shapeSelected;

        //Checking booleans
        private bool bInSelectedRect;
        public bool bSelected;
        public bool bCanDraw;

        /**
         * App Constructor
         **/
        public Tabula()
        {
            InitializeComponent();
        }

        /**--------------------------
         * File operations start here
         ---------------------------*/
           
        /**
         * New File Button
         */
        private void newFileButton_Click(object sender, EventArgs e)
        {
            if (baseCanvas.Image != null)
            {
                savePrevImage();
                NewCreation newBlank = new NewCreation(baseCanvas);
            }
            else
            {
                NewCreation newBlank = new NewCreation(baseCanvas);
            }
        }
        
        /**
         * File Import Object created here. Redirects to Open.cs
         */
        private void openFileButton_Click(object sender, EventArgs e)
        {
            Open newPic = new Open(); //Create new Open Object
            baseCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
            baseCanvas.Refresh();
            newPic.importImage(baseCanvas); //Use the importImage method to assign a picture to the PictureBox
        }

        /**
         * Print Button
         */
        private void printButton_Click(object sender, EventArgs e)
        {
            Print printer = new Print(baseCanvas.Image);
        }

        /**
         * Click on Quit
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            QuitApp die = new QuitApp();
            die.beginQuit(baseCanvas);
        }

        /**-----------------------
         * Save methods start here
         -----------------------*/

        /**
         * Save File as JPEG
         */
        private void saveAsJPEG_Click(object sender, EventArgs e)
        {
            SavePicture jpeg = new SavePicture(); //New SavePicture Object
            jpeg.saveJpeg(baseCanvas.Image);
        }
        /**
         * Save File as Bitmap
         */
        private void saveAsBitmap_Click(object sender, EventArgs e)
        {
            SavePicture bmp = new SavePicture(); //New SavePicture Object
            bmp.saveBitmap(baseCanvas.Image);
        }

        /**
         * Save File as PNG
         */
        private void saveAsPNG_Click(object sender, EventArgs e)
        {
            SavePicture png = new SavePicture(); //New SavePicture Object
            png.savePng(baseCanvas.Image);
        }

        /**-----------------------
         * Edit methods start here
         -----------------------*/

        /**
         * Cut
         */
        public void CutImage()
        {
            CropImage();
            if (SelectRect.Width < 0 && SelectRect.Height < 0) //Bottom-Right to Top-Left
            {
                using (Graphics g = Graphics.FromImage(baseCanvas.Image))
                {
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(SelectRect.Right, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else if (SelectRect.Width >= 0 && SelectRect.Height >= 0)  //Top-Left to Bottom-Right
            {
                using (Graphics g = Graphics.FromImage(baseCanvas.Image))
                {
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(SelectRect.Left, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else if (SelectRect.Width < 0 && SelectRect.Height >= 0) //Top-Right to Bottom-Left
            {
                using (Graphics g = Graphics.FromImage(baseCanvas.Image))
                {
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(SelectRect.Right, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else //Bottom-Left - Top-Right
            {
                using (Graphics g = Graphics.FromImage(baseCanvas.Image))
                {
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(SelectRect.Left, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            baseCanvas.Refresh();
        }
        
        /**
         * Copy
         */
        public void CropImage()
        {
            savePrevImage();
            Bitmap bmp = (Bitmap)baseCanvas.Image.Clone();
            if (SelectRect.Width < 0 && SelectRect.Height < 0) //Bottom-Right to Top-Left
            {
                CopiedImage = bmp.Clone(new Rectangle(SelectRect.Right, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)), bmp.PixelFormat);
            }
            else if (SelectRect.Width >= 0 && SelectRect.Height >= 0) //Top-Left to Bottom-Right
            {
                CopiedImage = bmp.Clone(new Rectangle(SelectRect.Left, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)), bmp.PixelFormat);
            }
            else if (SelectRect.Width < 0 && SelectRect.Height >= 0) //Top-Right to Bottom-Left
            {
                CopiedImage = bmp.Clone(new Rectangle(SelectRect.Right, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)), bmp.PixelFormat);
            }
            else //Bottom-Left to Top-Right
            {
                CopiedImage = bmp.Clone(new Rectangle(SelectRect.Left, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)), bmp.PixelFormat);
            }

            //using (Form form = new Form())
            //{
            //    form.StartPosition = FormStartPosition.CenterScreen;
            //    form.Size = CopiedImage.Size;
            //    PictureBox pb = new PictureBox();
            //    pb.Dock = DockStyle.Fill;
            //    pb.Image = CopiedImage;
            //    form.Controls.Add(pb);
            //    form.ShowDialog();
            //}
        }
        
        /**
         * Paste
         */
        public void Paste(Bitmap ImageToPaste, Image SourceImage)
        {
            savePrevImage();
            if (SelectRect.Width < 0 && SelectRect.Height < 0) //Bottom-Right to Top-Left
            {
                using (Graphics g = Graphics.FromImage(SourceImage))
                {
                    g.DrawImage(ImageToPaste, new Rectangle(SelectRect.Right, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else if (SelectRect.Width >= 0 && SelectRect.Height >= 0)  //Top-Left to Bottom-Right
            {
                using (Graphics g = Graphics.FromImage(SourceImage))
                {
                    g.DrawImage(ImageToPaste, new Rectangle(SelectRect.Left, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else if (SelectRect.Width < 0 && SelectRect.Height >= 0) //Top-Right to Bottom-Left
            {
                using (Graphics g = Graphics.FromImage(SourceImage))
                {
                    g.DrawImage(ImageToPaste, new Rectangle(SelectRect.Right, SelectRect.Top, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else //Bottom-Left - Top-Right
            {
                using (Graphics g = Graphics.FromImage(SourceImage))
                {
                    g.DrawImage(ImageToPaste, new Rectangle(SelectRect.Left, SelectRect.Bottom, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            baseCanvas.Refresh();
        }

        /**
         * Paste [Overloaded]
         */
        public void Paste(Bitmap ImageToPaste, Image SourceImage, int X, int Y)
        {
            savePrevImage();
            //using (Graphics g = Graphics.FromImage(SourceImage))
            //{
            //    g.DrawImage(ImageToPaste, new Rectangle(X, Y, SelectRect.Width, SelectRect.Height));
            //}

            //----
            if (SelectRect.Width < 0 && SelectRect.Height < 0) //Bottom-Right to Top-Left
            {
                using (Graphics g = Graphics.FromImage(SourceImage))
                {
                    g.DrawImage(ImageToPaste, new Rectangle(X, Y, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else if (SelectRect.Width >= 0 && SelectRect.Height >= 0)  //Top-Left to Bottom-Right
            {
                using (Graphics g = Graphics.FromImage(SourceImage))
                {
                    g.DrawImage(ImageToPaste, new Rectangle(X, Y, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else if (SelectRect.Width < 0 && SelectRect.Height >= 0) //Top-Right to Bottom-Left
            {
                using (Graphics g = Graphics.FromImage(SourceImage))
                {
                    g.DrawImage(ImageToPaste, new Rectangle(X, Y, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            else //Bottom-Left - Top-Right
            {
                using (Graphics g = Graphics.FromImage(SourceImage))
                {
                    g.DrawImage(ImageToPaste, new Rectangle(X, Y, Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height)));
                }
            }
            baseCanvas.Refresh();
        }

        /**
         * Button for Undo
         */
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUndoStack.Count == 0)
            {
                MessageBox.Show("There's nothing to undo.");
            }
            else
            {
                GlobalRedoStack.Push((Image)baseCanvas.Image.Clone());
                baseCanvas.Image = GlobalUndoStack.Pop();
            }
        }

        /**
         * Redo Button
         */
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalRedoStack.Count == 0)
            {
                MessageBox.Show("There's nothing to redo.");
            }
            else
            {
                GlobalUndoStack.Push((Image)baseCanvas.Image.Clone());
                baseCanvas.Image = GlobalRedoStack.Pop();
            }
        }

        /**
         * Click on Cut
         */
        private void cutButton_Click(object sender, EventArgs e)
        {
            CutImage();
        }

        /**
         * Click on Copy
         */
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CropImage();
        }

        /**
         * Click on Paste
         */
        private void pasteButton_Click(object sender, EventArgs e)
        {
            Paste(CopiedImage, baseCanvas.Image);
        }
        
        /**
         * BrushSizeBar methods
         */
        private void BrushSizeBar_Scroll(object sender, EventArgs e) { }

        /**
         * Zoom in
         */
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom zoo = new Zoom();
            Paste((Bitmap)zoo.Scale(baseCanvas, new Rectangle(0, 0, 50, 50)), baseCanvas.Image);
        }


        /**
         * Save Previous Image
         * Use this whenever a tool is called to make sure the undo stack always gets updated
         */
        private void savePrevImage()
        {
            if (baseCanvas.Image == null)
            {
                
            }
            else
            {
                GlobalUndoStack.Push((Image)baseCanvas.Image.Clone());
            }
        }

        /**-----------------------
         * Canvas methods start here
         -----------------------*/

        /**
         * Canvas Click Method should do nothing
         */
        private void baseCanvas_Click(object sender, EventArgs e){}
        
        /**
         * Canvas Click and hold Button
         */
        private void baseCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            BeginningMousePos[0] = e.Location.X;
            BeginningMousePos[1] = e.Location.Y;
            switch (CurrentTool)
            {
                case (ETools.Select):
                    bSelected = true;
                    break;
                case (ETools.Pen):
                    bCanDraw = true;
                    break;
                case (ETools.Move):
                    if (SelectRect.Contains(new Point(e.X, e.Y)))
                    {
                        bInSelectedRect = true;
                        //sets the mouse position to the "origin" of the selected rectangle
                        Cursor.Position = new Point(e.X, e.Y);
                    }
                    else
                    {
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
        private void baseCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            EndMousePos[0] = e.Location.X;
            EndMousePos[1] = e.Location.Y;

            if (bSelected)
            {
                bSelected = false;
                DrawSelectArea(e.X, e.Y);
            }

            if (bCanDraw)
            {
                bCanDraw = false;
            }
            if (CurrentTool == ETools.Move)
            {
                //Copied the selected image to the "clipboard"
                CropImage();

                //set the current copied image to the mouse position.
                Paste(CopiedImage, baseCanvas.Image, e.X, e.Y);

                //clear the tool to stop the constant repasting.
                CurrentTool = ETools.None;
                SelectRect = new Rectangle(0, 0, 0, 0);
            }
            else if (CurrentTool == ETools.Shapes)
            {
                savePrevImage();
                switch (shapeSelected)
                {
                    case (EShapes.Line):
                        Equations.DrawLine(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea, selectedColor, SelectRect);
                        break;
                    case (EShapes.Circle):
                        Equations.DrawCircle(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea, selectedColor, SelectRect);
                        break;
                    case (EShapes.Square):
                        Equations.DrawSquare(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea, selectedColor, SelectRect);
                        break;
                    case (EShapes.Triangle):
                        Equations.DrawTriangle(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea, selectedColor, SelectRect);
                        break;
                    default:
                        break;
                }
            }
        }

        /**
         * Canvas drag Button
         */
        private void baseCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            //mouse cords indicator on the screen
            MousePos.Text = e.X + ", " + e.Y;

            CurrentMosusePos[0] = e.X;
            CurrentMosusePos[1] = e.Y;

            if (bSelected)
            {
                DrawSelectArea(e.X, e.Y);
                baseCanvas.Invalidate();
            }

            if (bCanDraw)
            {
                Pen p = new Pen(selectedColor);
                p.Draw(BeforeLocation, e.X, e.Y, BrushSizeBar.Value, baseCanvas, baseCanvas.Image);
            }

            if (bInSelectedRect && CurrentTool == ETools.Move)
            {
                //create a moving object
                TranslateMedia TempMoving = new TranslateMedia();
                //move the object based on the mouse
                TempMoving.Move(baseCanvas, SelectRect, pen, e.X, e.Y);
                //clear the base can
                baseCanvas.Invalidate();
            }
            BeforeLocation[0] = e.X;
            BeforeLocation[1] = e.Y;
        }

        /**-----------------------
         * Shape methods start here
         -----------------------*/

        /**
         * Click on Shapes
         */
        private void shapesToolButton_Click(object sender, EventArgs e)
        {
            switch (shapeSelected)
            {
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
        private void lineToolButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Shapes;
            shapeSelected = EShapes.Line;
            BrushSizeBar.Visible = false; //Hide the bar if its not in use
        }

        /**
         * Click on Circle
         */
        private void circleToolButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Shapes;
            shapeSelected = EShapes.Circle;
            BrushSizeBar.Visible = false; //Hide the bar if its not in use
        }

        /**
         * Shape - Square
         */
        private void squareToolButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Shapes;
            shapeSelected = EShapes.Square;
            BrushSizeBar.Visible = false; //Hide the bar if its not in use
        }

        /**
         * Shape - Triangle
         */
        private void triangleToolButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Shapes;
            shapeSelected = EShapes.Triangle;
            BrushSizeBar.Visible = false; //Hide the bar if its not in use
        }

        /**-----------------------
         * Image effects start here
         -----------------------*/

        /**
         * Inverse
         */
        private void invertEffect_Click(object sender, EventArgs e)
        {
            savePrevImage();
            ImageEffects inv = new ImageEffects(baseCanvas);
            inv.useInverse(SelectRect);
        }

        /**
         * Flip Vertically
         */
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePrevImage();
            ImageEffects flipV = new ImageEffects(baseCanvas);
            flipV.useFlip(SelectRect, "Y");
        }

        /**
         * Flip Horizontally
         */
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePrevImage();
            ImageEffects flipH = new ImageEffects(baseCanvas);
            flipH.useFlip(SelectRect, "X");
        }

        /**
         * Increase Transparency
         */
        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageEffects seeThru = new ImageEffects(baseCanvas);
            seeThru.lessOpaque(SelectRect);
        }

        /**
         * Decrease Transparency
         */
        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageEffects seeThru = new ImageEffects(baseCanvas);
            seeThru.moreOpaque(SelectRect);
        }

        /**
         * Click on Sepia
         */
        private void sepiaEffect_Click(object sender, EventArgs e)
        {
            savePrevImage();
            ImageEffects sepia = new ImageEffects(baseCanvas);
            sepia.useSepia(SelectRect);
        }

        /**
         * Effect - Black & White
         */
        private void bWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePrevImage();
            ImageEffects bw = new ImageEffects(baseCanvas);
            bw.useBW(SelectRect);
        }

        /**-----------------------
         * Tool methods start here
         -----------------------*/

        /**
         * TextBox Tool
         */
        private void textBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextInput.placeText(baseCanvas, SelectRect);
        }

        /**
         * Fill Color
         */
        private void fillColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorButton_Click(sender, e);

            ImageEffects phil = new ImageEffects(baseCanvas);

            phil.useFill(SelectRect, selectedColor);
        }

        /**
         * Click on Move
         */
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Move;
            BrushSizeBar.Visible = false; //Hide the bar if its not in use
        }

        /**
         * Click on Meme
         */
        private void memeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePrevImage();
            Meme meme = new Meme(baseCanvas);
        }

        /**
         * Colour button.
         * Passes the ColorDialog from the form to ColorSelector so it can allow the user to choose. Stores the value in selectedColor. Other methods can use it.
         */
        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorSelector colorGrid = new ColorSelector();
            selectedColor = colorGrid.displayShades(availableColors);
        }

        /**
         * Draw Tool Button
         */
        private void DrawSelectArea(int X, int Y)
        {
            int[] CurrentPos = { X, Y };
            using (SelectionArea = this.baseCanvas.CreateGraphics())
            {
                if (CurrentPos[0] > BeginningMousePos[0] && CurrentPos[1] > BeginningMousePos[1]) //Quadrant [+ -]
                {
                    SelectRect = new Rectangle(CurrentPos[0], BeginningMousePos[1], BeginningMousePos[0] - CurrentPos[0], CurrentPos[1] - BeginningMousePos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
                else if (CurrentPos[0] < BeginningMousePos[0] && CurrentPos[1] < BeginningMousePos[1]) //Quadrant [- +]
                {
                    SelectRect = new Rectangle(CurrentPos[0], CurrentPos[1], BeginningMousePos[0] - CurrentPos[0], BeginningMousePos[1] - CurrentPos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
                else if (CurrentPos[0] > BeginningMousePos[0] && CurrentPos[1] < BeginningMousePos[1]) //Quadrant [+ +]
                {
                    SelectRect = new Rectangle(BeginningMousePos[0], CurrentPos[1], CurrentPos[0] - BeginningMousePos[0], BeginningMousePos[1] - CurrentPos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
                else //Quadrant [- -]
                {
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
        private void penToolButton_Click(object sender, EventArgs e)
        {
            if (baseCanvas.Image == null)
            {
                MessageBox.Show("Cannot write on an empty canvas.");
            }
            else
            {
                CurrentTool = ETools.Pen;
                BrushSizeBar.Visible = true;
            }
        }

        /**
         * Click on Deselect
         */
        private void deselectButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.None; //No tool selected
            BrushSizeBar.Visible = false; //Hide the bar if its not in use
        }

        /**
         * Select Button
         */
        private void selectToolButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Select;
        }

        /**
         * Set Mouse Position
         */
        public void SetMousePoss(int[] DesiredArray, int x, int y)
        {
            DesiredArray[0] = x;
            DesiredArray[1] = y;
        }
    }
}