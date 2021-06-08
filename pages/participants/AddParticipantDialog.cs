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

        public AddParticipantDialog()
        {
            InitializeComponent();

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

            List<Label> labels = new List<Label>() { lblBalance, lblFirstName, lblMail,lblName, lblPhone, lblEuro, txtSuccessfulDescription, lblShares};
            foreach(Label lbl in labels)
            {
                ProbPotesDialog.ApplyLabelStyle(lbl);
            }

            List<TextBox> txtBoxes = new List<TextBox>() { boxFirstName, boxMail, boxName, boxPhone, boxBalance, boxShares };
            foreach(TextBox txt in txtBoxes)
            {
                ProbPotesDialog.ApplyTextBoxStyle(txt);
            }

            // Icones :
            iconShares.Text = char.ConvertFromUtf32(0xE125);
            iconMail.Text = char.ConvertFromUtf32(0xE715);
            iconName.Text = char.ConvertFromUtf32(0xE77B);
            iconPhone.Text = char.ConvertFromUtf32(0xE717);
            iconSuccessful.Text = char.ConvertFromUtf32(0xE8FA);

            // Couleurs 
            iconSuccessful.ForeColor = Colors.blue;


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
                    Participant newParticipant = new Participant();

                    // SI ECHEC : 
                    //tabControl1.SelectedIndex = 0;
                    // AJOUTER WARNING
                    
                    // SI REUSSITE :
                    tabControl1.SelectedIndex = value;
                } else
                {
                    tabControl1.SelectedIndex = value;
                }
                

            }

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

        private void boxBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (char.IsDigit(e.KeyChar)||e.KeyChar==',' || e.KeyChar == (char)Keys.Back || (e.KeyChar == ',' && !boxBalance.Text.Contains(',')))
            {
                e.Handled = false;
            }
        }
        private void boxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (char.IsDigit(e.KeyChar)||cha    r.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '@' || e.KeyChar =='.')
            {
                e.Handled = false;
            }
        }
    }
}
