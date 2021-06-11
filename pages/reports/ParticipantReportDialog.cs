using ProbPotes.components;
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

            btnExportToPDF.Font = new Font(Fonts.book, 11);
            btnExportToPDF.BackColor = Colors.blue;
            btnExportToPDF.FlatAppearance.MouseOverBackColor = Colors.green;
            btnExportToPDF.FlatAppearance.MouseDownBackColor = Colors.blue;

            // Calcul des totaux
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


            // Selection des dépenses payés
            selectPaid.Selected = true;
            ShowPaidExpenses(null);
            selectPaid.action = ShowPaidExpenses;
            selectOwes.action = ShowOwesExpenses;

            selectPaid.Title = PaidExpenses.Count + (PaidExpenses.Count == 1 ? " dépense payée (" + Decimal.Round(paid, 2) + " €)" : " dépenses payées (" + Decimal.Round(paid, 2) + " €)");
            selectOwes.Title = OwesExpenses.Count + (OwesExpenses.Count == 1 ? " dépense bénéficiée (" + Decimal.Round(owes, 2) + " €)" : " dépenses bénéficiées (" + Decimal.Round(owes, 2) + " €)");

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
                    flowLayoutPanel1.Controls.Add(new ExpenseReportTile(exp, (exp.sum / exp.GetPartAmount()) * Participant.Shares));
                }
            }
        }

        private void ShowEmptyLabel()
        {
            flowLayoutPanel1.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = "Aucune dépense ici :(";
            lbl.AutoSize = false;
            lbl.Size = new Size(flowLayoutPanel1.Width-10, flowLayoutPanel1.Height-10);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font(Fonts.book, 13);
            lbl.ForeColor = Colors.black;

            flowLayoutPanel1.Controls.Add(lbl);
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            // TODO: Générer un PDF pour le participant Participant dans Event
            GeneratePDF(Event);
        }
    }
}
