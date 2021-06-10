using ProbPotes.components;
using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.pages.events;
using ProbPotes.services;
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

namespace ProbPotes.pages
{
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();

            // Ajout des liens :
            tileEvents.DestinationPage = Pages.Events;
            tileExpenses.DestinationPage = Pages.Expenses;
            tileParticipants.DestinationPage = Pages.Participants;
            tileTotal.DestinationPage = Pages.Reports;

            // Définition des polices :
            txtAddExpenseTitle.Font = new Font(Fonts.medium, 25);
            txtAddExpenseDescription.Font = new Font(Fonts.regular, 13);

            // Définition des couleurs :
            iconAddExpense.ForeColor = Colors.black;
            txtAddExpenseTitle.ForeColor = Colors.black;
            txtAddExpenseDescription.ForeColor = Colors.grey;

            // Définition des icones :
            iconAddExpense.Text = char.ConvertFromUtf32(0xE719);

            // Affichage des nombres 
            tileEvents.Number = DatabaseManager.Events.Events.Count.ToString();
            tileParticipants.Number = DatabaseManager.Participants.Participants.Count.ToString();
            int expenseCount = 0;
            decimal expenseAmount = 0;
            List<EventClass> events = DatabaseManager.Events.Events;
            foreach(EventClass e in events)
            {
                foreach(Expense expense in e.Expenses.Expenses)
                {
                    expenseCount++;
                    expenseAmount += expense.sum;
                }
            }

            tileExpenses.Number = expenseCount.ToString();
            tileTotal.Number = expenseAmount.ToString() + " €";

            // Affichage des évènements
            int i = 0;
            events.Reverse();
            foreach(EventClass e in events)
            {
                if (!e.SoldeOn)
                {
                    EventPreview tile = new EventPreview();
                    tile.EventClass = e;
                    tile.Location = new Point(i * (tile.Width + 10), 0);
                    tile.ClickAction = OpenAddExpense;
                    pnlEvents.Controls.Add(tile);
                    i++;
                }
            }

        }

        public void OpenAddExpense(EventClass e)
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Ajouter une dépense à " + e.Title, 59161, new AddExpenseDialog(e), this.ParentForm);
            DialogResult result = dialog.Open();
        }

    }
}
