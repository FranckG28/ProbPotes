using ProbPotes.components;
using ProbPotes.components.expenses;
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
    public partial class ExpensesPage : UserControl
    {
        private EventClass SelectedEvent = null;

        public ExpensesPage()
        {
            InitializeComponent();

            // Affichage du choix des évènements

            int width = pnlEvents.Width - 10;

            ProbPotesSelector all = new ProbPotesSelector("Tous", null);
            all.Icon = 59198;
            all.action = EventSelection;
            all.Selected = true;
            all.Width = width;
            pnlEvents.Controls.Add(all);

            foreach (EventClass e in DatabaseManager.Events.Events)
            {
                ProbPotesSelector selector = new ProbPotesSelector(e.Title + " (" + e.Expenses.Expenses.Count+")", e);
                selector.action = EventSelection;
                selector.Width = width;
                pnlEvents.Controls.Add(selector);
            }

            // Rafraichissement
            RefreshExpenses();

        }

        private void EditExpense(Expense e)
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Modifier "+e.description, 59161, new AddExpenseDialog(DatabaseManager.Events.GetEvent(e.eventCode), ((MainForm)ParentForm).navigation.RefreshActualPage, e), ParentForm);
            DialogResult result = dialog.Open();
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
                    int expCount = SelectedEvent.Expenses.Expenses.Count;
                    pnlExpenses.Controls.Add(MakeLabel(expCount.ToString() + ((expCount == 1) ? " dépense pour un total de " : " dépenses pour un total de ") + SelectedEvent.Expenses.GetExpenseSum() + " €"));

                }
            }
        }

        private ExpenseTile MakeExpenseTile(Expense e)
        {
            ExpenseTile tile = new ExpenseTile();
            tile.Expense = e;
            tile.ClickAction = EditExpense;
            tile.Width = pnlExpenses.Width - 20;
            return tile;
        }   

        private Control MakeLabel(string content)
        {
            // Ajout d'un petit texte récapitulatif
            
            Label lbl = new Label();
            lbl.Font = new Font(Fonts.regular, 12);
            lbl.Width = pnlExpenses.Width - 25;
            lbl.AutoSize = false;
            lbl.Margin = new Padding(0,20,0,50);
            lbl.ForeColor = Color.FromArgb(100,100,100);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = content;
            return lbl;
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
