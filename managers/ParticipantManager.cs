using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.managers
{
    class ParticipantManager
    {

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
            return null;
        }

        // Fonction qui retourne la liste de tous les participant de la base
        public List<Participant> GetParticipants()
        {
            return null;
        }
    }
}
