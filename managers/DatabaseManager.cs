using System;
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
        
        // INSTANCE STATIQUE DE LA BASE DE DONNÉE, AVEC CHEMIN D'ACCES RELATIF
        public static OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\bdEvents.mdb") + ";Persist Security Info=True");

        // ACCES AUX INSTANCES STATIQUES DES GESTIONNAIRES D'EVENEMENTS ET DE DEPENSES
        public static EventManager Events = new EventManager();
        public static ParticipantManager Participants = new ParticipantManager();
    
    }
}
