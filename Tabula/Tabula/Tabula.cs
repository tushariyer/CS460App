using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabula
{
    public partial class Tabula : Form
    {
        public static Stack<Image> GlobalUndoStack;
        public static Stack<Image> GlobalRedoStack;
        private Color selectedColor;


        public Tabula()
        {
            InitializeComponent();
        }

        /**
         * File Import Object created here. Redirects to Open.cs
         */
        private void openFileButton_Click(object sender, EventArgs e)
        {
            Open newPic = new Open(); //Create new Open Object
            baseCanvas.Image = newPic.importImage(); //USe the importImage method to assign a picture to the PictureBox
        }

        /**
         * Save methods start here
         */
        
        /**
         * Save File as JPEG
         */
        private void saveAsJPEG_Click(object sender, EventArgs e)
        {
            SavePicture jpeg = new SavePicture(); //New SavePicture Object
            jpeg.saveJpeg(baseCanvas.Image); 
        }

        /**
         * Save File as Bitmap
         */
        private void saveAsBitmap_Click(object sender, EventArgs e)
        {
            SavePicture bmp = new SavePicture(); //New SavePicture Object
            bmp.saveBitmap(baseCanvas.Image);
        }

        /**
         * Save File as PNG
         */
        private void saveAsPNG_Click(object sender, EventArgs e)
        {
            SavePicture png = new SavePicture(); //New SavePicture Object
            png.savePng(baseCanvas.Image);
        }

        /**
         * Canvas Click Method
         */
        private void baseCanvas_Click(object sender, EventArgs e)
        {

        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorSelector colorGrid = new ColorSelector();

            //Passes the ColorDialog from the form to ColorSelector so it can allow the user to choose. Stores the value in selectedColor. Other methods can use it.
            selectedColor = colorGrid.displayShades(availableColors); 
        }

        private void newFileButton_Click(object sender, EventArgs e)
        {
            NewCreation newBlank = new NewCreation();
            newBlank.importTemplate();
        }

        //Action Class Methods. See UML (Also, general functions that aren't Tool-specific.)
    }
}
