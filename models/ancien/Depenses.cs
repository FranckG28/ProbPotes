using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    class Depenses
    {
        int number;
        char description;
        double sum;
        DateTime dated;
        char comment;
        int eventCode;
        int codeGo;
        public Depenses(int eventCode, int codeGo, int number, double sum, char description, DateTime dated, char comment)
        {
            this.eventCode = eventCode;
            this.codeGo = codeGo;
            this.number=number;
            this.sum = sum;
            this.description = description;
            this.dated = dated;
            this.comment = comment;
        }

        public Depenses(DataRow row)
        {
            this.eventCode = (int)row["codeEvent"];
            this.codeGo = (int)row["codePart"];
            this.number = (int)row["numDepense"];
            this.sum = (int)row["montant"];
            this.description = (char)row["commentaire"];
            this.dated = (DateTime)row["dateDepense"];
            this.comment = (char)row["commentaire"];
        }


    }
}
