using ProbPotes.components;
using ProbPotes.components.participants;
using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.pages.participants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.pages
{
    public partial class ParticipantsPage : UserControl
    {
        public ParticipantsPage()
        {
            InitializeComponent();

            RefreshTiles();
        }

        public void RefreshTiles()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Participant> participants = DatabaseManager.Participants.Participants;

            foreach (Participant p in participants)
            {
                ParticipantTile tile = new ParticipantTile();
                tile.Participant = p;
                tile.ClickAction = EditParticipant;
                flowLayoutPanel1.Controls.Add(tile);
            }
        }

        private void EditParticipant(Participant p)
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Modifier un participant", 59642, new AddParticipantDialog(((MainForm)ParentForm).navigation.RefreshActualPage, p), this.ParentForm);
            DialogResult result = dialog.Open();
        }
    }
}
