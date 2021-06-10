using ProbPotes.components;
using ProbPotes.components.participants;
using ProbPotes.managers;
using ProbPotes.models;
using ProbPotes.pages.reports;
using ProbPotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProbPotes.pages
{
    public partial class ReportsPage : UserControl
    {

        EventClass SelectedEvent;

        public ReportsPage()
        {
            InitializeComponent();

            // Polices et couleurs 

            List<Label> subTitles = new List<Label>() { txtDatesSeparator, txtDateStart, txtDateEnd };
            foreach (Label lbl in subTitles)
            {
                lbl.Font = new Font(Fonts.book, 12);
                lbl.ForeColor = Colors.blue;
            }

            txtTitle.Font = new Font(Fonts.bold, 16);
            txtTitle.ForeColor = Colors.blue;

            List<Label> labels = new List<Label>() { txtDescription, txtParticipants, txtHelp, txtDetails };
            foreach (Label lbl in labels)
            {
                lbl.ForeColor = Colors.black;
                lbl.Font = new Font(Fonts.book, 11);
            }

            List<Label> tips = new List<Label>() { txtSoldTip, txtDetails };
            foreach(Label lbl in tips)
            {
                lbl.Font = new Font(Fonts.medium, 11);
                lbl.ForeColor = Colors.grey;
            }
            

            List<Panel> lines = new List<Panel>() { pnlLine1, pnlLine2 };
            foreach(Panel pnl in lines)
            {
                pnl.Size = new Size(pnl.Width, 1);
                pnl.BackColor = Colors.grey;
            }

            // Icones
            icon.Text = char.ConvertFromUtf32(59271);
            iconParticipants.Text = char.ConvertFromUtf32(59158);

            // Boutton
            btnQDQAQ.Font = new Font(Fonts.medium, 14);
            
            // Affichage des évènements
            foreach (EventClass e in DatabaseManager.Events.Events)
            {
                ProbPotesSelector ctrl = new ProbPotesSelector(e.Title, e);
                ctrl.action = ShowReport;
                pnlEvents.Controls.Add(ctrl);
                if (SelectedEvent == null)
                {
                    ShowReport(e);
                }
            }

            // Si il n'y a aucun évènement, afficher un message
            if (pnlEvents.Controls.Count == 0)
            {
                panel1.Controls.Clear();
                Label lbl = new Label();
                lbl.Text = "Aucun évènement soldé";
                lbl.Font = new Font(Fonts.book, 16);
                lbl.ForeColor = Colors.black;
                lbl.AutoSize = false;
                lbl.Width = panel1.Width;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Location = new Point(0, 50);

                Label lbl2 = new Label();
                lbl2.Text = "Cliquez sur le bouton \" Ajouter \" pour solder un évènement";
                lbl2.Font = new Font(Fonts.regular, 11);
                lbl2.ForeColor = Colors.black;
                lbl2.AutoSize = false;
                lbl2.Width = panel1.Width;
                lbl2.TextAlign = ContentAlignment.MiddleCenter;
                lbl2.Location = new Point(0, 80);
            }
            
        }

        private void ShowReport(Object e)
        {

            // Obtention de l'évènement à afficher
            EventClass eventClass = (EventClass)e;
            SelectedEvent = eventClass;

            // Décocher touts les autres 
            foreach(Control c in pnlEvents.Controls)
            {
                ProbPotesSelector s = (ProbPotesSelector)c;
                s.Selected = eventClass.Code == ((EventClass)s.Value).Code;
            }

            // Changement de l'état selon si l'évènement est soldé ou non
            btnQDQAQ.Text = eventClass.SoldeOn ? "Qui doit quoi à qui ?" : "Solder l'évènement";
            btnQDQAQ.BackColor = eventClass.SoldeOn ? Colors.blue : Colors.lightRed;
            btnQDQAQ.FlatAppearance.MouseOverBackColor = eventClass.SoldeOn ? Colors.green : Colors.red;
            btnQDQAQ.FlatAppearance.MouseDownBackColor = eventClass.SoldeOn ? Colors.blue : Colors.lightRed;

            txtSoldTip.Text = eventClass.SoldeOn ? "L'évènement est soldé" : "Soldez l'évènement pour voir qui doit quoi a qui";

            // Afficher les détails de l'évènement
            txtDateEnd.Text = eventClass.EndDate.ToShortDateString();
            txtDateStart.Text = eventClass.StartDate.ToShortDateString();
            txtDescription.Text = eventClass.Description;
            txtParticipants.Text = DatabaseManager.Participants.GetStringFromList(eventClass.Guests);
            txtTitle.Text = eventClass.Title;

            // Affichage des participants à l'évènement
            pnlGuests.Controls.Clear();
            foreach(int pCode in eventClass.Guests)
            {
                Participant p = DatabaseManager.Participants.GetParticipant(pCode);
                ParticipantSelectionTile tile = new ParticipantSelectionTile();
                tile.Participant = p;
                tile.SelectAction = OpenParticipantDetail;
                tile.IsSelectable = false;
                pnlGuests.Controls.Add(tile);
            }

        }

        private void OpenParticipantDetail(Participant p)
        {
            ProbPotesDialog dialog = new ProbPotesDialog("Bilan de " + p.FirstName + " " + p.Name + " dans " + SelectedEvent.Title, 59897, new ParticipantReportDialog(SelectedEvent, p), this.ParentForm);
            DialogResult result = dialog.Open();
        }

        private void btnQDQAQ_Click(object sender, EventArgs e)
        {

        }
    }
}
