using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System;

namespace Tabula
{
    class SavePicture
    {
        /**
         * Constructor
         */
        public SavePicture()
        {
            
        }

        /**
         * Save File as JPEG
         */
        public void saveJpeg(Image current) // Image imageToSave)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "JPEG (*.jpg|*.jpg";
            saveFile.FilterIndex = 1;

            string saveName = "";

            Image photoSave = current;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                saveName = CheckExtension(saveFile.FileName);
                photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        /**
         * Save File as Bitmap
         */
        public void saveBitmap(Image current)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "BMP (*.bmp|*.bmp";
            saveFile.FilterIndex = 1;

            string saveName = "";

            Image photoSave = current;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                saveName = CheckExtension(saveFile.FileName);
                photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        /**
         * Save File as PNG
         */
        public void savePng(Image current)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            //saveFile.FileOk += CheckExtension;
            saveFile.Filter = "PNG (*.png|*.png";
            saveFile.FilterIndex = 1;

            string saveName = "";

            Image photoSave = current;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                saveName = CheckExtension(saveFile.FileName);
                photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Png);
            }
            else { }
        }

        /**
         * Check File Extention
         */
        String CheckExtension(String sv)
        {
            if (Path.GetExtension(sv).ToLower() != ".png" || Path.GetExtension(sv).ToLower() != ".jpg" || Path.GetExtension(sv).ToLower() != ".jpeg" || Path.GetExtension(sv).ToLower() != ".bmp")
            {
                Console.WriteLine("Invalid extention.\nSaving as PNG");
                sv += ".png";
                Console.WriteLine(sv);
            }
            return sv;
        }
    }
}
