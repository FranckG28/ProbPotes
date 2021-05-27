using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.managers
{
    class ExpensesManager
    {

        // Inutile de créer des fonctions pour obtenir les dépenses, elles sont incluses dans les évènements

        // Procédure d'ajout d'une dépense à un évènement 
        // Retourne true si l'ajout a réussi
        public Boolean AddExpense(int eventId, Expense expense)
        {
            return false;
        }

        // Procédure de mise à jour d'une dépense
        // Retourne true si la mise à jour a reussi
        public Boolean UpdateExpense(int eventId, Expense expense)
        {
            return false;
        }

        // Procédure de suppression d'une dépense d'un évènement
        // Retourne true si la suppression a reussi
        public Boolean DeleteExpense(int eventId, int expenseId)
        {
            return false;
        }

    }
}
