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

                //DELETE L'EVENT
                OleDbCommand delete = new OleDbCommand(@"DELETE FROM Evenements WHERE codeEvent = @codeEvent;", DatabaseManager.db);
                delete.Parameters.Add(new OleDbParameter("@codeEvent", OleDbType.Integer)).Value = eventId;
                int result = delete.ExecuteNonQuery();

                //DELETE LES EXPENSE DE L'EVENT
                OleDbCommand deleteExpense = new OleDbCommand(@"DELETE FROM Depenses WHERE codeEvent=@codeEvent", DatabaseManager.db);
                deleteExpense.Parameters.Add(new OleDbParameter("@codeEvent", OleDbType.Integer)).Value = eventId;
                deleteExpense.ExecuteNonQuery();

                //DELETE LES INVITES DE L'EVENT
                OleDbCommand deleteInvites = new OleDbCommand(@"DELETE FROM invites WHERE codeEvent=@codeEvent", DatabaseManager.db);
                deleteInvites.Parameters.Add(new OleDbParameter("@codeEvent", OleDbType.Integer)).Value = eventId;
                deleteInvites.ExecuteNonQuery();

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

            if (DatabaseManager.db.State == ConnectionState.Closed)
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

                OleDbParameter paramplus1 = new OleDbParameter("pEvent", OleDbType.BigInt);
                paramplus1.Value = evt.Code;
                cdPlus.Parameters.Add(paramplus1);

                OleDbParameter paramplus2 = new OleDbParameter("pPart", OleDbType.BigInt);
                paramplus2.Value = val.Key;
                cdPlus.Parameters.Add(paramplus2);
                double plus = 0;

                try
                {
                    plus = Convert.ToDouble(cdPlus.ExecuteScalar().ToString());
                }
                catch { }

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

            //REQUETE POUR AJOUTER DANS LA TABLE BilanPart
            OleDbCommand cdBilanPart = new OleDbCommand("INSERT INTO BilanPart(codeEvent,codeDonneur,codeReceveur,montant)" +
"                          VALUES (?,?,?,?)", DatabaseManager.db);

            //CREATION DES PARAMETRE QU'ON REMPLIRA AU FUR ET A MESURE DE LA BOUCLE JUSTE EN DESSOUS
            OleDbParameter codeEvent = new OleDbParameter("codeEvent", OleDbType.Integer);
            codeEvent.Value = evt.Code;
            OleDbParameter codeDonneur = new OleDbParameter("codeDonneur", OleDbType.Integer);
            OleDbParameter codeReceveur = new OleDbParameter("codeReceveur", OleDbType.Integer);
            OleDbParameter montant = new OleDbParameter("montant", OleDbType.Currency);

            Boolean allSoldeAt0 = true;
            while (allSoldeAt0 && !evt.SoldeOn)
            {
                //ON PREND COMME 1er VALEUR LA DATAROW 0 EN GUISE DE TEST POUR LA 1er COMPARAISON
                int indexDonneur = 0;
                int indexReceveur = 0;
                for (int i = 1; i < dtBilan.Rows.Count; i++)
                {
                    //STOCK L'INDEX DU RECEVEUR
                    if (Convert.ToDouble(dtBilan.Rows[i]["Solde"].ToString()) < Convert.ToDouble(dtBilan.Rows[indexDonneur]["Solde"].ToString()))
                    {
                        indexDonneur = i;
                    }
                    //STOCK L'INDEX DU DONNEUR
                    if (Convert.ToDouble(dtBilan.Rows[i]["Solde"].ToString()) > Convert.ToDouble(dtBilan.Rows[indexReceveur]["Solde"].ToString()))
                    {
                        indexReceveur = i;
                    }
                }

                //REMPLI LES PARAMETRE DE LA REQUETE AVEC LES CODE DE DONNEUR ET RECEVEUR CAR ON LES CONNAIT DESORMAIS
                codeDonneur.Value = dtBilan.Rows[indexDonneur]["codeParticipant"];
                codeReceveur.Value = dtBilan.Rows[indexReceveur]["codeParticipant"];

                //1er CAS: SI LE SOLDE DU DONNEUR EST PLUS GRAND QUE SOLDE DU RECEVEUR
                if (-Convert.ToDouble(dtBilan.Rows[indexDonneur]["Solde"].ToString()) > Convert.ToDouble(dtBilan.Rows[indexReceveur]["Solde"].ToString()))
                {

                    montant.Value = Convert.ToDouble(dtBilan.Rows[indexReceveur]["Solde"].ToString());

                    //CHANGE LES SOLDE DANS LA LIGNE DU DONNEUR ET RECEVEUR
                    decimal soldeDonneur = Convert.ToDecimal(dtBilan.Rows[indexDonneur]["Solde"].ToString()) + Convert.ToDecimal(dtBilan.Rows[indexReceveur]["Solde"].ToString());
                    dtBilan.Rows[indexDonneur]["Moins"] = soldeDonneur;
                    dtBilan.Rows[indexDonneur]["Plus"] = 0;
                    dtBilan.Rows[indexReceveur]["Moins"] = 0;
                    dtBilan.Rows[indexReceveur]["Plus"] = 0;
                    dtBilan.Rows[indexReceveur]["Solde"] = Convert.ToDecimal(dtBilan.Rows[indexReceveur]["Plus"].ToString()) - Convert.ToDecimal(dtBilan.Rows[indexReceveur]["Moins"].ToString());
                    dtBilan.Rows[indexDonneur]["Solde"] = Convert.ToDecimal(dtBilan.Rows[indexDonneur]["Plus"].ToString()) - Convert.ToDecimal(dtBilan.Rows[indexDonneur]["Moins"].ToString());
                }//2er CAS: SI LE SOLDE DU DONNEUR EST PLUS PETIT QUE SOLDE DU RECEVEUR
                else
                {
                    montant.Value = -Convert.ToDouble(dtBilan.Rows[indexDonneur]["Solde"].ToString());

                    //CHANGE LES SOLDE DANS LA LIGNE DU DONNEUR ET RECEVEUR
                    decimal SoldeReceveur = Convert.ToDecimal(dtBilan.Rows[indexReceveur]["Solde"].ToString()) + Convert.ToDecimal(dtBilan.Rows[indexDonneur]["Solde"].ToString());
                    dtBilan.Rows[indexDonneur]["Moins"] = 0;
                    dtBilan.Rows[indexDonneur]["Plus"] = 0;
                    dtBilan.Rows[indexReceveur]["Moins"] = SoldeReceveur;
                    dtBilan.Rows[indexReceveur]["Plus"] = 0;
                    dtBilan.Rows[indexReceveur]["Solde"] = Convert.ToDecimal(dtBilan.Rows[indexReceveur]["Plus"].ToString()) - Convert.ToDecimal(dtBilan.Rows[indexReceveur]["Moins"].ToString());
                    dtBilan.Rows[indexDonneur]["Solde"] = Convert.ToDecimal(dtBilan.Rows[indexDonneur]["Plus"].ToString()) - Convert.ToDecimal(dtBilan.Rows[indexDonneur]["Moins"].ToString());
                }

                try
                {
                    //AJOUTe 1 SEUL FOIS LES PARAMETRE ( IL Y A JUSTE LES VALEURS QUI VONT CHANGER A CHAQUE TOUR DE BOUCLE )    
                    cdBilanPart.Parameters.Add(codeEvent);
                    cdBilanPart.Parameters.Add(codeDonneur);
                    cdBilanPart.Parameters.Add(codeReceveur);
                    cdBilanPart.Parameters.Add(montant);
                }
                catch { }

                //INSERTION DANS LA TABLE BilanPart
                cdBilanPart.ExecuteNonQuery();

                foreach (DataColumn column in dtBilan.Columns) column.ReadOnly = false;
                //VERIFIE SI LES LES DEPENSE SONT TOUTES A 0 OU NON
                int cptSoldeAt0 = 0;
                foreach (DataRow row in dtBilan.Rows)
                {
                    if (Convert.ToDouble(row["Solde"].ToString()) == 0)
                    {
                        cptSoldeAt0 += 1;
                    }
                }

                //SI TOUTE LES DEPENSES == 0 , ARRETE LE WHILE
                if (cptSoldeAt0 == dtBilan.Rows.Count)
                {
                    allSoldeAt0 = false;
                }
            }
            evt.SoldeOn = true;
            this.UpdateEvent(evt);
            DatabaseManager.db.Close();
        }

        public List<WOWTW> GetWOWTWs(EventClass evt)
        {
            List<WOWTW> res = new List<WOWTW>();

            if (DatabaseManager.db.State == ConnectionState.Closed)
                DatabaseManager.db.Open();

            OleDbCommand cdBilanPart = new OleDbCommand("SELECT * FROM BilanPart WHERE codeEvent=" + evt.Code, DatabaseManager.db);
            OleDbDataReader dr = cdBilanPart.ExecuteReader();
            while (dr.Read())
            {
                //PARTI POUR LES INVITES
                foreach(int part in evt.Guests)
                {
                    Dictionary<int, decimal> giveTo = new Dictionary<int, decimal>();
                    Dictionary<int, decimal> receiveFrom = new Dictionary<int, decimal>();
                    if (Convert.ToInt32(dr[1]) == part)
                    {
                        giveTo.Add(Convert.ToInt32(dr[2]),Convert.ToDecimal(dr[3]));
                    }else if(Convert.ToInt32(dr[2]) == part)
                    {
                        receiveFrom.Add(Convert.ToInt32(dr[1].ToString()), Convert.ToDecimal(dr[3].ToString()));
                    }
                    res.Add(new WOWTW(part, giveTo, receiveFrom));
                }

                //PARTIE POUR LE CREATEUR DE L'EVT ( JSP SI IL EST COMPRIS DANS LES INVITES OU NON MAIS AU KAOU J'AI FAIT CA )
                Dictionary<int, decimal> giveToCreator = new Dictionary<int, decimal>();
                Dictionary<int, decimal> receiveFromCreator = new Dictionary<int, decimal>();
                if (dr[1].ToString() == evt.CreatorCode.ToString())
                {
                    giveToCreator.Add(Convert.ToInt32(dr[2].ToString()), Convert.ToDecimal(dr[3].ToString()));
                }
                else if (dr[2].ToString() == evt.CreatorCode.ToString())
                {
                    receiveFromCreator.Add(Convert.ToInt32(dr[1].ToString()), Convert.ToDecimal(dr[3].ToString()));
                }
                res.Add(new WOWTW(evt.CreatorCode, giveToCreator, receiveFromCreator));
            }
            return res;
        }

        public int GetExpenseCount()
        {
            int count = 0;
            foreach (EventClass e in EventsList)
            {
                foreach (Expense expense in e.Expenses.Expenses)
                {
                    count++;
                }
            }
            return count;
        }

        public Decimal GetExpenseSum()
        {
            Decimal count = 0;
            foreach (EventClass e in EventsList)
            {
                foreach (Expense expense in e.Expenses.Expenses)
                {
                    count+= expense.sum;
                }
            }
            return count;
        }

    }
}
