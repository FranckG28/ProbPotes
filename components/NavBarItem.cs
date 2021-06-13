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

            // Polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.book, 14);
            }

            // Effet de survol :
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Color.Transparent, Colors.lightBlue, Colors.white);
            HoverColor hoverFg = new HoverColor(new List<Control>() { txtIcon, txtTitle }, true, Colors.white, Colors.white, Colors.blue);

            hover = new SelectableHoverController(new List<HoverColor>() {hoverBg, hoverFg }, this);

        }


        [Description("Titre de l'élément"), Category("Data")]
        public string Title
        {
            get => txtTitle.Text;
            set => txtTitle.Text = value;
        }

        // Code de l'icone
        private int iconInt = 0xE711;

        // TRUE si l'élément est sélectionné
        public bool Selected
        {
            get => hover.Selected;
            set { hover.Selected = value; }
        }

        // Getter/Setter de l'icone
        public int Icon
        {
            get => iconInt;
            set { iconInt = value; txtIcon.Text = char.ConvertFromUtf32(iconInt); }
        }

        // Action au clic 
        public delegate void NavbarAction(NavigationTemplate destination);
        public NavbarAction action;
        public NavigationTemplate page;

        private void NavBarItem_Click(object sender, EventArgs e)
        {
            if (action != null)
            {
                action(page);
            }
        }

    }
}
