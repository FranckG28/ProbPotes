
namespace ProbPotes.components.expenses
{
    partial class ExpenseReportTile
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
            this.txtPrice = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtCreator = new System.Windows.Forms.Label();
            this.txtBalanceTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.AutoEllipsis = true;
            this.txtPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrice.Location = new System.Drawing.Point(598, 9);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(157, 54);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.Text = "label1";
            this.txtPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.AutoEllipsis = true;
            this.txtTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtTitle.Location = new System.Drawing.Point(15, 9);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(577, 35);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "label1";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.AutoEllipsis = true;
            this.txtDescription.Location = new System.Drawing.Point(15, 63);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(580, 30);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "label1";
            // 
            // txtCreator
            // 
            this.txtCreator.AutoEllipsis = true;
            this.txtCreator.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtCreator.Location = new System.Drawing.Point(15, 37);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(577, 35);
            this.txtCreator.TabIndex = 0;
            this.txtCreator.Text = "label1";
            // 
            // txtBalanceTotal
            // 
            this.txtBalanceTotal.AutoEllipsis = true;
            this.txtBalanceTotal.BackColor = System.Drawing.Color.Transparent;
            this.txtBalanceTotal.Location = new System.Drawing.Point(601, 63);
            this.txtBalanceTotal.Name = "txtBalanceTotal";
            this.txtBalanceTotal.Size = new System.Drawing.Size(154, 18);
            this.txtBalanceTotal.TabIndex = 0;
            this.txtBalanceTotal.Text = "label1";
            this.txtBalanceTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ExpenseReportTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBalanceTotal);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.txtTitle);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "ExpenseReportTile";
            this.Size = new System.Drawing.Size(766, 98);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtCreator;
        private System.Windows.Forms.Label txtBalanceTotal;
    }
}
