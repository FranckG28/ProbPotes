﻿using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.managers
{
    public class ExpensesManager
    {

        // Classe de gestion des dépenses d'un évènement

        // Code de l'évènement à gérer
        private int EventId;

        // Liste des dépenses de l'évènement
        private List<Expense> ExpensesList;

        // Getter de la liste des évènements
        public List<Expense> Expenses
        {
            get => ExpensesList;
        }

        // Constructeur de la classe
        public ExpensesManager(int id)
        {
            this.EventId = id;

            RefreshExpenses();
        }

        // Procédure de mise à jour de la liste des dépenses

        // Procédure d'ajout d'une dépense 
        // Retourne true si l'ajout a réussi
        public Boolean AddExpense(Expense expense)
        {
            return false;
        }

        // Procédure de mise à jour d'une dépense
        // Retourne true si la mise à jour a reussi
        public Boolean UpdateExpense(Expense expense)
        {
            return false;
        }

        // Procédure de suppression d'une dépense
        // Retourne true si la suppression a reussi
        public Boolean DeleteExpense(int expenseId)
        {
            return false;
        }

        public Boolean RefreshExpenses()
        {

            try
            {
                //RECHERCHE DES DEPENSES DE L'EVENEMENT
                OleDbCommand cdExpense = new OleDbCommand("SELECT * FROM Depenses WHERE codeEvent=" + EventId, DatabaseManager.db);
                OleDbDataReader drExpense = cdExpense.ExecuteReader();
                List<Expense> rowExpense = new List<Expense>();

                while (drExpense.Read())
                {
                    List<int> listRecipients = new List<int>();
                    OleDbCommand cdRecipients = new OleDbCommand("SELECT codePart FROM Beneficiaires WHERE codePart=" + drExpense[0].ToString(), DatabaseManager.db);
                    OleDbDataReader drRecipients = cdRecipients.ExecuteReader();

                    while (drRecipients.Read())
                    {
                        listRecipients.Add(Convert.ToInt32(drRecipients[0].ToString()));
                    }

                    DateTime debutExpense = (DateTime)drExpense[3];
                    rowExpense.Add(new Expense(Convert.ToInt32(drExpense[0].ToString()), EventId, drExpense[1].ToString(), (decimal)drExpense[2], listRecipients, Convert.ToInt32(drExpense[6].ToString()), debutExpense, drExpense[4].ToString()));
                }

                ExpensesList = rowExpense;

                return true;

            } catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }

    }
}
