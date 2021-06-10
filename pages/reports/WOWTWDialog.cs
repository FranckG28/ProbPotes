﻿using ProbPotes.components;
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
    public partial class WOWTWDialog : UserControl, IDialogPage
    {
        public ProbPotesDialog ParentDialog;
        public EventClass Event;

        public WOWTWDialog(EventClass e)
        {
            InitializeComponent();

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