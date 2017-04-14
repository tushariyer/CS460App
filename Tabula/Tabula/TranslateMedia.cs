using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tabula
{
    class TranslateMedia
    {
        Rectangle ImageSelected;
        int CurrentX;
        int CurrentY;

        public TranslateMedia(Rectangle ImageSelected, int CurrentX, int CurrentY)
        {
            this.ImageSelected = ImageSelected;
            this.CurrentX = CurrentX;
            this.CurrentY = CurrentY;


        }

        public void Move(PictureBox Layer)
        {

            Bitmap bmp = new Bitmap(ImageSelected.Width, ImageSelected.Height);

            Graphics g = Graphics.FromImage(bmp);

            //g.DrawImage(ImageSelected, 0, 0, 100, 100);

        }

    }
}
