
namespace ProbPotes.components.participants
{
    partial class ParticipantTile
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
            this.txtName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.Label();
            this.iconPhone = new System.Windows.Forms.Label();
            this.iconMail = new System.Windows.Forms.Label();
            this.iconShares = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.Label();
            this.txtShares = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::ProbPotes.Properties.Resources.person;
            this.pictureBox1.Location = new System.Drawing.Point(19, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Location = new System.Drawing.Point(88, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 20);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "N?ame";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtFirstName.Location = new System.Drawing.Point(86, 25);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(211, 31);
            this.txtFirstName.TabIndex = 4;
            this.txtFirstName.Text = "FirstName";
            this.txtFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtFirstName.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // iconPhone
            // 
            this.iconPhone.AutoSize = true;
            this.iconPhone.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconPhone.Location = new System.Drawing.Point(16, 93);
            this.iconPhone.Name = "iconPhone";
            this.iconPhone.Size = new System.Drawing.Size(35, 15);
            this.iconPhone.TabIndex = 5;
            this.iconPhone.Text = "label1";
            this.iconPhone.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // iconMail
            // 
            this.iconMail.AutoSize = true;
            this.iconMail.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconMail.Location = new System.Drawing.Point(16, 119);
            this.iconMail.Name = "iconMail";
            this.iconMail.Size = new System.Drawing.Size(35, 15);
            this.iconMail.TabIndex = 6;
            this.iconMail.Text = "label1";
            this.iconMail.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // iconShares
            // 
            this.iconShares.AutoSize = true;
            this.iconShares.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconShares.Location = new System.Drawing.Point(16, 145);
            this.iconShares.Name = "iconShares";
            this.iconShares.Size = new System.Drawing.Size(35, 15);
            this.iconShares.TabIndex = 7;
            this.iconShares.Text = "label2";
            this.iconShares.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.AutoSize = true;
            this.txtPhone.Location = new System.Drawing.Point(44, 91);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(35, 13);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.Text = "label1";
            this.txtPhone.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // txtMail
            // 
            this.txtMail.AutoSize = true;
            this.txtMail.Location = new System.Drawing.Point(44, 117);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(35, 13);
            this.txtMail.TabIndex = 10;
            this.txtMail.Text = "label2";
            this.txtMail.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // txtShares
            // 
            this.txtShares.AutoSize = true;
            this.txtShares.Location = new System.Drawing.Point(44, 144);
            this.txtShares.Name = "txtShares";
            this.txtShares.Size = new System.Drawing.Size(35, 13);
            this.txtShares.TabIndex = 11;
            this.txtShares.Text = "label3";
            this.txtShares.Click += new System.EventHandler(this.ParticipantTile_Click);
            // 
            // ParticipantTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtShares);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.iconShares);
            this.Controls.Add(this.iconMail);
            this.Controls.Add(this.iconPhone);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ParticipantTile";
            this.Size = new System.Drawing.Size(300, 174);
            this.Click += new System.EventHandler(this.ParticipantTile_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtFirstName;
        private System.Windows.Forms.Label iconPhone;
        private System.Windows.Forms.Label iconMail;
        private System.Windows.Forms.Label iconShares;
        private System.Windows.Forms.Label txtPhone;
        private System.Windows.Forms.Label txtMail;
        private System.Windows.Forms.Label txtShares;
    }
}
