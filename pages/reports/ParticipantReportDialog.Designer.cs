
namespace ProbPotes.pages.reports
{
    partial class ParticipantReportDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParticipantReportDialog));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.selectOwes = new ProbPotes.components.ProbPotesSelector();
            this.selectPaid = new ProbPotes.components.ProbPotesSelector();
            this.btnExportToPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(787, 297);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // selectOwes
            // 
            this.selectOwes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(209)))), ((int)(((byte)(191)))));
            this.selectOwes.Icon = 59198;
            this.selectOwes.Location = new System.Drawing.Point(400, 0);
            this.selectOwes.Margin = new System.Windows.Forms.Padding(5);
            this.selectOwes.Name = "selectOwes";
            this.selectOwes.Selected = false;
            this.selectOwes.Size = new System.Drawing.Size(390, 34);
            this.selectOwes.TabIndex = 7;
            this.selectOwes.Title = "Dépenses bénéficiés";
            // 
            // selectPaid
            // 
            this.selectPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(209)))), ((int)(((byte)(191)))));
            this.selectPaid.Icon = 59198;
            this.selectPaid.Location = new System.Drawing.Point(0, 0);
            this.selectPaid.Margin = new System.Windows.Forms.Padding(5);
            this.selectPaid.Name = "selectPaid";
            this.selectPaid.Selected = false;
            this.selectPaid.Size = new System.Drawing.Size(390, 34);
            this.selectPaid.TabIndex = 6;
            this.selectPaid.Title = "Dépenses payés";
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.FlatAppearance.BorderSize = 0;
            this.btnExportToPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportToPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToPDF.Image")));
            this.btnExportToPDF.Location = new System.Drawing.Point(3, 342);
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(223, 35);
            this.btnExportToPDF.TabIndex = 34;
            this.btnExportToPDF.Text = "    Exporter en PDF";
            this.btnExportToPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportToPDF.UseVisualStyleBackColor = true;
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // ParticipantReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportToPDF);
            this.Controls.Add(this.selectOwes);
            this.Controls.Add(this.selectPaid);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ParticipantReportDialog";
            this.Size = new System.Drawing.Size(790, 380);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private components.ProbPotesSelector selectPaid;
        private components.ProbPotesSelector selectOwes;
        private System.Windows.Forms.Button btnExportToPDF;
    }
}
