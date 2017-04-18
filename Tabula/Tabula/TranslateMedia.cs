using System.Drawing;
using System.Windows.Forms;
namespace Tabula
{
    class TranslateMedia
    {
        public TranslateMedia()
        {
        }
        //shows the user where the picture box will end up with a rectangle
        public void Move(PictureBox Layer, Rectangle R, System.Drawing.Pen pen, int X, int Y)
        {
            using (Graphics g = Layer.CreateGraphics())
            {
                //draw the rectangle
                g.DrawRectangle(pen, new Rectangle(X, Y, R.Right - R.Left, R.Bottom - R.Top));
            }
        }
    }
}