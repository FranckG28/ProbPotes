using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.services;
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

namespace ProbPotes.components.expenses
{
    public partial class ExpenseTile : UserControl
    {

        private Expense expense;
        private HoverController hover;

        // Delegate de l'action à effectuer au clic
        public delegate void Del(Expense e);
        public Del ClickAction;

        public ExpenseTile()
        {
            InitializeComponent();
            Init();
        }

        public ExpenseTile(Expense expense)
        { 
            InitializeComponent();
            Init();
            Expense = expense;
        }


        // Procédure d'initialisation du composant
        private void Init()
        {
            // Création de l'effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverForeBlue = new HoverColor(new List<Control>() { txtTitle, txtCreator, txtPrice }, true, Colors.blue, Colors.blue, Colors.white);
            HoverColor hoverForeBlack = new HoverColor(new List<Control>() { txtDescription, txtRecipients, iconRecipients, txtLblParticipants, txtLblDescription, iconDescription }, true, Colors.grey, Colors.black, Colors.white);

            hover = new HoverController(new List<HoverColor>() {hoverBg, hoverForeBlue, hoverForeBlack}, this);

            // Icones :
            iconRecipients.Text = char.ConvertFromUtf32(0xE716);
            iconDescription.Text = char.ConvertFromUtf32(0XE8C4);

            // Polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.bold, 16);
                txtDescription.Font = new Font(Fonts.regular, 10);
                txtPrice.Font = new Font(Fonts.bold, 18);
                txtRecipients.Font = new Font(Fonts.book, 10);
                txtCreator.Font = new Font(Fonts.book, 12);
                txtLblParticipants.Font = new Font(Fonts.bold, 9);
                txtLblDescription.Font = new Font(Fonts.bold, 9);
            }

        }


        // Getter/Setter de la dépense à afficher
        public Expense Expense
        {
            get => expense;
            set
            {
                expense = value;
                if (expense != null)
                {
                    // Affichage des données de la dépense
                    Participant creator = DatabaseManager.Participants.GetParticipant(expense.creatorCode);
                    txtTitle.Text = expense.description;
                    txtDescription.Text = expense.comment;
                    txtPrice.Text = expense.sum.ToString()+" €";
                    txtCreator.Text = "payé par " + creator.FirstName + " " + creator.Name.ToUpper() + " le " + expense.date.ToShortDateString();

                    // Génération d'une liste des participants 
                    txtRecipients.Text = DatabaseManager.Participants.GetStringFromList(expense.recipients);
                }
            }
        }

        // Evènement clic
        private void ExpenseTile_Click(object sender, EventArgs e)
        {
            ClickAction?.DynamicInvoke(Expense);
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
