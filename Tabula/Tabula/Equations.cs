using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

enum EShapes
{
    Line,
    Circle,
    Square,
    Triangle,
    //Star
};

namespace Tabula
{
    class Equations
    {
        EShapes shapeSelected;
        //Pen pen = new Pen(Color.Black, 2);
        //Combination of Equations[Interface] and Shape[Class]. Refer to UML for details.
        public Equations(EShapes shapeSelected)
        {
            this.shapeSelected = shapeSelected;

            //Constructor
            //Make all these methods static if you dont want to instantiate this class as individual objects
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

        /*public static void DrawStar(PictureBox baseCanvas, System.Drawing.Pen pen, int startX, int startY, int endX, int endY, Graphics SelectionArea)
        {
            using (SelectionArea = baseCanvas.CreateGraphics())
            {
                //temp
                /*SelectionArea.DrawLine(pen, 15, 30, 20, 20);
                SelectionArea.DrawLine(pen, 20, 20, 25, 30);
                SelectionArea.DrawLine(pen, 25, 30, 40, 30);
                SelectionArea.DrawLine(pen, 40, 30, 30, 40);
                SelectionArea.DrawLine(pen, 30, 40, 35, 50);
                SelectionArea.DrawLine(pen, 35, 50, 20, 45);
                SelectionArea.DrawLine(pen, 20, 45, 5, 50);
                SelectionArea.DrawLine(pen, 5, 50, 10, 40);
                SelectionArea.DrawLine(pen, 10, 40, 0, 30);
                SelectionArea.DrawLine(pen, 0, 30, 15, 30);*/

        /*top point*/
        /*SelectionArea.DrawLine(pen, 
                               startX, 
                               startY, 
                               (startX + (endX - startX) / 2) + 15, 
                               (startY + (endY - startY) / 2));

        SelectionArea.DrawLine(pen, 
                               startX, 
                               startY, 
                               (startX + (endX - startX) / 2) - 15, 
                               (startY + (endY - startY) / 2));

        /*right arm*/
        /*SelectionArea.DrawLine(pen, 
                               (startX + (endX - startX) / 2) + 15, 
                               (startY + (endY - startY) / 2), 
                               (startX + (endX - startX) / 2) + 30, 
                               (startY + (endY - startY) / 2));

        SelectionArea.DrawLine(pen, 
                               (startX + (endX - startX) / 2) + 30, 
                               (startY + (endY - startY) / 2), 
                               (startX + (endX - startX) / 2) - 2,
                               (startY + (endY - startY) / 2) + 15);


        /*left arm*/
        /*SelectionArea.DrawLine(pen, 
                               (startX + (endX - startX) / 2) - 15, 
                               (startY + (endY - startY) / 2), 
                               (startX + (endX - startX) / 2) - 30,
                               (startY + (endY - startY) / 2));

        SelectionArea.DrawLine(pen, 
                               (startX + (endX - startX) / 2) - 30, 
                               (startY + (endY - startY) / 2), 
                               (startX + (endX - startX) / 2) + 2, 
                               (startY + (endY - startY) / 2) + 25);

    }
}*/
    }
}
