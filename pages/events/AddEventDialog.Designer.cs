
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
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.boxTitle = new System.Windows.Forms.TextBox();
            this.iconTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.iconDate = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtTitle1 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.boxDescription = new System.Windows.Forms.TextBox();
            this.iconDescription = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(413, 158);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(344, 20);
            this.dateEnd.TabIndex = 29;
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(55, 158);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(344, 20);
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
            // iconTitle
            // 
            this.iconTitle.AutoSize = true;
            this.iconTitle.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconTitle.Location = new System.Drawing.Point(5, 81);
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
            this.lblEndDate.Location = new System.Drawing.Point(410, 134);
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
            this.iconDate.Location = new System.Drawing.Point(6, 156);
            this.iconDate.Name = "iconDate";
            this.iconDate.Size = new System.Drawing.Size(47, 19);
            this.iconDate.TabIndex = 20;
            this.iconDate.Text = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtTitle1
            // 
            this.txtTitle1.AutoSize = true;
            this.txtTitle1.Location = new System.Drawing.Point(7, 10);
            this.txtTitle1.Name = "txtTitle1";
            this.txtTitle1.Size = new System.Drawing.Size(141, 13);
            this.txtTitle1.TabIndex = 19;
            this.txtTitle1.Text = "Informations sur l\'évènement";
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
            this.iconDescription.Location = new System.Drawing.Point(6, 232);
            this.iconDescription.Name = "iconDescription";
            this.iconDescription.Size = new System.Drawing.Size(47, 19);
            this.iconDescription.TabIndex = 31;
            this.iconDescription.Text = "label1";
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
    }
}
