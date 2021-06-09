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
    public partial class ReportManager : Form
    {
        public ReportManager()
        {
            InitializeComponent();
        }

        private void ReportManager_Load(object sender, EventArgs e)
        {

        }

        public void Test(EventClass evt)
        {
            DatabaseManager.db.Open();

            DataTable dtBilan = new DataTable();

            dtBilan.Columns.Add("codeParticipant", typeof(int));
            dtBilan.Columns.Add("Personne", typeof(string));
            dtBilan.Columns.Add("Plus", typeof(double));
            dtBilan.Columns.Add("Moins", typeof(double));
            dtBilan.Columns.Add("Solde", typeof(double));

            Dictionary<int, int> partShare = new Dictionary<int, int>();

            for (int i = 0; i < evt.Guests.Count; i++)
            {
                OleDbCommand cdPartShare = new OleDbCommand("SELECT codeParticipant,nbParts FROM Participants WHERE codeParticipant=" + i, DatabaseManager.db);

                OleDbDataReader dr = cdPartShare.ExecuteReader();
                dr.Read();

                partShare.Add(Convert.ToInt32(dr[0].ToString()), Convert.ToInt32(dr[1].ToString()));
            }


            foreach (KeyValuePair<int, int> val in partShare)
            {
                //PROCEDURE STOCKEE MAIS JSP COMMENT FAIRE ;(
                //APPELER LES 2 PROCEDURES STOCKE, REMPLIR UNE DATAROX ET LA RAJOUTER 
                //DANS DTBILAN


                //PARTI MOINS
                double moins = 0;

                OleDbCommand cdMoins = new OleDbCommand
                {
                    Connection = DatabaseManager.db,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DepensesQuiMeConcernent"
                };

                var paramMoins1 = new OleDbParameter("@pEvent", OleDbType.BigInt);
                paramMoins1.Value = evt.Code;
                cdMoins.Parameters.Add(paramMoins1);


                var paramMoins2 = new OleDbParameter("@pPart", OleDbType.BigInt);
                paramMoins2.Value = val.Key;
                cdMoins.Parameters.Add(paramMoins2);

                OleDbDataReader dr = cdMoins.ExecuteReader();

                while (dr.Read())
                {
                    moins+= Math.Truncate(Convert.ToDouble(dr[1].ToString())/ Convert.ToDouble(dr[1].ToString())*val.Value*100)/100;
                }

                //PARTI PLUS
                OleDbCommand cdPlus = new OleDbCommand
                {
                    Connection = DatabaseManager.db,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DepensesQuiMeConcernent"
                };

                var paramplus1 = new OleDbParameter("@pEvent", OleDbType.BigInt);
                paramplus1.Value = evt.Code;
                cdPlus.Parameters.Add(paramplus1);


                var paramplus2 = new OleDbParameter("@pPart", OleDbType.BigInt);
                paramplus2.Value = val.Key;
                cdPlus.Parameters.Add(paramplus2);

                double plus = Convert.ToDouble(cdPlus.ExecuteScalar().ToString());


                //AJOUT DANS dtBilan

                OleDbCommand findName = new OleDbCommand("SELECT * FROM Participants WHERE codeParticipant=" + val.Key, DatabaseManager.db);
                OleDbDataReader drName = findName.ExecuteReader();
                drName.Read();

                DataRow partBilan = dtBilan.NewRow();
                partBilan[0] = val.Key;
                partBilan[1] = drName[2].ToString()+" "+drName[3].ToString();
                partBilan[2] = plus;
                partBilan[3] = moins;
                partBilan[4] = plus-moins;

                dtBilan.Rows.Add(partBilan);
            }

            Boolean allSoldeAt0 = false;

            while (allSoldeAt0)
            {
                DataRow receveur = dtBilan.Rows[0];
                DataRow donneur = dtBilan.Rows[0];

                foreach (DataRow row in dtBilan.Rows)
                {
                    if (Convert.ToDecimal(row["Solde"].ToString()) < Convert.ToDecimal(receveur["Solde"].ToString()))
                    {
                        receveur = row;
                        row.Delete();
                    }

                    if (Convert.ToDecimal(row["Solde"].ToString()) > Convert.ToDecimal(donneur["Solde"].ToString()))
                    {
                        donneur = row;
                        row.Delete();
                    }
                }

                if (Convert.ToDecimal(donneur["Solde"].ToString()) > Convert.ToDecimal(receveur["Solde"].ToString()))
                {
                    OleDbCommand cdBilanPart = new OleDbCommand("INSERT INTO BilanPart(codeEvent,codeDonneur,codeReceveur,montant)" +
                        "                          VALUES (?,?,?,?)", DatabaseManager.db);

                    cdBilanPart.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = evt.Code;
                    cdBilanPart.Parameters.Add(new OleDbParameter("codeDonneur", OleDbType.Integer)).Value = donneur["codeParticipant"];
                    cdBilanPart.Parameters.Add(new OleDbParameter("codeReceveur", OleDbType.Integer)).Value = receveur["codeParticipant"];
                    cdBilanPart.Parameters.Add(new OleDbParameter("montant", OleDbType.Currency)).Value = receveur["Solde"];

                    cdBilanPart.ExecuteNonQuery();

                    donneur["Solde"] = Convert.ToDecimal(donneur["Solde"].ToString()) - Convert.ToDecimal(receveur["Solde"].ToString());
                    receveur["Solde"] = 0;

                    dtBilan.Rows.Add(donneur);
                    dtBilan.Rows.Add(receveur);
                }
                else
                {
                    OleDbCommand cdBilanPart = new OleDbCommand("INSERT INTO BilanPart(codeEvent,codeDonneur,codeReceveur,montant)" +
    "                          VALUES (?,?,?,?)", DatabaseManager.db);

                    cdBilanPart.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = evt.Code;
                    cdBilanPart.Parameters.Add(new OleDbParameter("codeDonneur", OleDbType.Integer)).Value = donneur["codeParticipant"];
                    cdBilanPart.Parameters.Add(new OleDbParameter("codeReceveur", OleDbType.Integer)).Value = receveur["codeParticipant"];
                    cdBilanPart.Parameters.Add(new OleDbParameter("montant", OleDbType.Currency)).Value = donneur["Solde"];

                    cdBilanPart.ExecuteNonQuery();

                    donneur["Solde"] = 0;
                    receveur["Solde"] = Convert.ToDecimal(receveur["Solde"].ToString()) - Convert.ToDecimal(donneur["Solde"].ToString());

                    dtBilan.Rows.Add(donneur);
                    dtBilan.Rows.Add(receveur);
                }


                //VERIFIE SI LES LES DEPENSE SONT TOUTES A 0 OU NON
                int cptSoldeAt0 = 0;
                foreach (DataRow row in dtBilan.Rows)
                {
                    if (Convert.ToDecimal(row["Solde"].ToString()) == 0)
                    {
                        cptSoldeAt0 += 1;
                    }
                }

                //SI TOUTE LES DEPENSES == 0 , ARRETE LE WHILE
                if (cptSoldeAt0 == dtBilan.Rows.Count)
                {
                    allSoldeAt0 = true;
                }
            }

        }
    }
}


