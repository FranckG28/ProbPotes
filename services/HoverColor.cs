using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.services
{
    public class HoverColor
    {

        public Color Default;
        public Color Hover;
        public Color Pressed;

        public bool isForeColor;

        public List<Control> Controls;

        public HoverColor(List<Control> ctrlList, bool isForeColor, Color defaultColor, Color hoverColor, Color pressedColor)
        {
            this.Controls = ctrlList;
            this.isForeColor = isForeColor;
            this.Default = defaultColor;
            this.Hover = hoverColor;
            this.Pressed = pressedColor;
        }

        public void SetDefault()
        {
            SetColor(Default);
        }

        public void SetHover()
        {
            SetColor(Hover);
        }

        public void SetPressed()
        {
            SetColor(Pressed);
        }

        private void SetColor(Color color)
        {
            foreach(Control ctrl in Controls)
            {
                if (isForeColor)
                {
                    ctrl.ForeColor = color;
                    ctrl.BackColor = Color.Transparent;
                } else
                {
                    ctrl.BackColor = color;
                }
            }
        }

    }
}
