using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    public class Participant
    {
        public int code;
        public string name;
        public string firstName;
        public string phone;
        public int number;
        public double balance;
        public string mailAddress;

        public Participant(int code, string phone, int number, double balance, string name, string firstName, string mailAddress)
        {
            this.code= code;
            this.phone = phone;
            this.number = number;
            this.balance= balance;
            this.name = name;
            this.firstName = firstName;
            this.mailAddress = mailAddress;
        }

        public Participant(DataRow row)
        {
            this.code = (int)row["codeParticipant"];
            this.name = (string)row["nomPart"];
            this.firstName = (string)row["prenomPart"];
            this.phone = (string)row["mobile"];
            this.number = (int)row["nbParts"];
            this.balance = (int)row["solde"];
            this.mailAddress = (string)row["adresseMail"];
        }
    }
}
