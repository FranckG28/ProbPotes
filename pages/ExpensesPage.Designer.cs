
namespace ProbPotes.pages
{
    partial class ExpensesPage
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
            this.txtDescription = new System.Windows.Forms.Label();
            this.pnlEvents = new System.Windows.Forms.Panel();
            this.pnlExpenses = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(61, 13);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Text = "Évènement";
            // 
            // pnlEvents
            // 
            this.pnlEvents.AutoScroll = true;
            this.pnlEvents.Location = new System.Drawing.Point(0, 26);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(250, 494);
            this.pnlEvents.TabIndex = 2;
            // 
            // pnlExpenses
            // 
            this.pnlExpenses.AutoScroll = true;
            this.pnlExpenses.Location = new System.Drawing.Point(250, 26);
            this.pnlExpenses.Name = "pnlExpenses";
            this.pnlExpenses.Size = new System.Drawing.Size(700, 494);
            this.pnlExpenses.TabIndex = 2;
            // 
            // ExpensesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlExpenses);
            this.Controls.Add(this.pnlEvents);
            this.Controls.Add(this.txtDescription);
            this.Name = "ExpensesPage";
            this.Size = new System.Drawing.Size(950, 520);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlEvents;
        private System.Windows.Forms.Panel pnlExpenses;
        private System.Windows.Forms.Label txtDescription;
    }
}
