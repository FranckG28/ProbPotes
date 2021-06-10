
namespace ProbPotes.pages
{
    partial class ReportsPage
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
            this.txtHelp = new System.Windows.Forms.Label();
            this.pnlEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLine1 = new System.Windows.Forms.Panel();
            this.pnlLine2 = new System.Windows.Forms.Panel();
            this.txtSoldTip = new System.Windows.Forms.Label();
            this.pnlGuests = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDetails = new System.Windows.Forms.Label();
            this.btnQDQAQ = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.Label();
            this.pnlDates = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDateStart = new System.Windows.Forms.Label();
            this.txtDatesSeparator = new System.Windows.Forms.Label();
            this.txtDateEnd = new System.Windows.Forms.Label();
            this.txtParticipants = new System.Windows.Forms.Label();
            this.iconParticipants = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHelp
            // 
            this.txtHelp.AutoSize = true;
            this.txtHelp.Location = new System.Drawing.Point(0, 12);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(139, 13);
            this.txtHelp.TabIndex = 1;
            this.txtHelp.Text = "Sélectionnez un évènement";
            // 
            // pnlEvents
            // 
            this.pnlEvents.AutoScroll = true;
            this.pnlEvents.Location = new System.Drawing.Point(0, 28);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(344, 528);
            this.pnlEvents.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlLine1);
            this.panel1.Controls.Add(this.pnlLine2);
            this.panel1.Controls.Add(this.txtSoldTip);
            this.panel1.Controls.Add(this.pnlGuests);
            this.panel1.Controls.Add(this.txtDetails);
            this.panel1.Controls.Add(this.btnQDQAQ);
            this.panel1.Controls.Add(this.icon);
            this.panel1.Controls.Add(this.pnlDates);
            this.panel1.Controls.Add(this.txtParticipants);
            this.panel1.Controls.Add(this.iconParticipants);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Location = new System.Drawing.Point(350, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 556);
            this.panel1.TabIndex = 3;
            // 
            // pnlLine1
            // 
            this.pnlLine1.Location = new System.Drawing.Point(6, 162);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Size = new System.Drawing.Size(586, 10);
            this.pnlLine1.TabIndex = 32;
            // 
            // pnlLine2
            // 
            this.pnlLine2.Location = new System.Drawing.Point(6, 254);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(586, 10);
            this.pnlLine2.TabIndex = 31;
            // 
            // txtSoldTip
            // 
            this.txtSoldTip.Location = new System.Drawing.Point(3, 175);
            this.txtSoldTip.Name = "txtSoldTip";
            this.txtSoldTip.Size = new System.Drawing.Size(588, 24);
            this.txtSoldTip.TabIndex = 30;
            this.txtSoldTip.Text = "ou choisissez un participant pour lequel vous souhaitez obtenir les détails";
            this.txtSoldTip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlGuests
            // 
            this.pnlGuests.AutoScroll = true;
            this.pnlGuests.Location = new System.Drawing.Point(6, 290);
            this.pnlGuests.Name = "pnlGuests";
            this.pnlGuests.Size = new System.Drawing.Size(585, 263);
            this.pnlGuests.TabIndex = 29;
            // 
            // txtDetails
            // 
            this.txtDetails.AutoSize = true;
            this.txtDetails.Location = new System.Drawing.Point(9, 269);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(170, 13);
            this.txtDetails.TabIndex = 28;
            this.txtDetails.Text = "Consulter les détails par participant";
            // 
            // btnQDQAQ
            // 
            this.btnQDQAQ.FlatAppearance.BorderSize = 0;
            this.btnQDQAQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQDQAQ.ForeColor = System.Drawing.Color.White;
            this.btnQDQAQ.Location = new System.Drawing.Point(6, 202);
            this.btnQDQAQ.Name = "btnQDQAQ";
            this.btnQDQAQ.Size = new System.Drawing.Size(585, 40);
            this.btnQDQAQ.TabIndex = 27;
            this.btnQDQAQ.Text = "Qui doit quoi à qui ?";
            this.btnQDQAQ.UseVisualStyleBackColor = true;
            this.btnQDQAQ.Click += new System.EventHandler(this.btnQDQAQ_Click);
            // 
            // icon
            // 
            this.icon.AutoSize = true;
            this.icon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icon.Location = new System.Drawing.Point(7, 30);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(48, 27);
            this.icon.TabIndex = 26;
            this.icon.Text = "icon";
            // 
            // pnlDates
            // 
            this.pnlDates.Controls.Add(this.txtDateStart);
            this.pnlDates.Controls.Add(this.txtDatesSeparator);
            this.pnlDates.Controls.Add(this.txtDateEnd);
            this.pnlDates.Location = new System.Drawing.Point(60, 45);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(515, 24);
            this.pnlDates.TabIndex = 25;
            // 
            // txtDateStart
            // 
            this.txtDateStart.AutoSize = true;
            this.txtDateStart.Location = new System.Drawing.Point(3, 0);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(33, 13);
            this.txtDateStart.TabIndex = 3;
            this.txtDateStart.Text = "dates";
            // 
            // txtDatesSeparator
            // 
            this.txtDatesSeparator.AutoSize = true;
            this.txtDatesSeparator.Location = new System.Drawing.Point(42, 0);
            this.txtDatesSeparator.Name = "txtDatesSeparator";
            this.txtDatesSeparator.Size = new System.Drawing.Size(10, 13);
            this.txtDatesSeparator.TabIndex = 11;
            this.txtDatesSeparator.Text = "-";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.AutoSize = true;
            this.txtDateEnd.Location = new System.Drawing.Point(58, 0);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(33, 13);
            this.txtDateEnd.TabIndex = 10;
            this.txtDateEnd.Text = "dates";
            // 
            // txtParticipants
            // 
            this.txtParticipants.Location = new System.Drawing.Point(49, 128);
            this.txtParticipants.Name = "txtParticipants";
            this.txtParticipants.Size = new System.Drawing.Size(542, 39);
            this.txtParticipants.TabIndex = 24;
            this.txtParticipants.Text = "Participants";
            // 
            // iconParticipants
            // 
            this.iconParticipants.AutoSize = true;
            this.iconParticipants.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconParticipants.Location = new System.Drawing.Point(1, 128);
            this.iconParticipants.Name = "iconParticipants";
            this.iconParticipants.Size = new System.Drawing.Size(47, 19);
            this.iconParticipants.TabIndex = 23;
            this.iconParticipants.Text = "label1";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(3, 75);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(588, 46);
            this.txtDescription.TabIndex = 22;
            this.txtDescription.Text = "Description";
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Location = new System.Drawing.Point(62, 16);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(103, 13);
            this.txtTitle.TabIndex = 21;
            this.txtTitle.Text = "Titre de l\'évènement";
            // 
            // ReportsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlEvents);
            this.Controls.Add(this.txtHelp);
            this.Name = "ReportsPage";
            this.Size = new System.Drawing.Size(950, 559);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDates.ResumeLayout(false);
            this.pnlDates.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtHelp;
        private System.Windows.Forms.FlowLayoutPanel pnlEvents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel pnlGuests;
        private System.Windows.Forms.Label txtDetails;
        private System.Windows.Forms.Button btnQDQAQ;
        private System.Windows.Forms.Label icon;
        private System.Windows.Forms.FlowLayoutPanel pnlDates;
        private System.Windows.Forms.Label txtDateStart;
        private System.Windows.Forms.Label txtDatesSeparator;
        private System.Windows.Forms.Label txtDateEnd;
        private System.Windows.Forms.Label txtParticipants;
        private System.Windows.Forms.Label iconParticipants;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label txtSoldTip;
        private System.Windows.Forms.Panel pnlLine2;
        private System.Windows.Forms.Panel pnlLine1;
    }
}
