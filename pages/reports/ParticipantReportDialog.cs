using ProbPotes.components;
using ProbPotes.models;
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
    public partial class ParticipantReportDialog : UserControl, IDialogPage
    {
        private ProbPotesDialog ParentDialog;

        public Participant Participant;
        public EventClass Event;

        public ParticipantReportDialog(EventClass e, Participant p)
        {
            InitializeComponent();

            Participant = p;
            Event = e;

            
        }

        public bool CanGoBack => false;

        public bool CanGoForward => false;

        public bool ShowBackBtn => false;

        public bool ShowNextBtn => true;

        public int Index { get => 0; set { } }

        public int PageCount => 1;

        public ProbPotesDialog ParentController { set => ParentDialog = value; }

        public void FocusBox()
        {

        }
    }
}
