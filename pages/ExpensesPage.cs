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

namespace ProbPotes.pages
{
    public partial class ExpensesPage : UserControl
    {
        public ExpensesPage()
        {
            InitializeComponent();

            expenseTile1.Expense = expense;
        }

        Expense expense = new Expense(20, 30, "Ma dépense", new Decimal(29.26), new List<int>() { 28,10,2002}, 28, DateTime.Now, "Commentaire de test");
    }
}
