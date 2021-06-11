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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

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
                lbl.Font = new System.Drawing.Font(Fonts.book, 12);
                lbl.ForeColor = Colors.blue;
            }

            txtTitle.Font = new System.Drawing.Font(Fonts.bold, 16);
            txtTitle.ForeColor = Colors.blue;
            icon.ForeColor = Colors.blue;

            List<Label> labels = new List<Label>() { txtDescription, txtParticipants, txtHelp, txtDetails };
            foreach (Label lbl in labels)
            {
                lbl.ForeColor = Colors.black;
                lbl.Font = new System.Drawing.Font(Fonts.book, 11);
            }

            List<Label> tips = new List<Label>() { txtSoldTip, txtDetails };
            foreach(Label lbl in tips)
            {
                lbl.Font = new System.Drawing.Font(Fonts.medium, 11);
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
            btnQDQAQ.Font = new System.Drawing.Font(Fonts.medium, 14);

            btnExportToPDF.Font = new System.Drawing.Font(Fonts.book, 11);
            btnExportToPDF.BackColor = Colors.blue;
            btnExportToPDF.FlatAppearance.MouseOverBackColor = Colors.green;
            btnExportToPDF.FlatAppearance.MouseDownBackColor = Colors.blue;
            
            // Affichage des évènements
            foreach (EventClass e in DatabaseManager.Events.Events)
            {
                ProbPotesSelector ctrl = new ProbPotesSelector(e.Title, e);
                ctrl.action = ShowReport;
                ctrl.Width = pnlEvents.Width-20;
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
                lbl.Text = "Aucun évènement à afficher";
                lbl.Font = new System.Drawing.Font(Fonts.book, 16);
                lbl.ForeColor = Colors.black;
                lbl.AutoSize = false;
                lbl.Width = panel1.Width;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Location = new Point(0, 50);
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

            btnExportToPDF.Visible = eventClass.SoldeOn;
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
            if (!SelectedEvent.SoldeOn)
            {
                DatabaseManager.Events.CreateReport(SelectedEvent);
                ShowReport(SelectedEvent);
            } else
            {
                ProbPotesDialog dialog = new ProbPotesDialog("Qui doit qui à quoi ? ", 59897, new WOWTWDialog(SelectedEvent), this.ParentForm);
                DialogResult result = dialog.Open();
            }
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            if (!SelectedEvent.SoldeOn)
            {
                DatabaseManager.Events.CreateReport(SelectedEvent);
                ShowReport(SelectedEvent);
            }
            else
            {
                ProbPotesDialog dialog = new ProbPotesDialog("Qui doit qui à quoi ? ", 59897, new WOWTWDialog(SelectedEvent), this.ParentForm);
                DialogResult result = dialog.Open();
            }
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            // TODO: Exporter tous les participants à SelectedEvent en PDF :)
            //MessageBox.Show(Path.Combine(Environment.CurrentDirectory,"\\..\\..\\BilanPDF\\Bilan_.pdf"));
            try
            {
                string outFile = Environment.CurrentDirectory + @"\\..\\..\\BilanPDF\\BILAN_" + SelectedEvent.Title + ".pdf";
                //CREATION DU DOCUMENT
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(outFile, FileMode.Create));

                doc.Open();

                //COULEUR
                BaseColor blue = new BaseColor(0, 75, 155);
                BaseColor gris = new BaseColor(240, 240, 240);
                BaseColor blanc = new BaseColor(255, 255, 255);

                //POLICE D'ECRITURE
                iTextSharp.text.Font h1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20f, iTextSharp.text.Font.BOLD, blue);
                iTextSharp.text.Font h2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.UNDERLINE, blue);
                iTextSharp.text.Font tr = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.UNDEFINED, blanc);

                //PAGE

                //Titre
                Paragraph titre = new Paragraph("Bilan", h1);
                titre.Alignment = Element.ALIGN_CENTER;
                doc.Add(titre);

                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
