﻿using ProbPotes.services;
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

namespace ProbPotes.components
{
    public interface IDialogPage
    {
         
        bool CanGoBack { get;}

        bool CanGoForward { get; }

        int Index { get; set; }

    }

    public partial class ProbPotesDialog : Form
    {

        public IDialogPage Content;
        private Form ParentForm;

        public ProbPotesDialog(String title, int icon, IDialogPage content, Form parent)
        {
            InitializeComponent();

            // Couleurs
            BackColor = Colors.white;
            iconTitle.ForeColor = Colors.black;
            txtTitle.ForeColor = Colors.black;

            // Boutons 
            btnBack.BackColor = Colors.black;
            btnNext.BackColor = Colors.blue;
            btnBack.FlatAppearance.MouseOverBackColor = Colors.red;
            btnBack.FlatAppearance.MouseDownBackColor = Colors.lightRed;
            btnNext.FlatAppearance.MouseOverBackColor = Colors.green;
            btnNext.FlatAppearance.MouseDownBackColor = Colors.lightBlue;

            // Polices 
            txtTitle.Font = new Font(Fonts.medium, 16);
            Font btnFont = new Font(Fonts.book, 12);
            btnBack.Font = btnFont;
            btnNext.Font = btnFont;

            // Assigne la fonction CloseForm à l'action Click du bouton fermer
            closeBtn1.ClickEvent = CloseForm;

            // Application de l'ombre sur le formulaire 
            new DropShadow().ApplyShadows(this);

            // Definition des valeurs
            Content = content;
            Title = title;
            TitleIcon = icon;
            ParentForm = parent;

            // Ajout de la page 
            pnlContent.Controls.Add((UserControl)content);
            Navigate(0);

        }

        public String Title
        {
            get => txtTitle.Text;
            set => txtTitle.Text = value;
        }

        private int iconInt = 0xE001;

        public int TitleIcon
        {
            get => iconInt;
            set
            {
                iconInt = value;
                iconTitle.Text = char.ConvertFromUtf32(iconInt);
            }
        }

        public DialogResult Open()
        {
            // take a screenshot of the form and darken it:
            Bitmap bmp = new Bitmap(ParentForm.ClientRectangle.Width, ParentForm.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(ParentForm.PointToScreen(new Point(0, 0)), new Point(0, 0), ParentForm.ClientRectangle.Size);
                double percent = 0.70;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brsh = new SolidBrush(darken))
                {
                    G.FillRectangle(brsh, ParentForm.ClientRectangle);
                }
            }

            // put the darkened screenshot into a Panel and bring it to the front:
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = ParentForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                ParentForm.Controls.Add(p);
                p.BringToFront();

                // display your dialog somehow:
                return ShowDialog();
            } // panel will be disposed and the form will "lighten" again...
        }

        private void Navigate(int index)
        {
            Content.Index = index;
            
            if (Content.CanGoForward)
            {
                // Bouton suivant
                btnNext.Text = "Suivant";
                btnNext.Image = Properties.Resources.nextIcon;
            } else
            {
                // Bouton terminer
                btnNext.Text = "OK";
                btnNext.Image = Properties.Resources.doneIcon;
            }

            if (Content.CanGoBack)
            {
                // Bouton précédent
                btnBack.Text = "Précédent";
            } else
            {
                // Bouton annuler
                btnBack.Text = "Annuler";
            }
        }

        public void GoNext()
        {
            Navigate(Content.Index +1);
        }

        public void GoBack()
        {
            Navigate(Content.Index -1);
            Debug.WriteLine(Content.Index);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Content.CanGoBack)
            {
                GoBack();
            } else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Content.CanGoForward)
            {
                GoNext();
            } else
            {
                DialogResult = DialogResult.OK;
            }
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

        private void CloseForm()
        {
            DialogResult = DialogResult.Cancel;
        }


        public static Font TitleFont = new Font(Fonts.bold, 22);

        public static void ApplyTitleStyle(Label lbl)
        {
            lbl.Font = TitleFont;
            lbl.ForeColor = Colors.blue;
        }

        public static Font LabelFont = new Font(Fonts.regular, 11);

        public static void ApplyLabelStyle(Label lbl)
        {
            lbl.Font = LabelFont;
            lbl.ForeColor = Colors.black;
        }

        public static Font TextBoxFont = new Font(Fonts.book, 13);

        public static void ApplyTextBoxStyle(TextBox txtBox)
        {
            txtBox.Font = TextBoxFont;
            txtBox.ForeColor = Colors.blue;
        }


    }
}