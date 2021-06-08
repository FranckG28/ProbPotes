﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    public class Participant
    {
        public int Code;
        public string Name;
        public string FirstName;
        public string Phone;
        public int Shares;
        public double Balance;
        public string MailAddress;

        public Participant(int code, string phone, int shares, double balance, string name, string firstName, string mailAddress)
        {
            this.Code= code;
            this.Phone = phone;
            this.Shares = shares;
            this.Balance= balance;
            this.Name = name;
            this.FirstName = firstName;
            this.MailAddress = mailAddress;
        }

        public Participant(DataRow row)
        {
            this.Code = (int)row["codeParticipant"];
            this.Name = (string)row["nomPart"];
            this.FirstName = (string)row["prenomPart"];
            this.Phone = (string)row["mobile"];
            this.Shares = (int)row["nbParts"];
            if (row["solde"].ToString() != "") this.Balance = (double)row["solde"];
            this.MailAddress = (string)row["adresseMail"];
        }
    }
}
