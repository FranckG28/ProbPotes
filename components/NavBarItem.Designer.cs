
namespace ProbPotes.components
{
    partial class NavBarItem
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
            this.txtIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIcon.ForeColor = System.Drawing.Color.White;
            this.txtIcon.Location = new System.Drawing.Point(10, 13);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(13, 21);
            this.txtIcon.TabIndex = 0;
            this.txtIcon.Text = "i";
            this.txtIcon.Click += new System.EventHandler(this.NavBarItem_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(44, 11);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(37, 18);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "Titre";
            this.txtTitle.Click += new System.EventHandler(this.NavBarItem_Click);
            // 
            // NavBarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtIcon);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "NavBarItem";
            this.Size = new System.Drawing.Size(170, 47);
            this.Click += new System.EventHandler(this.NavBarItem_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtIcon;
        private System.Windows.Forms.Label txtTitle;
    }
}
