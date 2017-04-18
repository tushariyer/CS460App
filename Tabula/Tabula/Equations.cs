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
        //Combination of Equations[Interface] and Shape[Class]. Refer to UML for details.
        public Equations(EShapes shapeSelected)
        {
            this.shapeSelected = shapeSelected;
        }

        public static void DrawLine(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea)
        {
            using (SelectionArea = baseCanvas.CreateGraphics())
            {
                SelectionArea.DrawLine(pen, startX, startY, endX, endY);
            }
        }

        public static void DrawCircle(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea)
        {
            int radius = (int)Math.Round(Math.Sqrt(Math.Pow(endY - startY, 2) + Math.Pow(endX - startX, 2)));
            using (SelectionArea = baseCanvas.CreateGraphics())
            {
                SelectionArea.DrawEllipse(pen, startX - (radius), startY - (radius), 2 * radius, 2 * radius);
            }

        }

        public static void DrawSquare(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea)
        {
            using (SelectionArea = baseCanvas.CreateGraphics())
            {
                SelectionArea.DrawRectangle(pen, startX, startY, endX - startX, endY - startY);
            }
        }

        public static void DrawTriangle(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea)
        {
            using (SelectionArea = baseCanvas.CreateGraphics())
            {
                SelectionArea.DrawLine(pen, startX, startY, endX, endY);
                SelectionArea.DrawLine(pen, (startX + (endX - startX) / 2) - 15, (startY + (endY - startY) / 2) - 15, startX, startY);
                SelectionArea.DrawLine(pen, (startX + (endX - startX) / 2) - 15, (startY + (endY - startY) / 2) - 15, endX, endY);
            }
        }
    }
}
