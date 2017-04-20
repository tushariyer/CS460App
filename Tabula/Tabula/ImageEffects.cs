using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Tabula {
    class ImageEffects {
        private PictureBox baseCanvas;
        private Rectangle recty;
        private Image pastImage;
        private Color chosenShade;

        /**
         * Image Effects constructor
         */
        public ImageEffects(PictureBox baseCanvas) {
            this.baseCanvas = baseCanvas;
            try {
                pastImage = (Image)baseCanvas.Image.Clone();
            }
            catch (NullReferenceException) {
                MessageBox.Show("Please import an image to use this tool.");
            }

        }

        /**
         * Prep for Sepia
         */
        public void useSepia(Rectangle selectedRectum) {
            if (baseCanvas.Image == null) {

            }
            else {
                recty = selectedRectum;
                sepia();
            }
        }

        /**
         * Sepia
         */
        private void sepia() {
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
            using (var G = Graphics.FromImage(pastImage)) {
                //Draws base image first
                G.DrawImage(pastImage, 0, 0);
                //Draws sepia's image on top
                G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel, IA);
                G.Dispose();
            }

            baseCanvas.Image = pastImage;
        }

        /**
         * Prep for Inverse
         */
        public void useInverse(Rectangle selectedRectum) {
            if (baseCanvas.Image == null) {

            }
            else {
                recty = selectedRectum;
                inverse();
            }
        }

        /**
         * Inverse
         */
        private void inverse() {
            try {
                using (var G = Graphics.FromImage(pastImage)) {
                    Bitmap pic = new Bitmap(pastImage); //Store the inverse in a bitmap
                    for (int y = recty.Top; (y < recty.Bottom); y++) { //Y-Axis
                        for (int x = recty.Left; (x < recty.Right); x++) { //X-Axis
                            Color inv = pic.GetPixel(x, y); //Get the color per pixel
                            inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B)); //Get negative values
                            pic.SetPixel(x, y, inv); //Set negative values
                        }
                    }
                    baseCanvas.Image = pic;

                    G.DrawImage(pastImage, 0, 0); //Draws base image first and then the inverted image
                    G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel);

                    G.Dispose(); //Bye
                }
            }
            catch (NullReferenceException) {

            }
        }

        /**
         * Opacity Decrease
         */
        public void lessOpaque(Rectangle rect) {
            try {
                recty = rect;

                using (var G = Graphics.FromImage(pastImage)) {
                    Bitmap pic = new Bitmap(pastImage); //Store the inverse in a bitmap
                    for (int y = recty.Top; (y <= recty.Bottom); y++) { //Y-Axis
                        for (int x = recty.Left; (x <= recty.Right); x++) {  //X-Axis
                            Color inv = pic.GetPixel(x, y); //Get the color per pixel

                            if ((inv.A - 10) >= 0) {
                                inv = Color.FromArgb((inv.A - 10), inv.R, inv.G, inv.B); //Get negative values
                                pic.SetPixel(x, y, inv); //Set negative values
                            }
                            else {
                                break;
                            }
                        }
                    }
                    baseCanvas.Image = pic;

                    G.DrawImage(pastImage, 0, 0); //Draws base image first and then the inverted image
                    G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel);

                    G.Dispose(); //Bye
                }
            }
            catch (ArgumentNullException) {

            }

        }

        /**
         * Opacity Increase
         */
        public void moreOpaque(Rectangle rect) {
            try {
                recty = rect;

                using (var G = Graphics.FromImage(pastImage)) {
                    Bitmap pic = new Bitmap(pastImage); //Store the inverse in a bitmap
                    for (int y = recty.Top; (y <= recty.Bottom); y++) {  //Y-Axis
                        for (int x = recty.Left; (x <= recty.Right); x++) { //X-Axis
                            Color inv = pic.GetPixel(x, y); //Get the color per pixel

                            if ((inv.A + 10) <= 255) {
                                inv = Color.FromArgb((inv.A + 10), inv.R, inv.G, inv.B); //Get negative values
                                pic.SetPixel(x, y, inv); //Set negative values
                            }
                            else {
                                break;
                            }
                        }
                    }
                    baseCanvas.Image = pic;

                    G.DrawImage(pastImage, 0, 0); //Draws base image first and then the inverted image
                    G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel);

                    G.Dispose(); //Bye
                }
            }
            catch (ArgumentNullException) {

            }
        }

        /**
         * Prep Flip
         */
        public void useFlip(Rectangle selectedRectum, String axis) {
            try {
                recty = selectedRectum;
                switch (axis.ToUpper()) {
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
            catch (NullReferenceException) {

            }
        }

        /**
         * Flip Vertically
         */
        private void flipVert() {
            //Flip entire image
            baseCanvas.Image.RotateFlip(RotateFlipType.Rotate180FlipX);

            using (var G = Graphics.FromImage(pastImage)) {
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
         * Flip Horizontally
         */
        private void flipHoriz() {
            //Flip entire image
            baseCanvas.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

            using (var G = Graphics.FromImage(pastImage)) {
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
        public void useFill(Rectangle selectedRectum, Color selectedColor) {
            try {
                recty = selectedRectum;
                chosenShade = selectedColor;
                fill();
            }
            catch (ArgumentNullException) {

            }
        }

        /**
         * Fill
         */
        private void fill() { //Change the graphics of the image
            using (var G = Graphics.FromImage(pastImage))
            using (SolidBrush brush = new SolidBrush(chosenShade)) {
                //Draws base image first
                G.DrawImage(pastImage, 0, 0);
                //Draws color on top of that
                G.FillRectangle(brush, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top);
                G.Dispose();
                brush.Dispose();
            }
            baseCanvas.Image = pastImage;
        }

        /**
         * Prep B&W
         */
        public void useBW(Rectangle selectedRectum) {
            try {
                recty = selectedRectum;
                blackAndWhite();
            }
            catch (NullReferenceException) {

            }
        }

        /**
         * B&W
         */
        private void blackAndWhite() {
            try { //Creation of values that are used to change the apperance of the image. this set of creates a b&w effect

                float[][] bwValues = {
            new float[] {.3f, .3f, .3f, 0, 0},
            new float[] {.59f, .59f, .59f, 0, 0},
            new float[] {.11f, .11f, .11f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            };

                ColorMatrix bwMatrix = new ColorMatrix(bwValues); //Creates a drawing matrix

                ImageAttributes IA = new ImageAttributes(); //Creates default Image Attributes because it's needed for the draw image function below

                IA.SetColorMatrix(bwMatrix); //sets the image Attributes color matrix the 2D array above

                using (var G = Graphics.FromImage(pastImage)) {  //Change the graphics of the image
                    G.DrawImage(pastImage, 0, 0); //Draws base image first & Draws sepia's image on top
                    G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel, IA);
                    G.Dispose();
                }
                baseCanvas.Image = pastImage;
            }
            catch (ArgumentNullException) {

            }
        }

        /**
         * Prep Hue
         */
        public void useHue(Rectangle selectedRectum, Color selectedColor) {
            try {
                recty = selectedRectum;
                chosenShade = selectedColor;
                hue();
            }
            catch (NullReferenceException) {

            }
        }

        /**
         * Hue
         */
        private void hue() {
            try {
                Color newColor = Color.FromArgb(150, chosenShade); //Change the graphics of the image

                using (var G = Graphics.FromImage(pastImage))
                using (SolidBrush brush = new SolidBrush(newColor)) {
                    G.DrawImage(pastImage, 0, 0); //Draws base image first

                    G.FillRectangle(brush, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top); //Draws color on top of that
                    G.Dispose();
                    brush.Dispose();
                }
                baseCanvas.Image = pastImage;
            }
            catch (ArgumentNullException) {

            }
        }

        /**
         * Prep Brightness
         */
        public void useBright(string upDown, Rectangle selectedRectum) {
            try {
                recty = selectedRectum;

                if (upDown == "up") {
                    increaseBrightness();
                }
                else if (upDown == "down") {
                    decreaseBrightness();
                }
                else { }
            }
            catch (ArgumentNullException) { }
        }

        /**
         * Increase Brightness
         */
        private void increaseBrightness() {
            Bitmap originalImage = (Bitmap)pastImage;
            float brightness = 1.0f; // no change in brightness
            float contrast = 1.5f;
            float gamma = 1.0f; // no change in gamma
            var imageAttributes = new ImageAttributes();

            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
            new float[] {contrast, 0, 0, 0, 0}, // scale red
            new float[] {0, contrast, 0, 0, 0}, // scale green
            new float[] {0, 0, contrast, 0, 0}, // scale blue
            new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
            new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};


            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);

            using (var G = Graphics.FromImage(pastImage)) {  //Change the graphics of the image
                G.DrawImage(pastImage, 0, 0); //Draws base image first & Draws sepia's image on top
                G.DrawImage(originalImage, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel, imageAttributes);
                G.Dispose();
            }
            baseCanvas.Image = pastImage;
        }

        /**
         * Decrease Brightness
         */
        private void decreaseBrightness() {
            Bitmap originalImage = (Bitmap)pastImage;
            float brightness = 1.0f; // no change in brightness
            float contrast = 0.5f;
            float gamma = 1.0f; // no change in gamma
            var imageAttributes = new ImageAttributes();

            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
            new float[] {contrast, 0, 0, 0, 0}, // scale red
            new float[] {0, contrast, 0, 0, 0}, // scale green
            new float[] {0, 0, contrast, 0, 0}, // scale blue
            new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
            new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};


            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);

            using (var G = Graphics.FromImage(pastImage)) { //Change the graphics of the image
                G.DrawImage(pastImage, 0, 0); //Draws base image first & Draws sepia's image on top
                G.DrawImage(originalImage, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel, imageAttributes);
                G.Dispose();
            }
            baseCanvas.Image = pastImage;
        }

        /**
         * Prep Rotator
         */
        public void rotatePrep(Rectangle rect, Color selectedColor, float rotAngle) {
            try {
                recty = rect;
                chosenShade = selectedColor;
                RotateImg(rotAngle);
            }
            catch (ArgumentNullException) {

            }
        }

        /**
         * Rotate Image 
         */
        private void RotateImg(float rotAngle) {
            using (var G = Graphics.FromImage(pastImage)) { //Change the graphics of the image
                G.DrawImage(pastImage, 0, 0); //Draws base image first

                G.TranslateTransform((float)pastImage.Width / 2, (float)pastImage.Height / 2);
                G.RotateTransform(rotAngle); //Rotate
                G.TranslateTransform(-(float)pastImage.Width / 2, -(float)pastImage.Height / 2);
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //Draw the new image
                G.DrawImage(baseCanvas.Image, recty, recty.Left, recty.Top, recty.Right - recty.Left, recty.Bottom - recty.Top, GraphicsUnit.Pixel);
                G.Dispose();
            }
            baseCanvas.Image = pastImage;
        }

        public static Image Blur(Image pb, Rectangle rectum) {
            return new Bitmap((Bitmap)pb.Clone(), new Size(rectum.Width + 100, rectum.Height + 100));

        }
    }
}
