﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProbPotes.managers
{
    abstract class DatabaseManager
    {
        string way = Directory.GetCurrentDirectory();
        //METTEZ VOTRE SOURCE DE BDD SINON CA MARCHE PAS !
        public static OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\gutma\source\repos\probpotes\bdEvents.mdb;Persist Security Info=True");

        // ACCES AUX MANAGERS
        public static EventManager Events = new EventManager();
        public static ParticipantManager Participants = new ParticipantManager();
    
    }
}
