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

            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Color.Transparent, Colors.red, Colors.lightRed);
            HoverColor hoverFg = new HoverColor(new List<Control>() { icon }, true, Colors.black, Colors.white, Colors.white);

            hover = new HoverController(new List<HoverColor>() { hoverBg, hoverFg }, this);

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
