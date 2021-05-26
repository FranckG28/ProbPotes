
namespace ProbPotes.components.home
{
    partial class StatTile
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
            this.txtNumber = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIcon
            // 
            this.txtIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIcon.Location = new System.Drawing.Point(6, 25);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(213, 95);
            this.txtIcon.TabIndex = 0;
            this.txtIcon.Text = "icon";
            this.txtIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtIcon.Click += new System.EventHandler(this.StatTile_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(3, 138);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(216, 45);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.Text = "0";
            this.txtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtNumber.Click += new System.EventHandler(this.StatTile_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(3, 172);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(216, 36);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "description";
            this.txtDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtDescription.Click += new System.EventHandler(this.StatTile_Click);
            // 
            // StatTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.txtIcon);
            this.Name = "StatTile";
            this.Size = new System.Drawing.Size(222, 222);
            this.Click += new System.EventHandler(this.StatTile_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtIcon;
        private System.Windows.Forms.Label txtNumber;
        private System.Windows.Forms.Label txtDescription;
    }
}
