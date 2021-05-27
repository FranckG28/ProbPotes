using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProbPotes.models
{
    public class Expense
    {

        public int code;
        public int eventCode;
        public string description;
        public Decimal sum;
        public List<int> recipients;
        public int creatorCode;
        public DateTime date;
        public string comment;

        public Expense(int code, int eventCode, string description, Decimal sum, List<int> recipients, int creatorCode, DateTime date, string comment)
        {
            this.code = code;
            this.eventCode = eventCode;
            this.description = description;
            this.sum = sum;
            this.recipients = recipients;
            this.creatorCode = creatorCode;
            this.date = date;
            this.comment = comment;
        }
        
        // RESTE A DEFINIR LA LISTE DES BENEFICIAIRE LORS DE L'UTILISATION DE CE CONSTRUCTEUR :
        public Expense(DataRow row)
        {
            this.code = (int)row["numDepense"];
            this.description = (string)row["description"];
            this.sum = (Decimal)row["montant"];
            this.creatorCode = (int)row["codePart"];
            this.eventCode = (int)row["codeEvent"];
            this.date = (DateTime)row["dateDepense"];
            this.comment = (string)row["commentaire"];
        }

        public Boolean insertExpend(OeldbConnection connect)
        {
        //METHOD AJOUTER UNE DEPENSE
        public Boolean insertSpent(OleDbConnection connect)
        {
            //AJOUT DANS LES BASES DE DONNEES
            try
            {
                //AJOUT DANS DEPENSE
                OleDbCommand cdInsert = new OleDbCommand(@"INSERT INTO Depenses (numDepense,description,montant,dateDepense,commentaire,codeEvent,codePart)
                                                         VALUES (?,?,?,?,?,?,?)", connect);

                //RECHERCHE DE CODEEVENT AVEC LE NOM E L EVENT
                /*OleDbCommand cdCodeEvent = new OleDbCommand("SELECT codeEvent FROM Evenements WHERE titreEvent='" + this.codeEvent + "'", connect);
                int codeEvent = Convert.ToInt32(cdCodeEvent.ExecuteScalar().ToString());*/

                //RECHERCHE DE CODEPART AVEC LE NOM DU PART
                /*OleDbCommand cdCodePart = new OleDbCommand("SELECT codeParticipant FROM Participants WHERE nomPart='" + cboPayer.Text.Split(' ')[0] + "'", connect);*/


                //RECHERCHE DU DERNIERE ID DE LA DERNIERE DEPENSE POUR PRENDRE CETTE ID+1 POUR CREER UNE NOUVELLE DEPENSE
                OleDbCommand recupNumDepense = new OleDbCommand("SELECT numDepense FROM Depenses ORDER BY numDepense DESC", connect);

                int numDepense = Convert.ToInt32(recupNumDepense.ExecuteScalar().ToString()) + 1;

                cdInsert.Parameters.Add(new OleDbParameter("numDepense", OleDbType.Integer)).Value = this.code;
                cdInsert.Parameters.Add(new OleDbParameter("description", OleDbType.WChar)).Value = this.description;
                cdInsert.Parameters.Add(new OleDbParameter("montant", OleDbType.Currency)).Value = this.sum;
                cdInsert.Parameters.Add(new OleDbParameter("dateDepense", OleDbType.Date)).Value = this.date;
                cdInsert.Parameters.Add(new OleDbParameter("commentaire", OleDbType.WChar)).Value = this.comment;
                cdInsert.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = this.eventCode;
                cdInsert.Parameters.Add(new OleDbParameter("codePart", OleDbType.Integer)).Value = this.creatorCode;
                cdInsert.ExecuteNonQuery();


                //AJOUT DANS BENEFICIAIRE

                OleDbCommand insertBenef = new OleDbCommand(@"INSERT INTO Beneficiaires(numDepense,codePart)
                                                                    VALUES (?,?)", connect);

                insertBenef.Parameters.Add(new OleDbParameter("numDepense", OleDbType.Integer));
                insertBenef.Parameters.Add(new OleDbParameter("codePart", OleDbType.Integer));


                foreach (int val in this.beneficiaire)
                {
                    //AJOUTS DES BENEFICIAIRES
                    insertBenef.Parameters["numDepense"].Value = numDepense;
                    insertBenef.Parameters["codePart"].Value = val;

                    insertBenef.ExecuteNonQuery();
                }
                //AJOUT DU PAYEUR
                insertBenef.Parameters["numDepense"].Value = numDepense;
                insertBenef.Parameters["codePart"].Value = this.creatorCode;

                insertBenef.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                Console.WriteLine(ex);
            }
        }

        }
}
