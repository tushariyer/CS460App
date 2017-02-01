using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class MainForm : Form
    {

        //Instance
        public Bitmap photoOne;
        protected bool bSelected;
        protected int[] SelectOrigin = { 0, 0 };
        protected int[] SelectEnd = { 0, 0 };
        protected Graphics SelectionArea;
        protected bool bPen;
        private Color selectedColor;

        public MainForm()
        {
            InitializeComponent();
        }

        //File Drop down
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        //Import Photo Button
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
                //Opens a dialog box to choose a file
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "All Files (*.*)|*.*";
                openFile.FilterIndex = 1;

                string fileName = "";

                if(openFile.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFile.FileName;
                }
                else
                {
                    return; //K
                }

                //Places photo inside picture box
                //Hopefully sets the right resolution
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(fileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void jPEGToolStripMenuItem_Click(object sender, EventArgs e)
        {
                SaveFileDialog saveFile = new SaveFileDialog();

                saveFile.Filter = "JPEG (*.jpg)|*.jpg";
                saveFile.FilterIndex = 1;

                string saveName = "";

                Image photoSave = pictureBox1.Image;

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    saveName = saveFile.FileName;
                    photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
        }

        //
        private void bitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
                //Try to save
                SaveFileDialog saveFile = new SaveFileDialog();

                saveFile.Filter = "BMP (*.bmp)|*.bmp";
                saveFile.FilterIndex = 1;

                string saveName = "";

                Image photoSave = pictureBox1.Image;

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    saveName = saveFile.FileName;
                    photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
        }

        //Called when the user clicks inside the canvas requires both press and release.
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        //called when the user enters the picture box canvas with mouse, sets the cursor to the cross
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (bSelected)
            {
                this.Cursor = Cursors.Cross;
            }
        }
        //Called when the Mouse button has been pressed.
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (bSelected)
            {
                SelectOrigin[0] = Cursor.Position.X - 30;
                SelectOrigin[1] = Cursor.Position.Y - 47;
            }
        }

        //Called when the Mouse button has been released.
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //If in the selection mode then set the end cords for the selection tool box
            if (bSelected)
            {
                // Makes select box based off picture box location
                SelectEnd[0] = e.Location.X;
                SelectEnd[1] = e.Location.Y;
                //Draw the box to show what area the user has selected
                using (SelectionArea = this.pictureBox1.CreateGraphics())
                {
                    //SelectionArea.Clear(BackColor);
                    Pen pen = new Pen(Color.Azure, 2);
                    Brush brush = new SolidBrush(this.pictureBox1.BackColor);

                    SelectionArea.DrawRectangle(pen, SelectOrigin[0], SelectOrigin[1], SelectEnd[0] - SelectOrigin[0], SelectEnd[1] - SelectOrigin[1]);
                }

            }
        }

        //called when the user exits the picture box canvas with mouse, sets the cursor back to default
        private void pictureBox1_MouseExit(object sender, EventArgs e)
        {
           this.Cursor = Cursors.Default;
        }

        //Is called when the mouse is moved within the picture box/canvas
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Outputs the Current mouse cords
            MouseCords.Text = "Mouse Pos:  " + (Cursor.Position.X - 30).ToString() + " ," + (Cursor.Position.Y - 47).ToString();

            //Checks to see if the mouse button is still pressed down
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (bSelected)
                {
                    //draws a black rectangle
                    using (SelectionArea = this.pictureBox1.CreateGraphics())
                    {
                        //SelectionArea.
                        //SelectionArea.Clear(BackColor);
                        //Pen pen = new Pen(Color.Black, 2);
                        //Brush brush = new SolidBrush(this.pictureBox1.BackColor);

                        //SelectionArea.DrawRectangle(pen, SelectOrigin[0], SelectOrigin[1],  e.Location.X - SelectOrigin[0], e.Location.Y - SelectOrigin[1]);
                    }
                }
                if (bPen)
                {
                    using (SelectionArea = this.pictureBox1.CreateGraphics())
                    {
                        Pen pen = new Pen(Color.FromArgb(1,1,1,5));
                        Brush brush = new SolidBrush(selectedColor);

                        SelectionArea.FillRectangle(brush, Cursor.Position.X, Cursor.Position.Y, 10 , 10);
                    }
                }

            }
        }


        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dunno
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage; 
        }

        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Try to save
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "PNG (*.png)|*.png";
            saveFile.FilterIndex = 1;

            string saveName = "";

            Image photoSave = pictureBox1.Image;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                saveName = saveFile.FileName;
                photoSave.Save(saveName, System.Drawing.Imaging.ImageFormat.Png);
            }

        }

        //Works with the selection tool.
        //Takes an image finds the bounds of what needs to be changed via the selection tool, and then 
        //clones the image and applys a filter to the cloned image, then places that image where it resided before.
        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creation of values that are used to change the apperance of the image. this set of creates a sepia effect
            float[][] sepiaValues = {
            new float[]{.393f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
            };

            //Creates a drawing matrix
            System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);

            //Creates default Image Attributes because it's needed for the draw image function below
            System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
            //sets the image Attributes color matrix the 2D array above
            IA.SetColorMatrix(sepiaMatrix);

            //Creates a bitMap image that default value is whatever in currently on the canvas
            Bitmap sepiaEffect = (Bitmap)pictureBox1.Image.Clone();

            //Change the graphics of the image
            using (Graphics G = Graphics.FromImage(sepiaEffect))
            {
                //the x,y cords in the rectangle are to find where to place the edited section of the image
                //same with width and height
                G.DrawImage(pictureBox1.Image, new Rectangle(SelectOrigin[0],SelectOrigin[1], SelectEnd[0] - SelectOrigin[0], SelectEnd[1] - SelectOrigin[1]),
                   SelectOrigin[0], SelectOrigin[1], SelectEnd[0] - SelectOrigin[0], SelectEnd[1] - SelectOrigin[1], GraphicsUnit.Pixel, IA);
            }
            pictureBox1.Image = sepiaEffect;
            

            //MessageBox.Show("Currently Broken trying to fix :)");

        }

        //Sets the state of the current pane, allowing the select tool to be chosen
        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bSelected)
            {
                bSelected = false;
            }
            else
            {
                bSelected = true;
            }
        }

        //Clears the entire canvas
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bPen)
            {
                bPen = false;
            }
            else
            {
                bPen = true;
            }
        }

        //Color Selector tools
        private void selectColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
                colorSelected.BackColor = colorDialog1.Color;
            }
        }

        private void colorSelected_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(colorSelected, "Colour Currently Selected");
        }
    }

}
