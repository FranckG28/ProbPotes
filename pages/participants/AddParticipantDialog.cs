using ProbPotes.components;
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
            ProbPotesDialog.ApplyTitleStyle(txtTitle1);

            List<Label> labels = new List<Label>() { lblBalance, lblFirstName, lblMail,lblName, lblPhone, lblEuro};
            foreach(Label lbl in labels)
            {
                ProbPotesDialog.ApplyLabelStyle(lbl);
            }

            List<TextBox> txtBoxes = new List<TextBox>() { boxFirstName, boxMail, boxName, boxPhone, boxBalance };
            foreach(TextBox txt in txtBoxes)
            {
                ProbPotesDialog.ApplyTextBoxStyle(txt);
            }

            // Icones :
            iconBalance.Text = char.ConvertFromUtf32(0xE8EF);
            iconMail.Text = char.ConvertFromUtf32(0xE715);
            iconName.Text = char.ConvertFromUtf32(0xE77B);
            iconPhone.Text = char.ConvertFromUtf32(0xE717);

        }

        public bool CanGoBack {
            get => tabControl1.SelectedIndex > 0;
        }

        public bool CanGoForward {
            get => tabControl1.SelectedIndex < tabControl1.TabCount-1;
        }

        public int Index { 
            get => tabControl1.SelectedIndex; 
            set => tabControl1.SelectedIndex = value; 
        }
    }
}
