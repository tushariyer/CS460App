using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
            pictureBox.Image = Properties.Resources.Blank;
        }
    }
}
