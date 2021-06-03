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
            return false;
        }

        // Procédure de mise à jour d'un participant 
        // Retourne true si la mise à jour a réussi
        public Boolean UpdateParticipant(Participant participant)
        {
            return false;
        }

        // Procédure de suppression d'un participant
        // Retourne true si la suppression a reussi
        public Boolean DeleteParticipant(int id)
        {
            return false;
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
