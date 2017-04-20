using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

/**
 * Enum for Drawable shapes
 */
enum EShapes {
    Line,
    Circle,
    Square,
    Triangle
};

namespace Tabula {
    class Equations {
        EShapes shapeSelected;

        /**
         * Constructor
         */
        public Equations(EShapes shapeSelected) {
            this.shapeSelected = shapeSelected;
        }

        /**
         * Draw Line
         */
        public static void DrawLine(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea, Color toUse, Rectangle recty, bool btemp) {

            pen.Color = toUse;

            //checks whether to create a temp shape, so real shape that will draw onto the image, not the picture box
            if (!btemp) {
                using (Graphics g = Graphics.FromImage(baseCanvas.Image)) {
                    //draws the shape on the IMAGE
                    g.DrawLine(pen, startX, startY, endX, endY);
                    baseCanvas.Refresh();
                }
            }
            else {
                using (SelectionArea = baseCanvas.CreateGraphics()) {
                    //draws the shape on the PICTURE BOX
                    SelectionArea.DrawLine(pen, startX, startY, endX, endY);
                    SelectionArea.Dispose();
                    //deletes it from the picture box, creates the moving preview effect.
                    baseCanvas.Invalidate();
                }
            }
        }

        /**
         * Draw Circle
         */

        public static void DrawCircle(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea, Color toUse, Rectangle recty, bool btemp) {
            pen.Color = toUse;
            int radius = (int)Math.Round(Math.Sqrt(Math.Pow(endY - startY, 2) + Math.Pow(endX - startX, 2)));
            //checks whether to create a temp shape, so real shape that will draw onto the image, not the picture box
            if (!btemp) {
                //creates a graphic object to use on the base canvas.
                using (Graphics G = Graphics.FromImage(baseCanvas.Image)) {
                    //draws the shape on the IMAGE
                    G.DrawEllipse(pen, startX - (radius), startY - (radius), 2 * radius, 2 * radius);
                    G.Dispose();
                }
            }
            else {
                using (SelectionArea = baseCanvas.CreateGraphics()) {
                    //draws the shape on the PICTURE BOX
                    SelectionArea.DrawEllipse(pen, startX - (radius), startY - (radius), 2 * radius, 2 * radius);
                    SelectionArea.Dispose();
                    //deletes it from the picture box, creates the moving preview effect.
                    baseCanvas.Invalidate();
                }
            }
            baseCanvas.Refresh();
        }

        /**
         * Draw Square
         */
        public static void DrawSquare(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea, Color toUse, Rectangle recty, bool btemp) {
            pen.Color = toUse;

            //checks whether to create a temp shape, so real shape that will draw onto the image, not the picture box
            if (!btemp) {
                //Creates a graphic object to use on the base canvas
                using (Graphics G = Graphics.FromImage(baseCanvas.Image)) {
                    //draws the shape on the IMAGE
                    G.DrawRectangle(pen, startX, startY, endX - startX, endY - startY);
                    G.Dispose();
                }
            }
            else {
                using (SelectionArea = baseCanvas.CreateGraphics()) {
                    //draws the shape on the PICTURE BOX
                    SelectionArea.DrawRectangle(pen, startX, startY, endX - startX, endY - startY);
                    SelectionArea.Dispose();
                    //deletes it from the picture box, creates the moving preview effect.
                    baseCanvas.Invalidate();
                }
            }
            baseCanvas.Refresh();
        }

        /**
         * Draw Triangle
         */
        public static void DrawTriangle(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea, Color toUse, Rectangle recty, bool btemp) {
            pen.Color = toUse;
            Image pastImage = (Image)baseCanvas.Image.Clone();

            //checks whether to create a temp shape, so real shape that will draw onto the image, not the picture box
            if (!btemp) {
                using (var G = Graphics.FromImage(pastImage)) {
                    //draws the line from the mouse click to the mouse position
                    G.DrawLine(pen, startX, startY, endX, endY);
                    //flips that point over the Y axis that is where the mouse click is one
                    G.DrawLine(pen, startX, startY, endX - (endX - startX) * 2, endY);
                    //connects the two
                    G.DrawLine(pen, endX - (endX - startX) * 2, endY, endX, endY);
                    G.Dispose();
                    //deletes it from the picture box, creates the moving preview effect.
                    baseCanvas.Image = pastImage;
                }
            }
            else {
                using (SelectionArea = baseCanvas.CreateGraphics()) {
                    //draws the line from the mouse click to the mouse position
                    SelectionArea.DrawLine(pen, startX, startY, endX, endY);
                    //flips that point over the Y axis that is where the mouse click is one
                    SelectionArea.DrawLine(pen, startX, startY, endX - (endX - startX) * 2, endY);
                    //connects the two
                    SelectionArea.DrawLine(pen, endX - (endX - startX) * 2, endY, endX, endY);
                    SelectionArea.Dispose();
                    //deletes it from the picture box, creates the moving preview effect.
                    baseCanvas.Invalidate();
                }

            }
            //refreshes the canvas so the draw changes show
            baseCanvas.Refresh();
        }

    }
}