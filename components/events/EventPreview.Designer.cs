
namespace ProbPotes.components
{
    partial class EventPreview
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
            this.txtTitle = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtParticipants = new System.Windows.Forms.Label();
            this.iconParticipants = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.AutoEllipsis = true;
            this.txtTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(250, 25);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "titre";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.AutoEllipsis = true;
            this.txtDate.Location = new System.Drawing.Point(12, 37);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(250, 18);
            this.txtDate.TabIndex = 1;
            this.txtDate.Text = "date";
            // 
            // txtParticipants
            // 
            this.txtParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParticipants.AutoEllipsis = true;
            this.txtParticipants.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtParticipants.Location = new System.Drawing.Point(50, 64);
            this.txtParticipants.Name = "txtParticipants";
            this.txtParticipants.Size = new System.Drawing.Size(211, 37);
            this.txtParticipants.TabIndex = 2;
            this.txtParticipants.Text = "participants";
            this.txtParticipants.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconParticipants
            // 
            this.iconParticipants.AutoSize = true;
            this.iconParticipants.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconParticipants.Location = new System.Drawing.Point(13, 72);
            this.iconParticipants.Name = "iconParticipants";
            this.iconParticipants.Size = new System.Drawing.Size(35, 19);
            this.iconParticipants.TabIndex = 3;
            this.iconParticipants.Text = "icon";
            // 
            // EventPreview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.iconParticipants);
            this.Controls.Add(this.txtParticipants);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTitle);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EventPreview";
            this.Size = new System.Drawing.Size(265, 114);
            this.Click += new System.EventHandler(this.EventPreview_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label txtParticipants;
        private System.Windows.Forms.Label iconParticipants;
    }
}
