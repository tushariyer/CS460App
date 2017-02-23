using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Tabula
{
    class Open
    {
        /**
         * Constructor
         */
        public Open()
        {

        }

        /**
         * Uses OpenFileDialog to import an image and store it in an Image object.
         */
        public Image importImage()
        {
            //Opens a dialog box to choose a file
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All Files (*.*)|*.*";
            openFile.FilterIndex = 1;

            string fileName = ""; //Includes path to file

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
            }
            else
            {
                MessageBox.Show("Please select an image to import.");
                return null; // Because why not
            }

            return Image.FromFile(fileName); //Send it back to Tabula handler. it will get assigned to the PictureBox there.
        }
    }
}
