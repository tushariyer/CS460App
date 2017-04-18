using System;
using System.Windows.Forms;

namespace Tabula
{
    class QuitApp
    {
        public QuitApp()
        {
            //constructor
        }

        public void beginQuit(PictureBox canvas)
        {
            DialogResult WaitASec = MessageBox.Show("Are you sure you want to quit?", "Save your work!", MessageBoxButtons.OKCancel);

            switch (WaitASec)
            {
                case DialogResult.Yes: ByeBye();
                    break;
                case DialogResult.Cancel: MessageBox.Show("Returning to App...");
                    break;
            }
        }

        private static void ByeBye()
        {
            System.Environment.Exit(0);
            System.Windows.Forms.Application.Exit();
        }
    }
}
