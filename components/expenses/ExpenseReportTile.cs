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
    public partial class ExpenseReportTile : UserControl
    {

        private Expense expense;
        private HoverController hover;

        public ExpenseReportTile()
        {
            InitializeComponent();
            Init();
        }


        public ExpenseReportTile(Expense expense)
        {
            InitializeComponent();
            Init();
            Expense = expense;
            RecipientValue = expense.sum;
            txtBalanceTotal.Visible = false;
        }

        public ExpenseReportTile(Expense expense, Decimal amount)
        { 
            InitializeComponent();
            Init();
            Expense = expense;
            RecipientValue = amount;
        }

        private void Init()
        {
            // Création de l'effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverForeBlue = new HoverColor(new List<Control>() { txtTitle, txtCreator, txtPrice, txtBalanceTotal }, true, Colors.blue, Colors.blue, Colors.white);
            HoverColor hoverGreyFg = new HoverColor(new List<Control>() { txtDescription }, true, Colors.grey, Colors.grey, Colors.white);

            hover = new HoverController(new List<HoverColor>() {hoverBg, hoverForeBlue, hoverGreyFg }, this);


            // Polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.bold, 16);
                txtDescription.Font = new Font(Fonts.regular, 11);
                txtPrice.Font = new Font(Fonts.bold, 18);
                txtCreator.Font = new Font(Fonts.regular, 10);
                txtBalanceTotal.Font = new Font(Fonts.book, 10);
            }

        }

        public Expense Expense
        {
            get => expense;
            set
            {
                expense = value;
                if (expense != null)
                {
                    Participant creator = DatabaseManager.Participants.GetParticipant(expense.creatorCode);
                    txtTitle.Text = expense.description;
                    txtDescription.Text = expense.comment;
                    txtBalanceTotal.Text = "Coût total : " + Decimal.Round(expense.sum, 2).ToString() + " €";
                    txtCreator.Text = "par " + creator.FirstName + " " + creator.Name.ToUpper() + " le " + expense.date.ToShortDateString();
                    
                }
            }
        }

        private Decimal val = 0;

        public Decimal RecipientValue
        {
            set 
            {
                val = value;
                txtPrice.Text = Decimal.Round(val, 2).ToString() + " €";
            }
            get => val;
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
