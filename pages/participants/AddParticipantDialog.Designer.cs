﻿
namespace ProbPotes.pages.participants
{
    partial class AddParticipantDialog
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtWarning = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.boxMail = new System.Windows.Forms.TextBox();
            this.iconMail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.boxPhone = new System.Windows.Forms.TextBox();
            this.iconPhone = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.boxName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.boxFirstName = new System.Windows.Forms.TextBox();
            this.iconName = new System.Windows.Forms.Label();
            this.txtTitle1 = new System.Windows.Forms.Label();
            this.lblShares = new System.Windows.Forms.Label();
            this.iconShares = new System.Windows.Forms.Label();
            this.boxShares = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtSuccessfulDescription = new System.Windows.Forms.Label();
            this.iconSuccessful = new System.Windows.Forms.Label();
            this.txtTitleSuccess = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 380);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtWarning);
            this.tabPage1.Controls.Add(this.lblMail);
            this.tabPage1.Controls.Add(this.boxMail);
            this.tabPage1.Controls.Add(this.iconMail);
            this.tabPage1.Controls.Add(this.lblPhone);
            this.tabPage1.Controls.Add(this.boxPhone);
            this.tabPage1.Controls.Add(this.iconPhone);
            this.tabPage1.Controls.Add(this.lblName);
            this.tabPage1.Controls.Add(this.boxName);
            this.tabPage1.Controls.Add(this.lblFirstName);
            this.tabPage1.Controls.Add(this.boxFirstName);
            this.tabPage1.Controls.Add(this.iconName);
            this.tabPage1.Controls.Add(this.txtTitle1);
            this.tabPage1.Controls.Add(this.lblShares);
            this.tabPage1.Controls.Add(this.iconShares);
            this.tabPage1.Controls.Add(this.boxShares);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtWarning
            // 
            this.txtWarning.Location = new System.Drawing.Point(402, 324);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.Size = new System.Drawing.Size(377, 27);
            this.txtWarning.TabIndex = 16;
            this.txtWarning.Text = "Veuillez completer tous les champs";
            this.txtWarning.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(53, 211);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(67, 13);
            this.lblMail.TabIndex = 11;
            this.lblMail.Text = "Adresse Mail";
            // 
            // boxMail
            // 
            this.boxMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxMail.Location = new System.Drawing.Point(56, 234);
            this.boxMail.Name = "boxMail";
            this.boxMail.Size = new System.Drawing.Size(703, 20);
            this.boxMail.TabIndex = 4;
            this.boxMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxEmail_KeyPress);
            // 
            // iconMail
            // 
            this.iconMail.AutoSize = true;
            this.iconMail.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconMail.Location = new System.Drawing.Point(6, 242);
            this.iconMail.Name = "iconMail";
            this.iconMail.Size = new System.Drawing.Size(47, 19);
            this.iconMail.TabIndex = 9;
            this.iconMail.Text = "label1";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(53, 138);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(58, 13);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Téléphone";
            // 
            // boxPhone
            // 
            this.boxPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxPhone.Location = new System.Drawing.Point(56, 161);
            this.boxPhone.MaxLength = 10;
            this.boxPhone.Name = "boxPhone";
            this.boxPhone.Size = new System.Drawing.Size(703, 20);
            this.boxPhone.TabIndex = 3;
            this.boxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxPhone_KeyPress);
            // 
            // iconPhone
            // 
            this.iconPhone.AutoSize = true;
            this.iconPhone.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconPhone.Location = new System.Drawing.Point(6, 169);
            this.iconPhone.Name = "iconPhone";
            this.iconPhone.Size = new System.Drawing.Size(47, 19);
            this.iconPhone.TabIndex = 6;
            this.iconPhone.Text = "label1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(426, 63);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Nom";
            // 
            // boxName
            // 
            this.boxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxName.Location = new System.Drawing.Point(429, 85);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(330, 20);
            this.boxName.TabIndex = 2;
            this.boxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxFirstName_KeyPress);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(53, 62);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(43, 13);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "Prénom";
            // 
            // boxFirstName
            // 
            this.boxFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxFirstName.Location = new System.Drawing.Point(56, 85);
            this.boxFirstName.Name = "boxFirstName";
            this.boxFirstName.Size = new System.Drawing.Size(330, 20);
            this.boxFirstName.TabIndex = 1;
            this.boxFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxName_KeyPress);
            // 
            // iconName
            // 
            this.iconName.AutoSize = true;
            this.iconName.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconName.Location = new System.Drawing.Point(6, 94);
            this.iconName.Name = "iconName";
            this.iconName.Size = new System.Drawing.Size(47, 19);
            this.iconName.TabIndex = 1;
            this.iconName.Text = "label1";
            // 
            // txtTitle1
            // 
            this.txtTitle1.AutoSize = true;
            this.txtTitle1.Location = new System.Drawing.Point(4, 3);
            this.txtTitle1.Name = "txtTitle1";
            this.txtTitle1.Size = new System.Drawing.Size(144, 13);
            this.txtTitle1.TabIndex = 0;
            this.txtTitle1.Text = "Informations sur le participant";
            // 
            // lblShares
            // 
            this.lblShares.AutoSize = true;
            this.lblShares.Location = new System.Drawing.Point(53, 282);
            this.lblShares.Name = "lblShares";
            this.lblShares.Size = new System.Drawing.Size(31, 13);
            this.lblShares.TabIndex = 18;
            this.lblShares.Text = "Parts";
            // 
            // iconShares
            // 
            this.iconShares.AutoSize = true;
            this.iconShares.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconShares.Location = new System.Drawing.Point(6, 313);
            this.iconShares.Name = "iconShares";
            this.iconShares.Size = new System.Drawing.Size(47, 19);
            this.iconShares.TabIndex = 16;
            this.iconShares.Text = "label1";
            // 
            // boxShares
            // 
            this.boxShares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxShares.Location = new System.Drawing.Point(56, 305);
            this.boxShares.Name = "boxShares";
            this.boxShares.Size = new System.Drawing.Size(330, 20);
            this.boxShares.TabIndex = 5;
            this.boxShares.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxShares_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtSuccessfulDescription);
            this.tabPage2.Controls.Add(this.iconSuccessful);
            this.tabPage2.Controls.Add(this.txtTitleSuccess);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtSuccessfulDescription
            // 
            this.txtSuccessfulDescription.Location = new System.Drawing.Point(3, 243);
            this.txtSuccessfulDescription.Name = "txtSuccessfulDescription";
            this.txtSuccessfulDescription.Size = new System.Drawing.Size(773, 43);
            this.txtSuccessfulDescription.TabIndex = 3;
            this.txtSuccessfulDescription.Text = "Participant ajouté";
            this.txtSuccessfulDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconSuccessful
            // 
            this.iconSuccessful.Font = new System.Drawing.Font("Segoe MDL2 Assets", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconSuccessful.Location = new System.Drawing.Point(3, 52);
            this.iconSuccessful.Name = "iconSuccessful";
            this.iconSuccessful.Size = new System.Drawing.Size(776, 148);
            this.iconSuccessful.TabIndex = 2;
            this.iconSuccessful.Text = "label1";
            this.iconSuccessful.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitleSuccess
            // 
            this.txtTitleSuccess.Location = new System.Drawing.Point(3, 200);
            this.txtTitleSuccess.Name = "txtTitleSuccess";
            this.txtTitleSuccess.Size = new System.Drawing.Size(773, 43);
            this.txtTitleSuccess.TabIndex = 0;
            this.txtTitleSuccess.Text = "Participant ajouté";
            this.txtTitleSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddParticipantDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "AddParticipantDialog";
            this.Size = new System.Drawing.Size(790, 380);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label txtTitle1;
        private System.Windows.Forms.Label txtTitleSuccess;
        private System.Windows.Forms.TextBox boxMail;
        private System.Windows.Forms.Label iconMail;
        private System.Windows.Forms.TextBox boxPhone;
        private System.Windows.Forms.Label iconPhone;
        private System.Windows.Forms.TextBox boxName;
        private System.Windows.Forms.TextBox boxFirstName;
        private System.Windows.Forms.Label iconName;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label iconSuccessful;
        private System.Windows.Forms.Label txtSuccessfulDescription;
        private System.Windows.Forms.Label lblShares;
        private System.Windows.Forms.TextBox boxShares;
        private System.Windows.Forms.Label iconShares;
        private System.Windows.Forms.Label txtWarning;
    }
}
