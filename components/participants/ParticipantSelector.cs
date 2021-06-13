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

    // Gestionnaire de sélection de participants
    public partial class ParticipantSelector : UserControl
    {

        private List<int> ParticipantList = new List<int>();

        private List<int> excluded = new List<int>();

        private Boolean multiSelect = false;

        // Delegate de l'action à effectuer lors d'une sélection
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

        // Getter/Setter de la liste des participant sélectionnés
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int> SelectedParticipants
        {
            get => ParticipantList;
            set
            {
                // Pour chaque participant, le sélectionner si il est dans la liste
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    ParticipantSelectionTile tile = (ParticipantSelectionTile)c;
                    tile.Selected = value.Contains(tile.Participant.Code);
                }
                ParticipantList = value;
            }
        }

        // Setter de la liste des participants à ne pas afficher
        public void SetExcludedParticipant(List<int> value)
        { 
                excluded = value;
                RefreshParticipantList();
        }

        // Getter de la liste des participants à ne pas afficher
        public List<int> GetExcludedParticipants()
        {
            return excluded;
        }

        // Propriété définissant si le sélecteur accepte plusieurs choix
        public Boolean MultiSelection
        {
            get => multiSelect;
            set
            {
                multiSelect = value;
                btnSelectAll.Visible = value;
            }
        }

        // Procédure de rafraichissement de la liste des participants
        public void RefreshSelection()
        {
            // Création d'une nouvelle liste
            ParticipantList = new List<int>();

            // Pour chaque participant affiché
            foreach(Control c in flowLayoutPanel1.Controls)
            {
                ParticipantSelectionTile tile = (ParticipantSelectionTile)c;
                if (tile.Selected)
                {
                    // Si il est sélectionné, l'ajouter à la liste
                    ParticipantList.Add(tile.Participant.Code);
                }
            }
        }

        // Procédure de rafraichissement de la liste des participants
        public void RefreshParticipantList()
        {
            // Nettoyage de la liste
            flowLayoutPanel1.Controls.Clear();

            // Calcul de la taile d'un participant
            int width = flowLayoutPanel1.Width / 2 - 20;
            foreach (Participant p in DatabaseManager.Participants.Participants)
            {
                if (!excluded.Contains(p.Code))
                {
                    // Affichage de tous les participants sauf les exclus
                    ParticipantSelectionTile tile = new ParticipantSelectionTile();
                    tile.Participant = p;
                    tile.Selected = ParticipantList.Contains(p.Code);
                    tile.SelectAction = Selection;
                    tile.Width = width;
                    flowLayoutPanel1.Controls.Add(tile);
                }
            }
        }

        // Procédure lancé lorsqu'un participant est sélectionné
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
            
            // Rafraichir la liste des participants sélectionnés
            RefreshSelection();

            // Déclenchement de l'action si elle est définie
            if (SelectAction != null)
            {
                SelectAction(p.Code);
            }
        }

        // Bouton "Tout sélectionner"
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            // TRUE Si il faut tout sélectionner, sinon il, faut tout désélectionner
            Boolean select = ParticipantList.Count != (DatabaseManager.Participants.Participants.Count-excluded.Count);

            // Changement du texte du bouton en conséquence
            if (select)
            {
                btnSelectAll.Text = "Tout déselectionner";
            } else
            {
                btnSelectAll.Text = "Tout sélectionner";
            }

            // Pour chaque participant :
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                ParticipantSelectionTile tile = (ParticipantSelectionTile)c;
                tile.Selected = select; // Le cocher ou le décocher selon l'action choisir
            }

            // Rafraichissement de la liste des participants sélectionnés
            RefreshSelection();

        }
    }

}
