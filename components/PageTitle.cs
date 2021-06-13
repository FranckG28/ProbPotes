using ProbPotes.pages;
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
    public partial class PageTitle : UserControl
    {
        public PageTitle()
        {
            InitializeComponent();

            //  Définition du style des textes :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.medium, 30);
                btnAdd.Font = new Font(Fonts.book, 12);
            }
            txtIcon.ForeColor = Colors.blue;
            txtTitle.ForeColor = Colors.blue;

            // Cacher le bouton ajouter
            btnAdd.Visible = false;

            // Définition des couleurs
            btnAdd.BackColor = Colors.blue;
            btnAdd.FlatAppearance.MouseOverBackColor = Colors.green;
            btnAdd.FlatAppearance.MouseDownBackColor = Colors.grey;

        }

        // Delegate de l'action du clic du bouton ajouter
        public PageTemplate.AddButtonDelegate addBtnAction;
        private int iconInt = 0xE899;

        [Description("Titre de l'élément"), Category("Data")]
        public string Title
        {
            get => txtTitle.Text;
            set => txtTitle.Text = value;
        }

        [Description("Titre de l'élément"), Category("Data")]
        public int Icon
        {
            get => iconInt;
            set {
                iconInt = value;
                txtIcon.Text = char.ConvertFromUtf32(iconInt);
            }
        }

        public PageTemplate.AddButtonDelegate AddButtonAction
        {
            get => addBtnAction;
            set
            {
                addBtnAction = value;
                btnAdd.Visible = addBtnAction != null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addBtnAction();
        }
    }
}
