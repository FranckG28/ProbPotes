using ProbPotes.components;
using ProbPotes.components.expenses;
using ProbPotes.managers;
using ProbPotes.models;
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
    public partial class ExpensesPage : UserControl
    {
        private EventClass SelectedEvent = null;

        public ExpensesPage()
        {
            InitializeComponent();

            // Polices et couleurs
            txtDescription.Font = new Font(Fonts.bold, 12);
            txtDescription.ForeColor = Colors.black;

            // Affichage du choix des évènements
            
            ProbPotesSelector all = new ProbPotesSelector("Tous", null);
            all.Icon = 59198;
            all.action = EventSelection;
            all.Selected = true;
            pnlEvents.Controls.Add(all);

            foreach (EventClass e in DatabaseManager.Events.Events)
            {
                ProbPotesSelector selector = new ProbPotesSelector(e.Title, e);
                selector.action = EventSelection;
                pnlEvents.Controls.Add(selector);
            }

            // Rafraichissement
            RefreshExpenses();

        }

        private void EventSelection(Object e)
        {
            foreach (Control c in pnlEvents.Controls)
            {
                ProbPotesSelector s = (ProbPotesSelector)c;
                s.Selected = false;
            }
            SelectedEvent = (EventClass)e;
            RefreshExpenses();
        }

        private void RefreshExpenses()
        {

            pnlExpenses.Controls.Clear();

            if (SelectedEvent == null)
            {
               if (DatabaseManager.Events.Events.Count == 0)
                {
                    ShowEmptyLabel();
                } else
                {
                    foreach (EventClass e in DatabaseManager.Events.Events)
                    {
                        if (e.Expenses.Expenses.Count == 0)
                        {
                            ShowEmptyLabel();
                        } else
                        {
                            foreach (Expense exp in e.Expenses.Expenses)
                            {
                                pnlExpenses.Controls.Add(MakeExpenseTile(exp));
                            }
                        }
                    }
                }

            } else
            {
                List<Expense> exps = DatabaseManager.Events.GetEvent(SelectedEvent.Code).Expenses.Expenses;

                if (exps.Count == 0)
                {
                    ShowEmptyLabel();
                }
                else
                {
                    foreach (Expense e in DatabaseManager.Events.GetEvent(SelectedEvent.Code).Expenses.Expenses)
                    {
                        pnlExpenses.Controls.Add(MakeExpenseTile(e));
                    }
                }
            }
        }

        private ExpenseTile MakeExpenseTile(Expense e)
        {
            ExpenseTile tile = new ExpenseTile();
            tile.Expense = e;
            return tile;
        }   

        private void ShowEmptyLabel()
        {
            if (SelectedEvent != null)
            {
                Label lbl = new Label();
                lbl.Text = "Aucune dépense pour cet évènement :(";
                lbl.ForeColor = Colors.grey;
                lbl.Font = new Font(Fonts.book, 16);
                lbl.AutoSize = false;
                lbl.Size = new Size(pnlExpenses.Width, pnlExpenses.Height);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                pnlExpenses.Controls.Add(lbl);
            }
        }

    }
}
