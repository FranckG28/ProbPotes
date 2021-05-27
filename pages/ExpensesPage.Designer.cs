
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
            this.expenseTile1 = new ProbPotes.components.expenses.ExpenseTile();
            this.SuspendLayout();
            // 
            // expenseTile1
            // 
            this.expenseTile1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.expenseTile1.Expense = null;
            this.expenseTile1.Location = new System.Drawing.Point(0, 3);
            this.expenseTile1.Name = "expenseTile1";
            this.expenseTile1.Size = new System.Drawing.Size(950, 120);
            this.expenseTile1.TabIndex = 0;
            // 
            // ExpensesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.expenseTile1);
            this.Name = "ExpensesPage";
            this.Size = new System.Drawing.Size(950, 520);
            this.ResumeLayout(false);

        }

        #endregion

        private components.expenses.ExpenseTile expenseTile1;
    }
}
