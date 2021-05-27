
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
            this.pnlPrice = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.iconRecipients = new System.Windows.Forms.Label();
            this.txtRecipients = new System.Windows.Forms.Label();
            this.txtCreator = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlPrice.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrice
            // 
            this.pnlPrice.Controls.Add(this.txtPrice);
            this.pnlPrice.Location = new System.Drawing.Point(14, 13);
            this.pnlPrice.Name = "pnlPrice";
            this.pnlPrice.Size = new System.Drawing.Size(133, 39);
            this.pnlPrice.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(3, 0);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(127, 39);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.Text = "label1";
            this.txtPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(166, 13);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(676, 39);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "label1";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(168, 52);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(676, 34);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "label1";
            // 
            // iconRecipients
            // 
            this.iconRecipients.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconRecipients.Location = new System.Drawing.Point(162, 86);
            this.iconRecipients.Name = "iconRecipients";
            this.iconRecipients.Size = new System.Drawing.Size(45, 39);
            this.iconRecipients.TabIndex = 0;
            this.iconRecipients.Text = "icon";
            this.iconRecipients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRecipients
            // 
            this.txtRecipients.Location = new System.Drawing.Point(213, 86);
            this.txtRecipients.Name = "txtRecipients";
            this.txtRecipients.Size = new System.Drawing.Size(537, 39);
            this.txtRecipients.TabIndex = 0;
            this.txtRecipients.Text = "label1";
            this.txtRecipients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreator
            // 
            this.txtCreator.Location = new System.Drawing.Point(756, 86);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(175, 39);
            this.txtCreator.TabIndex = 0;
            this.txtCreator.Text = "label1";
            this.txtCreator.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(914, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(887, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ExpenseTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.iconRecipients);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtRecipients);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.pnlPrice);
            this.Name = "ExpenseTile";
            this.Size = new System.Drawing.Size(950, 142);
            this.pnlPrice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrice;
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label iconRecipients;
        private System.Windows.Forms.Label txtRecipients;
        private System.Windows.Forms.Label txtCreator;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
