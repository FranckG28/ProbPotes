
namespace ProbPotes.components.expenses
{
    partial class ExpenseTile
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
            this.iconRecipients = new System.Windows.Forms.Label();
            this.txtRecipients = new System.Windows.Forms.Label();
            this.txtCreator = new System.Windows.Forms.Label();
            this.btnDelete = new ProbPotes.components.IconButton();
            this.btnEditRecipients = new ProbPotes.components.IconButton();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(714, 14);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(139, 35);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.Text = "label1";
            this.txtPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(13, 13);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(654, 35);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "label1";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(13, 49);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(922, 26);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "label1";
            // 
            // iconRecipients
            // 
            this.iconRecipients.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconRecipients.Location = new System.Drawing.Point(11, 72);
            this.iconRecipients.Name = "iconRecipients";
            this.iconRecipients.Size = new System.Drawing.Size(45, 39);
            this.iconRecipients.TabIndex = 0;
            this.iconRecipients.Text = "icon";
            this.iconRecipients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRecipients
            // 
            this.txtRecipients.Location = new System.Drawing.Point(59, 73);
            this.txtRecipients.Name = "txtRecipients";
            this.txtRecipients.Size = new System.Drawing.Size(537, 39);
            this.txtRecipients.TabIndex = 0;
            this.txtRecipients.Text = "label1";
            this.txtRecipients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreator
            // 
            this.txtCreator.Location = new System.Drawing.Point(759, 67);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(175, 39);
            this.txtCreator.TabIndex = 0;
            this.txtCreator.Text = "label1";
            this.txtCreator.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Icon = 57607;
            this.btnDelete.Location = new System.Drawing.Point(900, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(35, 35);
            this.btnDelete.TabIndex = 1;
            // 
            // btnEditRecipients
            // 
            this.btnEditRecipients.AutoSize = true;
            this.btnEditRecipients.BackColor = System.Drawing.Color.Transparent;
            this.btnEditRecipients.Icon = 57729;
            this.btnEditRecipients.Location = new System.Drawing.Point(859, 14);
            this.btnEditRecipients.Name = "btnEditRecipients";
            this.btnEditRecipients.Size = new System.Drawing.Size(35, 35);
            this.btnEditRecipients.TabIndex = 2;
            // 
            // ExpenseTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditRecipients);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.iconRecipients);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtRecipients);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.txtTitle);
            this.Name = "ExpenseTile";
            this.Size = new System.Drawing.Size(950, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label iconRecipients;
        private System.Windows.Forms.Label txtRecipients;
        private System.Windows.Forms.Label txtCreator;
        private IconButton btnDelete;
        private IconButton btnEditRecipients;
    }
}
