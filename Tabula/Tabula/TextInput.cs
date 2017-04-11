using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabula
{
    //Class used to pop up an input dialog box for text input
    public static class TextInput
    {
        public static string TextDialog(string title, string defaultVal)
        {
            //Creates new form with these properties
            Form popUp = new Form()
            {
                Width = 300,
                Height = 100,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = defaultVal,
                StartPosition = FormStartPosition.CenterScreen
            };

            //Sets up control buttons and sets their individual properties(height,width,etc.)
            Label popupTitle = new Label() { Left = 20, Top = 10, Text = title};
            TextBox textBox = new TextBox() {Left = 20, Top = 50, Width = 200 };
            Button ok = new Button() {Text = "Enter", Left = 150, Top = 90, Width = 50, DialogResult = DialogResult.OK};
            ok.Click += (sender, e) => { popUp.Close(); };

            //Adds the buttons to the actual form
            popUp.Controls.Add(popupTitle);
            popUp.Controls.Add(textBox);
            popUp.Controls.Add(ok);
            popUp.AcceptButton = ok;

            //Returns string hopefully
            return popUp.ShowDialog() == DialogResult.OK ? textBox.Text : "";        }
    }
}
