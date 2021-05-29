using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProbPotes.managers
{

    class EventManager
    {
        //METTEZ VOTRE SOURCE DE BDD SINON CA MARCHE PAS !
        OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hsche\source\repos\probpotes\bdEvents.mdb");

        // Un évènement inclus les dépenses et la liste des participant
        // --> A gérer lors de l'obtention, l'ajout et la suppression d'évènements

        // Procédure d'ajout d'un évènement
        // Retourne true si l'ajout a réussi
        public Boolean AddEvent(EventClass eventclass) {
            try
            {
                connect.Open();

                OleDbCommand insertEvent = new OleDbCommand(@"INSERT INTO Evenements(codeEvent,titreEvent,dateDebut,dateFin,description,soldeON,codeCreateur)
                                                       	VALUES(?,?,?,?,?,?,?)", connect);

                //CHERCHE LE PROCHAIN CODE EVENT LIBRE
                /*OleDbCommand cdCodeEvent = new OleDbCommand("SELECT codeEvent FROM Evenements ORDER BY codeEvent DESC", connect);
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
                connect.Close();
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
                connect.Open();
                OleDbCommand update = new OleDbCommand("UPDATE Evenements set titreEvent = @titreEvent,
                    dateDebut =@dateDebut, dateFin=@dateFin ,soldeON = @soldeON, codeCreateur =@codeCreateur where codeEvent =@codeEvent ;");

                update.Parameters.Add(new OleDbParameter("@codeEvent", OleDbType.Integer)).Value = eventclass.code;
                update.Parameters.Add(new OleDbParameter("@titreEvent", OleDbType.WChar)).Value = eventclass.title;
                update.Parameters.Add(new OleDbParameter("@dateDebut", OleDbType.Date)).Value = eventclass.startDate;
                update.Parameters.Add(new OleDbParameter("@dateFin", OleDbType.Date)).Value = eventclass.endDate;
                update.Parameters.Add(new OleDbParameter("@description", OleDbType.WChar)).Value = eventclass.description;
                update.Parameters.Add(new OleDbParameter("@soldeON", OleDbType.Boolean)).Value = eventclass.startDate < DateTime.Today &&                                 eventclass.endDate > DateTime.Today;
                update.Parameters.Add(new OleDbParameter("@codeCreateur", OleDbType.Integer)).Value = eventclass.creatorCode;

                update.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connect.Close();
            }
        }

        // Procédure de suppression d'un évènement
        // Retourne true si la suppression a reussi
        public Boolean DeleteEvent(int id)
        {
            return false;
        }

        // Fonction qui retourne la liste de tous les participants de la base :
        public List<EventClass> GetEvents()
        {
            return null;
        }

        // Fonction qui retourne l'évènement correspondant au numéro demandé dans la base :
        public EventClass GetEvent(int code)
        {
            return null;
        }

    }
}
