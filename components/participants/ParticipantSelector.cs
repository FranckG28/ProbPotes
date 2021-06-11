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

        private List<int> ParticipantList = new List<int>();

        private List<int> excluded = new List<int>();

        private Boolean multiSelect = false;

        public delegate void Del(int pCode);

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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int> SelectedParticipants
        {
            get => ParticipantList;
            set
            {
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    ParticipantSelectionTile tile = (ParticipantSelectionTile)c;
                    tile.Selected = value.Contains(tile.Participant.Code);
                }
                ParticipantList = value;
            }
        }

        public void SetExcludedParticipant(List<int> value)
        { 
                excluded = value;
                RefreshParticipantList();
        }

        public List<int> GetExcludedParticipants()
        {
            return excluded;
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
            ParticipantList = new List<int>();
            foreach(Control c in flowLayoutPanel1.Controls)
            {
                ParticipantSelectionTile tile = (ParticipantSelectionTile)c;
                if (tile.Selected)
                {
                    ParticipantList.Add(tile.Participant.Code);
                }
            }
        }

        public void RefreshParticipantList()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Participant p in DatabaseManager.Participants.Participants)
            {
                if (!excluded.Contains(p.Code))
                {
                    ParticipantSelectionTile tile = new ParticipantSelectionTile();
                    tile.Participant = p;
                    tile.Selected = ParticipantList.Contains(p.Code);
                    tile.SelectAction = Selection;
                    flowLayoutPanel1.Controls.Add(tile);
                }
            }
        }

        public void Selection(Participant p )
        {
            // Tout décocher sauf le sélectionné si pas de multi sélection
            if (!multiSelect && !ParticipantList.Contains(p.Code))
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
                SelectAction(p.Code);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            Boolean select = ParticipantList.Count != (DatabaseManager.Participants.Participants.Count-excluded.Count);

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
