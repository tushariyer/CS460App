using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace Tabula
{
    //Implementations of Action[Interface] and Tool[Interface]. See UML for details
    class MultiTool
    {
        //Instance
        protected string ToolTitle;
        protected bool IsActive;

        public MultiTool()
        {
            //Constructor
        }

        private void ActivateTool()
        {
            IsActive = true;
            //Add stuff here to make the tool the focus on screen.
        }

        private void DeactivateTool()
        {
            IsActive = false;
            //Add stuff here to make the default cursor active.
        }
    }
}
