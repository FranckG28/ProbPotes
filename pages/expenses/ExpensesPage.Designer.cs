
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
            this.pnlExpenses = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlEvents = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlExpenses
            // 
            this.pnlExpenses.AutoScroll = true;
            this.pnlExpenses.Location = new System.Drawing.Point(350, 3);
            this.pnlExpenses.Name = "pnlExpenses";
            this.pnlExpenses.Size = new System.Drawing.Size(600, 556);
            this.pnlExpenses.TabIndex = 3;
            // 
            // pnlEvents
            // 
            this.pnlEvents.AutoScroll = true;
            this.pnlEvents.Location = new System.Drawing.Point(0, 3);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(344, 556);
            this.pnlEvents.TabIndex = 4;
            // 
            // ExpensesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlEvents);
            this.Controls.Add(this.pnlExpenses);
            this.Name = "ExpensesPage";
            this.Size = new System.Drawing.Size(950, 559);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel pnlExpenses;
        private System.Windows.Forms.FlowLayoutPanel pnlEvents;
    }
}
