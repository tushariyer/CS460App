using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tabula
{
    class Meme
    {
        private TextBox topText, bottomText;
        private string userInput1,userInput2;

        //Takes in image from the main form and sets up meme(TM) text
        public Meme(Image image)
        {
            //Check to see if the user wants default meme text or nah
            
            //Get text from user if needed
            userInput1 = TextInput.TextDialog("Top Text", "Enter your text");
            userInput2 = TextInput.TextDialog("Bottom Text", "Enter your text");

            //Set text boxes to have text from user/default 
            //Also formatting text box size,position,etc. here

            //Returns(?) image to be placed on canvas afterward
        }

        //Method to handle setting default text
        private void SetTextDefault()
        {

        }


        //Method to handle setting user text
        private void SetTextUser()
        {

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
