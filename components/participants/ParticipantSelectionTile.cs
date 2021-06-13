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

namespace ProbPotes.components.participants
{
    public partial class ParticipantSelectionTile : UserControl
    {

        private SelectableHoverController hover;
        private Participant participant;

        public Boolean IsSelectable = true;

        public ParticipantSelectionTile()
        {
            InitializeComponent();

            // Polices
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtFirstName.Font = new Font(Fonts.bold, 13);
                txtName.Font = new Font(Fonts.book, 12);
            }

            // Effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverBlue = new HoverColor(new List<Control>() { txtFirstName, txtName }, true, Colors.blue, Colors.blue, Colors.white);
            hover = new SelectableHoverController(new List<HoverColor>() { hoverBg, hoverBlue }, this);
        }

        // Getter/Setter de l'état de la sélection du composant
        public bool Selected
        {
            get => hover.Selected;
            set => hover.Selected = value;
        }

        // Getter/Setter du participant à afficher
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Participant Participant
        {
            get => participant;
            set
            {
                participant = value;
                if (participant != null)
                {
                    txtFirstName.Text = participant.FirstName;
                    txtName.Text = participant.Name.ToUpper();
                }
            }
        }

        // Delegate de l'action à effectuer au clic
        public delegate void Del(Participant p);
        public Del SelectAction;

        private void ParticipantSelectionTile_Click(object sender, EventArgs e)
        {
            if (IsSelectable)
            {
                Selected = !Selected;
            }
            SelectAction?.DynamicInvoke(Participant);
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
