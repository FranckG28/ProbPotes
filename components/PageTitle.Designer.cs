
namespace ProbPotes.components
{
    partial class PageTitle
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
            this.txtIcon = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIcon
            // 
            this.txtIcon.AutoSize = true;
            this.txtIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIcon.Location = new System.Drawing.Point(3, 21);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(24, 40);
            this.txtIcon.TabIndex = 0;
            this.txtIcon.Text = "i";
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Location = new System.Drawing.Point(67, 14);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(35, 13);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "label1";
            // 
            // PageTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtIcon);
            this.Name = "PageTitle";
            this.Size = new System.Drawing.Size(950, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtIcon;
        private System.Windows.Forms.Label txtTitle;
    }
}
