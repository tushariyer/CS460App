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
            DrawText("Impact",50);
        }


        //Method to handle setting user text
        private void SetTextUser()
        {
            
        }

        //Method to handle formatting
        private void FormatTextBox()
        {

        }

        private void DrawText(String fontStyle, int fontSize)
        {
            //Takes in user input for top and bottom text
            userInput1 = TextInput.TextDialog("Top Text", "Enter your text");
            userInput2 = TextInput.TextDialog("Bottom Text", "Enter your text");

            //Sets font stlye, size, and centers it in the "text box"
            textFont = new Font(fontStyle, fontSize);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;

            //Size object to test string width
            Size textSize = new Size();
            //Measures first text size
            textSize = TextRenderer.MeasureText(userInput1, textFont);
            //Draws text at top of screen and centered
            //Width / 2 - textWidth
            Graphics.FromImage(imageOnCanvas.Image).DrawString(userInput1, textFont, Brushes.White, (imageOnCanvas.Image.Width) / 2 - (textSize.Width), 0);
            //Draws text at bottom of screen and centered
            //Width / 2 - textWidth
            //85% of the way down the canvas
            textSize = TextRenderer.MeasureText(userInput2, textFont);
            Graphics.FromImage(imageOnCanvas.Image).DrawString(userInput2, textFont, Brushes.White, (imageOnCanvas.Image.Width / 2) - (textSize.Width), imageOnCanvas.Image.Height * 0.85f);

            //Refreshes pictureBox
            imageOnCanvas.Refresh();
        }
    }
}
