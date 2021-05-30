
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
            this.txtIndex = new System.Windows.Forms.Label();
            this.btnFirst = new ProbPotes.components.IconButton();
            this.btnPrevious = new ProbPotes.components.IconButton();
            this.btnLast = new ProbPotes.components.IconButton();
            this.btnNext = new ProbPotes.components.IconButton();
            this.btnDelete = new ProbPotes.components.IconButton();
            this.btnEdit = new ProbPotes.components.IconButton();
            this.txtTitle = new System.Windows.Forms.Label();
            this.txtDates = new System.Windows.Forms.Label();
            this.txtCreator = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.iconParticipants = new System.Windows.Forms.Label();
            this.iconSoldOut = new System.Windows.Forms.Label();
            this.txtParticipants = new System.Windows.Forms.Label();
            this.txtSoldOn = new System.Windows.Forms.Label();
            this.pnlEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEvent
            // 
            this.pnlEvent.Controls.Add(this.txtSoldOn);
            this.pnlEvent.Controls.Add(this.txtParticipants);
            this.pnlEvent.Controls.Add(this.iconSoldOut);
            this.pnlEvent.Controls.Add(this.iconParticipants);
            this.pnlEvent.Controls.Add(this.txtDescription);
            this.pnlEvent.Controls.Add(this.txtCreator);
            this.pnlEvent.Controls.Add(this.txtDates);
            this.pnlEvent.Controls.Add(this.txtTitle);
            this.pnlEvent.Controls.Add(this.btnEdit);
            this.pnlEvent.Controls.Add(this.btnDelete);
            this.pnlEvent.Location = new System.Drawing.Point(226, 99);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(499, 301);
            this.pnlEvent.TabIndex = 0;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(0, 450);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(950, 36);
            this.txtIndex.TabIndex = 1;
            this.txtIndex.Text = "0/0";
            this.txtIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Location = new System.Drawing.Point(24, 25);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(103, 13);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.Text = "Titre de l\'évènement";
            // 
            // txtDates
            // 
            this.txtDates.AutoSize = true;
            this.txtDates.Location = new System.Drawing.Point(24, 58);
            this.txtDates.Name = "txtDates";
            this.txtDates.Size = new System.Drawing.Size(33, 13);
            this.txtDates.TabIndex = 3;
            this.txtDates.Text = "dates";
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
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(24, 87);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(458, 102);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "Description";
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
            // txtParticipants
            // 
            this.txtParticipants.AutoSize = true;
            this.txtParticipants.Location = new System.Drawing.Point(72, 199);
            this.txtParticipants.Name = "txtParticipants";
            this.txtParticipants.Size = new System.Drawing.Size(62, 13);
            this.txtParticipants.TabIndex = 8;
            this.txtParticipants.Text = "Participants";
            // 
            // txtSoldOn
            // 
            this.txtSoldOn.AutoSize = true;
            this.txtSoldOn.Location = new System.Drawing.Point(72, 238);
            this.txtSoldOn.Name = "txtSoldOn";
            this.txtSoldOn.Size = new System.Drawing.Size(34, 13);
            this.txtSoldOn.TabIndex = 9;
            this.txtSoldOn.Text = "Soldé";
            // 
            // EventsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.Label iconSoldOut;
        private System.Windows.Forms.Label iconParticipants;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtCreator;
        private System.Windows.Forms.Label txtDates;
        private System.Windows.Forms.Label txtTitle;
        private components.IconButton btnEdit;
        private components.IconButton btnDelete;
        private System.Windows.Forms.Label txtIndex;
        private components.IconButton btnFirst;
        private components.IconButton btnPrevious;
        private components.IconButton btnLast;
        private components.IconButton btnNext;
        private System.Windows.Forms.Label txtSoldOn;
        private System.Windows.Forms.Label txtParticipants;
    }
}
