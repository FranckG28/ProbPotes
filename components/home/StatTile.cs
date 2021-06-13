using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.components.home
{
    public partial class StatTile : UserControl
    {

        HoverController hover;

        public StatTile()
        {
            InitializeComponent();

            // Initialisation des polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtNumber.Font = new Font(Fonts.bold, 25);
                txtDescription.Font = new Font(Fonts.regular, 14);
            }

            // Initialisation des effets de survol :
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverFg = new HoverColor(new List<Control>() { txtDescription, txtIcon, txtNumber }, true, Colors.blue, Colors.blue, Colors.white); 

            hover = new HoverController(new List<HoverColor>() { hoverBg, hoverFg }, this);

    }

        public Pages DestinationPage;

        private int iconInt = 0xE711;

        public int Icon
        {
            get => iconInt;
            set
            {
                iconInt = value;
                txtIcon.Text = char.ConvertFromUtf32(value);
            }
        }

        public String Number
        {
            get => txtNumber.Text;
            set => txtNumber.Text = value;
        }

        public String Description
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value;
        }

        private void StatTile_Click(object sender, EventArgs e)
        {
                // Recuperation du controlleur de la navigation
                NavigationController navigation = ((MainForm) this.FindForm()).navigation;

                navigation.NavigateTo(DestinationPage);
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
