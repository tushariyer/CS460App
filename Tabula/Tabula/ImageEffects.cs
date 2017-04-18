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
        private Color chosenShade;

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
            ColorMatrix sepiaMatrix = new ColorMatrix(sepiaValues);

            //Creates default Image Attributes because it's needed for the draw image function below
            ImageAttributes IA = new ImageAttributes();

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
                MessageBox.Show("Processing Invert\nThis may take a couple seconds..."); //Patience
                Bitmap pic = new Bitmap(pastImage); //Store the inverse in a bitmap
                for (int y = 0; (y <= (pic.Height - 1)); y++) //Y-Axis
                {
                    for (int x = 0; (x <= (pic.Width - 1)); x++) //X-Axis
                    {
                        Color inv = pic.GetPixel(x, y); //Get the color per pixel
                        inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B)); //Get negative values
                        pic.SetPixel(x, y, inv); //Set negative values
                    }
                }
                //using (Form form = new Form())
                //{
                //    form.StartPosition = FormStartPosition.CenterScreen;
                //    form.Size = pic.Size;
                //    PictureBox pb = new PictureBox();
                //    pb.Dock = DockStyle.Fill;
                //    pb.Image = (Image)pic;
                //    form.Controls.Add(pb);
                //    form.ShowDialog();
                //}
                G.DrawImage(pastImage, 0, 0); //Draws base image first and then the inverted image
                G.DrawImage(pic, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel);
                G.Dispose(); //Bye
            }
        }

        /**
         * Prep Flip
         */
        public void useFlip(Rectangle selectedRectum, String axis)
        {
            recty = selectedRectum;
            switch (axis.ToUpper())
            {
                case ("X"):
                    flipHoriz();
                    break;
                case ("Y"):
                    flipVert();
                    break;
                default:
                    break;
            }
        }

        /**
         * Flip Vertically
         */
        public void flipVert()
        {
            //Flip entire image
            baseCanvas.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            
            using (var G = Graphics.FromImage(pastImage))
            {
                //Draws image from before as a base
                G.DrawImage(pastImage, 0, 0);
                //Draws selected area of flipped image
                G.DrawImage(baseCanvas.Image, recty, recty.Left,recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top,GraphicsUnit.Pixel);
                G.Dispose();
            }
            //Sure?
            baseCanvas.Image = pastImage;
        }

        /**
         * Flip Horizontally
         */
        public void flipHoriz()
        {
            //Flip entire image
            baseCanvas.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

            using (var G = Graphics.FromImage(pastImage))
            {
                //Draws image from before as a base
                G.DrawImage(pastImage, 0, 0);
                //Draws selected area of flipped image
                G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel);
                G.Dispose();
            }            
            //Sure?
            baseCanvas.Image = pastImage;
        }

        /**
         * Prep Fill
         */
        public void useFill(Rectangle selectedRectum, Color selectedColor)
        {
            recty = selectedRectum;
            chosenShade = selectedColor;
            fill();
        }

        /**
         * Fill
         */
        public void fill()
        {
            //Change the graphics of the image
            using (var G = Graphics.FromImage(pastImage))
            using (SolidBrush brush = new SolidBrush(chosenShade))
            {
                //Draws base image first
                G.DrawImage(pastImage, 0, 0);
                //Draws color on top of that
                G.FillRectangle(brush, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top);
                G.Dispose();
                brush.Dispose();
            }
            baseCanvas.Image = pastImage;
        }
    }
}
