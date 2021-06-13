using ProbPotes.components;
using ProbPotes.components.participants;
using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.pages.events;
using ProbPotes.pages.participants;
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

namespace ProbPotes.pages
{
    public partial class EventsPage : UserControl
    {

        private EventNavigation nav;

        public EventsPage()
        {
            InitializeComponent();

            // Icones 
            iconParticipants.Text = char.ConvertFromUtf32(0xE716);
            iconCreator.Text = char.ConvertFromUtf32(59642);

            // Polices
            txtTitle.Font = new Font(Fonts.bold, 24);
            txtDateStart.Font = new Font(Fonts.book, 16);
            txtDatesSeparator.Font = new Font(Fonts.book, 16);
            txtDateEnd.Font = new Font(Fonts.book, 16);
            txtDescription.Font = new Font(Fonts.regular, 11);
            
            chkSold.Font = new Font(Fonts.bold, 14);
            txtDetails.Font = new Font(Fonts.medium, 14);

            Font fnt1 = new Font(Fonts.bold, 12);

            lblCreator.Font = fnt1;
            lblParticipants.Font = fnt1;

            txtIndex.Font = new Font(Fonts.medium, 14);
            txtCount.Font = new Font(Fonts.medium, 14);
            

            // Couleurs
            txtTitle.ForeColor = Colors.blue;
            txtDateStart.ForeColor = Colors.blue;
            txtDatesSeparator.ForeColor = Colors.blue;
            txtDateEnd.ForeColor = Colors.blue;
            
            txtDescription.ForeColor = Colors.black;
            txtIndex.ForeColor = Colors.black;
            txtCount.ForeColor = Colors.black;
            lblParticipants.ForeColor = Colors.black;
            chkSold.ForeColor = Colors.black;
            
            txtDetails.ForeColor = Colors.black;
            iconCreator.ForeColor = Colors.black;

            lblCreator.ForeColor = Colors.black;
            iconParticipants.ForeColor = Colors.black;
            iconCreator.ForeColor = Colors.black;
            lblParticipants.ForeColor = Colors.black;

            // Supprimer les couleurs de fond
            pnlDates.BackColor = Color.Transparent;

            foreach (Control ctrl in pnlEvent.Controls)
            {
                if (ctrl is Label || ctrl is CheckBox)
                {
                    ctrl.BackColor = Color.Transparent;
                }
            }
            foreach (Control ctrl in pnlDates.Controls)
            {
                if (ctrl is Label || ctrl is CheckBox)
                {
                    ctrl.BackColor = Color.Transparent;
                }
            }

            // Ajout des évènements 
            btnFirst.ClickAction = ButtonFirst;
            btnLast.ClickAction = ButtonLast;
            btnNext.ClickAction = ButtonNext;
            btnPrevious.ClickAction = ButtonPrevious;
            btnEdit.ClickAction = Edit;

            // Recuperation des evènement :
            nav = DatabaseManager.Events.GetEventNavigator();

            // Initialisation des labels
            AddBinding(txtTitle, "titreEvent");
            AddBinding(txtIndex, "codeEvent");
            AddBinding(txtDateStart, "dateDebut");
            AddBinding(txtDateEnd, "dateFin");
            AddBinding(txtDescription, "description");
            chkSold.DataBindings.Add("checked", nav.eventBs, "soldeON", true);
            Binding bind = new Binding("visible", nav.eventBs, "soldeON");

            bind.Format += SwitchBool;
            bind.Parse += SwitchBool;

            btnEdit.DataBindings.Add(bind);

            // Rafraichissement des boutons 
            RefreshInterface();

            // Affichage du nombre d'évènement 
            txtCount.Text = "/ " + nav.EventCount;

        }

        private void SwitchBool(object sender, ConvertEventArgs e)
        {
            e.Value = !(bool)e.Value;
            chkSold.Text = !(bool)e.Value ? "Soldé" : "Non soldé";
        }

        private void AddBinding(Label lbl, string name)
        {
            lbl.DataBindings.Add("text", nav.eventBs, name, true);
        }

        private void RefreshInterface()
        {

            // Activation/Désactivation des boutons :
            bool showPrevious = nav.Index >1;
            bool showNext = nav.Index < nav.EventCount;

            btnFirst.Visible = showPrevious;
            btnPrevious.Visible = showPrevious;
            btnNext.Visible = showNext;
            btnLast.Visible = showNext;

            // Affichage du créateur de l'evènement
            participantCreator.Participant = nav.Creator;
            participantCreator.IsSelectable = false;
            participantCreator.SelectAction = EditParticipant;

            // Affichage des participants à l'évènement
            pnlParticipants.Controls.Clear();
            foreach(Participant p in nav.ParticipantList)
            {
                ParticipantSelectionTile tile = new ParticipantSelectionTile();
                tile.Participant = p;
                tile.Width = pnlParticipants.Width / 2 - 20;
                tile.IsSelectable = false;
                tile.SelectAction = EditParticipant;
                pnlParticipants.Controls.Add(tile);
            }

            // Affichage des détails
            EventClass evt = nav.Event;
            Decimal expenseAmount = evt.Expenses.GetExpenseSum(); 
            int expenseCount = evt.Expenses.Expenses.Count;
            txtDetails.Text = expenseCount + (expenseCount == 1 ? " dépense " : " dépenses ") + "pour un total de " + expenseAmount + " €";

        }

        private void EditParticipant(Participant p)
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Modifier un participant", 59642, new AddParticipantDialog(((MainForm)ParentForm).navigation.RefreshActualPage, p), this.ParentForm);
            DialogResult result = dialog.Open();
        }

        private void ButtonNext()
        {
            nav.NextButton();
            RefreshInterface();
        }

        private void ButtonLast()
        {
            nav.LastButton();
            RefreshInterface();
        }

        private void ButtonPrevious()
        {
            nav.PreviousButton();
            RefreshInterface();
        }

        private void ButtonFirst()
        {
            nav.FirstButton();
            RefreshInterface();
        }

        private void Edit()
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Modifier un évènement", 59601, new AddEventDialog(((MainForm)ParentForm).navigation.RefreshActualPage, DatabaseManager.Events.GetEvent(Convert.ToInt32(txtIndex.Text))), this.ParentForm);
            DialogResult result = dialog.Open();
        }

        private void iconParticipants_Click(object sender, EventArgs e)
        {

        }

        private void lblParticipants_Click(object sender, EventArgs e)
        {

        }
    }
}
