using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tabula
{
    class Zoom
    {
        Image CopiedImage;
        public Zoom()
        {

        }

        public Image Scale(PictureBox pb, Rectangle rectum)
        {
            Bitmap bmp = (Bitmap)pb.Image.Clone();
            CopiedImage = bmp.Clone(new Rectangle(rectum.Left, rectum.Top, Math.Abs(rectum.Width), Math.Abs(rectum.Height)), bmp.PixelFormat);
            return CopiedImage;
        }
    }
}
