
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
            this.txtTitle = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.iconParticipants = new System.Windows.Forms.Label();
            this.lblParticipants = new System.Windows.Forms.Label();
            this.chkSold = new System.Windows.Forms.CheckBox();
            this.pnlDates = new System.Windows.Forms.FlowLayoutPanel();
            this.txtDateStart = new System.Windows.Forms.Label();
            this.txtDatesSeparator = new System.Windows.Forms.Label();
            this.txtDateEnd = new System.Windows.Forms.Label();
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.pnlParticipants = new System.Windows.Forms.FlowLayoutPanel();
            this.iconCreator = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.Label();
            this.pnlCreator = new System.Windows.Forms.Panel();
            this.btnLast = new ProbPotes.components.IconButton();
            this.btnNext = new ProbPotes.components.IconButton();
            this.btnPrevious = new ProbPotes.components.IconButton();
            this.btnFirst = new ProbPotes.components.IconButton();
            this.participantCreator = new ProbPotes.components.participants.ParticipantSelectionTile();
            this.btnEdit = new ProbPotes.components.IconButton();
            this.pnlDates.SuspendLayout();
            this.pnlEvent.SuspendLayout();
            this.pnlCreator.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Location = new System.Drawing.Point(26, 55);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(103, 13);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.Text = "Titre de l\'évènement";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Location = new System.Drawing.Point(63, 27);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(47, 13);
            this.lblCreator.TabIndex = 4;
            this.lblCreator.Text = "Créateur";
            this.lblCreator.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(27, 135);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(851, 55);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "Description";
            // 
            // iconParticipants
            // 
            this.iconParticipants.AutoSize = true;
            this.iconParticipants.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconParticipants.Location = new System.Drawing.Point(353, 26);
            this.iconParticipants.Name = "iconParticipants";
            this.iconParticipants.Size = new System.Drawing.Size(47, 19);
            this.iconParticipants.TabIndex = 6;
            this.iconParticipants.Text = "label1";
            this.iconParticipants.Click += new System.EventHandler(this.iconParticipants_Click);
            // 
            // lblParticipants
            // 
            this.lblParticipants.AutoSize = true;
            this.lblParticipants.Location = new System.Drawing.Point(392, 27);
            this.lblParticipants.Name = "lblParticipants";
            this.lblParticipants.Size = new System.Drawing.Size(38, 13);
            this.lblParticipants.TabIndex = 8;
            this.lblParticipants.Text = "Invités";
            this.lblParticipants.Click += new System.EventHandler(this.lblParticipants_Click);
            // 
            // chkSold
            // 
            this.chkSold.AutoSize = true;
            this.chkSold.Enabled = false;
            this.chkSold.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSold.Location = new System.Drawing.Point(29, 203);
            this.chkSold.Name = "chkSold";
            this.chkSold.Size = new System.Drawing.Size(59, 18);
            this.chkSold.TabIndex = 11;
            this.chkSold.Text = "Soldé";
            this.chkSold.UseVisualStyleBackColor = true;
            // 
            // pnlDates
            // 
            this.pnlDates.Controls.Add(this.txtDateStart);
            this.pnlDates.Controls.Add(this.txtDatesSeparator);
            this.pnlDates.Controls.Add(this.txtDateEnd);
            this.pnlDates.Location = new System.Drawing.Point(25, 99);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(852, 24);
            this.pnlDates.TabIndex = 12;
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
            // txtDatesSeparator
            // 
            this.txtDatesSeparator.AutoSize = true;
            this.txtDatesSeparator.Location = new System.Drawing.Point(42, 0);
            this.txtDatesSeparator.Name = "txtDatesSeparator";
            this.txtDatesSeparator.Size = new System.Drawing.Size(10, 13);
            this.txtDatesSeparator.TabIndex = 11;
            this.txtDatesSeparator.Text = "-";
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
            // pnlEvent
            // 
            this.pnlEvent.BackColor = System.Drawing.Color.Transparent;
            this.pnlEvent.Controls.Add(this.pnlCreator);
            this.pnlEvent.Controls.Add(this.pnlDates);
            this.pnlEvent.Controls.Add(this.chkSold);
            this.pnlEvent.Controls.Add(this.txtDetails);
            this.pnlEvent.Controls.Add(this.txtDescription);
            this.pnlEvent.Controls.Add(this.txtTitle);
            this.pnlEvent.Controls.Add(this.btnEdit);
            this.pnlEvent.Location = new System.Drawing.Point(0, 0);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(947, 506);
            this.pnlEvent.TabIndex = 0;
            // 
            // pnlParticipants
            // 
            this.pnlParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParticipants.AutoScroll = true;
            this.pnlParticipants.Location = new System.Drawing.Point(357, 48);
            this.pnlParticipants.Name = "pnlParticipants";
            this.pnlParticipants.Size = new System.Drawing.Size(582, 145);
            this.pnlParticipants.TabIndex = 14;
            // 
            // iconCreator
            // 
            this.iconCreator.AutoSize = true;
            this.iconCreator.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconCreator.Location = new System.Drawing.Point(23, 26);
            this.iconCreator.Name = "iconCreator";
            this.iconCreator.Size = new System.Drawing.Size(47, 19);
            this.iconCreator.TabIndex = 13;
            this.iconCreator.Text = "label1";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(159, 204);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(743, 27);
            this.txtDetails.TabIndex = 8;
            this.txtDetails.Text = "details";
            this.txtDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(220, 512);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(254, 36);
            this.txtIndex.TabIndex = 1;
            this.txtIndex.Text = "0/0";
            this.txtIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(467, 512);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(263, 36);
            this.txtCount.TabIndex = 6;
            this.txtCount.Text = "0/0";
            this.txtCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCreator
            // 
            this.pnlCreator.Controls.Add(this.lblParticipants);
            this.pnlCreator.Controls.Add(this.participantCreator);
            this.pnlCreator.Controls.Add(this.iconParticipants);
            this.pnlCreator.Controls.Add(this.pnlParticipants);
            this.pnlCreator.Controls.Add(this.lblCreator);
            this.pnlCreator.Controls.Add(this.iconCreator);
            this.pnlCreator.Location = new System.Drawing.Point(2, 307);
            this.pnlCreator.Name = "pnlCreator";
            this.pnlCreator.Size = new System.Drawing.Size(942, 196);
            this.pnlCreator.TabIndex = 16;
            // 
            // btnLast
            // 
            this.btnLast.AutoSize = true;
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.Icon = 59539;
            this.btnLast.Location = new System.Drawing.Point(863, 512);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(35, 35);
            this.btnLast.TabIndex = 5;
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Icon = 59178;
            this.btnNext.Location = new System.Drawing.Point(773, 512);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 35);
            this.btnNext.TabIndex = 4;
            // 
            // btnPrevious
            // 
            this.btnPrevious.AutoSize = true;
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Icon = 59179;
            this.btnPrevious.Location = new System.Drawing.Point(129, 512);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(35, 35);
            this.btnPrevious.TabIndex = 3;
            // 
            // btnFirst
            // 
            this.btnFirst.AutoSize = true;
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.Icon = 59538;
            this.btnFirst.Location = new System.Drawing.Point(39, 512);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(35, 35);
            this.btnFirst.TabIndex = 2;
            // 
            // participantCreator
            // 
            this.participantCreator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.participantCreator.Location = new System.Drawing.Point(27, 51);
            this.participantCreator.Name = "participantCreator";
            this.participantCreator.Selected = false;
            this.participantCreator.Size = new System.Drawing.Size(285, 59);
            this.participantCreator.TabIndex = 15;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Icon = 59151;
            this.btnEdit.Location = new System.Drawing.Point(875, 55);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(35, 35);
            this.btnEdit.TabIndex = 1;
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
            this.Size = new System.Drawing.Size(950, 559);
            this.pnlDates.ResumeLayout(false);
            this.pnlDates.PerformLayout();
            this.pnlEvent.ResumeLayout(false);
            this.pnlEvent.PerformLayout();
            this.pnlCreator.ResumeLayout(false);
            this.pnlCreator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private components.IconButton btnEdit;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label iconParticipants;
        private System.Windows.Forms.Label lblParticipants;
        private System.Windows.Forms.CheckBox chkSold;
        private System.Windows.Forms.FlowLayoutPanel pnlDates;
        private System.Windows.Forms.Label txtDateStart;
        private System.Windows.Forms.Label txtDatesSeparator;
        private System.Windows.Forms.Label txtDateEnd;
        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.Label txtIndex;
        private components.IconButton btnFirst;
        private components.IconButton btnPrevious;
        private components.IconButton btnNext;
        private components.IconButton btnLast;
        private System.Windows.Forms.Label txtCount;
        private System.Windows.Forms.Label iconCreator;
        private System.Windows.Forms.FlowLayoutPanel pnlParticipants;
        private System.Windows.Forms.Label txtDetails;
        private components.participants.ParticipantSelectionTile participantCreator;
        private System.Windows.Forms.Panel pnlCreator;
    }
}
