using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;

namespace Tabula
{
    class Meme
    {
        private TextBox topText, bottomText;
        private string userInput1,userInput2;
        private PictureBox imageOnCanvas;
        private Font textFont;

        //Takes in image from the main form and sets up meme(TM) text
        public Meme(PictureBox image)
        {
            imageOnCanvas = image;
            //Check to see if the user wants default meme text or nah
            string messageBoxText = "Would you like to choose the font for this meme?";
            string caption = "Meme Generator";
            MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(messageBoxText, caption, button);

            switch(result)
            {
                case DialogResult.Yes:
                    SetTextUser();
                    break;
                case DialogResult.No:
                    SetTextDefault();
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }

            //Set text boxes to have text from user/default 
            //Also formatting text box size,position,etc. here

            //Returns(?) image to be placed on canvas afterward
        }

        //Method to handle setting default text
        private void SetTextDefault()
        {
            userInput1 = TextInput.TextDialog("Top Text", "Enter your text");
            userInput2 = TextInput.TextDialog("Bottom Text", "Enter your text");

            textFont = new Font("Impact", 50);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            

            Graphics.FromImage(imageOnCanvas.Image).DrawString(userInput1, textFont, Brushes.White, imageOnCanvas.Image.Width / 2, 0);
            Graphics.FromImage(imageOnCanvas.Image).DrawString(userInput2, textFont, Brushes.White, (imageOnCanvas.Image.Width / 2), imageOnCanvas.Image.Height * 0.85f);
            imageOnCanvas.Refresh();
        }


        //Method to handle setting user text
        private void SetTextUser()
        {
            userInput1 = TextInput.TextDialog("Top Text", "Enter your text");
            userInput2 = TextInput.TextDialog("Bottom Text", "Enter your text");
        }

        //Method to handle formatting
        private void FormatTextBox()
        {

        }

        //Method to render image without editable text boxes
        //private Image RenderMeme()
        //{

        //}

    }
}
