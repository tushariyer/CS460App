using System.Drawing;
using System.Windows.Forms;

namespace Tabula
{
    class ColorSelector : MultiTool
    {
        //Instance
        private Color currentColor;
        /**
         * Constructor
         */
        public ColorSelector()
        {

        }

        /**
         * Method that allows the user to select a color. Can then be assigned to tools or to fill
         */
        public Color displayShades(ColorDialog availableColors)
        {
            if (availableColors.ShowDialog() == DialogResult.OK)
            {
                //assigns the color selected from the parameter to a variable
                currentColor = availableColors.Color;
            }
            return currentColor; //Sends it back to Tabula Handler
        }
    }
}
//Tushar Iyer