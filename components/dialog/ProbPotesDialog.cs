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

namespace ProbPotes.components
{

    // Interface commune à toutes les pages des boities de dialogues
    public interface IDialogPage
    {
        
        // Getter qui renvoie TRUE si l'on peut retourner en arrière
        bool CanGoBack { get;}

        // Getter qui renvoie TRUE si il y a une page suivante
        bool CanGoForward { get; }

        // Getter qui renvoie TRUE si le bouton précédent doit être affiché
        bool ShowBackBtn { get; }
        
        // Getter qui renvoie TRUE si le bouton suivant doit être affiché
        bool ShowNextBtn { get; }

        // Getter/Setter du numéro de la page actuel
        int Index { get; set; }

        // Getter du nombre de pages de la boite de dialogue
        int PageCount { get; }

        // Variable contenant la boite dialogue parent du contenu
        ProbPotesDialog ParentController { set; }

        // Procédure déclenchée au lancement de la boite de dialogue afin de focus le premier champs
        void FocusBox();

    }


    // Boite de dialogue ProbPotes avec gestion de la navigation
    public partial class ProbPotesDialog : Form
    {

        // Contenu de la boite de dialogue
        public IDialogPage Content;

        // Formulaire parent (MainForm)
        private new Form ParentForm;

        // Constante : marge interne des textboxes
        private static int TEXTBOX_PADDING = 10;

        // Constructeur
        public ProbPotesDialog(String title, int icon, IDialogPage content, Form parent)
        {
            InitializeComponent();

            // Définition des couleurs
            BackColor = Colors.white;
            iconTitle.ForeColor = Colors.black;
            txtTitle.ForeColor = Colors.black;

            // Style des boutons 
            btnBack.BackColor = Colors.black;
            btnNext.BackColor = Colors.blue;
            btnBack.FlatAppearance.MouseOverBackColor = Colors.red;
            btnBack.FlatAppearance.MouseDownBackColor = Colors.lightRed;
            btnNext.FlatAppearance.MouseOverBackColor = Colors.green;
            btnNext.FlatAppearance.MouseDownBackColor = Colors.lightBlue;

            // Définition des polices polices 
            txtTitle.Font = new Font(Fonts.medium, 16);
            Font btnFont = new Font(Fonts.book, 12);
            btnBack.Font = btnFont;
            btnNext.Font = btnFont;

            // Assigne la fonction CloseForm à l'action Click du bouton fermer
            closeBtn1.ClickEvent = CloseForm;

            // Application de l'ombre sur le formulaire 
            new FormDropShadow().ApplyShadows(this);

            // Definition des propriétés depuis les arguments passés dans le constructeurs
            Content = content;
            Title = title;
            TitleIcon = icon;
            ParentForm = parent;

            // Définition de la boite dialogue de l'enfant à lui même
            Content.ParentController = this;

            // Ajout de la page en question
            pnlContent.Controls.Add((UserControl)content);

            // Actualisation des boutons
            RefreshButtons();

            // Appel de la fonction de focus 
            Content.FocusBox();
        }

        // Défini le titre de la boite de dialogue
        public String Title
        {
            get => txtTitle.Text;
            set => txtTitle.Text = value;
        }

        // Variable privé contenant le numéro de l'icone
        private int iconInt = 0xE001;

        // Getter/Setter de l'icone de la boite de dialogue
        public int TitleIcon
        {
            get => iconInt;
            set
            {
                iconInt = value;
                iconTitle.Text = char.ConvertFromUtf32(iconInt);
            }
        }

        // Procédure d'ouverture de la boite de dialogue
        public DialogResult Open()
        {

            // Assombrir le formulaire principal :
            // Prise d'une screenshot de la fenêtre :
            Bitmap bmp = new Bitmap(ParentForm.ClientRectangle.Width, ParentForm.ClientRectangle.Height);
            // Noircissement de l'image :
            using (Graphics G = Graphics.FromImage(bmp))
            {
                // Définition de la zone de dessin à la taille de la fenêtre principale
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(ParentForm.PointToScreen(new Point(0, 0)), new Point(0, 0), ParentForm.ClientRectangle.Size);
                // Création d'un pinceau assombrissant
                double percent = 0.70;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brsh = new SolidBrush(darken))
                {
                    // Déssin d'un rectangle assombrissant sur toute la fenêtre
                    G.FillRectangle(brsh, ParentForm.ClientRectangle);
                }
            }

            // Placement de la capture d'écran assombrie par dessus la fenêtre principale dans un panel
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = ParentForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                ParentForm.Controls.Add(p);
                p.BringToFront();

                // Affichage du formulaire
                return ShowDialog();
            } // Le panel n'existe qu'à l'intérieur du "Using", il disparait automatiquement ici, à la fermeture de la fenêtre
        }

        // Procédure de navigation
        public void Navigate(int index)
        {
            // Définition de l'index de l'enfant à la page demandée
            Content.Index = index;
            // Actualisation des boutons
            RefreshButtons();
        }

        // Procédure d'actualisation des boutons
        private void RefreshButtons()
        {
            // Affichage des boutons si l'enfant le demande
            btnBack.Visible = Content.ShowBackBtn;
            btnNext.Visible = Content.ShowNextBtn;

            // Si une page suivante existe
            if (Content.CanGoForward)
            {
                if (Content.Index == Content.PageCount - 2)
                {
                    // Si c'est l'avant dernière page :
                    btnNext.Text = "Valider";
                    btnNext.Image = Properties.Resources.doneIcon;
                }
                else
                {
                    // Si c'est n'importe quelle autre page
                    btnNext.Text = "Suivant";
                    btnNext.Image = Properties.Resources.nextIcon;
                }
            }
            else
            {
                // Si c'est la dernière page :
                btnNext.Text = "OK";
                btnNext.Image = Properties.Resources.doneIcon;
            }

            // Si le retour arrière est possible
            if (Content.CanGoBack)
            {
                // Bouton précédent
                btnBack.Text = "Précédent";
            }
            else
            {
                // Bouton annuler
                btnBack.Text = "Annuler";
            }
        }

        // Procédure de navigation à la page suivante
        public void GoNext()
        {
            Navigate(Content.Index +1);
        }

        // Procédure de navigation à la page précédente
        public void GoBack()
        {
            Navigate(Content.Index -1);
        }

        // Evènemement du bouton retour
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Content.CanGoBack)
            {
                // Si possibilité d'aller en arrière
                GoBack();
            } else
            {
                // Sinon fermer la fenêtre
                DialogResult = DialogResult.Cancel;
            }
        }

        // Evènement du bouton suivant
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Content.CanGoForward)
            {
                // Si il existe une page suivante
                GoNext();
            } else
            {
                // Sinon fermer la fenêtre
                DialogResult = DialogResult.OK;
            }
        }


        #region Design des composants du formulaire
        // Procédure de fermeture de la fenêtre
        private void CloseForm()
        {
            DialogResult = DialogResult.Cancel;
        }

        // Constante de la police à utiliser pour les titres
        public static Font TitleFont = new Font(Fonts.bold, 22);

        // Procédure d'application du style d'un titre de la boite de dialogue
        public static void ApplyTitleStyle(Label lbl)
        {
            lbl.Font = TitleFont;
            lbl.ForeColor = Colors.blue;
        }

        // Constante de la police à utiliser pour les labels
        public static Font LabelFont = new Font(Fonts.regular, 11);

        // Procédure d'application du style d'un Label de la boite de dialogue
        public static void ApplyLabelStyle(Label lbl)
        {
            lbl.Font = LabelFont;
            lbl.ForeColor = Colors.black;
        }

        // Constante de la police à utiliser pour les textbox
        public static Font TextBoxFont = new Font(Fonts.book, 13);

        // Procédure d'application du style d'un Textbox de la boite de dialogue
        public static void ApplyTextBoxStyle(TextBox txtBox)
        {
            // Obtention du control parent à la textbox
            Control Parent = txtBox.Parent;

            // Définition des propriétés de la textbox
            txtBox.Font = TextBoxFont;
            txtBox.BackColor = Color.White;
            txtBox.ForeColor = Colors.blue;
            txtBox.BorderStyle = BorderStyle.None;

            // Création d'un panel pour contenir la textbox
            Panel pnl = new Panel();
            pnl.Padding = new Padding(TEXTBOX_PADDING * 2, TEXTBOX_PADDING, TEXTBOX_PADDING * 2, TEXTBOX_PADDING);
            pnl.Size = new Size(txtBox.Width + TEXTBOX_PADDING, txtBox.Height + TEXTBOX_PADDING);
            pnl.Location = txtBox.Location;
            pnl.BackColor = Color.White;
            pnl.TabIndex = txtBox.TabIndex;

            // Supprimer la textbox de son parent et la mettre dans son panel à la place
            Parent.Controls.Remove(txtBox);
            pnl.Controls.Add(txtBox);
            Parent.Controls.Add(pnl);

            txtBox.Dock = DockStyle.Fill;

        }

        // Procédure d'application du style d'un DatePicker de la boite de dialogue
        public static void ApplyDatePickerStyle(DateTimePicker picker)
        {
            // Obtention du control parent au DatePicker
            Control Parent = picker.Parent;

            // Définition des propriétés
            picker.Font = TextBoxFont;
            picker.ForeColor = Colors.blue;
            picker.CalendarFont = TextBoxFont;

            // Création d'un panel 
            Panel pnl = new Panel();
            pnl.Padding = new Padding(TEXTBOX_PADDING * 2, TEXTBOX_PADDING, TEXTBOX_PADDING * 2, TEXTBOX_PADDING);
            pnl.Size = new Size(picker.Width + TEXTBOX_PADDING, picker.Height + TEXTBOX_PADDING);
            pnl.Location = picker.Location;
            pnl.BackColor = Color.White;
            pnl.TabIndex = picker.TabIndex;

            // Supprimer la datePicker de son parent et la mettre dans son panel à la place
            Parent.Controls.Remove(picker);
            pnl.Controls.Add(picker);
            Parent.Controls.Add(pnl);

            picker.Dock = DockStyle.Fill;


        }
        #endregion


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
