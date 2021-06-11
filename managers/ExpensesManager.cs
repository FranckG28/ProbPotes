using ProbPotes.models;
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
        private List<Expense> ExpensesList = new List<Expense>();

        // Getter de la liste des évènements
        public List<Expense> Expenses
        {
            get => ExpensesList;
        }

        public Expense GetExpense(int id)
        {
            return Expenses.Where(e => e.code == id).FirstOrDefault(null);
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
            try
            {
                OleDbCommand insertExpense = new OleDbCommand("INSERT INTO Depenses (numDepense,description,montant,dateDepense,commentaire,codeEvent,codePart)" +
                    "                                       VALUES(?,?,?,?,?,?,?)", DatabaseManager.db);

                insertExpense.Parameters.Add(new OleDbParameter("numDepense", OleDbType.Integer)).Value = expense.code;
                insertExpense.Parameters.Add(new OleDbParameter("description", OleDbType.WChar)).Value = expense.description;
                insertExpense.Parameters.Add(new OleDbParameter("montant", OleDbType.Currency)).Value = expense.sum;
                insertExpense.Parameters.Add(new OleDbParameter("dateDepense", OleDbType.Date)).Value = expense.date;
                insertExpense.Parameters.Add(new OleDbParameter("commentaire", OleDbType.WChar)).Value = expense.comment;
                insertExpense.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = expense.eventCode;
                insertExpense.Parameters.Add(new OleDbParameter("codePart", OleDbType.Integer)).Value = expense.creatorCode;

                int resultInsertExpense = insertExpense.ExecuteNonQuery();

                OleDbCommand insertBeneficiaire = new OleDbCommand("INSERT INTO Beneficiaires(numDepense,codePart)" +
    "                                             VALUES(?,?)", DatabaseManager.db);

                insertBeneficiaire.Parameters.Add(new OleDbParameter("numDepense", OleDbType.Integer)).Value = expense.code;
                OleDbParameter codePart = new OleDbParameter("codePart", OleDbType.Integer);

                foreach(int part in expense.recipients)
                {
                    codePart.Value = part;
                    insertBeneficiaire.Parameters.Add(codePart);
                    try
                    {
                        insertBeneficiaire.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                return resultInsertExpense > 0;
            }
            catch (Exception)
            {
                return false;
            }
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
                if (DatabaseManager.db.State == System.Data.ConnectionState.Closed)
                    DatabaseManager.db.Open();

                OleDbDataReader drExpense = cdExpense.ExecuteReader();
                List<Expense> rowExpense = new List<Expense>();

                while (drExpense.Read())
                {
                    List<int> listRecipients = new List<int>();
                    OleDbCommand cdRecipients = new OleDbCommand("SELECT codePart FROM Beneficiaires WHERE numDepense=" + drExpense[0].ToString(), DatabaseManager.db);
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
            } finally
            {
                //DatabaseManager.db.Close();
            }
        }

    }
}
