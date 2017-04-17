using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tabula
{
    class ImageEffects
    {
        PictureBox ApplyArea = new PictureBox();

        public static int[] BeginningMousePos = { 0, 0 };
        public int x, y, w, h;

        public void useSepia(Image target, int xCoord, int yCoord, int width, int height)
        {
            ApplyArea.Image = target;
            x = xCoord;
            y = yCoord;
            w = width;
            h = height;
        }
        public void sepia()
        {
            //Creation of values that are used to change the apperance of the image. this set of creates a sepia effect
            float[][] sepiaValues = {
            new float[]{.393f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            };
            //Creates a drawing matrix
            System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);

            //Creates default Image Attributes because it's needed for the draw image function below
            System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();

            //sets the image Attributes color matrix the 2D array above
            IA.SetColorMatrix(sepiaMatrix);

            //Creates a bitMap image that default value is whatever in currently on the canvas
            Bitmap sepiaEffect = (Bitmap)ApplyArea.Image.Clone();

            //Change the graphics of the image
            using (Graphics G = Graphics.FromImage(sepiaEffect))
            {
                //the x,y cords in the rectangle are to find where to place the edited section of the image
                //same with width and height
                G.DrawImage(ApplyArea.Image, x , y , w, h);
                    
                    //new Rectangle(BeginningMousePos[0], BeginningMousePos[1], EndMousePos - BeginningMousePos[0], EndMousePos - BeginningMousePos[1]),
                   //BeginningMousePos[0], BeginningMousePos[1], EndMousePos - BeginningMousePos[0], EndMousePos - BeginningMousePos[1], GraphicsUnit.Pixel, IA);
            }
            ApplyArea.Image = sepiaEffect;

            //MessageBox.Show("Currently Broken trying to fix :)");

            //Throw exception here

        }
    }
}
