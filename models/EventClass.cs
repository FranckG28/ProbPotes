using ProbPotes.managers;
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
        public int Code;
        public string Title;
        public DateTime StartDate;
        public DateTime EndDate;
        public string Description;
        public bool SoldeOn;
        public int CreatorCode;

        public List<int> Guests;
        public ExpensesManager Expenses;

        public EventClass(int code, string title, int creatorCode, bool soldeOn, string description, DateTime startDate, DateTime endDate, List<int> guests)
        {
            this.Code = code;
            this.Title = title;
            this.StartDate = startDate;
            this.Description = description;
            this.EndDate = endDate;
            this.CreatorCode = creatorCode;
            this.SoldeOn = soldeOn;
            this.Guests = guests;
            this.Expenses = new ExpensesManager(code);
        }

        // LISTE DES INVITES A JOUTER MANUELLEMENT VIA CE CONSTRUCTEUR :
        public EventClass(DataRow row)
        {
            this.Code = (int)row["codeEvent"];
            this.Title = (string)row["titreEvent"];
            this.StartDate = (DateTime)row["dateDebut"];
            this.Description= (string)row["description"];
            this.EndDate = (DateTime)row["dateFin"];
            this.CreatorCode = (int)row["codeCreateur"];
            this.SoldeOn= (bool)row["soldeOn"];
            this.Expenses = new ExpensesManager(Code);
        }
    }
}
