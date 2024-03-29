﻿using ProbPotes.managers;
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
    public partial class ParticipantTile : UserControl
    {

        private Participant participant;
        private HoverController hover;

        public ParticipantTile()
        {
            InitializeComponent();

            // Polices
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtFirstName.Font = new Font(Fonts.bold,18);
                txtName.Font = new Font(Fonts.book, 12);
                List<Label> labels = new List<Label>() { txtMail, txtShares, txtPhone };
                foreach(Label lbl in labels)
                {
                    lbl.Font = new Font(Fonts.book, 10);
                }
            }

            // Icones 
            iconPhone.Text = char.ConvertFromUtf32(0xE717);
            iconMail.Text = char.ConvertFromUtf32(0xE715);
            iconShares.Text = char.ConvertFromUtf32(0xE125);

            // Effet de survol
            HoverColor hoverBg = new HoverColor(new List<Control>() { this }, false, Colors.lightGrey, Colors.lightBlue2, Colors.blue);
            HoverColor hoverBlue = new HoverColor(new List<Control>() { txtFirstName, txtName }, true, Colors.blue, Colors.blue, Colors.white);
            HoverColor hoverBlack = new HoverColor(new List<Control>() { txtShares, txtMail, txtPhone, iconMail, iconPhone, iconShares }, true, Colors.black, Colors.black, Colors.white);
            hover = new HoverController(new List<HoverColor>() { hoverBg, hoverBlack, hoverBlue }, this);

        }

        // Getter/Setter d'un participant
        public Participant Participant
        {
            get => participant;
            set
            {
                participant = value;
                if (participant != null)
                {
                    // Affichage des données du participant
                    txtFirstName.Text = participant.FirstName;
                    txtName.Text = participant.Name;
                    txtPhone.Text = participant.Phone;
                    txtMail.Text = participant.MailAddress;
                    txtShares.Text = participant.Shares.ToString() + (participant.Shares > 1 ? " parts" : " part");
                }
            }
        }

        // Délégate de l'action à effectuer au clic
        public delegate void Del(Participant p);
        public Del ClickAction;

        private void ParticipantTile_Click(object sender, EventArgs e)
        {
            if (ClickAction != null)
            {
                ClickAction(participant);
            }
        }

        public Del RefreshDelegate;


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
