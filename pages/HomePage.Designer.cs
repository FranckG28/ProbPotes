﻿
namespace ProbPotes.pages
{
    partial class HomePage
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.iconAddExpense = new System.Windows.Forms.Label();
            this.txtAddExpenseTitle = new System.Windows.Forms.Label();
            this.txtAddExpenseDescription = new System.Windows.Forms.Label();
            this.pnlEvents = new System.Windows.Forms.Panel();
            this.tileTotal = new ProbPotes.components.home.StatTile();
            this.tileEvents = new ProbPotes.components.home.StatTile();
            this.tileExpenses = new ProbPotes.components.home.StatTile();
            this.tileParticipants = new ProbPotes.components.home.StatTile();
            this.SuspendLayout();
            // 
            // iconAddExpense
            // 
            this.iconAddExpense.AutoSize = true;
            this.iconAddExpense.Font = new System.Drawing.Font("Segoe MDL2 Assets", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconAddExpense.Location = new System.Drawing.Point(2, 298);
            this.iconAddExpense.Name = "iconAddExpense";
            this.iconAddExpense.Size = new System.Drawing.Size(0, 48);
            this.iconAddExpense.TabIndex = 4;
            // 
            // txtAddExpenseTitle
            // 
            this.txtAddExpenseTitle.AutoSize = true;
            this.txtAddExpenseTitle.Location = new System.Drawing.Point(66, 290);
            this.txtAddExpenseTitle.Name = "txtAddExpenseTitle";
            this.txtAddExpenseTitle.Size = new System.Drawing.Size(105, 13);
            this.txtAddExpenseTitle.TabIndex = 5;
            this.txtAddExpenseTitle.Text = "Ajouter une dépense";
            // 
            // txtAddExpenseDescription
            // 
            this.txtAddExpenseDescription.AutoSize = true;
            this.txtAddExpenseDescription.Location = new System.Drawing.Point(68, 333);
            this.txtAddExpenseDescription.Name = "txtAddExpenseDescription";
            this.txtAddExpenseDescription.Size = new System.Drawing.Size(340, 13);
            this.txtAddExpenseDescription.TabIndex = 6;
            this.txtAddExpenseDescription.Text = "Sélectionnez l\'évènement auquel vous souhaitez ajouter une dépense ";
            // 
            // pnlEvents
            // 
            this.pnlEvents.AutoScroll = true;
            this.pnlEvents.Location = new System.Drawing.Point(0, 377);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(942, 146);
            this.pnlEvents.TabIndex = 8;
            // 
            // tileTotal
            // 
            this.tileTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tileTotal.Description = "total dépensé";
            this.tileTotal.Icon = 60156;
            this.tileTotal.Location = new System.Drawing.Point(720, 3);
            this.tileTotal.Name = "tileTotal";
            this.tileTotal.Number = "--";
            this.tileTotal.Size = new System.Drawing.Size(222, 222);
            this.tileTotal.TabIndex = 3;
            // 
            // tileEvents
            // 
            this.tileEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tileEvents.Description = "évènements";
            this.tileEvents.Icon = 59271;
            this.tileEvents.Location = new System.Drawing.Point(480, 3);
            this.tileEvents.Name = "tileEvents";
            this.tileEvents.Number = "8";
            this.tileEvents.Size = new System.Drawing.Size(222, 222);
            this.tileEvents.TabIndex = 2;
            // 
            // tileExpenses
            // 
            this.tileExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tileExpenses.Description = "dépenses";
            this.tileExpenses.Icon = 59161;
            this.tileExpenses.Location = new System.Drawing.Point(240, 3);
            this.tileExpenses.Name = "tileExpenses";
            this.tileExpenses.Number = "--";
            this.tileExpenses.Size = new System.Drawing.Size(222, 222);
            this.tileExpenses.TabIndex = 1;
            // 
            // tileParticipants
            // 
            this.tileParticipants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tileParticipants.Description = "participants";
            this.tileParticipants.Icon = 59158;
            this.tileParticipants.Location = new System.Drawing.Point(0, 3);
            this.tileParticipants.Name = "tileParticipants";
            this.tileParticipants.Number = "3";
            this.tileParticipants.Size = new System.Drawing.Size(222, 222);
            this.tileParticipants.TabIndex = 0;
            // 
            // HomePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlEvents);
            this.Controls.Add(this.txtAddExpenseDescription);
            this.Controls.Add(this.txtAddExpenseTitle);
            this.Controls.Add(this.iconAddExpense);
            this.Controls.Add(this.tileTotal);
            this.Controls.Add(this.tileEvents);
            this.Controls.Add(this.tileExpenses);
            this.Controls.Add(this.tileParticipants);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(950, 559);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private components.home.StatTile tileParticipants;
        private components.home.StatTile tileExpenses;
        private components.home.StatTile tileEvents;
        private components.home.StatTile tileTotal;
        private System.Windows.Forms.Label iconAddExpense;
        private System.Windows.Forms.Label txtAddExpenseTitle;
        private System.Windows.Forms.Label txtAddExpenseDescription;
        private System.Windows.Forms.Panel pnlEvents;
    }
}
