using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/**
 * Enum for usable tools
 */
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
        bool    bCanDrawShape;

        public int CurrentPictureAngle = 0;

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
        private void defaultSelect()
        {
            SelectRect = new Rectangle(0, 0, baseCanvas.Width, baseCanvas.Height);
        }
        
        /**
         * New File Button
         */
        private void newFileButton_Click(object sender, EventArgs e)
        {
            if (baseCanvas.Image != null)
            {
                savePrevImage();
                DialogResult check = MessageBox.Show("Do you want to save?", "Warning!", MessageBoxButtons.YesNo);
                if (check == DialogResult.Yes)
                {
                    saveAsPNG_Click(sender, e);
                }
                else if (check == DialogResult.No)
                {
                    NewCreation newBlank = new NewCreation(baseCanvas);
                    defaultSelect();
                }
            }
        }
        
        /**
         * File Import Object created here. Redirects to Open.cs
         */
        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (baseCanvas.Image != null)
            {
                savePrevImage();
                DialogResult check = MessageBox.Show("Do you want to save?", "Warning!", MessageBoxButtons.YesNo);
                if (check == DialogResult.Yes)
                {
                    saveAsPNG_Click(sender, e);
                }
                else if (check == DialogResult.No)
                {
                    Open newPic = new Open(); //Create new Open Object
                    baseCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
                    baseCanvas.Refresh();
                    newPic.importImage(baseCanvas); //Use the importImage method to assign a picture to the PictureBox
                    defaultSelect();
                }
            }
            else
            {
                Open newPic = new Open(); //Create new Open Object
                baseCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
                baseCanvas.Refresh();
                newPic.importImage(baseCanvas); //Use the importImage method to assign a picture to the PictureBox
                defaultSelect();
            }
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
            if (baseCanvas.Image != null)
            {
                SavePicture jpeg = new SavePicture(); //New SavePicture Object
                jpeg.saveJpeg(baseCanvas.Image);
            }
            else
            {
                MessageBox.Show("There's nothing to save.");
            }
        }
        
        /**
         * Save File as Bitmap
         */
        private void saveAsBitmap_Click(object sender, EventArgs e)
        {
            if (baseCanvas.Image != null)
            {
                SavePicture bmp = new SavePicture(); //New SavePicture Object
                bmp.saveBitmap(baseCanvas.Image);
            }
            else
            {
                MessageBox.Show("There's nothing to save.");
            }
        }

        /**
         * Save File as PNG
         */
        private void saveAsPNG_Click(object sender, EventArgs e)
        {
            if (baseCanvas.Image != null)
            {
                SavePicture png = new SavePicture(); //New SavePicture Object
                png.savePng(baseCanvas.Image);
            }
            else
            {
                MessageBox.Show("There's nothing to save.");
            }
                
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
                    //makes it so the shapes will only draw after a mouse down event
                case (ETools.Shapes):
                    bCanDrawShape = true;
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
                CutImage();

                //set the current copied image to the mouse position.
                Paste(CopiedImage, baseCanvas.Image, e.X, e.Y);

                //clear the tool to stop the constant repasting.
                CurrentTool = ETools.None;
                SelectRect = new Rectangle(0, 0, 0, 0);
            }
            else if (CurrentTool == ETools.None)
            {
                defaultSelect();
            }
            else if (CurrentTool == ETools.Shapes)
            {
                bCanDrawShape = false;
                savePrevImage();
                //draws the shpae that has been selected. DRAWS ONTO IMAGE
                switch (shapeSelected)
                {
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

            //if the mouse has been pressed.
            if (bCanDrawShape)
            {
                //draw the image onto the PICTURE BOX, and then invalidate it.
                switch (shapeSelected)
                {
                    case (EShapes.Line):
                        Equations.DrawLine(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, true);
                        break;
                    case (EShapes.Circle):
                        Equations.DrawCircle(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, true);
                        break;
                    case (EShapes.Square):
                        Equations.DrawSquare(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, true);
                        break;
                    case (EShapes.Triangle):
                        Equations.DrawTriangle(baseCanvas, pen, BeginningMousePos[0], BeginningMousePos[1], e.X, e.Y, SelectionArea, selectedColor, SelectRect, true);
                        break;
                    default:
                        break;
                }
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

        /**
         * Effect - Hue
         */
        private void hueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePrevImage();
            colorButton_Click(sender, e);
            ImageEffects hue = new ImageEffects(baseCanvas);
            hue.useHue(SelectRect, selectedColor);
        }

        /**
         * Effect - Increase Brightness
         */
        private void increaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            savePrevImage();
            ImageEffects brightUp = new ImageEffects(baseCanvas);
            brightUp.useBright("up", SelectRect);
        }

        /**
         * Effect - Decrease Brightness
         */
        private void decreaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            savePrevImage();
            ImageEffects brightUp = new ImageEffects(baseCanvas);
            brightUp.useBright("down", SelectRect);
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
                colorButton_Click(sender, e);
                CurrentTool = ETools.Pen;
                BrushSizeBar.Visible = true;
            }
        }

        /**
         * Click on Deselect
         */
        private void deselectButton_Click(object sender, EventArgs e)
        {
            defaultSelect();
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

        /**
         * Rotate Tool
         */
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageEffects rotator = new ImageEffects(baseCanvas);


            System.Windows.Forms.MessageBox.Show("My message here");

            //rotator.rotatePrep(new Rectangle(SelectRect.Left, SelectRect.Top, 1, 1),selectedColor, CurrentPictureAngle);
            //CropImage();
            if (CurrentPictureAngle < 360)
            {
                CurrentPictureAngle += 5;
            }
            else
            {
                CurrentPictureAngle = 0;
            }

            if(CopiedImage == null)
            {
                CropImage();
            }
            CopiedImage = RotateImage(CopiedImage, CurrentPictureAngle);
            Paste(CopiedImage, baseCanvas.Image, SelectRect.Left, SelectRect.Top);


            

            using (Form form = new Form())
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Size = CopiedImage.Size;
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.Image = CopiedImage;
                form.Controls.Add(pb);
                form.ShowDialog();
            }


        }


       //// public Bitmap RotateImg(Bitmap bmp, float angle, Color bkColor)
       // {

       //     angle = angle % 360;
       //     if (angle > 180)
       //         angle -= 360;

       //     System.Drawing.Imaging.PixelFormat pf = default(System.Drawing.Imaging.PixelFormat);
       //     if (bkColor == Color.Transparent)
       //     {
       //         pf = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
       //     }
       //     else
       //     {
       //         pf = bmp.PixelFormat;
       //     }

       //     float sin = (float)Math.Abs(Math.Sin(angle * Math.PI / 180.0)); // this function takes radians
       //     float cos = (float)Math.Abs(Math.Cos(angle * Math.PI / 180.0)); // this one too
       //     float newImgWidth = sin * bmp.Height + cos * bmp.Width;
       //     float newImgHeight = sin * bmp.Width + cos * bmp.Height;
       //     float originX = 0f;
       //     float originY = 0f;

       //     if (angle > 0)
       //     {
       //         if (angle <= 90)
       //             originX = sin * bmp.Height;
       //         else
       //         {
       //             originX = newImgWidth;
       //             originY = newImgHeight - sin * bmp.Width;
       //         }
       //     }
       //     else
       //     {
       //         if (angle >= -90)
       //             originY = sin * bmp.Width;
       //         else
       //         {
       //             originX = newImgWidth - sin * bmp.Height;
       //             originY = newImgHeight;
       //         }
       //     }

       //     Bitmap newImg = new Bitmap((int)newImgWidth, (int)newImgHeight, pf);
       //     Graphics g = Graphics.FromImage(newImg);
       //     g.Clear(bkColor);
       //     g.TranslateTransform(originX, originY); // offset the origin to our calculated values
       //     g.RotateTransform(angle); // set up rotate
       //     g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
       //     g.DrawImageUnscaled(bmp, 0, 0); // draw the image at 0, 0
       //     g.Dispose();

       //     baseCanvas.Refresh();

       //     return newImg;
       // }


        public Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            const double pi2 = Math.PI / 2.0;


            double oldWidth = (double)image.Width;
            double oldHeight = (double)image.Height;

            // Convert degrees to radians
            double theta = ((double)angle) * Math.PI / 180.0;
            double locked_theta = theta;

            // Ensure theta is now [0, 2pi)
            while (locked_theta < 0.0)
                locked_theta += 2 * Math.PI;

            double newWidth, newHeight;
            int nWidth, nHeight; // The newWidth/newHeight expressed as ints



            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;


            if ((locked_theta >= 0.0 && locked_theta < pi2) ||
                (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2)))
            {
                adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
                oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;

                adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
                oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;

                adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
            }

            newWidth = adjacentTop + oppositeBottom;
            newHeight = adjacentBottom + oppositeTop;

            nWidth = (int)Math.Ceiling(newWidth);
            nHeight = (int)Math.Ceiling(newHeight);

            Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {

                Point[] points;

                if (locked_theta >= 0.0 && locked_theta < pi2)
                {
                    points = new Point[] {
                                             new Point( (int) oppositeBottom, 0 ),
                                             new Point( nWidth, (int) oppositeTop ),
                                             new Point( 0, (int) adjacentBottom )
                                         };

                }
                else if (locked_theta >= pi2 && locked_theta < Math.PI)
                {
                    points = new Point[] {
                                             new Point( nWidth, (int) oppositeTop ),
                                             new Point( (int) adjacentTop, nHeight ),
                                             new Point( (int) oppositeBottom, 0 )
                                         };
                }
                else if (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2))
                {
                    points = new Point[] {
                                             new Point( (int) adjacentTop, nHeight ),
                                             new Point( 0, (int) adjacentBottom ),
                                             new Point( nWidth, (int) oppositeTop )
                                         };
                }
                else
                {
                    points = new Point[] {
                                             new Point( 0, (int) adjacentBottom ),
                                             new Point( (int) oppositeBottom, 0 ),
                                             new Point( (int) adjacentTop, nHeight )
                                         };
                }

                SelectRect.Width = (int)newWidth;
                SelectRect.Height = (int)newHeight;


                g.DrawImage(image, points);
            }

            return rotatedBmp;
        }
    }
}