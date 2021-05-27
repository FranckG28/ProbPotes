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
        public SelectableHoverController(List<HoverColor> colors, UserControl parent) : base(colors, parent)
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
            foreach (HoverColor hoverColor in Colors)
            {
                if (isPressed || isSelected)
                {
                    hoverColor.SetPressed();
                }
                else if (isHover)
                {
                    hoverColor.SetHover();
                }
                else
                {
                    hoverColor.SetDefault();
                }
            }
        }

    }
}
