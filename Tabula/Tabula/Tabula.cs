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


        public Tabula()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            Open newPic = new Open();
            //Places photo inside picture box
            //baseCanvas.SizeMode = PictureBoxSizeMode.Zoom;
            baseCanvas.Image = newPic.importImage();
        }

        private void saveAsJPEG_Click(object sender, EventArgs e)
        {
            SavePicture jpeg = new SavePicture();
            jpeg.saveJpeg(baseCanvas.Image);
        }

        private void saveAsBitmap_Click(object sender, EventArgs e)
        {
            SavePicture bmp = new SavePicture();
            bmp.saveBitmap(baseCanvas.Image);
        }

        private void saveAsPNG_Click(object sender, EventArgs e)
        {
            SavePicture png = new SavePicture();
            png.savePng(baseCanvas.Image);
        }

        private void baseCanvas_Click(object sender, EventArgs e)
        {

        }

        //Action Class Methods. See UML (Also, general functions that aren't Tool-specific.)
    }
}
