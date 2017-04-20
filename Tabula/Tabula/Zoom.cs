using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tabula {
    class Zoom {
        Image CopiedImage;
        public Zoom() {

        }

        public Image Scale(Image pb, Rectangle rectum) {
            Bitmap bmp = (Bitmap)pb.Clone();
            try {
                CopiedImage = bmp.Clone(new Rectangle(rectum.Left, rectum.Top, rectum.Width + 100, rectum.Height + 100), bmp.PixelFormat);
            }
            catch (OutOfMemoryException) {
                CopiedImage = bmp.Clone(rectum, bmp.PixelFormat);
            }
            bmp.Dispose();
            return CopiedImage; 
        }

        public Image ScaleIn(Image pb, Rectangle rectum) {
            Bitmap bmp = (Bitmap)pb.Clone();
            CopiedImage = bmp.Clone(new Rectangle(rectum.Left, rectum.Top, rectum.Width - 100, rectum.Height - 100), bmp.PixelFormat);
            bmp.Dispose();
            return CopiedImage;
        }
    }
}
