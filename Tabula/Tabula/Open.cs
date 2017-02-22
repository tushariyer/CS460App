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
        public Open()
        {

        }

        public Image importImage()
        {
            //Opens a dialog box to choose a file
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All Files (*.*)|*.*";
            openFile.FilterIndex = 1;

            string fileName = "";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
            }
            else
            {
                MessageBox.Show("Please select an image to import.");
                return null; //K
            }

            return Image.FromFile(fileName);
        }
    }
}
