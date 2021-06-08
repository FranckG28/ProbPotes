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
    public partial class ProbPotesSelector : UserControl
    {

        private SelectableHoverController hover; 

        public ProbPotesSelector()
        {
            InitializeComponent();

            // Polices et couleurs
            txtTitle.Font = new Font(Fonts.medium, 11);

            // Icon
            txtIcon.Visible = false;

            // Effet de survol :
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGreen1, Colors.lightGreen2, Colors.green);
            HoverColor hoverFg = new HoverColor(new List<Control>() { txtTitle, txtIcon }, true, Colors.black, Colors.black, Colors.white);

            hover = new SelectableHoverController(new List<HoverColor>() { hoverBg, hoverFg }, this);

        }

        [Description("Titre de l'élément"), Category("Data")]
        public string Title
        {
            get => txtTitle.Text;
            set => txtTitle.Text = value;
        }

        public delegate void SelectorAction(Object arg);

        public SelectorAction action;
        public Object argument;
        private int iconInt = 59198;

        public bool Selected
        {
            get => hover.Selected;
            set { hover.Selected = value; txtIcon.Visible = value; }
        }

        public int Icon
        {
            get => iconInt;
            set { iconInt = value; txtIcon.Text = char.ConvertFromUtf32(iconInt); }
        }

        private void ProbPotesSelector_Click(object sender, EventArgs e)
        {
            if (action != null)
            {
                action(argument);
            }
            Selected = true;
        }
    }
}
