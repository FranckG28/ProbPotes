using ProbPotes.components;

namespace ProbPotes.pages
{
    partial class PageTemplate
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
            this.pageContent = new System.Windows.Forms.Panel();
            this.pageTitle = new ProbPotes.components.PageTitle();
            this.SuspendLayout();
            // 
            // pageContent
            // 
            this.pageContent.Location = new System.Drawing.Point(0, 91);
            this.pageContent.Name = "pageContent";
            this.pageContent.Size = new System.Drawing.Size(950, 520);
            this.pageContent.TabIndex = 1;
            // 
            // pageTitle
            // 
            this.pageTitle.BackColor = System.Drawing.Color.Transparent;
            this.pageTitle.Icon = 59545;
            this.pageTitle.Location = new System.Drawing.Point(0, 0);
            this.pageTitle.Name = "pageTitle";
            this.pageTitle.Size = new System.Drawing.Size(950, 85);
            this.pageTitle.TabIndex = 0;
            this.pageTitle.Title = "label1";
            // 
            // PageTemplate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pageContent);
            this.Controls.Add(this.pageTitle);
            this.Name = "PageTemplate";
            this.Size = new System.Drawing.Size(950, 610);
            this.Load += new System.EventHandler(this.PageTemplate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private components.PageTitle pageTitle;
        private System.Windows.Forms.Panel pageContent;
    }
}
