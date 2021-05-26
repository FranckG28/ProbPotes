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
    public partial class CloseBtn : UserControl
    {

        HoverController hover;

        public CloseBtn()
        {
            InitializeComponent();

            hover = new HoverController(new List<Control>() { this }, new List<Control>() { icon }, this);

            hover.bg_default = Color.Transparent;
            hover.bg_hover = Colors.red;
            hover.bg_pressed = Colors.lightRed;

            hover.fg_default = Colors.black;
            hover.fg_hover = Color.White;
            hover.fg_pressed = Color.White;

            icon.Text = Char.ConvertFromUtf32(0xE711);
        }

        public delegate void CloseDel();

        public CloseDel ClickEvent;

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            ClickEvent();
        }

    }
}
