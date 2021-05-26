
namespace ProbPotes.components
{
    partial class CloseBtn
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
            this.icon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // icon
            // 
            this.icon.AutoSize = true;
            this.icon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icon.Location = new System.Drawing.Point(14, 8);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(0, 15);
            this.icon.TabIndex = 0;
            this.icon.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // CloseBtn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.icon);
            this.Name = "CloseBtn";
            this.Size = new System.Drawing.Size(47, 30);
            this.Click += new System.EventHandler(this.CloseBtn_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label icon;
    }
}
