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

namespace ProbPotes.pages
{
    public partial class EventsPage : UserControl
    {
        public EventsPage()
        {
            InitializeComponent();

            // Icones 
            iconParticipants.Text = char.ConvertFromUtf32(0xE716);
            iconSoldOut.Text = char.ConvertFromUtf32(0xE895);

            // Polices
            txtTitle.Font = new Font(Fonts.bold, 18);
            txtDates.Font = new Font(Fonts.book, 13);
            txtDescription.Font = new Font(Fonts.regular, 11);
            txtParticipants.Font = new Font(Fonts.regular, 11);
            txtSoldOn.Font = new Font(Fonts.regular, 11);
            txtCreator.Font = new Font(Fonts.book, 11);
            txtIndex.Font = new Font(Fonts.medium, 14);

            // Couleurs
            pnlEvent.BackColor = Colors.lightBlue;
            txtTitle.ForeColor = Colors.blue;
            txtDates.ForeColor = Colors.blue;
            txtCreator.ForeColor = Colors.blue;
            txtDescription.ForeColor = Colors.black;
            txtIndex.ForeColor = Colors.black;
            txtParticipants.ForeColor = Colors.black;
            txtSoldOn.ForeColor = Colors.black;
            iconParticipants.ForeColor = Colors.black;
            iconSoldOut.ForeColor = Colors.black;
            foreach (Control ctrl in Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.BackColor = Color.Transparent;
                }
            }

        }
    }
}
