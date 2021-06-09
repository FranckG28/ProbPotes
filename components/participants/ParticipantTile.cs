using ProbPotes.managers;
using ProbPotes.models;
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

namespace ProbPotes.components.participants
{
    public partial class ParticipantTile : UserControl
    {

        private Participant participant;
        private HoverController hover;

        public ParticipantTile()
        {
            InitializeComponent();

            // Polices
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtFirstName.Font = new Font(Fonts.bold,18);
                txtName.Font = new Font(Fonts.book, 12);
                List<Label> labels = new List<Label>() { txtMail, txtShares, txtPhone };
                foreach(Label lbl in labels)
                {
                    lbl.Font = new Font(Fonts.book, 10);
                }
            }

            // Icones 
            iconPhone.Text = char.ConvertFromUtf32(0xE717);
            iconMail.Text = char.ConvertFromUtf32(0xE715);
            iconShares.Text = char.ConvertFromUtf32(0xE125);

            // Effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverBlue = new HoverColor(new List<Control>() { txtFirstName, txtName }, true, Colors.blue, Colors.blue, Colors.white);
            HoverColor hoverBlack = new HoverColor(new List<Control>() { txtShares, txtMail, txtPhone, iconMail, iconPhone, iconShares }, true, Colors.black, Colors.black, Colors.white);
            hover = new HoverController(new List<HoverColor>() { hoverBg, hoverBlack, hoverBlue }, this);

        }

        public Participant Participant
        {
            get => participant;
            set
            {
                participant = value;
                if (participant != null)
                {
                    txtFirstName.Text = participant.FirstName;
                    txtName.Text = participant.Name;
                    txtPhone.Text = participant.Phone;
                    txtMail.Text = participant.MailAddress;
                    txtShares.Text = participant.Shares.ToString() + (participant.Shares > 1 ? " parts" : " part");
                }
            }
        }

        public delegate void Del();

        public Del ClickAction;
        public Del RefreshDelegate;

        private void ParticipantTile_Click(object sender, EventArgs e)
        {
            if (ClickAction != null)
            {
                ClickAction();
            }
        }
        
    }
}
