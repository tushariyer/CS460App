using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tabula {
    class Zoom {
        public Zoom() {

        }

        public Image Scale(Image pb, Rectangle rectum) {
            //Graphics g = Graphics.FromImage(pb);
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            using (Graphics g = Graphics.FromImage(pb)){
                Image temp = (Image)pb.Clone();
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(pb,0,0, rectum.Width - 100, rectum.Height - 100);
            }
            return pb;
        }

        public Image ScaleIn(Image pb, Rectangle rectum) {
            //Graphics g = Graphics.FromImage(pb);
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //using (Form form = new Form()) {
            //    Bitmap img = new Bitmap(rectum.Width,rectum.Height,g);
            //    form.StartPosition = FormStartPosition.CenterScreen;
            //    form.Size = img.Size;
            //    PictureBox pb2 = new PictureBox();
            //    pb2.Dock = DockStyle.Fill;
            //    pb2.Image = img;
            //    form.Controls.Add(pb2);
            //    form.ShowDialog();
            //}
            return new Bitmap((Image)pb.Clone(),rectum.Width + 100, rectum.Height + 100);
        }
    }
}
