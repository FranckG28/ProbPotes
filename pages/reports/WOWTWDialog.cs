using ProbPotes.components;
using ProbPotes.components.reports;
using ProbPotes.managers;
using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.pages.reports
{
    public partial class WOWTWDialog : UserControl, IDialogPage
    {
        public ProbPotesDialog ParentDialog;
        public EventClass eventClass;

        public WOWTWDialog(EventClass e)
        {
            InitializeComponent();

            Event = e;            
        }

        public EventClass Event
        {
            get => eventClass;
            set
            {
                eventClass = value;

                List<WOWTW> wOWTWs = DatabaseManager.Events.GetWOWTWs(eventClass);
                flowLayoutPanel1.Controls.Clear();
                foreach(WOWTW wowtw in wOWTWs) 
                {
                    Debug.WriteLine(wowtw.ParticipantId);
                    flowLayoutPanel1.Controls.Add(new WOWTWTile(wowtw));
                }
            }
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
