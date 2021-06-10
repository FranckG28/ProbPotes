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

        // Un évènement inclus les dépenses et la liste des participants
        // --> A gérer lors de l'obtention, l'ajout et la suppression d'évènements


        public EventManager()
        {
            RefreshEvents();
        }

        // Procédure d'ajout d'un évènement
        // Retourne true si l'ajout a réussi
        public Boolean AddEvent(EventClass eventclass) {
            try
            {
                if (DatabaseManager.db.State != ConnectionState.Open)
                    DatabaseManager.db.Open();

                OleDbCommand insertEvent = new OleDbCommand(@"INSERT INTO Evenements(codeEvent,titreEvent,dateDebut,dateFin,description,soldeON,codeCreateur)
                                                       	VALUES(?,?,?,?,?,?,?)", DatabaseManager.db);

                insertEvent.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = eventclass.Code;
                insertEvent.Parameters.Add(new OleDbParameter("titreEvent", OleDbType.WChar)).Value = eventclass.Title;
                insertEvent.Parameters.Add(new OleDbParameter("dateDebut", OleDbType.Date)).Value = eventclass.StartDate;
                insertEvent.Parameters.Add(new OleDbParameter("dateFin", OleDbType.Date)).Value = eventclass.EndDate;
                insertEvent.Parameters.Add(new OleDbParameter("description", OleDbType.WChar)).Value = eventclass.Description;
                insertEvent.Parameters.Add(new OleDbParameter("soldeON", OleDbType.Boolean)).Value =  false;
                insertEvent.Parameters.Add(new OleDbParameter("codeCreateur", OleDbType.Integer)).Value = eventclass.CreatorCode;

                //AJOUT DANS LA TABLE Evenement
                int resultInsertEvent = insertEvent.ExecuteNonQuery();


                Boolean resultInsertPart = true;
                //AJOUT DES PARTICIPANTS DANS LA TABLE Invites
                foreach(int codePart in eventclass.Guests)
                {
                    OleDbCommand insertPart = new OleDbCommand("INSERT INTO invites (codeEvent,codePart) VALUES (?,?)", DatabaseManager.db);
                    insertPart.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = eventclass.Code;
                    insertPart.Parameters.Add(new OleDbParameter("codePart", OleDbType.Integer)).Value = codePart;

                    int boolInsertPart = insertPart.ExecuteNonQuery();
                    if (resultInsertPart)
                    {
                        resultInsertPart = boolInsertPart > 0;
                    }
                }

                return resultInsertEvent > 0 && resultInsertPart;
                
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
                if (DatabaseManager.db.State != ConnectionState.Open)
                    DatabaseManager.db.Open();
                OleDbCommand update = new OleDbCommand("UPDATE Evenements SET titreEvent = ? ,dateDebut = ? , dateFin= ? , description = ? ,soldeON = ? , codeCreateur = ? WHERE codeEvent = ?", DatabaseManager.db);

                
                update.Parameters.Add(new OleDbParameter("titreEvent", OleDbType.WChar)).Value = eventclass.Title;
                update.Parameters.Add(new OleDbParameter("dateDebut", OleDbType.Date)).Value = eventclass.StartDate;
                update.Parameters.Add(new OleDbParameter("dateFin", OleDbType.Date)).Value = eventclass.EndDate;
                update.Parameters.Add(new OleDbParameter("description", OleDbType.WChar)).Value = eventclass.Description;
                update.Parameters.Add(new OleDbParameter("soldeON", OleDbType.Boolean)).Value = eventclass.SoldeOn;
                update.Parameters.Add(new OleDbParameter("codeCreateur", OleDbType.Integer)).Value = eventclass.CreatorCode;
                update.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = eventclass.Code;

                int result = update.ExecuteNonQuery();

                if (result != 1) throw new Exception("Impossible de mettre à jour l'évènement (" + result + ")");

                //UPDATE DES PARTICIPANTS
                OleDbCommand deleteAllPartEvent = new OleDbCommand("DELETE FROM Invites WHERE codeEvent=" + eventclass.Code, DatabaseManager.db);
                int resultDelete=deleteAllPartEvent.ExecuteNonQuery();

                //AJOUT DES PARTICIPANTS DANS LA TABLE Invites
                foreach (int codePart in eventclass.Guests)
                {
                    OleDbCommand insertPart = new OleDbCommand("INSERT INTO Invites (codeEvent,codePart) VALUES (?,?)", DatabaseManager.db);
                    insertPart.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = eventclass.Code;
                    insertPart.Parameters.Add(new OleDbParameter("codePart", OleDbType.Integer)).Value = codePart;

                    int insertResult = insertPart.ExecuteNonQuery();
                    if (insertResult != 1) throw new Exception("Impossible d'ajouter les participants");
                }

                return true;
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
            try
            {
                if (DatabaseManager.db.State != ConnectionState.Open)
                    DatabaseManager.db.Open();
                OleDbCommand delete = new OleDbCommand(@"DELETE FROM Evenements WHERE codeEvent = @codeEvent;", DatabaseManager.db);

                // TODO: Supprimmer aussi toutes les dépenses et invités de l'évènement

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

                OleDbCommand cdGetEvent = new OleDbCommand("SELECT * FROM Evenements", DatabaseManager.db);

                if (DatabaseManager.db.State == ConnectionState.Closed)
                    DatabaseManager.db.Open();
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


                    res.Add(new EventClass(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), Convert.ToInt32(dr[6].ToString()), (Boolean)dr[5], dr[4].ToString(), debut, fin, guest));
                }
                
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

        public void CreateReport(EventClass evt)
        {
            if (DatabaseManager.db.State != ConnectionState.Open)
                DatabaseManager.db.Open();

            DataTable dtBilan = new DataTable();

            dtBilan.Columns.Add("codeParticipant", typeof(int));
            dtBilan.Columns.Add("Personne", typeof(string));
            dtBilan.Columns.Add("Plus", typeof(double));
            dtBilan.Columns.Add("Moins", typeof(double));
            dtBilan.Columns.Add("Solde", typeof(double));

            Dictionary<int, int> partShare = new Dictionary<int, int>();

            for (int i = 0; i < evt.Guests.Count; i++)
            {
                OleDbCommand cdPartShare = new OleDbCommand("SELECT * FROM Participants WHERE codeParticipant=" + evt.Guests[i], DatabaseManager.db);

                OleDbDataReader dr = cdPartShare.ExecuteReader();

                dr.Read();

                partShare.Add(Convert.ToInt32(dr["codeParticipant"].ToString()), Convert.ToInt32(dr["nbParts"].ToString()));
            }


            foreach (KeyValuePair<int, int> val in partShare)
            {

                //PARTI MOINS
                double moins = 0;

                OleDbCommand cdMoins = new OleDbCommand
                {
                    Connection = DatabaseManager.db,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DepensesQuiMeConcernent"
                };

                var paramMoins1 = new OleDbParameter("@pEvent", OleDbType.BigInt);
                paramMoins1.Value = evt.Code;
                cdMoins.Parameters.Add(paramMoins1);


                var paramMoins2 = new OleDbParameter("@pPart", OleDbType.BigInt);
                paramMoins2.Value = val.Key;
                cdMoins.Parameters.Add(paramMoins2);

                OleDbDataReader dr = cdMoins.ExecuteReader();

                while (dr.Read())
                {
                    moins += Convert.ToDouble(dr[1].ToString()) / Convert.ToDouble(dr[2].ToString()) * val.Value;
                }


                //PARTI PLUS
                OleDbCommand cdPlus = new OleDbCommand
                {
                    Connection = DatabaseManager.db,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "TotalMesDepenses"
                };

                var paramplus1 = new OleDbParameter("pEvent", OleDbType.BigInt);
                paramplus1.Value = evt.Code;
                cdPlus.Parameters.Add(paramplus1);

                var paramplus2 = new OleDbParameter("pPart", OleDbType.BigInt);
                paramplus2.Value = val.Key;
                cdPlus.Parameters.Add(paramplus2);
                double plus;

                try
                {
                    plus = Convert.ToDouble(cdPlus.ExecuteScalar().ToString());
                }
                catch
                {
                    plus = 0;
                }

                //AJOUT DANS dtBilan

                OleDbCommand findName = new OleDbCommand("SELECT * FROM Participants WHERE codeParticipant=" + val.Key, DatabaseManager.db);
                OleDbDataReader drName = findName.ExecuteReader();
                drName.Read();

                DataRow partBilan = dtBilan.NewRow();
                partBilan[0] = val.Key;
                partBilan[1] = drName[1].ToString() + " " + drName[2].ToString();
                partBilan[2] = plus;
                partBilan[3] = moins;
                partBilan[4] = plus - moins;

                dtBilan.Rows.Add(partBilan);
            }

                Boolean allSoldeAt0 = true;

                OleDbCommand cdBilanPart = new OleDbCommand("INSERT INTO BilanPart(codeEvent,codeDonneur,codeReceveur,montant)" +
"                          VALUES (?,?,?,?)", DatabaseManager.db);

                cdBilanPart.Parameters.AddWithValue("codeEvent", evt.Code);


                while (allSoldeAt0)
                {
                    //PREND LA 1er LIGNE COMME BASE
                    DataRow receveur = dtBilan.Rows[0];
                    DataRow donneur = dtBilan.Rows[0];

                    int indexDonneur = 1;
                    int indexReceveur = 1;
                    for(int i=0;i<dtBilan.Rows.Count;i++)
                    {
                        //STOCK LA LIGNE DU RECEVEUR ET LA SUPPRIME DE LA TABLE ( POUR LA RAJOUTER APRES AVEC LES MODIFICATIONS)
                        if (Convert.ToDouble(dtBilan.Rows[i]["Solde"].ToString()) < Convert.ToDouble(receveur["Solde"].ToString()))
                        {
                            donneur = dtBilan.Rows[i];
                            indexDonneur = i;
                        }
                        //STOCK LA LIGNE DU DONNEUR ET LA SUPPRIME DE LA TABLE ( POUR LA RAJOUTER APRES AVEC LES MODIFICATIONS)
                        if(Convert.ToDouble(dtBilan.Rows[i]["Solde"].ToString()) > Convert.ToDouble(donneur["Solde"].ToString()))
                        {
                            receveur = dtBilan.Rows[i];
                            indexReceveur = i;
                        }
                    }

                    cdBilanPart.Parameters.AddWithValue("codeDonneur", donneur["codeParticipant"]);
                    cdBilanPart.Parameters.AddWithValue("codeReceveur", receveur["codeParticipant"]);

                //1er CAS: SI LE SOLDE DU DONNEUR EST PLUS GRAND QUE SOLDE DU RECEVEUR
                if (-Convert.ToDouble(donneur["Solde"].ToString()) > Convert.ToDouble(receveur["Solde"].ToString()))
                    {
                        cdBilanPart.Parameters.AddWithValue("montant", Convert.ToDouble(receveur["Solde"].ToString()));


                        //CHANGE LES SOLDE DANS LA LIGNE DU DONNEUR ET RECEVEUR
                    donneur["Solde"] = Convert.ToDecimal(donneur["Solde"].ToString()) + Convert.ToDecimal(receveur["Solde"].ToString());
                        receveur["Solde"] = 0;
                    }//2er CAS: SI LE SOLDE DU DONNEUR EST PLUS PETIT QUE SOLDE DU RECEVEUR
                    else
                    {
                        cdBilanPart.Parameters.AddWithValue("montant", -Convert.ToDouble(donneur["Solde"].ToString()));

                    //CHANGE LES SOLDE DANS LA LIGNE DU DONNEUR ET RECEVEUR
                        donneur["Solde"] = 0;
                        receveur["Solde"] = Convert.ToDecimal(receveur["Solde"].ToString()) + Convert.ToDecimal(donneur["Solde"].ToString());
                    }
                        Debug.WriteLine(cdBilanPart.CommandText);
                        cdBilanPart.ExecuteNonQuery();

                    //AJOUTE LE RECEVEUR ET LE DONNEUR DANS LA BASE dtBilan  AVEC LES SOLDES MODIFIER
                    dtBilan.Rows.Add(donneur);
                    dtBilan.Rows.Add(receveur);

                    //VERIFIE SI LES LES DEPENSE SONT TOUTES A 0 OU NON
                    int cptSoldeAt0 = 0;
                    foreach (DataRow row in dtBilan.Rows)
                    {
                        if (Convert.ToDecimal(row["Solde"].ToString()) == 0)
                        {
                            cptSoldeAt0 += 1;
                        }
                    }

                    //SI TOUTE LES DEPENSES == 0 , ARRETE LE WHILE
                    if (cptSoldeAt0 == dtBilan.Rows.Count)
                    {
                        allSoldeAt0 = true;
                    }
                }
            DatabaseManager.db.Close();
        }

        public List<WOWTW> GetWOWTWs()
        {
            return null;
        }

    }
}
