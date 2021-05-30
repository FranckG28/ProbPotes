using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.pages
{
    public partial class PageTemplate : UserControl
    {
        public PageTemplate()
        {
            InitializeComponent();
        }

        [Description("Titre de la page"), Category("Data")]
        public string Title
        {
            get => pageTitle.Title;
            set => pageTitle.Title = value;
        }

        [Description("Contenu de la page"), Category("Data")]
        public Control Content
        {
            get => pageContent.Controls[0];
            set
            {
                pageContent.Controls.Clear();
                pageContent.Controls.Add(value);
            }
        }

        [Description("Icone de la page"), Category("Data")]
        public int Icon
        {
            get => pageTitle.Icon;
            set => pageTitle.Icon = value;
        }

        public delegate void AddButtonDelegate();

        public AddButtonDelegate AddButtonAction
        {
            set
            {
                pageTitle.AddButtonAction = value;
            }
        }

        private void PageTemplate_Load(object sender, EventArgs e)
        {
            // Implémentation du déplacement de la fenêtre sur le title de la page
            MainForm mainForm = ((MainForm)this.FindForm());

            mainForm.AddDraggableControl(pageTitle);

            foreach(Control ctrl in pageTitle.Controls)
            {
                mainForm.AddDraggableControl(ctrl);
            }
        }
    }
}
