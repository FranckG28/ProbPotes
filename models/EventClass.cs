using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    public class EventClass
    {
        public int code;
        public string title;
        public DateTime startDate;
        public DateTime endDate;
        public string description;
        public bool soldeOn;
        public int creatorCode;

        public List<int> guests;
        public List<Expense> expenses;

        public EventClass(int code, string title, int creatorCode, bool soldeOn, string description, DateTime startDate, DateTime endDate, List<int> guests, List<Expense> expenses)
        {
            this.code = code;
            this.title = title;
            this.startDate = startDate;
            this.description = description;
            this.startDate = startDate;
            this.creatorCode = creatorCode;
            this.soldeOn = soldeOn;
            this.guests = guests;
            this.expenses = expenses;
        }

        // LISTE DES INVITES ET LISTE DES DEPENSES A JOUTER MANUELLEMENT VIA CE CONSTRUCTEUR :
        public EventClass(DataRow row)
        {
            this.code = (int)row["codeEvent"];
            this.title = (string)row["titreEvent"];
            this.startDate = (DateTime)row["dateDebut"];
            this.description= (string)row["description"];
            this.endDate = (DateTime)row["dateFin"];
            this.creatorCode = (int)row["codeCreateur"];
            this.soldeOn= (bool)row["soldeOn"];
        }
    }
}
