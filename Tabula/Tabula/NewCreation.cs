using System;
using System.IO;
using System.Windows.Forms;

namespace Tabula {
    class NewCreation : MultiTool {
        /**
         * Constructor
         */
        public NewCreation(PictureBox pictureBox) {
            importTemplate(pictureBox);
        }

        /**
         * Uses OpenFileDialog to import an image and store it in an Image object.
         */
        private void importTemplate(PictureBox pictureBox) {
            pictureBox.Size = Properties.Resources.Blank.Size;
            pictureBox.Image = Properties.Resources.Blank;
        }

        /**
         * Check File Extention
         */
        String CheckExtension(String sv) {
            if (Path.GetExtension(sv).ToLower() != ".png" || Path.GetExtension(sv).ToLower() != ".jpg" || Path.GetExtension(sv).ToLower() != ".jpeg" || Path.GetExtension(sv).ToLower() != ".bmp") {
                Console.WriteLine("Invalid extention.\nSaving as PNG");
                sv += ".png";
                Console.WriteLine(sv);
            }
            return sv;
        }
    }
}
