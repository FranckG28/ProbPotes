using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.models
{
    class Participant
    {
        int code;
        char name;
        char firstName;
        char phone;
        int number;
        double balance;
        char mailAddress;

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
            this.balance = (int)row["balancee"];
            this.mailAddress = (char)row["adresseMail"];
        }
    }
}
