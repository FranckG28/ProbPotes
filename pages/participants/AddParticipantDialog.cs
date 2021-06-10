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

        public delegate void Del();

        public Del RefreshParent;

        public AddParticipantDialog(Del refreshParent)
        {
            InitializeComponent();

            this.RefreshParent = refreshParent;

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

            List<Label> labels = new List<Label>() { lblFirstName, lblMail,lblName, lblPhone, txtSuccessfulDescription, lblShares};
            foreach(Label lbl in labels)
            {
                ProbPotesDialog.ApplyLabelStyle(lbl);
            }

            List<TextBox> txtBoxes = new List<TextBox>() { boxFirstName, boxMail, boxName, boxPhone, boxShares };
            foreach(TextBox txt in txtBoxes)
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
                        Participant newParticipant = new Participant(DatabaseManager.Participants.Participants.Count + 1, boxPhone.Text, Convert.ToInt32(boxShares.Text), boxName.Text, boxFirstName.Text, boxMail.Text);
                        correct = DatabaseManager.Participants.AddParticipant(newParticipant);
                    }

                    // Si l'ajout a réussi
                    if (correct)
                    {
                        tabControl1.SelectedIndex = value;
                        if (RefreshParent != null)
                        {
                            RefreshParent();
                        }
                    } else
                    {
                        tabControl1.SelectedIndex = 0;
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
        private void boxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
        }

        private void boxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
        }

        private void boxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = false;
            }
        }

        private void boxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (char.IsDigit(e.KeyChar)||char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar =='.')
            {
                e.Handled = false;
            }
        }
    }
}
