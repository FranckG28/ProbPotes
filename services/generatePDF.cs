using ProbPotes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using ProbPotes.managers;

namespace ProbPotes.services
{
    class GeneratePDF
    {
        public Boolean PDFEvent(EventClass evt, Participant part)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory + @"\\BilanPDF\\"+evt.Title);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string outFile = path+ @"\\BILAN_"+ part.Name+"_"+part.FirstName + ".pdf";
                //CREATION DU DOCUMENT
                Document doc = new Document(PageSize.A4,25f,25f,1f,25f);
                PdfWriter.GetInstance(doc, new FileStream(outFile, FileMode.Create));

                doc.Open();

                //COULEUR
                BaseColor blue = new BaseColor(0, 75, 155);
                BaseColor gris = new BaseColor(240, 240, 240);
                BaseColor blanc = new BaseColor(255, 255, 255);
                BaseColor noir = new BaseColor(0, 0, 0);

                //POLICE D'ECRITURE
                iTextSharp.text.Font title = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 23f, iTextSharp.text.Font.BOLD, blue);
                iTextSharp.text.Font pBlue = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.UNDERLINE, blue);
                iTextSharp.text.Font h3 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.UNDERLINE, blue);
                iTextSharp.text.Font pBlackBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, noir);
                iTextSharp.text.Font nbPart = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9f, iTextSharp.text.Font.BOLD, noir);
                iTextSharp.text.Font pBlack = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.UNDEFINED, noir);
                iTextSharp.text.Font th = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, blanc);
                iTextSharp.text.Font td = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.UNDEFINED, blanc);
                iTextSharp.text.Font response = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLD, noir);


                //PAGE
                Paragraph space = new Paragraph("\n");
                doc.Add(space);
                //HEADER
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Properties.Resources.PDFBG, System.Drawing.Imaging.ImageFormat.Png);
                logo.ScalePercent(25);
                logo.Alignment = Element.ALIGN_CENTER;
                doc.Add(logo);

                doc.Add(space);

                Paragraph eventName = new Paragraph(evt.Title, pBlue);
                eventName.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 30f, iTextSharp.text.Font.BOLD, noir);
                eventName.Alignment = Element.ALIGN_CENTER;
                doc.Add(eventName);


                doc.Add(space);

                Chunk startDate = new Chunk("\t Date de début: ", pBlack);
                doc.Add(startDate);

                Chunk startDateRes = new Chunk(evt.StartDate.ToString() + "\n", response);
                doc.Add(startDateRes);

                Chunk endDate = new Chunk("\t Date de fin: ", pBlack);
                doc.Add(endDate);

                Chunk endDateRes = new Chunk(evt.EndDate.ToString()+"\n", response);
                doc.Add(endDateRes);

                Chunk desc = new Chunk("\t Description: ", pBlack);
                doc.Add(desc);

                Chunk descRes = new Chunk(evt.Description + "\n", response);
                doc.Add(descRes);

                doc.Add(space);
                doc.Add(space);

                //ALGO POUR RECUP LES DEPENSE PAYE ET BENEFICIAIRE
                //ROW DU TAB
                List<string[]> DepensePaye = new List<string[]>();
                List<string[]> DepenseBeneficie = new List<string[]>();

                foreach (Expense expense in evt.Expenses.Expenses)
                {
                    if (expense.creatorCode == part.Code)
                    {
                        string[] s = new string[2];
                        s[0] = expense.description;
                        s[1] = expense.sum.ToString()+" €";
                        DepensePaye.Add(s);
                    }
                    else
                    {
                        foreach (int i in expense.recipients)
                        {
                            if (i == part.Code)
                            {
                                string[] s = new string[2];
                                s[0] = expense.description;
                                s[1] = expense.sum.ToString()+" €";
                                DepenseBeneficie.Add(s);
                            }
                        }
                    }
                }

                //PARTICIPANT + NB DE PARTS

                Chunk name = new Chunk("\t Participant: ", pBlack);
                doc.Add(name);

                Chunk nameRes = new Chunk(part.Name+" "+part.FirstName + "\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD, noir));
                doc.Add(nameRes);

                Chunk nombrepart = new Chunk("\t Nombre de parts: ", pBlack);
                doc.Add(nombrepart);

                Chunk nombrepartRes = new Chunk(part.Shares.ToString()+ "\n", response);
                doc.Add(nombrepartRes);

                doc.Add(space);
                doc.Add(space);
                doc.Add(space);


                //TABLEAU DEPENSE PAYE
                int cptIsEmpty = 0;


                Paragraph titleDepense = new Paragraph("Dépenses payées: ", h3);
                doc.Add(titleDepense);

                doc.Add(space);
                doc.Add(space);


                PdfPTable tabPayeur = new PdfPTable(3);
                tabPayeur.WidthPercentage = 75;

                this.addThToTab("Description", th, blue, tabPayeur,2);
                this.addThToTab("Montant", th, blue, tabPayeur,1);

                int cptCell = 0;
                foreach (String[] valeur in DepensePaye)
                {
                    foreach (string info in valeur)
                    {
                        if (cptCell % 2 == 0)
                        {
                            this.addCellToTab(info, gris, tabPayeur, 2);
                        }
                        else
                        {
                            this.addCellToTab(info, gris,tabPayeur,1);
                        }
                        cptIsEmpty++;
                    }
                }
                this.tabIsEmpty(cptIsEmpty, tabPayeur, gris);
                cptIsEmpty = 0;

                doc.Add(tabPayeur);

                doc.Add(space);
                doc.Add(space);

                //TABLEAU DEPENSE BENEFICIARE
                Paragraph titlebeneficiaire = new Paragraph("Dépenses bénéficiées: ", h3);
                doc.Add(titlebeneficiaire);

                doc.Add(space);
                doc.Add(space);

                PdfPTable tabBeneficiaire = new PdfPTable(3);
                tabBeneficiaire.WidthPercentage = 75;

                this.addThToTab("Description", th, blue, tabBeneficiaire,2);
                this.addThToTab("Montant", th, blue, tabBeneficiaire,1);

                cptCell = 0;
                foreach (String[] valeur in DepenseBeneficie)
                {
                    foreach (string info in valeur)
                    {
                        if (cptCell % 2 == 0)
                        {
                            this.addCellToTab(info, gris, tabBeneficiaire, 2);
                        }
                        else
                        {
                            this.addCellToTab(info, gris, tabBeneficiaire, 1);
                        }
                        cptIsEmpty++;
                    }
                }
                this.tabIsEmpty(cptIsEmpty, tabBeneficiaire, gris);
                cptIsEmpty = 0;

                doc.Add(tabBeneficiaire);

                doc.Add(space);
                doc.Add(space);
                doc.Add(space);
                doc.Add(space);
                doc.Add(space);

                //TABLEAU GIVETO

                EventManager em = new EventManager();
                WOWTW wwPart = em.GetWOWTWsPart(evt, part);
                ParticipantManager pm = new ParticipantManager();

                Paragraph titleGiveTo = new Paragraph(part.Name+" "+part.FirstName+" doit payer à:", h3);
                doc.Add(titleGiveTo);

                doc.Add(space);
                doc.Add(space);

                PdfPTable tabGiveTo = new PdfPTable(3);
                tabGiveTo.WidthPercentage = 75;

                this.addThToTab("Nom", th, blue, tabGiveTo,2);
                this.addThToTab("Montant", th, blue, tabGiveTo,1);

                foreach (KeyValuePair<int,decimal> val in wwPart.GiveTo)
                {
                    Participant p = pm.GetParticipant(val.Key);
                    this.addCellToTab(p.Name.ToString() + " " + p.FirstName.ToString(), gris, tabGiveTo, 2);

                    this.addCellToTab(val.Value.ToString() + " €", gris, tabGiveTo, 1);
                    cptIsEmpty++;
                }
                this.tabIsEmpty(cptIsEmpty, tabGiveTo, gris);
                cptIsEmpty = 0;

                doc.Add(tabGiveTo);

                doc.Add(space);
                doc.Add(space);

                //TABLEAU RECEIVEFROM

                Paragraph titleReceiveFrom = new Paragraph(part.Name + " " + part.FirstName + " doit recevoir de:", h3);
                doc.Add(titleReceiveFrom);

                doc.Add(space);
                doc.Add(space);

                PdfPTable tabReceiveFrom = new PdfPTable(3);
                tabReceiveFrom.WidthPercentage = 75;

                this.addThToTab("Nom", th, blue, tabReceiveFrom,2);
                this.addThToTab("Montant", th, blue, tabReceiveFrom,1);

                foreach (KeyValuePair<int, decimal> val in wwPart.ReceiveFrom)
                {
                    Participant p = pm.GetParticipant(val.Key);
                    this.addCellToTab(p.Name.ToString() + " " + p.FirstName.ToString(), gris, tabReceiveFrom, 2);

                    this.addCellToTab(val.Value.ToString() + " €", gris, tabReceiveFrom, 1);
                    cptIsEmpty++;
                }
                this.tabIsEmpty(cptIsEmpty, tabReceiveFrom, gris);
                cptIsEmpty = 0;

                doc.Add(tabReceiveFrom);


                doc.Close();
                Process.Start(@"cmd.exe ", @"/c " + outFile);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Erreur génération PDF : " + e.ToString());
                return false;
            }
        }

        private void addThToTab(string str, Font f, BaseColor c, PdfPTable t,int colSpan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(str, f));
            cell.BackgroundColor = c;
            cell.Colspan = colSpan;
            cell.Padding = 5;
            cell.BorderColor = c;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            t.AddCell(cell);
        }

        private void addCellToTab(string str, BaseColor c, PdfPTable t, int colSpan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(str));
            cell.BackgroundColor = c;
            cell.Colspan = colSpan;
            cell.Padding = 7;
            cell.BorderColorBottom = BaseColor.BLACK;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            t.AddCell(cell);
        }

        private void tabIsEmpty(int cpt,PdfPTable t,BaseColor c)
        {
            if (cpt == 0)
            {
                PdfPCell cell = new PdfPCell(new Phrase("Aucune ligne trouvée :("));
                cell.BackgroundColor = c;
                cell.Colspan = 3;
                cell.Padding = 7;
                cell.BorderColorBottom = BaseColor.BLACK;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                t.AddCell(cell);
            }
        }
    }
}


