﻿
namespace ProbPotes.pages
{
    partial class EventsPage
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
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.chkSold = new System.Windows.Forms.CheckBox();
            this.txtDateEnd = new System.Windows.Forms.Label();
            this.txtParticipants = new System.Windows.Forms.Label();
            this.iconSoldOut = new System.Windows.Forms.Label();
            this.iconParticipants = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtCreator = new System.Windows.Forms.Label();
            this.txtDateStart = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.Label();
            this.btnLast = new ProbPotes.components.IconButton();
            this.btnNext = new ProbPotes.components.IconButton();
            this.btnPrevious = new ProbPotes.components.IconButton();
            this.btnFirst = new ProbPotes.components.IconButton();
            this.btnEdit = new ProbPotes.components.IconButton();
            this.btnDelete = new ProbPotes.components.IconButton();
            this.pnlDates = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDatesSeparator = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.Label();
            this.pnlEvent.SuspendLayout();
            this.pnlDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEvent
            // 
            this.pnlEvent.Controls.Add(this.pnlDates);
            this.pnlEvent.Controls.Add(this.chkSold);
            this.pnlEvent.Controls.Add(this.txtParticipants);
            this.pnlEvent.Controls.Add(this.iconSoldOut);
            this.pnlEvent.Controls.Add(this.iconParticipants);
            this.pnlEvent.Controls.Add(this.txtDescription);
            this.pnlEvent.Controls.Add(this.txtCreator);
            this.pnlEvent.Controls.Add(this.txtTitle);
            this.pnlEvent.Controls.Add(this.btnEdit);
            this.pnlEvent.Controls.Add(this.btnDelete);
            this.pnlEvent.Location = new System.Drawing.Point(226, 99);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(499, 301);
            this.pnlEvent.TabIndex = 0;
            // 
            // chkSold
            // 
            this.chkSold.AutoSize = true;
            this.chkSold.Enabled = false;
            this.chkSold.Location = new System.Drawing.Point(76, 239);
            this.chkSold.Name = "chkSold";
            this.chkSold.Size = new System.Drawing.Size(53, 17);
            this.chkSold.TabIndex = 11;
            this.chkSold.Text = "Soldé";
            this.chkSold.UseVisualStyleBackColor = true;
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.AutoSize = true;
            this.txtDateEnd.Location = new System.Drawing.Point(58, 0);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(33, 13);
            this.txtDateEnd.TabIndex = 10;
            this.txtDateEnd.Text = "dates";
            // 
            // txtParticipants
            // 
            this.txtParticipants.AutoSize = true;
            this.txtParticipants.Location = new System.Drawing.Point(72, 199);
            this.txtParticipants.Name = "txtParticipants";
            this.txtParticipants.Size = new System.Drawing.Size(62, 13);
            this.txtParticipants.TabIndex = 8;
            this.txtParticipants.Text = "Participants";
            // 
            // iconSoldOut
            // 
            this.iconSoldOut.AutoSize = true;
            this.iconSoldOut.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconSoldOut.Location = new System.Drawing.Point(24, 238);
            this.iconSoldOut.Name = "iconSoldOut";
            this.iconSoldOut.Size = new System.Drawing.Size(47, 19);
            this.iconSoldOut.TabIndex = 7;
            this.iconSoldOut.Text = "label1";
            // 
            // iconParticipants
            // 
            this.iconParticipants.AutoSize = true;
            this.iconParticipants.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconParticipants.Location = new System.Drawing.Point(24, 199);
            this.iconParticipants.Name = "iconParticipants";
            this.iconParticipants.Size = new System.Drawing.Size(47, 19);
            this.iconParticipants.TabIndex = 6;
            this.iconParticipants.Text = "label1";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(24, 87);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(458, 97);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "Description";
            // 
            // txtCreator
            // 
            this.txtCreator.Location = new System.Drawing.Point(24, 259);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(458, 27);
            this.txtCreator.TabIndex = 4;
            this.txtCreator.Text = "crée par";
            this.txtCreator.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtDateStart
            // 
            this.txtDateStart.AutoSize = true;
            this.txtDateStart.Location = new System.Drawing.Point(3, 0);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(33, 13);
            this.txtDateStart.TabIndex = 3;
            this.txtDateStart.Text = "dates";
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Location = new System.Drawing.Point(24, 25);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(103, 13);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.Text = "Titre de l\'évènement";
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(9, 446);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(480, 36);
            this.txtIndex.TabIndex = 1;
            this.txtIndex.Text = "0/0";
            this.txtIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLast
            // 
            this.btnLast.AutoSize = true;
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.Icon = 59539;
            this.btnLast.Location = new System.Drawing.Point(867, 232);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(35, 35);
            this.btnLast.TabIndex = 5;
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Icon = 59178;
            this.btnNext.Location = new System.Drawing.Point(777, 232);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 35);
            this.btnNext.TabIndex = 4;
            // 
            // btnPrevious
            // 
            this.btnPrevious.AutoSize = true;
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Icon = 59179;
            this.btnPrevious.Location = new System.Drawing.Point(133, 232);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(35, 35);
            this.btnPrevious.TabIndex = 3;
            // 
            // btnFirst
            // 
            this.btnFirst.AutoSize = true;
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.Icon = 59538;
            this.btnFirst.Location = new System.Drawing.Point(43, 232);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(35, 35);
            this.btnFirst.TabIndex = 2;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Icon = 59151;
            this.btnEdit.Location = new System.Drawing.Point(409, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(35, 35);
            this.btnEdit.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Icon = 59213;
            this.btnDelete.Location = new System.Drawing.Point(450, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(35, 35);
            this.btnDelete.TabIndex = 0;
            // 
            // pnlDates
            // 
            this.pnlDates.Controls.Add(this.txtDateStart);
            this.pnlDates.Controls.Add(this.txtDatesSeparator);
            this.pnlDates.Controls.Add(this.txtDateEnd);
            this.pnlDates.Location = new System.Drawing.Point(27, 54);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(455, 24);
            this.pnlDates.TabIndex = 12;
            // 
            // txtDatesSeparator
            // 
            this.txtDatesSeparator.AutoSize = true;
            this.txtDatesSeparator.Location = new System.Drawing.Point(42, 0);
            this.txtDatesSeparator.Name = "txtDatesSeparator";
            this.txtDatesSeparator.Size = new System.Drawing.Size(10, 13);
            this.txtDatesSeparator.TabIndex = 11;
            this.txtDatesSeparator.Text = "-";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(495, 446);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(455, 36);
            this.txtCount.TabIndex = 6;
            this.txtCount.Text = "0/0";
            this.txtCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EventsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.pnlEvent);
            this.Name = "EventsPage";
            this.Size = new System.Drawing.Size(950, 520);
            this.pnlEvent.ResumeLayout(false);
            this.pnlEvent.PerformLayout();
            this.pnlDates.ResumeLayout(false);
            this.pnlDates.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.Label iconSoldOut;
        private System.Windows.Forms.Label iconParticipants;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtCreator;
        private System.Windows.Forms.Label txtDateStart;
        private System.Windows.Forms.Label txtTitle;
        private components.IconButton btnEdit;
        private components.IconButton btnDelete;
        private System.Windows.Forms.Label txtIndex;
        private components.IconButton btnFirst;
        private components.IconButton btnPrevious;
        private components.IconButton btnLast;
        private components.IconButton btnNext;
        private System.Windows.Forms.Label txtParticipants;
        private System.Windows.Forms.Label txtDateEnd;
        private System.Windows.Forms.CheckBox chkSold;
        private System.Windows.Forms.FlowLayoutPanel pnlDates;
        private System.Windows.Forms.Label txtDatesSeparator;
        private System.Windows.Forms.Label txtCount;
    }
}