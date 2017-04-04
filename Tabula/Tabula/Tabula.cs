﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
enum ETools
{
    None,
    Select,
    Shapes,
    Pen
};
namespace Tabula
{
    public partial class Tabula : Form
    {
        //Global Stacks
        public static Stack<Image> GlobalUndoStack;
        public static Stack<Image> GlobalRedoStack;
        //Colour currently selected
        private Color selectedColor;
        //Select variables
        public static int[] BeginningMousePos = { 0, 0 };
        private int[] EndMousePos = { 0, 0 };
        public static int[] CurrentMosusePos = { 0, 0 };
        public Graphics SelectionArea;
        private ETools CurrentTool;
        private EShapes shapeSelected;
        private bool bSelected;
        //Get & Set for stacks
        //
        public Stack<Image> GetUndoStack() { return GlobalUndoStack; }
        public Stack<Image> GetRedoStack() { return GlobalRedoStack; }
        public Tabula()
        {
            InitializeComponent();
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
        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorSelector colorGrid = new ColorSelector();
            //Passes the ColorDialog from the form to ColorSelector so it can allow the user to choose. Stores the value in selectedColor. Other methods can use it.
            selectedColor = colorGrid.displayShades(availableColors);
        }
        private void newFileButton_Click(object sender, EventArgs e)
        {
            NewCreation newBlank = new NewCreation();
            newBlank.importTemplate();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalRedoStack.Push(baseCanvas.Image);
            baseCanvas.Image = GlobalUndoStack.Pop();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseCanvas.Image = GlobalRedoStack.Pop();
        }
        private void printButton_Click(object sender, EventArgs e)
        {
            Print printer = new Print();
            printer.PrepPicture(baseCanvas.Image);
        }
        private void selectToolButton_Click(object sender, EventArgs e)
        {
            CurrentTool = ETools.Select;
        }
        public void SetMousePoss(int[] DesiredArray, int x, int y)
        {
            DesiredArray[0] = x;
            DesiredArray[1] = y;
        }
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
                    break;
                default:
                    break;
            }
        }
        private void baseCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            EndMousePos[0] = e.Location.X;
            EndMousePos[1] = e.Location.Y;
            switch (CurrentTool)
            {
                case (ETools.Select):
                    bSelected = false;
                    DrawSelectArea(EndMousePos, BeginningMousePos);
                    break;
                case (ETools.Pen):
                    break;
                case (ETools.Shapes):
                    switch (shapeSelected)
                    {
                        case (EShapes.Line):
                            Equations.DrawLine(this.baseCanvas, new System.Drawing.Pen(Color.Azure, 2), BeginningMousePos[0], BeginningMousePos[1], EndMousePos[0], EndMousePos[1], SelectionArea);
                            break;
                            //add case for circle
                    }
                    break;
                default:
                    break;
            }
        }
        private void baseCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentMosusePos[0] = e.X;
            CurrentMosusePos[1] = e.Y;
            switch (CurrentTool)
            {
                case (ETools.Select):
                    if (bSelected)
                    {
                        int[] CurrentPos = { e.X, e.Y };
                        //handles the [1 -1] vector
                        if (CurrentPos[0] > BeginningMousePos[0] && CurrentPos[1] > BeginningMousePos[1])
                        {
                            DrawSelectArea(CurrentPos, BeginningMousePos);
                        }
                        //handles the [-1 1] vector
                        else if (CurrentPos[0] < BeginningMousePos[0] && CurrentPos[1] < BeginningMousePos[1])
                        {
                            DrawSelectArea(BeginningMousePos, CurrentPos);
                        }
                        //handles the [1, 1] vector
                        else if (CurrentPos[0] > BeginningMousePos[0] && CurrentPos[1] < BeginningMousePos[1])
                        {
                            using (SelectionArea = this.baseCanvas.CreateGraphics())
                            {
                                SelectionArea.Clear(BackColor);
                                PictureBox SelectLayer = new PictureBox();
                                SelectLayer.BringToFront();
                                System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                                Brush brush = new SolidBrush(SelectLayer.BackColor);
                                SelectionArea.DrawRectangle(pen, BeginningMousePos[0], CurrentPos[1], CurrentPos[0] - BeginningMousePos[0], BeginningMousePos[1] - CurrentPos[1]);
                                //
                            }
                        }
                        else
                        {
                            using (SelectionArea = this.baseCanvas.CreateGraphics())
                            {
                                SelectionArea.Clear(BackColor);
                                PictureBox SelectLayer = new PictureBox();
                                SelectLayer.BringToFront();
                                System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                                Brush brush = new SolidBrush(SelectLayer.BackColor);
                                SelectionArea.DrawRectangle(pen, CurrentPos[0], BeginningMousePos[1], BeginningMousePos[0] - CurrentPos[0], CurrentPos[1] - BeginningMousePos[1]);
                                //
                            }
                        }
                    }
                    break;
                case (ETools.Pen):
                    break;
                case (ETools.Shapes):
                    break;
                default:
                    break;
            }
        }
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
        private void DrawSelectArea(int EndX, int EndY, int OriginX, int OriginY)
        {
            using (SelectionArea = this.baseCanvas.CreateGraphics())
            {
                SelectionArea.Clear(BackColor);
                PictureBox SelectLayer = new PictureBox();
                SelectLayer.BringToFront();
                System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure, 2);
                Brush brush = new SolidBrush(SelectLayer.BackColor);
                SelectionArea.DrawRectangle(pen, OriginX, EndY, EndX - OriginX, OriginY - EndY);
                //
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

        //Action Class Methods. See UML (Also, general functions that aren't Tool-specific.)
    }
}