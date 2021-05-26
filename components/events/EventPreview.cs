using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProbPotes.models;
using ProbPotes.services;

namespace ProbPotes.components
{
    public partial class EventPreview : UserControl
    {

        private Evenement evenement;

        private HoverController hover;

        public EventPreview()
        {
            InitializeComponent();

            // Initialisation des icones :
            iconParticipants.Text = char.ConvertFromUtf32(0xEBDA);

            // Initialisation des polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.bold, 14);
                txtDate.Font = new Font(Fonts.regular, 10);
                txtParticipants.Font = new Font(Fonts.book, 10);
            }

            // Initialisation de l'effet de survol
            hover = new HoverController(new List<Control>() {this }, new List<Control>() { txtDate, txtParticipants, txtTitle, iconParticipants }, this);
            hover.bg_default = Colors.lightBlue;
            hover.bg_hover = Colors.blue;
            hover.bg_pressed = Colors.green;
            hover.fg_default = Colors.blue;
            hover.fg_hover = Colors.white;
            hover.fg_pressed = Colors.white;

            // Ajout de l'évènement Click à tout les controles
            foreach(Control ctrl in Controls)
            {
                ctrl.Click += new System.EventHandler(EventPreview_Click);
            }
        }

        public Evenement Evenement
        {
            get => evenement;
            set => evenement = value;
        }

        public delegate void Del();

        public Del ClickAction;

        private void EventPreview_Click(object sender, EventArgs e)
        {
            if (ClickAction != null)
            {
                ClickAction();
            }
        }
    }
}
