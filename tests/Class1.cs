using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProbPotes.models
{
    public class Participants
    {
        public int code;
        public char name;
        public char firstName;
        public char phone;
        public int number;
        public double balance;
        public char mailAddress;

        public Participants(int code, char phone, int number, double balance, char name, char firstName, char mailAddress)
        {
            this.code = code;
            this.phone = phone;
            this.number = number;
            this.balance = balance;
            this.name = name;
            this.firstName = firstName;
            this.mailAddress = mailAddress;
        }

        public Participants(DataRow row)
        {
            this.code = (int)row["codeParticipant"];
            this.name = (char)row["nomPart"];
            this.firstName = (char)row["prenomPart"];
            this.phone = (char)row["mobile"];
            this.number = (int)row["nbParts"];
            this.balance = (int)row["solde"];
            this.mailAddress = (char)row["adresseMail"];
        }

        public bool addParticipants(EventClass evenement, OleDbConnection connect){
            try
            {
                OleDbCommand cdAddParticipant = new OleDbCommand(@"INSERT INTO Evenements (codeEvent,codePart)
                                                                    VALUES (?,?)", connect);

                cdAddParticipant.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = evenement.code;
                cdAddParticipant.Parameters.Add(new OleDbParameter("codepart", OleDbType.Integer)).Value = this.code;

                cdAddParticipant.ExecuteNonQuery();

                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }
    }
}

