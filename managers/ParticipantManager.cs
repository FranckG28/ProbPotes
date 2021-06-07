using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.managers
{
    class ParticipantManager
    {

        // Liste des participants
        private List<Participant> Participants;

        // Constructeur de la classe
        // Récupère la liste des participants
        public ParticipantManager()
        {
            RefreshParticipants();
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

                insertPart.Parameters.Add(new OleDbParameter("codeParticipant", OleDbType.Integer)).Value = participant.code;
                insertPart.Parameters.Add(new OleDbParameter("nomPart", OleDbType.WChar)).Value = participant.name;
                insertPart.Parameters.Add(new OleDbParameter("prenomPart", OleDbType.WChar)).Value = participant.firstName;
                insertPart.Parameters.Add(new OleDbParameter("mobile", OleDbType.WChar)).Value = participant.phone;
                insertPart.Parameters.Add(new OleDbParameter("nbParts", OleDbType.Integer)).Value = participant.shares;
                insertPart.Parameters.Add(new OleDbParameter("solde", OleDbType.Double)).Value = participant.balance;
                insertPart.Parameters.Add(new OleDbParameter("adresseMail", OleDbType.WChar)).Value = participant.mailAddress;

                insertPart.ExecuteNonQuery();
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

        // Procédure de mise à jour d'un participant 
        // Retourne true si la mise à jour a réussi
        public Boolean UpdateParticipant(Participant participant)
        {
            try
            {
                Boolean partFind = false;

                for(int i = 0; i < Participants.Count; i++)
                {
                    if (participant.code == Participants[i].code)
                    {
                        participant.phone = Participants[i].phone;
                        participant.shares = Participants[i].shares;
                        participant.balance = Participants[i].balance;
                        participant.name = Participants[i].name;
                        participant.firstName = Participants[i].firstName;
                        participant.mailAddress = Participants[i].mailAddress;
                        partFind = true;
                    }
                }

                if (partFind)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }

        // Procédure de suppression d'un participant
        // Retourne true si la suppression a reussi
        public Boolean DeleteParticipant(int id)
        {

            try
            {
                Boolean partFind = false;
                for (int i = 0; i < Participants.Count; i++)
                {
                    if (Participants[i].code == id)
                    {
                        Participants.RemoveAt(i);
                        partFind = true;
                    }
                }

                DatabaseManager.db.Open();

                OleDbCommand deletePart = new OleDbCommand(@"DELETE FROM Participants WHERE codeParticipant="+id, DatabaseManager.db);

                int rowDelete= Convert.ToInt32(deletePart.ExecuteNonQuery().ToString());

                if (partFind && rowDelete>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }

        // Fonction qui retourne le participant correspondant au numéro dans la base
        public Participant GetParticipant(int id)
        {
            return Participants.Where(p => p.code == id).First();
        }

        // Fonction qui actualise la liste de tous les participant de la base
        public void RefreshParticipants()
        {
            Participants = new List<Participant>();

            OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM Participants", DatabaseManager.db);
            DataTable participantsTable = new DataTable();
            adapter.Fill(participantsTable);

            foreach(DataRow row in participantsTable.Rows)
            {
                Participants.Add(new Participant(row));
            }
        }
    }
}
