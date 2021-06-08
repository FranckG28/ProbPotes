using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using ProbPotes.managers;
using ProbPotes.models;

namespace ProbPotes.tests
{
    public partial class RerportManager : Form
    {
        public RerportManager()
        {
            InitializeComponent();
        }


        public void Test(EventClass evt)
        {
            DatabaseManager.db.Open();
            DataSet ds = new DataSet();

            DataTable dtBilan = new DataTable();

            dtBilan.Columns.Add("codeParticipant", typeof(Int32));
            dtBilan.Columns.Add("Personne", typeof(string));
            dtBilan.Columns.Add("Plus", typeof(double));
            dtBilan.Columns.Add("Moins", typeof(double));
            dtBilan.Columns.Add("Solde", typeof(double));

            Dictionary<int, int> partShare = new Dictionary<int, int>();

            for(int i = 0; i < evt.Guests.Count; i++)
            {
                OleDbCommand cdPartShare = new OleDbCommand("SELECT codeParticipant,nbParts FROM Participants WHERE codeParticipant=" + i, DatabaseManager.db);

                OleDbDataReader dr = cdPartShare.ExecuteReader();
                dr.Read();

                partShare.Add(Convert.ToInt32(dr[0].ToString()), Convert.ToInt32(dr[1].ToString()));
            }


            foreach (KeyValuePair<int, int> val in partShare)
            {
                //PROCEDURE STOCKEE JSP COMMENT FAIRE ;(
            }

        } 
    }
}
