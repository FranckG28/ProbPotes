﻿using ProbPotes.components;
using ProbPotes.components.expenses;
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

namespace ProbPotes.pages.reports
{
    public partial class ParticipantReportDialog : UserControl, IDialogPage
    {
        private ProbPotesDialog ParentDialog;

        public Participant Participant;
        public EventClass Event;

        private List<Expense> PaidExpenses = new List<Expense>();
        private List<Expense> OwesExpenses = new List<Expense>();

        public ParticipantReportDialog(EventClass e, Participant p)
        {
            InitializeComponent();

            Participant = p;
            Event = e;


            // Polices
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                List<Label> labels = new List<Label>() { txtLblOwes, txtLblPaid, txtTip };
                foreach(Label lbl in labels)
                {
                    lbl.Font = new Font(Fonts.book, 11);
                    lbl.ForeColor = Colors.black;
                }

                List<Label> prices = new List<Label>() { txtPaid, txtOwes };
                foreach(Label lbl in prices)
                {
                    lbl.Font = new Font(Fonts.bold, 13);
                    lbl.ForeColor = Colors.blue;
                }
            }

            // Calcul des totaux

            // Payé :
            Decimal paid = 0;
            Decimal owes = 0;
            foreach (Expense exp in e.Expenses.Expenses)
            {
                if (exp.creatorCode == p.Code)
                {
                    paid += exp.sum;
                    PaidExpenses.Add(exp);
                }

                if (exp.recipients.Contains(p.Code) && exp.creatorCode != p.Code)
                {
                    owes += (exp.sum/exp.GetPartAmount())*p.Shares;
                    OwesExpenses.Add(exp);
                }

            }

            txtOwes.Text = FormatDecimal(owes);
            txtPaid.Text = FormatDecimal(paid);

            // Selection des dépenses payés
            selectPaid.Selected = true;
            ShowPaidExpenses(null);
            selectPaid.action = ShowPaidExpenses;
            selectOwes.action = ShowOwesExpenses;

            selectPaid.Title = "Dépenses payés (" + PaidExpenses.Count + ")";
            selectOwes.Title = "Dépenses bénéficiés (" + OwesExpenses.Count + ")";

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

        private String FormatDecimal(Decimal d)
        {
            return d.ToString() + " €";
        } 

        private void ShowPaidExpenses(Object e)
        {
            selectOwes.Selected = false;
            if (PaidExpenses.Count == 0)
            {
                ShowEmptyLabel();
            } else
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (Expense exp in PaidExpenses)
                {
                    flowLayoutPanel1.Controls.Add(new ExpenseReportTile(exp));
                }
            }
        }

        private void ShowOwesExpenses(Object e)
        {
            selectPaid.Selected = false;
            if (OwesExpenses.Count == 0)
            {
                ShowEmptyLabel();
            } else
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (Expense exp in OwesExpenses)
                {
                    flowLayoutPanel1.Controls.Add(new ExpenseReportTile(exp));
                }
            }
        }

        private void ShowEmptyLabel()
        {
            flowLayoutPanel1.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = "Aucune dépense ici :(";
            lbl.AutoSize = false;
            lbl.Size = new Size(flowLayoutPanel1.Width, flowLayoutPanel1.Height);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font(Fonts.book, 13);
            lbl.ForeColor = Colors.black;

            flowLayoutPanel1.Controls.Add(lbl);
        }

        private void selectOwes_Load(object sender, EventArgs e)
        {

        }

        private void selectPaid_Load(object sender, EventArgs e)
        {

        }
    }
}
