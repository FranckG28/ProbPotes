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

        private EventClass eventClass;

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
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightBlue, Colors.blue, Colors.green);
            HoverColor hoverForeBlue = new HoverColor(new List<Control>() { txtTitle }, true, Colors.blue, Colors.white, Colors.white);
            HoverColor hoverForeBlack = new HoverColor(new List<Control>() { txtParticipants, txtDate, iconParticipants }, true, Colors.black, Colors.white, Colors.white);

            hover = new HoverController(new List<HoverColor>() { hoverBg, hoverForeBlack, hoverForeBlue }, this);

            // Ajout de l'évènement Click à tout les controles
            foreach(Control ctrl in Controls)
            {
                ctrl.Click += new System.EventHandler(EventPreview_Click);
            }
        }

        public EventClass EventClass
        {
            get => eventClass;
            set
            {
                eventClass = value;
                if (eventClass != null)
                {
                    txtTitle.Text = eventClass.title;
                    txtDate.Text = eventClass.startDate.ToShortDateString() + " - " + eventClass.endDate.ToShortDateString();

                    // Génération de la liste des participants :
                    string participantList = "";
                    foreach(int participant in eventClass.guests)
                    {
                        participantList += participant.ToString() + ", ";
                    }
                    txtParticipants.Text = participantList;
                }
            }
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
