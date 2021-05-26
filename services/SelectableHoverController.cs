using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.services
{
    public class SelectableHoverController : HoverController
    {
        public SelectableHoverController(List<Control> bg, List<Control> fg, UserControl parent) : base(bg, fg, parent)
        {

        }

        protected bool isSelected = false;

        public bool Selected
        {
            get => isHover;
            set
            {
                isSelected = value;
                Refresh();
            }
        }


        public override void Refresh()
        {
            if (isPressed || isSelected)
            {
                SetForeground(fg_pressed);
                SetBackground(bg_pressed);

            }
            else if (isHover)
            {
                SetForeground(fg_hover);
                SetBackground(bg_hover);
            }
            else
            {
                SetForeground(fg_default);
                SetBackground(bg_default);
            }
        }

    }
}
