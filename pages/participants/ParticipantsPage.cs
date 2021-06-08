using ProbPotes.components.participants;
using ProbPotes.managers;
using ProbPotes.models;
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
                flowLayoutPanel1.Controls.Add(tile);
            }
        }
    }
}
