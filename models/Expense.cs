﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using ProbPotes.managers;

namespace ProbPotes.models
{
    public class Expense
    {

        public int code;
        public int eventCode;
        public string description;
        public Decimal sum;
        public List<int> recipients;
        public int creatorCode;
        public DateTime date;
        public string comment;

        public Expense(int code, int eventCode, string description, Decimal sum, List<int> recipients, int creatorCode, DateTime date, string comment)
        {
            this.code = code;
            this.eventCode = eventCode;
            this.description = description;
            this.sum = sum;
            this.recipients = recipients;
            this.creatorCode = creatorCode;
            this.date = date;
            this.comment = comment;
        }
        
        // RESTE A DEFINIR LA LISTE DES BENEFICIAIRE LORS DE L'UTILISATION DE CE CONSTRUCTEUR :
        public Expense(DataRow row)
        {
            this.code = (int)row["numDepense"];
            this.description = (string)row["description"];
            this.sum = (Decimal)row["montant"];
            this.creatorCode = (int)row["codePart"];
            this.eventCode = (int)row["codeEvent"];
            this.date = (DateTime)row["dateDepense"];
            this.comment = (string)row["commentaire"];
        }

        public int GetPartAmount()
        {
            int counter = DatabaseManager.Participants.GetParticipant(creatorCode).Shares;

            foreach(int code in recipients)
            {
                counter += DatabaseManager.Participants.GetParticipant(code).Shares;
            }

            return counter;
        }

    }
}
