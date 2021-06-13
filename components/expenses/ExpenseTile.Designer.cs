
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
            this.txtCreator = new System.Windows.Forms.Label();
            this.txtLblDescription = new System.Windows.Forms.Label();
            this.iconDescription = new System.Windows.Forms.Label();
            this.iconRecipients = new System.Windows.Forms.Label();
            this.txtLblParticipants = new System.Windows.Forms.Label();
            this.txtRecipients = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrice.Location = new System.Drawing.Point(491, 12);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(164, 63);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.Text = "label1";
            this.txtPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtPrice.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtTitle.Location = new System.Drawing.Point(15, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(470, 35);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "label1";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTitle.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(64, 143);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(591, 31);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.Text = "label1";
            this.txtDescription.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // txtCreator
            // 
            this.txtCreator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreator.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtCreator.Location = new System.Drawing.Point(15, 40);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(470, 35);
            this.txtCreator.TabIndex = 0;
            this.txtCreator.Text = "label1";
            this.txtCreator.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // txtLblDescription
            // 
            this.txtLblDescription.AutoSize = true;
            this.txtLblDescription.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtLblDescription.Location = new System.Drawing.Point(64, 128);
            this.txtLblDescription.Name = "txtLblDescription";
            this.txtLblDescription.Size = new System.Drawing.Size(60, 13);
            this.txtLblDescription.TabIndex = 0;
            this.txtLblDescription.Text = "Description";
            this.txtLblDescription.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // iconDescription
            // 
            this.iconDescription.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.iconDescription.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconDescription.Location = new System.Drawing.Point(13, 123);
            this.iconDescription.Name = "iconDescription";
            this.iconDescription.Size = new System.Drawing.Size(51, 39);
            this.iconDescription.TabIndex = 0;
            this.iconDescription.Text = "icon";
            this.iconDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iconDescription.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // iconRecipients
            // 
            this.iconRecipients.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.iconRecipients.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconRecipients.Location = new System.Drawing.Point(13, 73);
            this.iconRecipients.Name = "iconRecipients";
            this.iconRecipients.Size = new System.Drawing.Size(51, 39);
            this.iconRecipients.TabIndex = 0;
            this.iconRecipients.Text = "icon";
            this.iconRecipients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iconRecipients.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // txtLblParticipants
            // 
            this.txtLblParticipants.AutoSize = true;
            this.txtLblParticipants.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtLblParticipants.Location = new System.Drawing.Point(64, 75);
            this.txtLblParticipants.Name = "txtLblParticipants";
            this.txtLblParticipants.Size = new System.Drawing.Size(67, 13);
            this.txtLblParticipants.TabIndex = 0;
            this.txtLblParticipants.Text = "Bénéficiaires";
            this.txtLblParticipants.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // txtRecipients
            // 
            this.txtRecipients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecipients.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtRecipients.Location = new System.Drawing.Point(64, 85);
            this.txtRecipients.Name = "txtRecipients";
            this.txtRecipients.Size = new System.Drawing.Size(591, 34);
            this.txtRecipients.TabIndex = 0;
            this.txtRecipients.Text = "label1";
            this.txtRecipients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtRecipients.Click += new System.EventHandler(this.ExpenseTile_Click);
            // 
            // ExpenseTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.iconDescription);
            this.Controls.Add(this.iconRecipients);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtLblDescription);
            this.Controls.Add(this.txtLblParticipants);
            this.Controls.Add(this.txtRecipients);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.txtTitle);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "ExpenseTile";
            this.Size = new System.Drawing.Size(670, 174);
            this.Click += new System.EventHandler(this.ExpenseTile_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtCreator;
        private System.Windows.Forms.Label txtLblDescription;
        private System.Windows.Forms.Label iconDescription;
        private System.Windows.Forms.Label iconRecipients;
        private System.Windows.Forms.Label txtLblParticipants;
        private System.Windows.Forms.Label txtRecipients;
    }
}
