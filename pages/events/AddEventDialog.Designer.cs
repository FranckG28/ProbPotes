﻿
namespace ProbPotes.pages.events
{
    partial class AddEventDialog
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
            this.txtWarningDescription = new System.Windows.Forms.Label();
            this.txtWarningTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.boxDescription = new System.Windows.Forms.TextBox();
            this.iconDescription = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.boxTitle = new System.Windows.Forms.TextBox();
            this.txtTitle1 = new System.Windows.Forms.Label();
            this.iconTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.iconDate = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtWarningCreator = new System.Windows.Forms.Label();
            this.txtTitle2 = new System.Windows.Forms.Label();
            this.psCreator = new ProbPotes.components.participants.ParticipantSelector();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtTip = new System.Windows.Forms.Label();
            this.txtTitle3 = new System.Windows.Forms.Label();
            this.psGuests = new ProbPotes.components.participants.ParticipantSelector();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtSuccessfulDescription = new System.Windows.Forms.Label();
            this.iconSuccessful = new System.Windows.Forms.Label();
            this.txtTitleSuccess = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 380);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.txtWarningDescription);
            this.tabPage1.Controls.Add(this.txtWarningTitle);
            this.tabPage1.Controls.Add(this.lblDescription);
            this.tabPage1.Controls.Add(this.boxDescription);
            this.tabPage1.Controls.Add(this.iconDescription);
            this.tabPage1.Controls.Add(this.dateEnd);
            this.tabPage1.Controls.Add(this.dateStart);
            this.tabPage1.Controls.Add(this.boxTitle);
            this.tabPage1.Controls.Add(this.txtTitle1);
            this.tabPage1.Controls.Add(this.iconTitle);
            this.tabPage1.Controls.Add(this.lblTitle);
            this.tabPage1.Controls.Add(this.lblEndDate);
            this.tabPage1.Controls.Add(this.lblStartDate);
            this.tabPage1.Controls.Add(this.iconDate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // txtWarningDescription
            // 
            this.txtWarningDescription.Location = new System.Drawing.Point(498, 332);
            this.txtWarningDescription.Name = "txtWarningDescription";
            this.txtWarningDescription.Size = new System.Drawing.Size(260, 24);
            this.txtWarningDescription.TabIndex = 34;
            this.txtWarningDescription.Text = "Veuillez entrer une description";
            this.txtWarningDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWarningTitle
            // 
            this.txtWarningTitle.Location = new System.Drawing.Point(497, 126);
            this.txtWarningTitle.Name = "txtWarningTitle";
            this.txtWarningTitle.Size = new System.Drawing.Size(260, 24);
            this.txtWarningTitle.TabIndex = 34;
            this.txtWarningTitle.Text = "Veuillez entrer un titre";
            this.txtWarningTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(53, 211);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 33;
            this.lblDescription.Text = "Description";
            // 
            // boxDescription
            // 
            this.boxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxDescription.Location = new System.Drawing.Point(56, 234);
            this.boxDescription.Multiline = true;
            this.boxDescription.Name = "boxDescription";
            this.boxDescription.Size = new System.Drawing.Size(703, 88);
            this.boxDescription.TabIndex = 32;
            // 
            // iconDescription
            // 
            this.iconDescription.AutoSize = true;
            this.iconDescription.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconDescription.Location = new System.Drawing.Point(6, 240);
            this.iconDescription.Name = "iconDescription";
            this.iconDescription.Size = new System.Drawing.Size(47, 19);
            this.iconDescription.TabIndex = 31;
            this.iconDescription.Text = "label1";
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(429, 158);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(328, 20);
            this.dateEnd.TabIndex = 29;
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(55, 158);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(328, 20);
            this.dateStart.TabIndex = 28;
            // 
            // boxTitle
            // 
            this.boxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxTitle.Location = new System.Drawing.Point(55, 83);
            this.boxTitle.Name = "boxTitle";
            this.boxTitle.Size = new System.Drawing.Size(703, 20);
            this.boxTitle.TabIndex = 26;
            // 
            // txtTitle1
            // 
            this.txtTitle1.AutoSize = true;
            this.txtTitle1.Location = new System.Drawing.Point(4, 3);
            this.txtTitle1.Name = "txtTitle1";
            this.txtTitle1.Size = new System.Drawing.Size(141, 13);
            this.txtTitle1.TabIndex = 19;
            this.txtTitle1.Text = "Informations sur l\'évènement";
            // 
            // iconTitle
            // 
            this.iconTitle.AutoSize = true;
            this.iconTitle.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconTitle.Location = new System.Drawing.Point(5, 89);
            this.iconTitle.Name = "iconTitle";
            this.iconTitle.Size = new System.Drawing.Size(47, 19);
            this.iconTitle.TabIndex = 25;
            this.iconTitle.Text = "label1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(52, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(103, 13);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "Titre de l\'évènement";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(426, 134);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(19, 13);
            this.lblEndDate.TabIndex = 24;
            this.lblEndDate.Text = "au";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(53, 134);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(19, 13);
            this.lblStartDate.TabIndex = 22;
            this.lblStartDate.Text = "du";
            // 
            // iconDate
            // 
            this.iconDate.AutoSize = true;
            this.iconDate.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconDate.Location = new System.Drawing.Point(6, 164);
            this.iconDate.Name = "iconDate";
            this.iconDate.Size = new System.Drawing.Size(47, 19);
            this.iconDate.TabIndex = 20;
            this.iconDate.Text = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtWarningCreator);
            this.tabPage2.Controls.Add(this.txtTitle2);
            this.tabPage2.Controls.Add(this.psCreator);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtWarningCreator
            // 
            this.txtWarningCreator.Location = new System.Drawing.Point(404, 50);
            this.txtWarningCreator.Name = "txtWarningCreator";
            this.txtWarningCreator.Size = new System.Drawing.Size(372, 24);
            this.txtWarningCreator.TabIndex = 24;
            this.txtWarningCreator.Text = "Veuillez sélectionner le créateur de l\'évènement";
            this.txtWarningCreator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle2
            // 
            this.txtTitle2.AutoSize = true;
            this.txtTitle2.Location = new System.Drawing.Point(4, 3);
            this.txtTitle2.Name = "txtTitle2";
            this.txtTitle2.Size = new System.Drawing.Size(177, 13);
            this.txtTitle2.TabIndex = 20;
            this.txtTitle2.Text = "Qui est le créateur de l\'évènement ?";
            // 
            // psCreator
            // 
            this.psCreator.BackColor = System.Drawing.Color.Transparent;
            this.psCreator.Location = new System.Drawing.Point(0, 43);
            this.psCreator.MultiSelection = false;
            this.psCreator.Name = "psCreator";
            this.psCreator.Size = new System.Drawing.Size(782, 308);
            this.psCreator.TabIndex = 21;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTip);
            this.tabPage3.Controls.Add(this.txtTitle3);
            this.tabPage3.Controls.Add(this.psGuests);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(782, 354);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtTip
            // 
            this.txtTip.Location = new System.Drawing.Point(282, 50);
            this.txtTip.Name = "txtTip";
            this.txtTip.Size = new System.Drawing.Size(494, 29);
            this.txtTip.TabIndex = 23;
            this.txtTip.Text = "Les invités recevrons une notification par email";
            this.txtTip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle3
            // 
            this.txtTitle3.AutoSize = true;
            this.txtTitle3.Location = new System.Drawing.Point(4, 3);
            this.txtTitle3.Name = "txtTitle3";
            this.txtTitle3.Size = new System.Drawing.Size(146, 13);
            this.txtTitle3.TabIndex = 21;
            this.txtTitle3.Text = "Qui est invité à l\'évènement ?";
            // 
            // psGuests
            // 
            this.psGuests.Location = new System.Drawing.Point(0, 43);
            this.psGuests.MultiSelection = true;
            this.psGuests.Name = "psGuests";
            this.psGuests.Size = new System.Drawing.Size(782, 308);
            this.psGuests.TabIndex = 22;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtSuccessfulDescription);
            this.tabPage4.Controls.Add(this.iconSuccessful);
            this.tabPage4.Controls.Add(this.txtTitleSuccess);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(782, 354);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtSuccessfulDescription
            // 
            this.txtSuccessfulDescription.Location = new System.Drawing.Point(6, 251);
            this.txtSuccessfulDescription.Name = "txtSuccessfulDescription";
            this.txtSuccessfulDescription.Size = new System.Drawing.Size(773, 43);
            this.txtSuccessfulDescription.TabIndex = 6;
            this.txtSuccessfulDescription.Text = "Les participants invités ont reçu une notification par email";
            this.txtSuccessfulDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconSuccessful
            // 
            this.iconSuccessful.Font = new System.Drawing.Font("Segoe MDL2 Assets", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconSuccessful.Location = new System.Drawing.Point(3, 60);
            this.iconSuccessful.Name = "iconSuccessful";
            this.iconSuccessful.Size = new System.Drawing.Size(776, 148);
            this.iconSuccessful.TabIndex = 5;
            this.iconSuccessful.Text = "label1";
            this.iconSuccessful.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitleSuccess
            // 
            this.txtTitleSuccess.Location = new System.Drawing.Point(3, 208);
            this.txtTitleSuccess.Name = "txtTitleSuccess";
            this.txtTitleSuccess.Size = new System.Drawing.Size(773, 43);
            this.txtTitleSuccess.TabIndex = 4;
            this.txtTitleSuccess.Text = "Évènement ajouté !";
            this.txtTitleSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddEventDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "AddEventDialog";
            this.Size = new System.Drawing.Size(790, 380);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox boxTitle;
        private System.Windows.Forms.Label iconTitle;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label iconDate;
        private System.Windows.Forms.Label txtTitle1;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox boxDescription;
        private System.Windows.Forms.Label iconDescription;
        private System.Windows.Forms.Label txtTitle2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label txtTitle3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label txtSuccessfulDescription;
        private System.Windows.Forms.Label iconSuccessful;
        private System.Windows.Forms.Label txtTitleSuccess;
        private System.Windows.Forms.Label txtWarningTitle;
        private components.participants.ParticipantSelector psCreator;
        private components.participants.ParticipantSelector psGuests;
        private System.Windows.Forms.Label txtWarningCreator;
        private System.Windows.Forms.Label txtTip;
        private System.Windows.Forms.Label txtWarningDescription;
    }
}
