using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

using ProbPotes.services;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using ProbPotes.pages;
using ProbPotes.components;
using ProbPotes.pages.participants;
using ProbPotes.pages.events;
using ProbPotes.managers;
using System.Diagnostics;

namespace ProbPotes
{
    
    public partial class MainForm : Form
    {

        public NavigationController navigation;

        public static int borderRadius = 25;

        public MainForm()
        {
            // Initialisation des polices
            Fonts.initFonts();

            // Initialisation des composants de la fenêtres
            InitializeComponent();

            // Ajout de l'ombre
            new FormDropShadow().ApplyShadows(this);

            // Assigne la fonction closeApp à l'action Click du bouton fermer
            closeBtn1.ClickEvent = CloseApp;

            // Changement de la couleur de fond de la fenêtre
            BackColor = Colors.white;

            // Initialisation de la navigation :
            navigation = new NavigationController(panelView);

            // Ajout des pages
            navigation.AddNavigation(navHome, Pages.Home, "Bonjour");
            navigation.AddNavigation(navExpenses, Pages.Expenses, "Vos dépenses", OpenAddExpense);
            navigation.AddNavigation(navEvents, Pages.Events, "Vos évènements", OpenAddEvent);
            navigation.AddNavigation(navParticipants, Pages.Participants, "Vos participants", OpenAddParticipant);
            navigation.AddNavigation(navReports, Pages.Reports, "Bilans");
        }

        public void CloseApp() 
        {
            Application.Exit();
        }

        public void AddDraggableControl(Control ctrl)
        {
            ctrl.MouseDown += new System.Windows.Forms.MouseEventHandler(MainForm_MouseDown);
            ctrl.MouseUp += new System.Windows.Forms.MouseEventHandler(MainForm_MouseUp);
            ctrl.MouseMove += new System.Windows.Forms.MouseEventHandler(MainForm_MouseMove);
        }

        public void GoToHome()
        {
            navigation.NavigateTo(Pages.Home);
        }

        public void OpenAddExpense()
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Ajouter une dépense", 59161, new AddExpenseDialog(null, navigation.RefreshActualPage), this);
            DialogResult result = dialog.Open();
        }

        public void OpenAddEvent()
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Ajouter un évènement", 59601, new AddEventDialog(navigation.RefreshActualPage), this);
            DialogResult result = dialog.Open();
        }

        public void OpenAddParticipant()
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Ajouter un participant", 59642, new AddParticipantDialog(navigation.RefreshActualPage), this);
            DialogResult result = dialog.Open();
            
        }


        #region Implémentation du déplacement du formulaire
        // dragging = true tant que l'utilisateur est en train de déplacer la fenêtre
        private bool dragging = false;

        // Emplacement du curseur de l'utilisateur au début du déplacement
        private Point dragCursorPoint;

        // Emplacement du formulaire au début du déplacement
        private Point dragFormPoint;

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Lorsque que l'utilisateur clique, démarrer le déplacement
            dragging = true;
            // Enregistrement des emplacements au début du déplacement :
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            // Lorsque que l'utilisateur lache le clique, arrêter le déplacement :
            dragging = false;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Au déplacement de la souris, si le déplacement est en cours :
            if (dragging)
            {
                // On calcule le déplacement effectué par le curseur entre sa position actuelle et sa position initiale :
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));

                // On ajoute cette différence de déplacement à la fenêtre :
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        #endregion

    }
}
