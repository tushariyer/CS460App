using System;
using System.Drawing;
using System.Windows.Forms;

enum EShapes
{
    Line,
    Circle,
    Square,
    Triangle
};

namespace Tabula
{
    class Equations
    {
        EShapes shapeSelected;

        /**
         * Constructor
         */
        public Equations(EShapes shapeSelected)
        {
            this.shapeSelected = shapeSelected;
        }

        /**
         * Draw Line
         */
        public static void DrawLine(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea, Color toUse)
        {
            pen.Color = toUse;
            using (SelectionArea = baseCanvas.CreateGraphics())
            {
                SelectionArea.DrawLine(pen, startX, startY, endX, endY);
            }
        }

        /**
         * Draw Circle
         */
        public static void DrawCircle(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea, Color toUse)
        {
            pen.Color = toUse;
            int radius = (int)Math.Round(Math.Sqrt(Math.Pow(endY - startY, 2) + Math.Pow(endX - startX, 2)));
            using (SelectionArea = baseCanvas.CreateGraphics())
            {
                SelectionArea.DrawEllipse(pen, startX - (radius), startY - (radius), 2 * radius, 2 * radius);
            }

        }

        /**
         * Draw Square
         */
        public static void DrawSquare(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea, Color toUse, Rectangle recty)
        {
            pen.Color = toUse;
            Image pastImage = (Image)baseCanvas.Image.Clone();
            using (var G = Graphics.FromImage(pastImage))
            //using (SelectionArea = baseCanvas.CreateGraphics())
            {
                G.DrawRectangle(pen, startX, startY, endX - startX, endY - startY);

                G.DrawImage(pastImage, 0, 0);
                G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel);
                G.Dispose();

                baseCanvas.Image = pastImage;
            }
            baseCanvas.Refresh();
        }

        /**
         * Draw Triangle
         */
        public static void DrawTriangle(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea, Color toUse)
        {
            pen.Color = toUse;
            using (SelectionArea = baseCanvas.CreateGraphics())
            {
                SelectionArea.DrawLine(pen, startX, startY, endX, endY);
                SelectionArea.DrawLine(pen, (startX + (endX - startX) / 2) - 15, (startY + (endY - startY) / 2) - 15, startX, startY);
                SelectionArea.DrawLine(pen, (startX + (endX - startX) / 2) - 15, (startY + (endY - startY) / 2) - 15, endX, endY);
            }
        }
    }
}