﻿using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.components.reports
{

    // Affichage d'un participant dans un Qui doit quoi a qui
    public partial class WOWTWTile : UserControl
    {
        public WOWTW WOWTW;

        public WOWTWTile(WOWTW wOWTW)
        {
            InitializeComponent();

            this.WOWTW = wOWTW;

            // Couleur de fond
            BackColor = Colors.lightGrey;

            // Polices
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtFirstName.Font = new Font(Fonts.bold, 14);
                txtName.Font = new Font(Fonts.book, 12);
                txtFirstName.ForeColor = Colors.blue;
                txtName.ForeColor = Colors.blue;
            }

            // Affichage du nom du participant
            Participant p = DatabaseManager.Participants.GetParticipant(WOWTW.ParticipantId);
            txtFirstName.Text = p.FirstName;
            txtName.Text = p.Name;

            // Affichages des titres et totaux
            Decimal totalDebts = 0;
            Decimal totalReceivables = 0;

            // Calcul de la dette totale
            foreach(KeyValuePair<int, Decimal> kvp in WOWTW.GiveTo)
            {
                totalDebts += kvp.Value;
            }

            // Calcul de la somme totale à perçevoir
            foreach (KeyValuePair<int, Decimal> kvp in WOWTW.ReceiveFrom)
            {
                totalReceivables += kvp.Value;
            }

            // Affichage des totaux
            selectDebts.Title = "Dettes (" + Decimal.Round(totalDebts, 2) + " €)";
            selectReceivable.Title = "À percevoir (" + Decimal.Round(totalReceivables, 2) + " €)";

            // Attribution des évènements :
            selectDebts.action = ShowDebts;
            selectReceivable.action = ShowReceivables;

            // Affichage des dêttes au démarrage 
            if (totalReceivables != 0 && totalDebts == 0)
            {
                // Si il n'y a pas de dettes mais seulement des créances, les afficher à la place: 
                selectReceivable.Selected = true;
                ShowReceivables(null);
            } else
            {
                ShowDebts(null);
            }

        }

        // Affichage des dettes
        private void ShowDebts(Object e)
        {
            // Décoche l'autre case
            selectReceivable.Selected = false;

            // Nettoie la liste
            flowLayoutPanel1.Controls.Clear();

            if (WOWTW.GiveTo.Count == 0)
            {
                // Afficher aucun résultat
                ShowEmptyLabel();
            } else {
                // Afficher les transactions 
                foreach (KeyValuePair<int, Decimal> kvp in WOWTW.GiveTo)
                {
                    flowLayoutPanel1.Controls.Add(MakeItem(kvp.Value, "à rembourser à", kvp.Key));
                }
            }

        }

        // Affichage des créances
        private void ShowReceivables(Object e)
        {
            // Décoche l'autre case
            selectDebts.Selected = false;

            // Nettoie la liste
            flowLayoutPanel1.Controls.Clear();

            if (WOWTW.ReceiveFrom.Count == 0)
            {
                // Afficher aucun résultat
                ShowEmptyLabel();
            }
            else
            {
                // Afficher les transactions 
                foreach (KeyValuePair<int, Decimal> kvp in WOWTW.ReceiveFrom)
                {
                    flowLayoutPanel1.Controls.Add(MakeItem(kvp.Value, "à recevoir de", kvp.Key));
                }
            }
        }

        // Fonction de création du control d'une ligne de transaction
        private Control MakeItem(Decimal amount, string str, int pCode)
        {
            CheckBox lbl = new CheckBox();

            // Définition des propriétés
            lbl.AutoSize = false;
            lbl.Size = new Size(flowLayoutPanel1.Width - 10, 30);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Font = new Font(Fonts.book, 10);
            lbl.ForeColor = Colors.black;
            lbl.Padding = new Padding(5);
            lbl.AutoEllipsis = true;

            Participant p = DatabaseManager.Participants.GetParticipant(pCode);
            String name = p.FirstName + " " + p.Name.ToUpper();

            lbl.Text = Decimal.Round(amount, 2) + " € " + str + " " + name;

            return lbl;
        }

        // Fonction de création du control du label à afficher si il n'y a pas de transaction
        private void ShowEmptyLabel()
        {
            Label lbl = new Label();
            lbl.Text = "Rien à afficher :(";
            lbl.AutoSize = false;
            lbl.Size = new Size(flowLayoutPanel1.Width - 10, flowLayoutPanel1.Height - 10);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font(Fonts.book, 10);
            lbl.ForeColor = Color.FromArgb(20,7,7,7);

            flowLayoutPanel1.Controls.Add(lbl);
        }

    }
}
