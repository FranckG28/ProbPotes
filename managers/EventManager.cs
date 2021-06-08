using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace ProbPotes.managers
{

    class EventManager
    {

        // CLASSE DE GESTION DES ÉVÈNEMENTS PROBPOTES

        private List<EventClass> EventsList = new List<EventClass>();

        public List<EventClass> Events
        {
            get => EventsList;
        }

        // Un évènement inclus les dépenses et la liste des participant
        // --> A gérer lors de l'obtention, l'ajout et la suppression d'évènements


        public EventManager()
        {
            Debug.WriteLine("Création d'EventManager");
            RefreshEvents();
        }

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

                insertEvent.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = eventclass.Code;
                insertEvent.Parameters.Add(new OleDbParameter("titreEvent", OleDbType.WChar)).Value = eventclass.Title;
                insertEvent.Parameters.Add(new OleDbParameter("dateDebut", OleDbType.Date)).Value = eventclass.StartDate;
                insertEvent.Parameters.Add(new OleDbParameter("dateFin", OleDbType.Date)).Value = eventclass.EndDate;
                insertEvent.Parameters.Add(new OleDbParameter("description", OleDbType.WChar)).Value = eventclass.Description;
                insertEvent.Parameters.Add(new OleDbParameter("soldeON", OleDbType.Boolean)).Value = eventclass.StartDate < DateTime.Today && eventclass.EndDate > DateTime.Today;
                insertEvent.Parameters.Add(new OleDbParameter("codeCreateur", OleDbType.Integer)).Value = eventclass.CreatorCode;

                int result = insertEvent.ExecuteNonQuery();

                return result > 0;
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                DatabaseManager.db.Close();
                RefreshEvents();
            }


        }

        // Procédure de mise à jour d'un évènement
        // Retourne true si la mise à jour a réussi
        public Boolean UpdateEvent(EventClass eventclass)
        {
            try
            {
                DatabaseManager.db.Open();
                OleDbCommand update = new OleDbCommand("UPDATE Evenements set titreEvent = @titreEvent,dateDebut =@dateDebut, dateFin=@dateFin ,soldeON = @soldeON, codeCreateur =@codeCreateur where codeEvent =@codeEvent ;", DatabaseManager.db);

                update.Parameters.Add(new OleDbParameter("@codeEvent", OleDbType.Integer)).Value = eventclass.Code;
                update.Parameters.Add(new OleDbParameter("@titreEvent", OleDbType.WChar)).Value = eventclass.Title;
                update.Parameters.Add(new OleDbParameter("@dateDebut", OleDbType.Date)).Value = eventclass.StartDate;
                update.Parameters.Add(new OleDbParameter("@dateFin", OleDbType.Date)).Value = eventclass.EndDate;
                update.Parameters.Add(new OleDbParameter("@description", OleDbType.WChar)).Value = eventclass.Description;
                update.Parameters.Add(new OleDbParameter("@soldeON", OleDbType.Boolean)).Value = eventclass.StartDate < DateTime.Today && eventclass.EndDate > DateTime.Today;
                update.Parameters.Add(new OleDbParameter("@codeCreateur", OleDbType.Integer)).Value = eventclass.CreatorCode;

                //manque la partie mettre à jour les participants donc utiliser la liste des participants
                //mais je sais vraiment pas comment m'y procéder

                // TODO: Utiliser le gestionnaire d'invités et de dépense pour mettre à jour ces données

                int result = update.ExecuteNonQuery();

                return result > 0;
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                DatabaseManager.db.Close();
                RefreshEvents();
            }
        }

        // Procédure de suppression d'un évènement
        // Retourne true si la suppression a reussi
        public Boolean DeleteEvent(int eventId)
        {
            //ici j'ai modifié le paramètre au lieu de int id j'ai juste mis eventclass (je sais pas si le id correspond au code de l'event!)
            try
            {
                DatabaseManager.db.Open();
                OleDbCommand delete = new OleDbCommand(@"DELETE FROM Evenements WHERE codeEvent = @codeEvent;", DatabaseManager.db);

                delete.Parameters.Add(new OleDbParameter("@codeEvent", OleDbType.Integer)).Value = eventId;
                int result = delete.ExecuteNonQuery();

                return result > 0;

            } 
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                DatabaseManager.db.Close();
                RefreshEvents();
            }
        }

        // Fonction qui retourne la liste de tous les participants de la base :
        public Boolean RefreshEvents()
        {
            try
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
                    OleDbCommand cdGuest = new OleDbCommand("SELECT codePart FROM Invites WHERE codeEvent=" + dr[0].ToString(), DatabaseManager.db);
                    OleDbDataReader drGuest = cdGuest.ExecuteReader();
                    List<int> guest = new List<int>();

                    while (drGuest.Read())
                    {
                        guest.Add(Convert.ToInt32(drGuest[0].ToString()));
                    }

                    Debug.WriteLine("event ajouté");

                    res.Add(new EventClass(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), Convert.ToInt32(dr[6].ToString()), (Boolean)dr[5], dr[4].ToString(), debut, fin, guest));
                }

                Debug.WriteLine("FIN REFRESHEVENT");
                
                EventsList = res;

                return true;
            } catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            } finally
            {
                DatabaseManager.db.Close();
            }
        }

        // Fonction qui retourne l'évènement correspondant au numéro demandé dans la base :
        public EventClass GetEvent(int code)
        {
            return EventsList.Where(e => e.Code == code).First();            
        }


        // Fonction qui retourne un navigateur d'évènement (pour la navigation un à un)
        public EventNavigation GetEventNavigator()
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
