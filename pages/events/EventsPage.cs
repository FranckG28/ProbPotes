using ProbPotes.components;
using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.pages.events;
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
            iconSoldOut.Text = char.ConvertFromUtf32(0xE895);

            // Polices
            txtTitle.Font = new Font(Fonts.bold, 18);
            txtDateStart.Font = new Font(Fonts.book, 13);
            txtDatesSeparator.Font = new Font(Fonts.book, 13);
            txtDateEnd.Font = new Font(Fonts.book, 13);
            txtDescription.Font = new Font(Fonts.regular, 11);
            txtParticipants.Font = new Font(Fonts.regular, 11);
            chkSold.Font = new Font(Fonts.regular, 11);
            txtCreator.Font = new Font(Fonts.book, 11);
            txtIndex.Font = new Font(Fonts.medium, 14);
            txtCount.Font = new Font(Fonts.medium, 14);

            // Couleurs
            pnlEvent.BackColor = Colors.lightGrey;
            txtTitle.ForeColor = Colors.blue;
            txtDateStart.ForeColor = Colors.blue;
            txtDatesSeparator.ForeColor = Colors.blue;
            txtDateEnd.ForeColor = Colors.blue;
            txtCreator.ForeColor = Colors.blue;
            txtDescription.ForeColor = Colors.black;
            txtIndex.ForeColor = Colors.black;
            txtCount.ForeColor = Colors.black;
            txtParticipants.ForeColor = Colors.black;
            chkSold.ForeColor = Colors.black;
            iconParticipants.ForeColor = Colors.black;
            iconSoldOut.ForeColor = Colors.black;


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

            // Rafraichissement des boutons 
            RefreshInterface();

            // Affichage du nombre d'évènement 
            txtCount.Text = "/ " + nav.EventCount;

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
            txtCreator.Text = "crée par " + nav.CreatorName;

            // Affichage des participants à l'évènement
            txtParticipants.Text = nav.ParticipantList;

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
            ProbPotesDialog dialog = new ProbPotesDialog("Ajouter un évènement", 59601, new AddEventDialog(((MainForm)ParentForm).navigation.RefreshActualPage, DatabaseManager.Events.GetEvent(Convert.ToInt32(txtIndex.Text))), this.ParentForm);
            DialogResult result = dialog.Open();
        }

    }
}
