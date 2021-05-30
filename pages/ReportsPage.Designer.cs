
namespace ProbPotes.pages
{
    partial class ReportsPage
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
            this.eventPreview1 = new ProbPotes.components.EventPreview();
            this.SuspendLayout();
            // 
            // eventPreview1
            // 
            this.eventPreview1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(255)))));
            this.eventPreview1.EventClass = null;
            this.eventPreview1.Location = new System.Drawing.Point(3, 3);
            this.eventPreview1.Name = "eventPreview1";
            this.eventPreview1.Size = new System.Drawing.Size(222, 120);
            this.eventPreview1.TabIndex = 0;
            // 
            // ReportsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.eventPreview1);
            this.Name = "ReportsPage";
            this.Size = new System.Drawing.Size(950, 520);
            this.ResumeLayout(false);

        }

        #endregion

        private components.EventPreview eventPreview1;
    }
}
