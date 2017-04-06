using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace Tabula
{
    class Print
    {
        /**
         * Constructor
         */
        public Print()
        {

        }

        public void PrepPicture(Image toPrint)
        {
            //Note: If no picture is in the picturebox, Tabula will crash if you try to print
            toPrint = new Bitmap(toPrint);

            Graphics formGraphics = Graphics.FromImage(toPrint);

            PrintPicture(toPrint);

            formGraphics.Dispose();
            
        }

        private void PrintPicture(Image toPrint)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.PrintChecker;

            PrintDialog printSettings = new PrintDialog();

            PrintPreviewDialog preview = new PrintPreviewDialog();

            doc.DefaultPageSettings.Landscape = true;


            preview.Document = doc;
            printSettings.Document = doc;

            //Control the dialog boxes....
            if (printSettings.ShowDialog() == DialogResult.OK)
            {
                if (preview.ShowDialog() == DialogResult.OK)
                {
                    // This method returns immediately, before the print job starts.
                    // The PrintPage event will fire asynchronously.

                    doc.Print();
                }
            }
        }

        private void PrintChecker(object sender, PrintPageEventArgs ev)
        {
            // Indicate that this is the last page to print.
            ev.HasMorePages = false;
        }
    }
}
