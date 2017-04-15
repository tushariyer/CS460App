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
        public static Stack<Image> GlobalUndoStack;
        public static Stack<Image> GlobalRedoStack;
        //Colour currently selected
        private Color selectedColor = Color.Azure;
        //Select variables
        public static int[] BeginningMousePos = { 0, 0 };
        private int[] EndMousePos = { 0, 0 };
        public static int[] CurrentMosusePos = { 0, 0 };

        public int[] BeforeLocation = { 0, 0 };
        public Bitmap CopiedImage;

        //Form Tools
        public Graphics SelectionArea;
        //Rectangle selected
        Rectangle SelectRect;
        private bool bInSelectedRect;
        //Current tool/shape selected
        private ETools CurrentTool;
        private EShapes shapeSelected;
        public bool bSelected;
        public bool bCanDraw;
        //Get & Set for stacks
        public Stack<Image> GetUndoStack() { return GlobalUndoStack; }
        public Stack<Image> GetRedoStack() { return GlobalRedoStack; }

        private PictureBox SelectLayer = new PictureBox();
        //Constructor
        public Tabula()
        {
            InitializeComponent();

        }

        public Bitmap CropImage(Image SourceImage)
        {
            Rectangle CroppedImage = SelectRect;
            Bitmap bmp = new Bitmap(Math.Abs(SelectRect.Width), Math.Abs(SelectRect.Height));
            //Graphics g = Graphics.FromImage(SourceImage);

            CopiedImage = bmp;  

            return bmp;
        }

        public void Paste(Bitmap ImageToPaste, Image SourceImage)
        {
            //savePrevImage();

            Graphics g = Graphics.FromImage(SourceImage);

            g.DrawImage(SourceImage, new Rectangle(200, 200, Math.Abs(SelectRect.Width), 
                Math.Abs(SelectRect.Height)), SelectRect.Left, SelectRect.Top, ImageToPaste.Width, ImageToPaste.Height, GraphicsUnit.Pixel);
            g.Dispose();
            baseCanvas.Refresh();
        }

        //Use this whenever a tool is called to make sure the undo stack always gets updated
        private void savePrevImage()
        {
            GlobalUndoStack.Push(baseCanvas.Image);
        }

        /**
         * File Import Object created here. Redirects to Open.cs
         */
        private void openFileButton_Click(object sender, EventArgs e)
        {
            Open newPic = new Open(); //Create new Open Object
            baseCanvas.Image = newPic.importImage(); //USe the importImage method to assign a picture to the PictureBox
        }
        /**
         * Save methods start here
         */
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
        /**
         * Canvas Click Method
         */
        private void baseCanvas_Click(object sender, EventArgs e)
        {
        }
        /**
         * Colour button.
         */
        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorSelector colorGrid = new ColorSelector();
            //Passes the ColorDialog from the form to ColorSelector so it can allow the user to choose. Stores the value in selectedColor. Other methods can use it.
            selectedColor = colorGrid.displayShades(availableColors);
        }
        /**
         * New File Button
         */
        private void newFileButton_Click(object sender, EventArgs e)
        {
            NewCreation newBlank = new NewCreation();
            newBlank.importTemplate();
        }
        /**
         * Button for Undo
         */
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalRedoStack.Push(baseCanvas.Image);
            baseCanvas.Image = GlobalUndoStack.Pop();
        }
        /**
         * Redo Button
         */
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseCanvas.Image = GlobalRedoStack.Pop();
        }
        /**
         * Print Button
         */
        private void printButton_Click(object sender, EventArgs e)
        {
            Print printer = new Print(baseCanvas.Image);
        }
        /**
         * Select Button
         */
        private void selectToolButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Select;
        }
        /**
         * Redo Button
         */
        public void SetMousePoss(int[] DesiredArray, int x, int y)
        {
            DesiredArray[0] = x;
            DesiredArray[1] = y;
        }
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
            switch (CurrentTool)
            {
                case (ETools.Select):
                    bSelected = false;
                    DrawSelectArea(e.X, e.Y);
                    break;
                case (ETools.Pen):
                    bCanDraw = false;
                    break;
                case (ETools.Shapes):
                    switch (shapeSelected)
                    {
                        case (EShapes.Line):
                            Equations.DrawLine(this.baseCanvas, new System.Drawing.Pen(selectedColor, 2), BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea);
                            break;
                        case (EShapes.Circle):
                            Equations.DrawCircle(this.baseCanvas, new System.Drawing.Pen(selectedColor, 2), BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea);
                            break;
                        case (EShapes.Square):
                            Equations.DrawSquare(this.baseCanvas, new System.Drawing.Pen(selectedColor, 2), BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea);
                            break;
                        case (EShapes.Triangle):
                            Equations.DrawTriangle(this.baseCanvas, new System.Drawing.Pen(selectedColor, 2), BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea);
                            break;
                            /* case (EShapes.Star):
                                 Equations.DrawStar(this.baseCanvas, new System.Drawing.Pen(Color.Azure, 2), BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea);
                                 break;*/

                    }
                    break;
                default:
                    break;
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

            switch (CurrentTool)
            {
                case (ETools.Select):
                    if (bSelected)
                    {
                        DrawSelectArea(e.X, e.Y);
                        baseCanvas.Invalidate();
                    }
                    break;
                case (ETools.Pen):
                    if (bCanDraw)
                    {
                        Pen p = new Pen(selectedColor);
                        p.Draw(BeforeLocation, e.X, e.Y, 3, baseCanvas, baseCanvas.Image);

                    }


                    break;
                case (ETools.Shapes):
                    break;
                case (ETools.Move):
                    if (bInSelectedRect)
                    {
                        TranslateMedia TempMoving = new TranslateMedia(SelectRect, e.X, e.Y);
                        //TempMoving.Move();
                        DrawSelectArea(e.X, e.Y);
                    }
                    break;
                default:
                    break;
            }
            BeforeLocation[0] = e.X;
            BeforeLocation[1] = e.Y;
        }
        /**
         * Draw Tool Button
         */
        private void DrawSelectArea(int[] End, int[] Origin)
        {
            using (SelectionArea = this.baseCanvas.CreateGraphics())
            {
                SelectionArea.Clear(BackColor);
                PictureBox SelectLayer = new PictureBox();
                SelectLayer.BringToFront();
                System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                Brush brush = new SolidBrush(SelectLayer.BackColor);
                SelectionArea.DrawRectangle(pen, Origin[0], Origin[1], End[0] - Origin[0], End[1] - Origin[1]);
                //
            }
        }
        private void DrawSelectArea(int X, int Y)
        {

            int[] CurrentPos = { X, Y };
            //handles the [1 -1] vector
            if (CurrentPos[0] > BeginningMousePos[0] && CurrentPos[1] > BeginningMousePos[1])
            {
                using (SelectionArea = this.baseCanvas.CreateGraphics())
                {
                    System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                    Brush brush = new SolidBrush(SelectLayer.BackColor);
                    SelectRect = new Rectangle(CurrentPos[0], BeginningMousePos[1], BeginningMousePos[0] - CurrentPos[0], CurrentPos[1] - BeginningMousePos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
            }
            //handles the [-1 1] vector
            else if (CurrentPos[0] < BeginningMousePos[0] && CurrentPos[1] < BeginningMousePos[1])
            {
                using (SelectionArea = this.baseCanvas.CreateGraphics())
                {
                    System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                    Brush brush = new SolidBrush(SelectLayer.BackColor);
                    SelectRect = new Rectangle(CurrentPos[0], CurrentPos[1], BeginningMousePos[0] - CurrentPos[0], BeginningMousePos[1] - CurrentPos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
            }
            //handles the [1, 1] vector
            else if (CurrentPos[0] > BeginningMousePos[0] && CurrentPos[1] < BeginningMousePos[1])
            {
                using (SelectionArea = this.baseCanvas.CreateGraphics())
                {
                    System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                    Brush brush = new SolidBrush(SelectLayer.BackColor);
                    SelectRect = new Rectangle(BeginningMousePos[0], CurrentPos[1], CurrentPos[0] - BeginningMousePos[0], BeginningMousePos[1] - CurrentPos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
            }
            //handles the [-1,-1] vector
            else
            {
                using (SelectionArea = this.baseCanvas.CreateGraphics())
                {
                    System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                    Brush brush = new SolidBrush(SelectLayer.BackColor);
                    SelectRect = new Rectangle(CurrentPos[0], BeginningMousePos[1], BeginningMousePos[0] - CurrentPos[0], CurrentPos[1] - BeginningMousePos[1]);
                    SelectionArea.DrawRectangle(pen, SelectRect);
                }
            }

            using (SelectionArea = this.baseCanvas.CreateGraphics())
            {
                System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                Brush brush = new SolidBrush(SelectLayer.BackColor);
                SelectRect = new Rectangle(BeginningMousePos[0], BeginningMousePos[1], CurrentPos[0] - BeginningMousePos[0], CurrentPos[1] - BeginningMousePos[1]);
                SelectionArea.DrawRectangle(pen, SelectRect);
            }
        }
        private void penToolButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Pen;
        }
        private void deselectButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.None;
        }
        private void shapesToolButton_Click(object sender, EventArgs e)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
            switch (shapeSelected)
            {
                case (EShapes.Line):
                    CurrentTool = ETools.Shapes;
                    //Equations.DrawLine(this.baseCanvas, new System.Drawing.Pen(Color.Azure, 2), BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea);

                    break;
                case (EShapes.Circle):

                    break;

            }
        }
        private void lineToolButton_Click(object sender, EventArgs e)
        {
            shapeSelected = EShapes.Line;
        }
        private void circleToolButton_Click(object sender, EventArgs e)
        {
            shapeSelected = EShapes.Circle;
        }

        private void sepiaEffect_Click(object sender, EventArgs e)
        {
            ImageEffects sepia = new ImageEffects();
            //sepia.useSepia(baseCanvas.Image, EndMousePos[0]);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            QuitApp die = new QuitApp();
            die.beginQuit(baseCanvas);
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Move;
        }

        private void memeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePrevImage();
            Meme meme = new Meme(baseCanvas);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CropImage(baseCanvas.Image);
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            Paste(CopiedImage, baseCanvas.Image);
        }
    }
}