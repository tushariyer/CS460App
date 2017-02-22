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
    class SavePicture
    {
        public SavePicture()
        {
            //Constructor
        }

        public void saveJpeg(Image current) // Image imageToSave)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "JPEG (*.jpg|*.jpg";
            saveFile.FilterIndex = 1;

            string saveName = "";

            Image photoSave = current;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                saveName = saveFile.FileName;
                photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            MessageBox.Show("Saved as JPEG");
        }

        public void saveBitmap(Image current)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "BMP (*.bmp|*.bmp";
            saveFile.FilterIndex = 1;

            string saveName = "";

            Image photoSave = current;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                saveName = saveFile.FileName;
                photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            MessageBox.Show("Saved as Bitmap Image");
        }

        public void savePng(Image current)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "PNG (*.png|*.png";
            saveFile.FilterIndex = 1;

            string saveName = "";

            Image photoSave = current;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                saveName = saveFile.FileName;
                photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            MessageBox.Show("Saved as PNG Image");
        }
    }
}
