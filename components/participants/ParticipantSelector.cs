using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.components.participants
{
    public partial class ParticipantSelector : UserControl
    {

        private List<Participant> ParticipantList = new List<Participant>();

        private Boolean multiSelect = false;

        public delegate void Del(Participant p);

        public Del SelectAction;

        public ParticipantSelector()
        {
            InitializeComponent();

            // Design des boutons
            List<Button> buttons = new List<Button>() { btnSelectAll };
            foreach(Button btn in buttons)
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
                    btn.Font = new Font(Fonts.medium, 11);
                btn.BackColor = Colors.lightGreen2;
                btn.FlatAppearance.MouseOverBackColor = Colors.green;
                btn.FlatAppearance.MouseDownBackColor = Colors.blue;
            }

            // Masquer le bouton tout sélectionner
            btnSelectAll.Visible = false;

            // Ajout des participants :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                RefreshParticipantList();
                RefreshSelection();
            }

        }

        public List<Participant> SelectedParticipants
        {
            get => ParticipantList;
        }

        public Boolean MultiSelection
        {
            get => multiSelect;
            set
            {
                multiSelect = value;
                btnSelectAll.Visible = value;
            }
        }

        public void RefreshSelection()
        {
            ParticipantList = new List<Participant>();
            foreach(Control c in flowLayoutPanel1.Controls)
            {
                ParticipantSelectionTile tile = (ParticipantSelectionTile)c;
                if (tile.Selected)
                {
                    ParticipantList.Add(tile.Participant);
                }
            }
        }

        public void RefreshParticipantList()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Participant p in DatabaseManager.Participants.Participants)
            {
                ParticipantSelectionTile tile = new ParticipantSelectionTile();
                tile.Participant = p;
                tile.Selected = ParticipantList.Contains(p);
                tile.SelectAction = Selection;
                flowLayoutPanel1.Controls.Add(tile);
            }
        }

        public void Selection(Participant p )
        {
            // Tout décocher sauf le sélectionné si pas de multi sélection
            if (!multiSelect && !ParticipantList.Contains(p))
            {
                foreach(Control c in flowLayoutPanel1.Controls)
                {
                    ParticipantSelectionTile tile = (ParticipantSelectionTile)c;
                    if (tile.Participant != p)
                    {
                        tile.Selected = false;
                    }
                }

            }

            RefreshSelection();

            if (SelectAction != null)
            {
                SelectAction(p);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            Boolean select = ParticipantList.Count != DatabaseManager.Participants.Participants.Count;

            if (select)
            {
                btnSelectAll.Text = "Tout déselectionner";
            } else
            {
                btnSelectAll.Text = "Tout sélectionner";
            }
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                ParticipantSelectionTile tile = (ParticipantSelectionTile)c;
                tile.Selected = select;
            }
            RefreshSelection();

        }
    }

}
