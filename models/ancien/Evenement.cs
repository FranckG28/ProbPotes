using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    public class Evenement
    {
        int eventCode;
        char titleEvent;
        DateTime startDate;
        DateTime endDate;
        char comment;
        bool soldeOn;
        int creatorCode;
        public Evenement(int eventCode, DateTime startDate, char titleEvent, int creatorCode, bool soldeOn, char comment, DateTime endDate, char commentaire)
        {
            this.eventCode = eventCode;
            this.titleEvent = titleEvent;
            this.startDate = startDate;
            this.comment = comment;
            this.startDate = startDate;
            this.creatorCode = creatorCode;
            this.soldeOn = soldeOn;

        }
        public Evenement(DataRow row)
        {
            this.eventCode = (int)row["codeEvent"];
            this.titleEvent = (char)row["titleEvent"];
            this.startDate = (DateTime)row["dateDebut"];
            this.comment= (char)row["description"];
            this.endDate = (DateTime)row["dateFin"];
            this.creatorCode = (int)row["codeCreateur"];
            this.soldeOn= (bool)row["soldeOn"];
        }
    }
}
