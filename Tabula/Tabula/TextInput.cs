using System.Windows.Forms;
using System.Drawing;

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
                Width = 275,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = defaultVal,
                StartPosition = FormStartPosition.CenterScreen
            };

            //Sets up control buttons and sets their individual properties(height,width,etc.)
            Label popupTitle = new Label() { Left = 20, Top = 10, Text = title};
            TextBox textBox = new TextBox() {Left = 20, Top = 40, Width = 200 };
            Button ok = new Button() {Text = "Enter", Left = 60, Top = 80, Width = 50, DialogResult = DialogResult.OK};
            ok.Click += (sender, e) => { popUp.Close(); };

            //Adds the buttons to the actual form
            popUp.Controls.Add(popupTitle);
            popUp.Controls.Add(textBox);
            popUp.Controls.Add(ok);
            popUp.AcceptButton = ok;

            //Returns string hopefully
            return popUp.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public static void placeText(PictureBox pb, Rectangle target) {
            Font userFont;
            FontDialog userFontInput = new FontDialog();
            if (userFontInput.ShowDialog() == DialogResult.OK)
            {
                userFont = new Font(userFontInput.Font.ToString(),userFontInput.Font.Size);
            }
            else
            {
                userFont = new Font("Calibri", 12);
            }
            //Get user input
            string userInput = TextInput.TextDialog("Text Box", "Enter your text:");

            Graphics.FromImage(pb.Image).DrawString(userInput, userFont, Brushes.White, target.Left,target.Top);
            pb.Refresh();
        }
    }
}
