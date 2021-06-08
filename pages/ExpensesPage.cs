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

        private static int EVENTS_PADDING_V = 10;
        private static int EVENTS_PADDING_H = 0;

        public ExpensesPage()
        {
            InitializeComponent();

            // Polices et couleurs
            txtDescription.Font = new Font(Fonts.bold, 12);
            txtDescription.ForeColor = Colors.black;

            // Affichage du choix des évènements
            
            ProbPotesSelector all = new ProbPotesSelector();
            all.Title = "Tous";
            all.Icon = 59198;
            all.Location = new Point(EVENTS_PADDING_H, EVENTS_PADDING_V);
            all.argument = null;
            all.action = EventSelection;
            all.Selected = true;
            pnlEvents.Controls.Add(all);

            pnlEvents.Width = 2 * EVENTS_PADDING_H + all.Width;

            int i = 1;

            foreach (EventClass e in DatabaseManager.Events.Events)
            {
                ProbPotesSelector selector = new ProbPotesSelector();
                selector.Title = e.Title;
                selector.Icon = 59198;
                selector.Location = new Point(EVENTS_PADDING_H, EVENTS_PADDING_V + i * (selector.Height + EVENTS_PADDING_V));
                selector.argument = e;
                selector.action = EventSelection;
                i++;
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
            int i = 0;

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
                                pnlExpenses.Controls.Add(MakeExpenseTile(exp, i));
                                i++;
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
                        pnlExpenses.Controls.Add(MakeExpenseTile(e, i));
                        i++;
                    }
                }
            }
        }

        private ExpenseTile MakeExpenseTile(Expense e, int i)
        {
            ExpenseTile tile = new ExpenseTile();
            tile.Expense = e;
            tile.Location = new Point(0, i * (tile.Height + 10));
            return tile;
        }   

        private void ShowEmptyLabel()
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
