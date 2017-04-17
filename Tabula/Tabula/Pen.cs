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
            Graphics.FromImage(CurrentImage).DrawLine(pen, new Point(BeforeLocation[0], BeforeLocation[1]), new Point(X, Y));
            Layer.Refresh();

        }

    }
}
