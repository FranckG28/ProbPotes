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

            Participant p = new Participant(20, "06 51 91 82 86", 2, 26.5, "AL HAMMUTI", "Sabrina", "sabrina080802@hotmail.fr");

            participantTile1.Participant = p;
        }
    }
}
