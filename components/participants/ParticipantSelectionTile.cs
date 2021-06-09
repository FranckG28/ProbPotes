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
    public partial class ParticipantSelectionTile : UserControl
    {

        private SelectableHoverController hover;
        private Participant participant;

        public ParticipantSelectionTile()
        {
            InitializeComponent();

            // Polices
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtFirstName.Font = new Font(Fonts.bold, 18);
                txtName.Font = new Font(Fonts.book, 12);
            }

            // Effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverBlue = new HoverColor(new List<Control>() { txtFirstName, txtName }, true, Colors.blue, Colors.blue, Colors.white);
            hover = new SelectableHoverController(new List<HoverColor>() { hoverBg, hoverBlue }, this);
        }

        public Boolean Selected
        {
            get => hover.Selected;
            set => hover.Selected = value;
        }

        public Participant Participant
        {
            get => participant;
            set
            {
                participant = value;
                txtFirstName.Text = participant.FirstName;
                txtName.Text = participant.Name.ToUpper();
            }
        }

        public delegate void Del(Participant p);
        public Del SelectAction;
        public Del UnselectAction;

        private void ParticipantSelectionTile_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
            if (Selected)
            {
                if (SelectAction != null)
                {
                    SelectAction(participant);
                }
            } else
            {
                if (UnselectAction != null)
                {
                    UnselectAction(participant);
                }
            }
        }
    }
}
