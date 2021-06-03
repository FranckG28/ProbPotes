using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace ProbPotes.managers
{

    class EventManager
    {
        
        // Un évènement inclus les dépenses et la liste des participant
        // --> A gérer lors de l'obtention, l'ajout et la suppression d'évènements

        // Procédure d'ajout d'un évènement
        // Retourne true si l'ajout a réussi
        public Boolean AddEvent(EventClass eventclass) {
            try
            {
                DatabaseManager.db.Open();

                OleDbCommand insertEvent = new OleDbCommand(@"INSERT INTO Evenements(codeEvent,titreEvent,dateDebut,dateFin,description,soldeON,codeCreateur)
                                                       	VALUES(?,?,?,?,?,?,?)", DatabaseManager.db);

                //CHERCHE LE PROCHAIN CODE EVENT LIBRE
                /*OleDbCommand cdCodeEvent = new OleDbCommand("SELECT codeEvent FROM Evenements ORDER BY codeEvent DESC", DatabaseManager.db);
                int codeEvent = Convert.ToInt32(cdCodeEvent.ExecuteScalar().ToString()) + 1;*/

                insertEvent.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = eventclass.code;
                insertEvent.Parameters.Add(new OleDbParameter("titreEvent", OleDbType.WChar)).Value = eventclass.title;
                insertEvent.Parameters.Add(new OleDbParameter("dateDebut", OleDbType.Date)).Value = eventclass.startDate;
                insertEvent.Parameters.Add(new OleDbParameter("dateFin", OleDbType.Date)).Value = eventclass.endDate;
                insertEvent.Parameters.Add(new OleDbParameter("description", OleDbType.WChar)).Value = eventclass.description;
                insertEvent.Parameters.Add(new OleDbParameter("soldeON", OleDbType.Boolean)).Value = eventclass.startDate < DateTime.Today && eventclass.endDate > DateTime.Today;
                insertEvent.Parameters.Add(new OleDbParameter("codeCreateur", OleDbType.Integer)).Value = eventclass.creatorCode;

                insertEvent.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DatabaseManager.db.Close();
            }


        }

        // Procédure de mise à jour d'un évènement
        // --> Mettre à jour un évènement signifie aussi mettre à jour sa liste des participant
        // --> Les modifications sur les dépenses ne sont pas gérés ici
        // Retourne true si la mise à jour a réussi
        public Boolean UpdateEvent(EventClass eventclass)
        {
            try
            {
                DatabaseManager.db.Open();
                OleDbCommand update = new OleDbCommand("UPDATE Evenements set titreEvent = @titreEvent,dateDebut =@dateDebut, dateFin=@dateFin ,soldeON = @soldeON, codeCreateur =@codeCreateur where codeEvent =@codeEvent ;", DatabaseManager.db);

                update.Parameters.Add(new OleDbParameter("@codeEvent", OleDbType.Integer)).Value = eventclass.code;
                update.Parameters.Add(new OleDbParameter("@titreEvent", OleDbType.WChar)).Value = eventclass.title;
                update.Parameters.Add(new OleDbParameter("@dateDebut", OleDbType.Date)).Value = eventclass.startDate;
                update.Parameters.Add(new OleDbParameter("@dateFin", OleDbType.Date)).Value = eventclass.endDate;
                update.Parameters.Add(new OleDbParameter("@description", OleDbType.WChar)).Value = eventclass.description;
                update.Parameters.Add(new OleDbParameter("@soldeON", OleDbType.Boolean)).Value = eventclass.startDate < DateTime.Today &&                                 eventclass.endDate > DateTime.Today;
                update.Parameters.Add(new OleDbParameter("@codeCreateur", OleDbType.Integer)).Value = eventclass.creatorCode;

                //manque la partie mettre à jour les participants donc utiliser la liste des participants
                //mais je sais vraiment pas comment m'y procéder

                update.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DatabaseManager.db.Close();
            }
        }

        // Procédure de suppression d'un évènement
        // Retourne true si la suppression a reussi
        public Boolean DeleteEvent(EventClass eventclass)
        {
            //ici j'ai modifié le paramètre au lieu de int id j'ai juste mis eventclass (je sais pas si le id correspond au code de l'event!)
            try
            {
                DatabaseManager.db.Open();
                OleDbCommand delete = new OleDbCommand(@"DELETE FROM Evenements WHERE codeEvent = @codeEvent;", DatabaseManager.db);

                delete.Parameters.Add(new OleDbParameter("@codeEvent", OleDbType.Integer)).Value = eventclass.code;
                delete.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DatabaseManager.db.Close();
            }
        }

        // Fonction qui retourne la liste de tous les participants de la base :
        public List<EventClass> GetEvents()
        {
            List<EventClass> res = new List<EventClass>();

                DatabaseManager.db.Open();

                OleDbCommand cdGetEvent = new OleDbCommand("SELECT * FROM Evenements", DatabaseManager.db);

                OleDbDataReader dr = cdGetEvent.ExecuteReader();

                while (dr.Read())
                {
                DateTime debut = (DateTime)dr[2];
                DateTime fin = (DateTime)dr[3];


                //RECHERCHE LES PARTICIPANTS A L'EVENEMENT
                OleDbCommand cdGuest = new OleDbCommand("SELECT codePart FROM Invites WHERE codeEvent="+dr[0].ToString(), DatabaseManager.db);
                OleDbDataReader drGuest = cdGuest.ExecuteReader();
                List<int> guest = new List<int>();

                while (drGuest.Read())
                {
                    guest.Add(Convert.ToInt32(drGuest[0].ToString()));
                }

                //RECHERCHE DES DEPENSES DE L'EVENEMENT
                OleDbCommand cdExpense = new OleDbCommand("SELECT * FROM Depenses WHERE codeEvent="+dr[0].ToString(), DatabaseManager.db);
                OleDbDataReader drExpense = cdExpense.ExecuteReader();
                List<Expense> rowExpense = new List<Expense>();

                while (drExpense.Read())
                {
                    List<int> listRecipients = new List<int>();
                    OleDbCommand cdRecipients = new OleDbCommand("SELECT codePart FROM Beneficiaires WHERE codePart="+drExpense[0].ToString(), DatabaseManager.db);
                    OleDbDataReader drRecipients = cdRecipients.ExecuteReader();

                    while (drRecipients.Read())
                    {
                        listRecipients.Add(Convert.ToInt32(drRecipients[0].ToString()));
                    }

                    DateTime debutExpense = (DateTime)drExpense[3];
                    rowExpense.Add(new Expense(Convert.ToInt32(drExpense[0].ToString()), Convert.ToInt32(dr[0].ToString()),drExpense[1].ToString(),(decimal)drExpense[2],listRecipients,Convert.ToInt32(drExpense[6].ToString()),debutExpense,drExpense[4].ToString()));
                }

                res.Add(new EventClass(Convert.ToInt32(dr[0].ToString()),dr[1].ToString(), Convert.ToInt32(dr[6].ToString()),(Boolean)dr[5],dr[4].ToString(),debut,fin,guest,rowExpense));
                }
            DatabaseManager.db.Close();

            return res;
        }

        // Fonction qui retourne l'évènement correspondant au numéro demandé dans la base :
        public EventClass GetEvent(int code)
        {
            DatabaseManager.db.Open();

            OleDbCommand cdGetEvent = new OleDbCommand("SELECT * FROM Evenements WHERE codeEvent="+code, DatabaseManager.db);

            OleDbDataReader dr = cdGetEvent.ExecuteReader();

            dr.Read();

                DateTime debut = new DateTime((long)dr[2]);
                DateTime fin = new DateTime((long)dr[3]);


                //RECHERCHE LES PARTICIPANTS A L'EVENEMENT
                OleDbCommand cdGuest = new OleDbCommand("SELECT codePart WHERE codeEvent=" + dr[0].ToString(), DatabaseManager.db);
                OleDbDataReader drGuest = cdGuest.ExecuteReader();
                List<int> guest = new List<int>();

                while (drGuest.Read())
                {
                    guest.Add(Convert.ToInt32(drGuest[0].ToString()));
                }

                //RECHERCHE DES DEPENSES DE L'EVENEMENT
                OleDbCommand cdExpense = new OleDbCommand("SELECT * FROM Depenses WHERE codeEvent=" + dr[0].ToString(), DatabaseManager.db);
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

                    DateTime debutExpense = new DateTime((long)drExpense[3]);
                    rowExpense.Add(new Expense(Convert.ToInt32(drExpense[0].ToString()), Convert.ToInt32(dr[0].ToString()), drExpense[1].ToString(), (decimal)drExpense[2], listRecipients, Convert.ToInt32(drExpense[6].ToString()), debutExpense, drExpense[4].ToString()));
                }

                EventClass rowRes=new EventClass(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), Convert.ToInt32(dr[6].ToString()), (Boolean)dr[5], dr[4].ToString(), debut, fin, guest, rowExpense);
            DatabaseManager.db.Close();

            return rowRes;

        }


        public EventNavigation getEventNavigator()
        {

            DataSet data = new DataSet();

            BindingSource eventBs = new BindingSource();
            BindingSource participantBs = new BindingSource();

            BindingNavigator bn = new BindingNavigator();

            OleDbDataAdapter adapter5 = new OleDbDataAdapter(@"SELECT * FROM Evenements", DatabaseManager.db);
            adapter5.Fill(data, "Evenements");
            new OleDbCommandBuilder(adapter5);

            OleDbDataAdapter adapter6 = new OleDbDataAdapter(@"SELECT * FROM Invites", DatabaseManager.db);
            adapter6.Fill(data, "Invites");
            new OleDbCommandBuilder(adapter6);

            OleDbDataAdapter adapter7 = new OleDbDataAdapter(@"SELECT * FROM Participants", DatabaseManager.db);
            adapter7.Fill(data, "Participants");
            new OleDbCommandBuilder(adapter7);

            eventBs.DataSource = data.Tables["Evenements"];
            participantBs.DataSource = data.Tables["Participants"]; //relation entre table-bindingsource
            bn.BindingSource = eventBs;

            return new EventNavigation(data, eventBs, participantBs, bn);

        }

    }
}
