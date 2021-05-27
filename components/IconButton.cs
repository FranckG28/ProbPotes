using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.components
{
    public partial class IconButton : UserControl
    {

        HoverController hover;

        public IconButton()
        {
            InitializeComponent();

            Icon = iconInt;

            // Effets de survol :
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Color.Transparent, Colors.blue, Colors.green);
            HoverColor hoverFg = new HoverColor(new List<Control>() { icon }, true, Colors.blue, Colors.white, Colors.white);
            hover = new HoverController(new List<HoverColor>() { hoverBg, hoverFg }, this);
            
        }

        private int iconInt = 0xE008;

        public int Icon
        {
            get => iconInt;
            set
            {
                icon.Text = char.ConvertFromUtf32(value);
                iconInt = value;
            }
        }

        public void SetBgColor(Color defaultColor, Color hoverColor, Color pressedColor)
        {
            hover.Colors[0].Default = defaultColor;
            hover.Colors[0].Hover = hoverColor;
            hover.Colors[0].Pressed = pressedColor;
        }

        public void SetFgColor(Color defaultColor, Color hoverColor, Color pressedColor)
        {
            hover.Colors[1].Default = defaultColor;
            hover.Colors[1].Hover = hoverColor;
            hover.Colors[1].Pressed = pressedColor;
        }

        public delegate void Del();
        public object Argument;
        public Del ClickAction;

        private void IconButton_Click(object sender, EventArgs e)
        {
            if (ClickAction != null)
            {
                ClickAction();
            }
        }
    }
}
