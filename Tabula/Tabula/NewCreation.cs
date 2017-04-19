using System.Windows.Forms;

namespace Tabula
{
    class NewCreation : MultiTool
    {
        /**
         * Constructor
         */
        public NewCreation(PictureBox pictureBox)
        {
            importTemplate(pictureBox);
        }

        /**
         * Uses OpenFileDialog to import an image and store it in an Image object.
         */
        private void importTemplate(PictureBox pictureBox)
        {
            pictureBox.MaximumSize = Properties.Resources.Blank.Size;
            pictureBox.Image = Properties.Resources.Blank;
        }
    }
}
