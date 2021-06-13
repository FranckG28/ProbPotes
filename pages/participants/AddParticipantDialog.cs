using ProbPotes.components;
using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.pages.participants
{
    public partial class AddParticipantDialog : UserControl, IDialogPage
    {

        private ProbPotesDialog ParentDialog;

        private bool editMode = false;
        private Participant oldParticipant;

        public delegate void Del();

        public Del RefreshParent;

        public AddParticipantDialog(Del refreshParent)
        {
            InitializeComponent();

            this.RefreshParent = refreshParent;

            Init();
            
        }

        public AddParticipantDialog(Del refreshParent, Participant p)
        {
            InitializeComponent();

            this.RefreshParent = refreshParent;
            this.editMode = true;
            this.oldParticipant = p;

            Init();

            // Chargement des données du participant :
            boxFirstName.Text = p.FirstName;
            boxName.Text = p.Name;
            boxPhone.Text = p.Phone;
            boxMail.Text = p.MailAddress;
            boxShares.Text = p.Shares.ToString();

            txtTitleSuccess.Text = "Participant modifié";

        }

        private void Init()
        {
            // Cacher les onglets
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            // Polices et couleurs
            List<Label> titles = new List<Label>() { txtTitle1, txtTitleSuccess };
            foreach (Label lbl in titles)
            {
                ProbPotesDialog.ApplyTitleStyle(lbl);
            }

            List<Label> labels = new List<Label>() { lblFirstName, lblMail, lblName, lblPhone, txtSuccessfulDescription, lblShares };
            foreach (Label lbl in labels)
            {
                ProbPotesDialog.ApplyLabelStyle(lbl);
            }

            List<TextBox> txtBoxes = new List<TextBox>() { boxFirstName, boxMail, boxName, boxPhone, boxShares };
            foreach (TextBox txt in txtBoxes)
            {
                ProbPotesDialog.ApplyTextBoxStyle(txt);
            }

            txtWarning.ForeColor = Colors.red;
            txtWarning.Font = new Font(Fonts.book, 14);
            txtWarning.Visible = false;

            // Icones :
            iconShares.Text = char.ConvertFromUtf32(0xE125);
            iconMail.Text = char.ConvertFromUtf32(0xE715);
            iconName.Text = char.ConvertFromUtf32(0xE77B);
            iconPhone.Text = char.ConvertFromUtf32(0xE717);
            iconSuccessful.Text = char.ConvertFromUtf32(0xE8FA);

            // Couleurs 
            iconSuccessful.ForeColor = Colors.blue;

            boxFirstName.Focus();
        }

        public bool CanGoBack {
            get => tabControl1.SelectedIndex > 0;
        }

        public bool CanGoForward {
            get => tabControl1.SelectedIndex < tabControl1.TabCount-1;
        }

        public int Index { 
            get => tabControl1.SelectedIndex; 
            set
            {
                if(value == 1)
                {

                    // Vérification des champs 
                    bool correct = boxFirstName.Text != "" 
                        && boxMail.Text != "" 
                        && boxName.Text != "" 
                        && boxPhone.Text != "" 
                        && boxShares.Text != "";

                    txtWarning.Visible = !correct;

                    // Si tout les champs sont corrects 
                    if (correct)
                    {
                        Participant newParticipant = new Participant(editMode ? oldParticipant.Code : DatabaseManager.Participants.Participants.Count + 1, boxPhone.Text, Convert.ToInt32(boxShares.Text), boxName.Text, boxFirstName.Text, boxMail.Text);
                        correct = editMode ? DatabaseManager.Participants.UpdateParticipant(newParticipant) : DatabaseManager.Participants.AddParticipant(newParticipant);

                        if (correct)
                        {
                            txtSuccessfulDescription.Text = newParticipant.FirstName + " " + newParticipant.Name.ToUpper() + " a bien été enregistré";
                            tabControl1.SelectedIndex = value;
                            if (RefreshParent != null)
                            {
                                RefreshParent();
                            }
                        } else
                        {
                            MessageBox.Show("Impossible d'enregistrer le participant !");
                        }
                    }
                    
                } else
                {
                    tabControl1.SelectedIndex = value;
                }
                

            }

        }

        public int PageCount
        {
            get => tabControl1.TabCount;
        }

        public bool ShowBackBtn => true;

        public bool ShowNextBtn => true;

        public ProbPotesDialog ParentController { set => ParentDialog = value; }

        public void FocusBox()
        {
            boxFirstName.Select();
        }

        //KeyPress
        //fonction qui verifie les caractères sont valides
        private void boxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // on refuse tout 
            e.Handled = true;
            // accepte les chiffres, les retours arrières et les espaces.
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                // on accepte 
                e.Handled = false;
            }
        }
        //fonction qui verifie les caractères sont valides
        private void boxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // on refuse tout 
            e.Handled = true;
            // accepte les chiffres, lettres, les retours arrières et les espaces.
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                // on accepte 
                e.Handled = false;
            }
        }
        //fonction qui verifie les caractères sont valides
        private void boxName_KeyPress(object sender, KeyPressEventArgs e)
        {

            // on refuse tout 
            e.Handled = true;
            // accepte les chiffres, lettres, les retours arrières et les espaces.
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                // on accepte 
                e.Handled = false;
            }
        }

        //fonction qui verifie les caractères sont valides
        private void boxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // on accepte tout 
            e.Handled = false;
        }

        //fonction qui verifie les caractères sont valides
        private void boxShares_KeyPress(object sender, KeyPressEventArgs e)
        {
            // on refuse tout 
            e.Handled = true;
            // accepte les chiffres, lettres, les retours arrières et les espaces.
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                // on accepte
                e.Handled = false;
            }
            
        }


        // fonction qui permet de déterminer si un caractère est valide pour un champ de saisies de nombre floattant
        private bool CheckChar(char xChar, TextBox box)
        {
            // mets le boolean a faux par défault on dit que les caractères ne sont pas valide
            bool isValid = false;
            // si le caractère est un chiffre
            if (char.IsDigit(xChar))
            {
                // alors on accepte
                isValid = true;
            }
            // si c'est une virgule
            else if (xChar == ',')
            {
                // on accepte le caractere si la textBox ne contient pas de virgule
                isValid = !box.Text.Contains(',');
            }
            // si c'est un @
            else if (xChar == '@')
            {
                // on accepte le caractere si la textBox ne contient pas de @
                isValid = !box.Text.Contains('@');
            }
            // si c'est un controle
            else if (char.IsControl(xChar))
            {
                // alors on accepte
                isValid = true;
            }
            // on retourne 
            return isValid;
        }
    }
}
