using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabula
{
    public partial class Tabula : Form
    {
        public static Stack<Image> GlobalUndoStack;
        public static Stack<Image> GlobalRedoStack;

        public Tabula()
        {
            InitializeComponent();
        }
    }
}
