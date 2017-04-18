using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace Tabula
{
    class Print
    {
        //Variable that holds the image to print
        private Image imageToPrint;

        /**
         * Constructor
         */
        public Print(Image toPrint)
        {
            PrepPicture(toPrint);
        }

        private void PrepPicture(Image toPrint)
        {
            //Note: If no picture is in the picturebox, Tabula will crash if you try to print
            imageToPrint = toPrint;
            PrintPicture(toPrint);   
        }

        private void PrintPicture(Image toPrint)
        {
            //New print document object
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.PrintChecker;
            
            //Sets up print dialog windows
            PrintDialog printSettings = new PrintDialog();
            PrintPreviewDialog preview = new PrintPreviewDialog();

            //Default view is landscape
            doc.DefaultPageSettings.Landscape = true;

            //Passes the print document into the dialog windows (I think?)
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
                    //Intended to close the preview after doesnt work
                    doc.Dispose();
                    preview.Dispose();
                    printSettings.Dispose();
                }
            }
        }

        private void PrintChecker(object sender, PrintPageEventArgs ev)
        {
            //Draws the image to the print preview panel at top left corner
            Point location = new Point(0, 0);
            ev.Graphics.DrawImage(imageToPrint, location);
            // Indicate that this is the last page to print.
            ev.HasMorePages = false;
        }
    }
}
