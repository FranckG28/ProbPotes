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

namespace ProbPotes.components
{


    public partial class ProbPotesDialog : Form
    {

        public List<UserControl> Pages;
        public int Index = 0;

        public ProbPotesDialog(String title, int icon, List<UserControl> pages)
        {
            InitializeComponent();

            // Couleurs
            BackColor = Colors.white;
            iconTitle.ForeColor = Colors.black;
            txtTitle.ForeColor = Colors.black;

            // Boutons 
            btnBack.BackColor = Colors.black;
            btnNext.BackColor = Colors.blue;
            btnBack.FlatAppearance.MouseOverBackColor = Colors.blue;
            btnBack.FlatAppearance.MouseDownBackColor = Colors.green;
            btnNext.FlatAppearance.MouseOverBackColor = Colors.green;
            btnNext.FlatAppearance.MouseDownBackColor = Colors.grey;

            // Polices 
            txtTitle.Font = new Font(Fonts.medium, 16);
            Font btnFont = new Font(Fonts.book, 12);
            btnBack.Font = btnFont;
            btnNext.Font = btnFont;

            // Definition des valeurs
            Pages = pages;
            Title = title;
            TitleIcon = icon;

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

        private void Navigate(int index)
        {
            Index = index;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(Pages[Index]);

            if (CanGoForward)
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

            if (CanGoBack)
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
            Navigate(Index+1);
        }

        public void GoBack()
        {
            Navigate(Index-1);
        }

        public bool CanGoBack
        {
            get => Index > 0;
        }

        public bool CanGoForward
        {
            get => Index <= Pages.Count;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (CanGoBack)
            {
                GoBack();
            } else
            {
                Close();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CanGoForward)
            {
                GoNext();
            } else
            {
                Close();
            }
        }

        private void closeBtn1_Load(object sender, EventArgs e)
        {
            Close();
        }
    }
}
