using ProbPotes.components;
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
