
namespace ProbPotes
{
    partial class MainForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelNavbar = new System.Windows.Forms.Panel();
            this.navReports = new ProbPotes.components.NavBarItem();
            this.navParticipants = new ProbPotes.components.NavBarItem();
            this.navEvents = new ProbPotes.components.NavBarItem();
            this.navExpenses = new ProbPotes.components.NavBarItem();
            this.navHome = new ProbPotes.components.NavBarItem();
            this.closeBtn1 = new ProbPotes.components.CloseBtn();
            this.panelView = new System.Windows.Forms.Panel();
            this.panelNavbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavbar
            // 
            this.panelNavbar.BackgroundImage = global::ProbPotes.Properties.Resources.Navbar_Background;
            this.panelNavbar.Controls.Add(this.navReports);
            this.panelNavbar.Controls.Add(this.navParticipants);
            this.panelNavbar.Controls.Add(this.navEvents);
            this.panelNavbar.Controls.Add(this.navExpenses);
            this.panelNavbar.Controls.Add(this.navHome);
            this.panelNavbar.Location = new System.Drawing.Point(0, 0);
            this.panelNavbar.Name = "panelNavbar";
            this.panelNavbar.Size = new System.Drawing.Size(170, 695);
            this.panelNavbar.TabIndex = 6;
            this.panelNavbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panelNavbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.panelNavbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // navReports
            // 
            this.navReports.BackColor = System.Drawing.Color.Transparent;
            this.navReports.Cursor = System.Windows.Forms.Cursors.Default;
            this.navReports.Icon = 59153;
            this.navReports.Location = new System.Drawing.Point(0, 448);
            this.navReports.Name = "navReports";
            this.navReports.Size = new System.Drawing.Size(170, 47);
            this.navReports.TabIndex = 11;
            this.navReports.Title = "Bilans";
            // 
            // navParticipants
            // 
            this.navParticipants.BackColor = System.Drawing.Color.Transparent;
            this.navParticipants.Cursor = System.Windows.Forms.Cursors.Default;
            this.navParticipants.Icon = 59153;
            this.navParticipants.Location = new System.Drawing.Point(0, 396);
            this.navParticipants.Name = "navParticipants";
            this.navParticipants.Size = new System.Drawing.Size(170, 47);
            this.navParticipants.TabIndex = 10;
            this.navParticipants.Title = "Participants";
            // 
            // navEvents
            // 
            this.navEvents.BackColor = System.Drawing.Color.Transparent;
            this.navEvents.Cursor = System.Windows.Forms.Cursors.Default;
            this.navEvents.Icon = 59153;
            this.navEvents.Location = new System.Drawing.Point(0, 344);
            this.navEvents.Name = "navEvents";
            this.navEvents.Size = new System.Drawing.Size(170, 47);
            this.navEvents.TabIndex = 9;
            this.navEvents.Title = "Évènements";
            // 
            // navExpenses
            // 
            this.navExpenses.BackColor = System.Drawing.Color.Transparent;
            this.navExpenses.Cursor = System.Windows.Forms.Cursors.Default;
            this.navExpenses.Icon = 59153;
            this.navExpenses.Location = new System.Drawing.Point(0, 292);
            this.navExpenses.Name = "navExpenses";
            this.navExpenses.Size = new System.Drawing.Size(170, 47);
            this.navExpenses.TabIndex = 8;
            this.navExpenses.Title = "Dépenses";
            // 
            // navHome
            // 
            this.navHome.BackColor = System.Drawing.Color.Transparent;
            this.navHome.Cursor = System.Windows.Forms.Cursors.Default;
            this.navHome.Icon = 59153;
            this.navHome.Location = new System.Drawing.Point(0, 240);
            this.navHome.Name = "navHome";
            this.navHome.Size = new System.Drawing.Size(170, 47);
            this.navHome.TabIndex = 7;
            this.navHome.Title = "Accueil";
            // 
            // closeBtn1
            // 
            this.closeBtn1.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn1.Location = new System.Drawing.Point(1193, 0);
            this.closeBtn1.Name = "closeBtn1";
            this.closeBtn1.Size = new System.Drawing.Size(47, 33);
            this.closeBtn1.TabIndex = 5;
            // 
            // panelView
            // 
            this.panelView.Location = new System.Drawing.Point(232, 45);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(950, 610);
            this.panelView.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1240, 695);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelNavbar);
            this.Controls.Add(this.closeBtn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1240, 695);
            this.MinimumSize = new System.Drawing.Size(1240, 695);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PromPotes";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.panelNavbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private components.CloseBtn closeBtn1;
        private System.Windows.Forms.Panel panelNavbar;
        private components.NavBarItem navHome;
        private components.NavBarItem navParticipants;
        private components.NavBarItem navEvents;
        private components.NavBarItem navExpenses;
        private components.NavBarItem navReports;
        private System.Windows.Forms.Panel panelView;
    }
}

