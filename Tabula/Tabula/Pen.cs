using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Tabula
{
    class Pen : MultiTool
    {
        
        System.Drawing.Pen pen = new System.Drawing.Pen(Color.Azure);
     
        public Pen(Color newColor)
        {
            pen.Color = newColor;

        }

        public void Draw(int[] BeforeLocation, int X, int Y, int BrushSize, PictureBox Layer, Image CurrentImage)
        {
            /*using (Graphics g  = Layer.CreateGraphics())
            {

                pen.Width = BrushSize;

                g.DrawLine(pen, new Point(BeforeLocation[0], BeforeLocation[1]), new Point(X, Y));
            }
            */

            pen.Width = BrushSize;
            
            //thin enough to just draw just one line
            if (pen.Width < 5)
            {
               Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0], BeforeLocation[1]), new Point(X, Y));
            }
            //thicker line needs more lines to fill open spaces in the brush strokes
            else {
                 Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0] - 1, BeforeLocation[1] - 1), new Point(X - 1, Y - 1));

                 Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0] - 1, BeforeLocation[1] + 1), new Point(X - 1, Y + 1));
                 Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0] + 1, BeforeLocation[1] - 1), new Point(X + 1, Y - 1));

                 Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0] - 1, BeforeLocation[1] + 1), new Point(X + 1, Y - 1));
                 Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0] + 1, BeforeLocation[1] - 1), new Point(X - 1, Y + 1));

                 Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0] + 1, BeforeLocation[1] + 1), new Point(X + 1, Y + 1));

                 Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0], BeforeLocation[1]), new Point(X, Y));             
             }
            Layer.Refresh();

        }

    }
}
