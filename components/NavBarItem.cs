using ProbPotes.models;
using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.components
{
    public partial class NavBarItem : UserControl
    {

        private SelectableHoverController hover;

        public NavBarItem()
        {
            InitializeComponent();
            txtIcon.Text = Char.ConvertFromUtf32(0xE78B);

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.book, 14);
            }

            hover = new SelectableHoverController(new List<Control>() {this }, new List<Control>() {txtIcon, txtTitle }, this);

            hover.bg_default = Color.Transparent;
            hover.bg_hover = Colors.lightBlue;
            hover.bg_pressed = Colors.white;
            hover.fg_default = Colors.white;
            hover.fg_hover = Colors.white;
            hover.fg_pressed = Colors.blue;
        }


        [Description("Titre de l'élément"), Category("Data")]
        public string Title
        {
            get => txtTitle.Text;
            set => txtTitle.Text = value;
        }

        public delegate void NavbarAction(NavigationTemplate destination);

        public NavbarAction action;
        public NavigationTemplate page;
        private int iconInt = 0xE711;

        public bool Selected
        {
            get => hover.Selected;
            set { hover.Selected = value; }
        }

        public int Icon
        {
            get => iconInt;
            set { iconInt = value; txtIcon.Text = char.ConvertFromUtf32(iconInt); }
        }

        private void NavBarItem_Click(object sender, EventArgs e)
        {
            if (action != null)
            {
                action(page);
            }
        }

    }
}
