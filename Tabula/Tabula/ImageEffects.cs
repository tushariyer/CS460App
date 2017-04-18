using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;


namespace Tabula
{
    class ImageEffects
    {
        private PictureBox baseCanvas;
        private Rectangle recty;
        private Image pastImage;

        /**
         * Image Effects constructor
         */
        public ImageEffects(PictureBox baseCanvas)
        {
            this.baseCanvas = baseCanvas;
            pastImage = (Image)baseCanvas.Image.Clone();
        }

        /**
         * Prep for Sepia
         */
        public void useSepia(Rectangle selectedRectum)
        {
            recty = selectedRectum;
            sepia();
        }

        /**
         * Sepia
         */
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

            //Change the graphics of the image
            using (var G = Graphics.FromImage(pastImage))
            {
                //Draws base image first
                G.DrawImage(pastImage,0,0);
                //Draws sepia's image on top
                G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel,IA);
                G.Dispose();
            }

            baseCanvas.Image = pastImage;
        }

        /**
         * Prep for Inverse
         */
        public void useInverse(Rectangle selectedRectum)
        {
            recty = selectedRectum;
            inverse();
        }

        /**
         * Inverse
         * WIP: Does not currently work. I don't know why
         */
        public void inverse()
        {
            using (var G = Graphics.FromImage(pastImage))
            {
                ColorMatrix cMat = new ColorMatrix(new float[][] 
                {
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] {0, 0, -1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {1, 1, 1, 0, 1}
                });

                ImageAttributes IA = new ImageAttributes();
                IA.SetColorMatrix(cMat);

                G.DrawImage(pastImage, 0, 0); //Draws base image first and then the inverted image
                G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel, IA);

                G.Dispose(); //Bye
            }
        }
    }
}
