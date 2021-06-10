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

        public Object Value;

        public ProbPotesSelector()
        {
            InitializeComponent();

            Init();

        }

        public ProbPotesSelector(string title, Object value)
        {
            InitializeComponent();

            Title = title;
            Value = value;

            Init();

        }

        private void Init()
        {
            // Polices et couleurs
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
                txtTitle.Font = new Font(Fonts.medium, 11);

            // Icon
            txtIcon.Visible = false;
            Icon = 59198;

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
                action(Value);
            }
            Selected = true;
        }
    }
}
