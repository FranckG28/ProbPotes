using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.services;

namespace ProbPotes.components
{
    public partial class EventPreview : UserControl
    {

        private EventClass eventClass;
        private HoverController hover;

        // Constructeur par défaut
        public EventPreview()
        {
            InitializeComponent();

            init();
        }

        // Constructeur avec un évènement donné
        public EventPreview(EventClass eventClass)
        {
            InitializeComponent();

            init();

            this.EventClass = eventClass;
        }

        // Initialisation du controle
        private void init()
        {
            // Initialisation des icones :
            iconParticipants.Text = char.ConvertFromUtf32(0xEBDA);

            // Initialisation des polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.bold, 14);
                txtDate.Font = new Font(Fonts.regular, 10);
                txtParticipants.Font = new Font(Fonts.book, 10);
            }

            // Initialisation de l'effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverForeBlue = new HoverColor(new List<Control>() { txtTitle }, true, Colors.blue, Colors.blue, Colors.white);
            HoverColor hoverForeBlack = new HoverColor(new List<Control>() { txtParticipants, txtDate, iconParticipants }, true, Colors.grey, Colors.black, Colors.white);

            hover = new HoverController(new List<HoverColor>() { hoverBg, hoverForeBlack, hoverForeBlue }, this);

            // Ajout de l'évènement Click à tout les controles
            foreach (Control ctrl in Controls)
            {
                ctrl.Click += new System.EventHandler(EventPreview_Click);
            }
        }

        // Getter/Setter de l'event à afficher
        public EventClass EventClass
        {
            get => eventClass;
            set
            {
                eventClass = value;
                if (eventClass != null)
                {
                    // Définition des textes aux données de l'évènement
                    txtTitle.Text = eventClass.Title;
                    txtDate.Text = eventClass.StartDate.ToShortDateString() + " - " + eventClass.EndDate.ToShortDateString();
                    txtParticipants.Text = DatabaseManager.Participants.GetStringFromList(eventClass.Guests);
                }
            }
        }

        // Delegate de l'action à affectuer au clic
        public delegate void Del(EventClass e);
        public Del ClickAction;

        // evènement click
        private void EventPreview_Click(object sender, EventArgs e)
        {
            if (ClickAction != null)
            {
                ClickAction(eventClass);
            }
        }



        #region Arrondissement des coins du UserControl

        // Source originale : https://stackoverflow.com/questions/32987649/how-to-create-a-user-control-with-rounded-corners

        // getter du rayon
        public int Radius
        {
            get { return MainForm.borderRadius; }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        // Fonction de création d'un rectangle arrondi
        private GraphicsPath GetRoundRectagle(Rectangle bounds, int radius)
        {
            // Définition du rayon
            float r = radius;
            // Création de la forme
            GraphicsPath path = new GraphicsPath();
            // Début du dessin
            path.StartFigure();
            // Ajout des 4 coins
            path.AddArc(bounds.Left, bounds.Top, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Top, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - r, r, r, 90, 90);
            // Arrêt du dessin
            path.CloseFigure();
            // Retour de la forme
            return path;
        }

        // Procédure de regénération de la forme
        private void RecreateRegion()
        {
            // Récupération du rectangle du control
            var bounds = ClientRectangle;

            // Remplacement de la forme du control par celle générée
            this.Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top,
                bounds.Right, bounds.Bottom, Radius, Radius));
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            // Recréation de la forme en cas de changement de taille
            base.OnSizeChanged(e);
            this.RecreateRegion();
        } 
        #endregion



    }
}
