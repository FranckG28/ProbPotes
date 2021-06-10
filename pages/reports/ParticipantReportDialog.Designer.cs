
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTip = new System.Windows.Forms.Label();
            this.txtLblPaid = new System.Windows.Forms.Label();
            this.txtLblOwes = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.Label();
            this.txtOwes = new System.Windows.Forms.Label();
            this.selectOwes = new ProbPotes.components.ProbPotesSelector();
            this.selectPaid = new ProbPotes.components.ProbPotesSelector();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(219, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(568, 380);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtTip
            // 
            this.txtTip.AutoSize = true;
            this.txtTip.Location = new System.Drawing.Point(2, 2);
            this.txtTip.Name = "txtTip";
            this.txtTip.Size = new System.Drawing.Size(43, 13);
            this.txtTip.TabIndex = 1;
            this.txtTip.Text = "Afficher";
            // 
            // txtLblPaid
            // 
            this.txtLblPaid.AutoSize = true;
            this.txtLblPaid.Location = new System.Drawing.Point(1, 261);
            this.txtLblPaid.Name = "txtLblPaid";
            this.txtLblPaid.Size = new System.Drawing.Size(75, 13);
            this.txtLblPaid.TabIndex = 2;
            this.txtLblPaid.Text = "Total dépensé";
            // 
            // txtLblOwes
            // 
            this.txtLblOwes.AutoSize = true;
            this.txtLblOwes.Location = new System.Drawing.Point(2, 325);
            this.txtLblOwes.Name = "txtLblOwes";
            this.txtLblOwes.Size = new System.Drawing.Size(46, 13);
            this.txtLblOwes.TabIndex = 3;
            this.txtLblOwes.Text = "Total dû";
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(2, 278);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(211, 34);
            this.txtPaid.TabIndex = 4;
            this.txtPaid.Text = "label3";
            this.txtPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOwes
            // 
            this.txtOwes.Location = new System.Drawing.Point(5, 341);
            this.txtOwes.Name = "txtOwes";
            this.txtOwes.Size = new System.Drawing.Size(208, 34);
            this.txtOwes.TabIndex = 5;
            this.txtOwes.Text = "label3";
            this.txtOwes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectOwes
            // 
            this.selectOwes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(209)))), ((int)(((byte)(191)))));
            this.selectOwes.Icon = 59198;
            this.selectOwes.Location = new System.Drawing.Point(0, 78);
            this.selectOwes.Margin = new System.Windows.Forms.Padding(5);
            this.selectOwes.Name = "selectOwes";
            this.selectOwes.Selected = false;
            this.selectOwes.Size = new System.Drawing.Size(211, 34);
            this.selectOwes.TabIndex = 7;
            this.selectOwes.Title = "Dépenses bénéficiés";
            // 
            // selectPaid
            // 
            this.selectPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(209)))), ((int)(((byte)(191)))));
            this.selectPaid.Icon = 59198;
            this.selectPaid.Location = new System.Drawing.Point(0, 34);
            this.selectPaid.Margin = new System.Windows.Forms.Padding(5);
            this.selectPaid.Name = "selectPaid";
            this.selectPaid.Selected = false;
            this.selectPaid.Size = new System.Drawing.Size(211, 34);
            this.selectPaid.TabIndex = 6;
            this.selectPaid.Title = "Dépenses payés";
            // 
            // ParticipantReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectOwes);
            this.Controls.Add(this.selectPaid);
            this.Controls.Add(this.txtOwes);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.txtLblOwes);
            this.Controls.Add(this.txtLblPaid);
            this.Controls.Add(this.txtTip);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ParticipantReportDialog";
            this.Size = new System.Drawing.Size(790, 380);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label txtTip;
        private System.Windows.Forms.Label txtLblPaid;
        private System.Windows.Forms.Label txtLblOwes;
        private System.Windows.Forms.Label txtPaid;
        private System.Windows.Forms.Label txtOwes;
        private components.ProbPotesSelector selectPaid;
        private components.ProbPotesSelector selectOwes;
    }
}
