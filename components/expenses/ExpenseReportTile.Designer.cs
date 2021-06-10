
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
            this.pnlLine = new System.Windows.Forms.Panel();
            this.txtLblDescription = new System.Windows.Forms.Label();
            this.iconDescription = new System.Windows.Forms.Label();
            this.txtBalanceTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.AutoEllipsis = true;
            this.txtPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrice.Location = new System.Drawing.Point(634, 9);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(145, 35);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.Text = "label1";
            this.txtPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitle
            // 
            this.txtTitle.AutoEllipsis = true;
            this.txtTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtTitle.Location = new System.Drawing.Point(15, 9);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(602, 35);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "label1";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(64, 97);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(715, 31);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "label1";
            // 
            // txtCreator
            // 
            this.txtCreator.AutoEllipsis = true;
            this.txtCreator.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtCreator.Location = new System.Drawing.Point(15, 37);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(602, 35);
            this.txtCreator.TabIndex = 0;
            this.txtCreator.Text = "label1";
            // 
            // pnlLine
            // 
            this.pnlLine.Location = new System.Drawing.Point(17, 66);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(761, 1);
            this.pnlLine.TabIndex = 2;
            // 
            // txtLblDescription
            // 
            this.txtLblDescription.AutoSize = true;
            this.txtLblDescription.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtLblDescription.Location = new System.Drawing.Point(64, 83);
            this.txtLblDescription.Name = "txtLblDescription";
            this.txtLblDescription.Size = new System.Drawing.Size(60, 13);
            this.txtLblDescription.TabIndex = 0;
            this.txtLblDescription.Text = "Description";
            // 
            // iconDescription
            // 
            this.iconDescription.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.iconDescription.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconDescription.Location = new System.Drawing.Point(13, 75);
            this.iconDescription.Name = "iconDescription";
            this.iconDescription.Size = new System.Drawing.Size(51, 39);
            this.iconDescription.TabIndex = 0;
            this.iconDescription.Text = "icon";
            this.iconDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBalanceTotal
            // 
            this.txtBalanceTotal.AutoEllipsis = true;
            this.txtBalanceTotal.BackColor = System.Drawing.Color.Transparent;
            this.txtBalanceTotal.Location = new System.Drawing.Point(634, 50);
            this.txtBalanceTotal.Name = "txtBalanceTotal";
            this.txtBalanceTotal.Size = new System.Drawing.Size(145, 17);
            this.txtBalanceTotal.TabIndex = 0;
            this.txtBalanceTotal.Text = "label1";
            this.txtBalanceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExpenseReportTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.txtBalanceTotal);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.iconDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtLblDescription);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.txtTitle);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "ExpenseReportTile";
            this.Size = new System.Drawing.Size(787, 127);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtCreator;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label txtLblDescription;
        private System.Windows.Forms.Label iconDescription;
        private System.Windows.Forms.Label txtBalanceTotal;
    }
}
