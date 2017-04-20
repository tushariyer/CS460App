using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tabula {
    class Zoom {
        public Zoom() {

        }

        public Image Scale(Image pb, Rectangle rectum) {
            try
            {
                return new Bitmap((Image)pb.Clone(), rectum.Width - 100, rectum.Height - 100);
            }
            catch (ArgumentException)
            {
                return new Bitmap((Image)pb.Clone(), rectum.Width, rectum.Height);
            }
        }

        public Image ScaleIn(Image pb, Rectangle rectum) {
            try
            {
                return new Bitmap((Image)pb.Clone(), rectum.Width + 100, rectum.Height + 100);
            }
            catch (ArgumentException)
            {
                return new Bitmap((Image)pb.Clone(), rectum.Width, rectum.Height);
            }
        }
    }
}
