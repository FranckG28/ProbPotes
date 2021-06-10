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

namespace ProbPotes.pages.reports
{
    public partial class WOWTWDialog : UserControl, IDialogPage
    {
        public WOWTWDialog()
        {
            InitializeComponent();
        }

        public bool CanGoBack => throw new NotImplementedException();

        public bool CanGoForward => throw new NotImplementedException();

        public bool ShowBackBtn => throw new NotImplementedException();

        public bool ShowNextBtn => throw new NotImplementedException();

        public int Index { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int PageCount => throw new NotImplementedException();

        public ProbPotesDialog ParentController { set => throw new NotImplementedException(); }

        public void FocusBox()
        {
            throw new NotImplementedException();
        }
    }
}
