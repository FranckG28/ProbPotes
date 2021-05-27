using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.managers
{
    class EventManager
    {

        // Un évènement inclus les dépenses et la liste des participant
        // --> A gérer lors de l'obtention, l'ajout et la suppression d'évènements

        // Procédure d'ajout d'un évènement
        // Retourne true si l'ajout a réussi
        public Boolean AddEvent(EventClass eventclass) {
            return false;
        }

        // Procédure de mise à jour d'un évènement
        // --> Mettre à jour un évènement signifie aussi mettre à jour sa liste des participant
        // --> Les modifications sur les dépenses ne sont pas gérés ici
        // Retourne true si la mise à jour a réussi
        public Boolean UpdateEvent(EventClass eventclass)
        {
            return false;
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
