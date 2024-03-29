﻿using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.managers
{
    class ParticipantManager
    {

        // Liste des participants
        private List<Participant> ParticipantsList = new List<Participant>();

        // Constructeur de la classe
        // Récupère la liste des participants
        public ParticipantManager()
        {
            RefreshParticipants();
        }

        // Getter de la liste des participants
        public List<Participant> Participants
        {
            get => ParticipantsList;
        }

        // Procédure d'ajout d'un participant à la base de donnée.
        // Retourne true si l'ajout a réussi
        public Boolean AddParticipant(Participant participant)
        {
            try
            {
                // Ouverture de la connexion
                DatabaseManager.db.Open();

                // Création de la commande
                OleDbCommand insertPart = new OleDbCommand(@"INSERT INTO Participants(codeParticipant,nomPart,prenomPart,mobile,nbParts,adresseMail)
                                                       	VALUES(?,?,?,?,?,?)", DatabaseManager.db);

                // Création des paramètres
                insertPart.Parameters.Add(new OleDbParameter("codeParticipant", OleDbType.Integer)).Value = participant.Code;
                insertPart.Parameters.Add(new OleDbParameter("nomPart", OleDbType.WChar)).Value = participant.Name;
                insertPart.Parameters.Add(new OleDbParameter("prenomPart", OleDbType.WChar)).Value = participant.FirstName;
                insertPart.Parameters.Add(new OleDbParameter("mobile", OleDbType.WChar)).Value = participant.Phone;
                insertPart.Parameters.Add(new OleDbParameter("nbParts", OleDbType.Integer)).Value = participant.Shares;
                insertPart.Parameters.Add(new OleDbParameter("adresseMail", OleDbType.WChar)).Value = participant.MailAddress;

                int result = insertPart.ExecuteNonQuery();

                return result > 0;
               
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                // Fermeture de la connexion et mise à jour de la liste
                DatabaseManager.db.Close();
                RefreshParticipants();
            }
        }

        // Procédure de mise à jour d'un participant 
        // Retourne true si la mise à jour a réussi
        public Boolean UpdateParticipant(Participant participant)
        {
            try
            {
                // Ouverture de la connexion
                if (DatabaseManager.db.State != ConnectionState.Open)
                    DatabaseManager.db.Open();

                // Création de la requete
                OleDbCommand update = new OleDbCommand(@"UPDATE Participants SET nomPart = ?, prenomPart = ?, mobile = ?, nbParts = ?, adresseMail= ? WHERE codeParticipant = ?", DatabaseManager.db);

                // Ajout des paramètres
                update.Parameters.Add(new OleDbParameter("nomPart", OleDbType.WChar)).Value = participant.Name;
                update.Parameters.Add(new OleDbParameter("prenomPart", OleDbType.WChar)).Value = participant.FirstName;
                update.Parameters.Add(new OleDbParameter("mobile", OleDbType.WChar)).Value = participant.Phone;
                update.Parameters.Add(new OleDbParameter("nbParts", OleDbType.Integer)).Value = participant.Shares;
                update.Parameters.Add(new OleDbParameter("adresseMail", OleDbType.WChar)).Value = participant.MailAddress;
                update.Parameters.Add(new OleDbParameter("codeParticipant", OleDbType.Integer)).Value = participant.Code;

                int result = update.ExecuteNonQuery();

                return result > 0;

            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            } finally
            {
                // Fermeture de la connexion et mise à jour de la liste
                RefreshParticipants();
                DatabaseManager.db.Close();
            }
        }


        // Fonction qui retourne le participant correspondant au numéro dans la base
        public Participant GetParticipant(int id)
        {
            return ParticipantsList.Where(p => p.Code == id).First();
        }


        // Fonction qui actualise la liste de tous les participant de la base
        public void RefreshParticipants()
        {
            
            ParticipantsList = new List<Participant>();

            // Récupération des participants
            OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM Participants", DatabaseManager.db);
            DataTable participantsTable = new DataTable();
            adapter.Fill(participantsTable);

            // Remplis la liste des participants a partir de chaque ligne de la table
            foreach(DataRow row in participantsTable.Rows)
            {
                ParticipantsList.Add(new Participant(row));
            }
        }

        // Fonction de transformation d'une liste de code Participant en une liste de leur noms+prénoms sous forme de chaine de caractère
        public string GetStringFromList(List<int> list)
        {
            List<Participant> guests = new List<Participant>();

            foreach(int i in list)
            {
                guests.Add(GetParticipant(i));
            }

            // Génération de la chaine de caractère 
            string result = "";

            for (int i = 0; i < guests.Count; i++)
            {
                result += guests[i].FirstName + " " + guests[i].Name.Substring(0, 1).ToUpper() + ".";
                if (i < guests.Count - 1)
                {
                    result += ", ";
                }
            }

            return result;
        }
    }
}
