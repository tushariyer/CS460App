using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tabula
{
    class ResizeMedia : MultiTool
    {
        //Private fields
        private Image target;
        private Bitmap bm;

        //Takes in an Image and converts it to bitmap for scaling purposes
        public ResizeMedia(Image current)
        {
            target = current;
            bm = (Bitmap)target;
        }

        //Takes in a new height for the Image in this object
        public Image Scale(int width,int height)
        {
            //Bitmap to be returned as an image
            Bitmap scaled = new Bitmap(bm,width,height);
            //Returns the newly scaled image
            return (Image)bm;
        }
    }
}
