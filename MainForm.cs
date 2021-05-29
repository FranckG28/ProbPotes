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

namespace ProbPotes
{
    
    public partial class MainForm : Form
    {

        public NavigationController navigation;

        public MainForm()
        {
            // Initialisation des polices
            Fonts.initFonts();

            // Initialisation des composants de la fenêtres
            InitializeComponent();

            // Ajout de l'ombre
            new DropShadow().ApplyShadows(this);

            // Assigne la fonction closeApp à l'action Click du bouton fermer
            closeBtn1.ClickEvent = CloseApp;

            // Changement de la couleur de fond de la fenêtre
            BackColor = Colors.white;

            // Initialisation de la navigation :
            navigation = new NavigationController(panelView);

            // Ajout des pages
            navigation.AddNavigation(navHome, new HomePage(), Pages.Home, "Bonjour");
            navigation.AddNavigation(navExpenses, new ExpensesPage(), Pages.Expenses);
            navigation.AddNavigation(navEvents, new EventsPage(), Pages.Events);
            navigation.AddNavigation(navParticipants, new ParticipantsPage(), Pages.Participants);
            navigation.AddNavigation(navReports, new ReportsPage(), Pages.Reports);

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
