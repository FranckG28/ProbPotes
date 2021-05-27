﻿using ProbPotes.models;
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

namespace ProbPotes.components.expenses
{
    public partial class ExpenseTile : UserControl
    {

        private Expense expense;
        private HoverController hover;

        public ExpenseTile()
        {
            InitializeComponent();
            Init();
        }

        public ExpenseTile(Expense expense)
        { 
            InitializeComponent();
            Init();
            Expense = expense;
        }

        private void Init()
        {
            // Création de l'effet de survol
            hover = new HoverController(new List<Control>() { this}, new List<Control>() {txtCreator,txtDescription, txtRecipients, txtTitle, iconRecipients }, this);

            hover.bg_default = Colors.lightBlue;
            hover.bg_hover = Colors.blue;
            hover.bg_pressed = Colors.green;

            hover.fg_default = Colors.blue;
            hover.fg_hover = Colors.white;
            hover.fg_pressed = Colors.white;

            // Icones :
            iconRecipients.Text = char.ConvertFromUtf32(0xE716);

            // Couleurs :
            pnlPrice.BackColor = Colors.blue;
            txtPrice.ForeColor = Colors.white;

            // Polices :
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                txtTitle.Font = new Font(Fonts.bold, 16);
                txtDescription.Font = new Font(Fonts.regular, 11);
                txtPrice.Font = new Font(Fonts.bold, 16);
                txtRecipients.Font = new Font(Fonts.book, 13);
                txtCreator.Font = new Font(Fonts.regular, 13);
            }

        }

        public Expense Expense
        {
            get => expense;
            set
            {
                expense = value;
                if (expense != null)
                {
                    txtTitle.Text = expense.description;
                    txtDescription.Text = expense.comment;
                    txtPrice.Text = expense.sum.ToString()+"€";
                    txtCreator.Text = "par " + expense.creatorCode.ToString();

                    // Génération d'une liste des participants 
                    string participantList = "";
                    foreach(int participant in expense.recipients)
                    {
                        participantList += participant.ToString() + ", ";
                    }
                    txtRecipients.Text = participantList;
                }
            }
        }
    }
}
