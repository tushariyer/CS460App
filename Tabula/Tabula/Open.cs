using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Tabula {
    class Open {
        /**
         * Constructor
         */
        public Open() {

        }

        /**
         * Uses OpenFileDialog to import an image and store it in an Image object.
         */
        public void importImage(PictureBox pb) {
            //Opens a dialog box to choose a file
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All Files (*.*)|*.*";
            openFile.FilterIndex = 1;

            string fileName = ""; //Includes path to file

            if (openFile.ShowDialog() == DialogResult.OK) {
                fileName = openFile.FileName;
                if (isImageType(fileName.ToLower())) {
                    pb.Size = Image.FromFile(fileName).Size;
                    pb.Image = Image.FromFile(fileName);
                }
                else {
                    MessageBox.Show("Please select an image file.");
                }
            }
            else {
                MessageBox.Show("Please select an image to import.");
            }
        }

        public bool isImageType(string dir) {
            //Check for image format. 
            return (dir.EndsWith(".png") || dir.EndsWith(".gif") || dir.EndsWith(".jpg") || dir.EndsWith(".jpeg") || dir.EndsWith(".ico") || dir.EndsWith(".bmp") || dir.EndsWith(".gif") || dir.EndsWith(".pdf"));
        }
    }
}
