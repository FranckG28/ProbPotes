
namespace ProbPotes.components.reports
{
    partial class WOWTWTile
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFirstName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.selectReceivable = new ProbPotes.components.ProbPotesSelector();
            this.selectDebts = new ProbPotes.components.ProbPotesSelector();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::ProbPotes.Properties.Resources.person;
            this.pictureBox1.Location = new System.Drawing.Point(19, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtFirstName.Location = new System.Drawing.Point(65, 13);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(290, 31);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.Text = "FirstName";
            this.txtFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Location = new System.Drawing.Point(67, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(288, 20);
            this.txtName.TabIndex = 5;
            this.txtName.Text = "N?ame";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 156);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(336, 87);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // selectReceivable
            // 
            this.selectReceivable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(52)))), ((int)(((byte)(209)))), ((int)(((byte)(191)))));
            this.selectReceivable.Icon = 59198;
            this.selectReceivable.Location = new System.Drawing.Point(19, 114);
            this.selectReceivable.Margin = new System.Windows.Forms.Padding(5);
            this.selectReceivable.Name = "selectReceivable";
            this.selectReceivable.Selected = false;
            this.selectReceivable.Size = new System.Drawing.Size(336, 34);
            this.selectReceivable.TabIndex = 8;
            this.selectReceivable.Title = "label1";
            // 
            // selectDebts
            // 
            this.selectDebts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(209)))), ((int)(((byte)(191)))));
            this.selectDebts.Icon = 59198;
            this.selectDebts.Location = new System.Drawing.Point(19, 76);
            this.selectDebts.Margin = new System.Windows.Forms.Padding(5);
            this.selectDebts.Name = "selectDebts";
            this.selectDebts.Selected = true;
            this.selectDebts.Size = new System.Drawing.Size(336, 34);
            this.selectDebts.TabIndex = 7;
            this.selectDebts.Title = "label1";
            // 
            // WOWTWTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.selectReceivable);
            this.Controls.Add(this.selectDebts);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "WOWTWTile";
            this.Size = new System.Drawing.Size(370, 259);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtFirstName;
        private System.Windows.Forms.Label txtName;
        private ProbPotesSelector selectDebts;
        private ProbPotesSelector selectReceivable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
