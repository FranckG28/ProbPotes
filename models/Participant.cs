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
        public char name;
        public char firstName;
        public char phone;
        public int number;
        public double balance;
        public char mailAddress;

        public Participant(int code, char phone, int number, double balance, char name,char firstName, char mailAddress)
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
            this.name = (char)row["nomPart"];
            this.firstName = (char)row["prenomPart"];
            this.phone = (char)row["mobile"];
            this.number = (int)row["nbParts"];
            this.balance = (int)row["solde"];
            this.mailAddress = (char)row["adresseMail"];
        }
    }
}
