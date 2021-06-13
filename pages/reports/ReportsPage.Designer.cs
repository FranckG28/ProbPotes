
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsPage));
            this.txtHelp = new System.Windows.Forms.Label();
            this.pnlEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportToPDF = new System.Windows.Forms.Button();
            this.pnlLine1 = new System.Windows.Forms.Panel();
            this.txtSoldTip = new System.Windows.Forms.Label();
            this.pnlGuests = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDetails = new System.Windows.Forms.Label();
            this.btnQDQAQ = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.Label();
            this.pnlDates = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDateStart = new System.Windows.Forms.Label();
            this.txtDatesSeparator = new System.Windows.Forms.Label();
            this.txtDateEnd = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlLine1.SuspendLayout();
            this.pnlDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHelp
            // 
            this.txtHelp.AutoSize = true;
            this.txtHelp.Location = new System.Drawing.Point(-3, 0);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(139, 13);
            this.txtHelp.TabIndex = 1;
            this.txtHelp.Text = "Sélectionnez un évènement";
            // 
            // pnlEvents
            // 
            this.pnlEvents.AutoScroll = true;
            this.pnlEvents.Location = new System.Drawing.Point(0, 16);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(344, 540);
            this.pnlEvents.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExportToPDF);
            this.panel1.Controls.Add(this.pnlLine1);
            this.panel1.Controls.Add(this.pnlGuests);
            this.panel1.Controls.Add(this.icon);
            this.panel1.Controls.Add(this.pnlDates);
            this.panel1.Controls.Add(this.txtDetails);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Location = new System.Drawing.Point(350, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 556);
            this.panel1.TabIndex = 3;
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.FlatAppearance.BorderSize = 0;
            this.btnExportToPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportToPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToPDF.Image")));
            this.btnExportToPDF.Location = new System.Drawing.Point(348, 133);
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(243, 35);
            this.btnExportToPDF.TabIndex = 33;
            this.btnExportToPDF.Text = "      Tout exporter en PDF";
            this.btnExportToPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportToPDF.UseVisualStyleBackColor = true;
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // pnlLine1
            // 
            this.pnlLine1.Controls.Add(this.btnQDQAQ);
            this.pnlLine1.Controls.Add(this.txtSoldTip);
            this.pnlLine1.Location = new System.Drawing.Point(6, 411);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Size = new System.Drawing.Size(585, 101);
            this.pnlLine1.TabIndex = 32;
            // 
            // txtSoldTip
            // 
            this.txtSoldTip.Location = new System.Drawing.Point(26, 18);
            this.txtSoldTip.Name = "txtSoldTip";
            this.txtSoldTip.Size = new System.Drawing.Size(530, 24);
            this.txtSoldTip.TabIndex = 30;
            this.txtSoldTip.Text = "ou choisissez un participant pour lequel vous souhaitez obtenir les détails";
            this.txtSoldTip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlGuests
            // 
            this.pnlGuests.AutoScroll = true;
            this.pnlGuests.Location = new System.Drawing.Point(6, 172);
            this.pnlGuests.Name = "pnlGuests";
            this.pnlGuests.Size = new System.Drawing.Size(588, 233);
            this.pnlGuests.TabIndex = 29;
            // 
            // txtDetails
            // 
            this.txtDetails.AutoSize = true;
            this.txtDetails.Location = new System.Drawing.Point(3, 144);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(109, 13);
            this.txtDetails.TabIndex = 28;
            this.txtDetails.Text = "Détails par participant";
            // 
            // btnQDQAQ
            // 
            this.btnQDQAQ.FlatAppearance.BorderSize = 0;
            this.btnQDQAQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQDQAQ.ForeColor = System.Drawing.Color.White;
            this.btnQDQAQ.Location = new System.Drawing.Point(26, 45);
            this.btnQDQAQ.Name = "btnQDQAQ";
            this.btnQDQAQ.Size = new System.Drawing.Size(530, 40);
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
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(3, 75);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(588, 55);
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
            this.Size = new System.Drawing.Size(950, 862);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLine1.ResumeLayout(false);
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
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label txtSoldTip;
        private System.Windows.Forms.Panel pnlLine1;
        private System.Windows.Forms.Button btnExportToPDF;
    }
}
