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
                List<Label> labels = new List<Label>() { txtBalance, txtMail, txtShares, txtPhone };
                foreach(Label lbl in labels)
                {
                    lbl.Font = new Font(Fonts.regular, 11);
                }
            }

            // Icones 
            iconPhone.Text = char.ConvertFromUtf32(0xE717);
            iconMail.Text = char.ConvertFromUtf32(0xE715);
            iconShares.Text = char.ConvertFromUtf32(0xE125);
            iconBalance.Text = char.ConvertFromUtf32(0xE1D0);

            // Effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightBlue, Colors.blue, Colors.green);
            HoverColor hoverBlue = new HoverColor(new List<Control>() { txtFirstName, txtName }, true, Colors.blue, Colors.white, Colors.white);
            HoverColor hoverBlack = new HoverColor(new List<Control>() { txtBalance, txtShares, txtMail, txtPhone, iconBalance, iconMail, iconPhone, iconShares }, true, Colors.black, Colors.white, Colors.white);
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
                    txtFirstName.Text = participant.firstName;
                    txtName.Text = participant.name;
                    txtPhone.Text = participant.phone;
                    txtMail.Text = participant.mailAddress;
                    txtShares.Text = participant.shares.ToString();
                    txtBalance.Text = participant.balance.ToString() + " €";
                }
            }
        }

        public delegate void Del();

        public Del ClickAction;

        private void ParticipantTile_Click(object sender, EventArgs e)
        {
            if (ClickAction != null)
            {
                ClickAction();
            }
        }
    }
}
