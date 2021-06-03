using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbPotes.managers
{
    abstract class DatabaseManager
    {

        //METTEZ VOTRE SOURCE DE BDD SINON CA MARCHE PAS !
        public static OleDbConnection db = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\gutma\source\repos\ProbPotes\bdEvents.mdb;Persist Security Info=True");
    }
}
