using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.managers
{
    class ParticipantManager
    {

        // Liste des participants
        private List<Participant> ParticipantsList = new List<Participant>();

        // Constructeur de la classe
        // Récupère la liste des participants
        public ParticipantManager()
        {
            RefreshParticipants();
        }

        // Getter de la liste des participants
        public List<Participant> Participants
        {
            get => ParticipantsList;
        }

        // Procédure d'ajout d'un participant à la base de donnée.
        // Retourne true si l'ajout a réussi
        public Boolean AddParticipant(Participant participant)
        {
            try
            {
                DatabaseManager.db.Open();

                OleDbCommand insertPart = new OleDbCommand(@"INSERT INTO Participants(codeParticipant,nomPart,prenomPart,mobile,nbParts,solde,adresseMail)
                                                       	VALUES(?,?,?,?,?,?,?)", DatabaseManager.db);

                insertPart.Parameters.Add(new OleDbParameter("codeParticipant", OleDbType.Integer)).Value = participant.Code;
                insertPart.Parameters.Add(new OleDbParameter("nomPart", OleDbType.WChar)).Value = participant.Name;
                insertPart.Parameters.Add(new OleDbParameter("prenomPart", OleDbType.WChar)).Value = participant.FirstName;
                insertPart.Parameters.Add(new OleDbParameter("mobile", OleDbType.WChar)).Value = participant.Phone;
                insertPart.Parameters.Add(new OleDbParameter("nbParts", OleDbType.Integer)).Value = participant.Shares;
                insertPart.Parameters.Add(new OleDbParameter("solde", OleDbType.Double)).Value = participant.Balance;
                insertPart.Parameters.Add(new OleDbParameter("adresseMail", OleDbType.WChar)).Value = participant.MailAddress;

                int result = insertPart.ExecuteNonQuery();
                if (result != 1)
                {
                    return false;
                } else
                {
                    ParticipantsList.Add(participant);
                    return true;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DatabaseManager.db.Close();
                RefreshParticipants();
            }
        }

        // Procédure de mise à jour d'un participant 
        // Retourne true si la mise à jour a réussi
        public Boolean UpdateParticipant(Participant participant)
        {
            try
            {
                /*                Boolean partFind = false;

                                for(int i = 0; i < ParticipantsList.Count; i++)
                                {
                                    if (participant.Code == Participants[i].Code)
                                    {
                                        participant.Phone = Participants[i].Phone;
                                        participant.Shares = Participants[i].Shares;
                                        participant.Balance = Participants[i].Balance;
                                        participant.Name = Participants[i].Name;
                                        participant.FirstName = Participants[i].FirstName;
                                        participant.MailAddress = Participants[i].MailAddress;
                                        partFind = true;
                                    }
                                }

                                return partFind;*/
                return false;

            }
            catch(Exception)
            {
                return false;
            } finally
            {
                RefreshParticipants();
            }
        }


        // Fonction qui retourne le participant correspondant au numéro dans la base
        public Participant GetParticipant(int id)
        {
            return ParticipantsList.Where(p => p.Code == id).First();
        }

        // Fonction qui actualise la liste de tous les participant de la base
        public void RefreshParticipants()
        {
            ParticipantsList = new List<Participant>();

            OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM Participants", DatabaseManager.db);
            DataTable participantsTable = new DataTable();
            adapter.Fill(participantsTable);

            foreach(DataRow row in participantsTable.Rows)
            {
                ParticipantsList.Add(new Participant(row));
            }
        }
    }
}
