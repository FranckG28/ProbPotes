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
        public Boolean PDFEvent(EventClass evt,Participant part)
        {
            try
            {
                string outFile = Environment.CurrentDirectory + @"\\..\\..\\BilanPDF\\BILAN_" + evt.Title +"_"+part.Name+ ".pdf";
                //CREATION DU DOCUMENT
                Document doc = new Document();
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

                //PAGE

                //HEADER
                Paragraph titre = new Paragraph("Bilan", title);
                titre.Alignment = Element.ALIGN_CENTER;
                doc.Add(titre);

                Paragraph eventName = new Paragraph(evt.Title, pBlue);
                eventName.Alignment = Element.ALIGN_LEFT;
                doc.Add(eventName);

                Paragraph space = new Paragraph("\n");
                doc.Add(space);

                Paragraph debut = new Paragraph("Date de début: "+evt.StartDate.ToString(), pBlackBold);
                debut.Alignment = Element.ALIGN_LEFT;
                debut.IndentationLeft = 10f;
                doc.Add(debut);

                Paragraph fin = new Paragraph("Date de fin: " + evt.EndDate.ToString(), pBlackBold);
                fin.Alignment = Element.ALIGN_LEFT;
                fin.IndentationLeft = 10f;
                doc.Add(fin);

                Paragraph desc = new Paragraph("Description: " + evt.Description.ToString(), pBlackBold);
                desc.Alignment = Element.ALIGN_LEFT;
                desc.IndentationLeft = 10f;
                doc.Add(desc);

                doc.Add(space);
                doc.Add(space);

                //ALGO POUR RECUP LES DEPENSE PAYE ET BENEFICIAIRE
                //ROW DU TAB
                List<string[]> DepensePaye = new List<string[]>();
                List<string[]> DepenseBeneficie = new List<string[]>();
                EventManager em = new EventManager();
                WOWTW wwPart = em.GetWOWTWsPart(evt, part);

                foreach (Expense expense in evt.Expenses.Expenses)
                {
                    if (expense.creatorCode == part.Code)
                    {
                        string[] s = new string[2];
                        s[0] = expense.description;
                        s[1] = expense.sum.ToString();
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
                                s[1] = expense.sum.ToString();
                                DepenseBeneficie.Add(s);
                            }
                        }
                    }
                }

                //PARTICIPANT + NB DE PARTS

                Paragraph participant = new Paragraph("Participant: " + part.Name+" "+part.FirstName, pBlackBold);
                participant.Alignment = Element.ALIGN_LEFT;
                participant.IndentationLeft =20f;
                doc.Add(participant);

                Paragraph nbpart = new Paragraph("Nombre de parts: " + part.Shares, nbPart);
                nbpart.Alignment = Element.ALIGN_LEFT;
                nbpart.IndentationLeft = 20f;
                doc.Add(nbpart);

                doc.Add(space);
                doc.Add(space);
                doc.Add(space);


                //TABLEAU DEPENSE PAYE
                Paragraph titleDepense = new Paragraph("Dépense payé: ", h3);
                participant.Alignment = Element.ALIGN_LEFT;
                doc.Add(titleDepense);

                doc.Add(space);
                doc.Add(space);


                PdfPTable tabPayeur = new PdfPTable(2);
                tabPayeur.WidthPercentage = 75;

                this.addCellToTab("Description", th, blue, tabPayeur);
                this.addCellToTab("Montant", th, blue, tabPayeur);

                int cptCell = 0;
                foreach(String[] valeur in DepensePaye)
                {
                    foreach(string info in valeur)
                    {
                        PdfPCell cell;
                        if (cptCell % 2 == 0)
                        {
                            cell = new PdfPCell(new Phrase(info));

                        }
                        else
                        {
                            cell = new PdfPCell(new Phrase(info+" €"));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;

                        }
                        cptCell++;
                        cell.BackgroundColor = gris;
                        cell.Padding = 7;
                        cell.BorderColorBottom = BaseColor.BLACK;
                        tabPayeur.AddCell(cell);

                    }
                }

                doc.Add(tabPayeur);

                doc.Add(space);
                doc.Add(space);

                //TABLEAU DEPENSE BENEFICIARE
                Paragraph titlebeneficiaire = new Paragraph("Dépense bénéficié: ", h3);
                participant.Alignment = Element.ALIGN_LEFT;
                doc.Add(titlebeneficiaire);

                doc.Add(space);
                doc.Add(space);

                PdfPTable tabBeneficiaire = new PdfPTable(2);
                tabBeneficiaire.WidthPercentage = 75;

                this.addCellToTab("Description", th, blue, tabBeneficiaire);
                this.addCellToTab("Montant", th, blue, tabBeneficiaire);


                foreach (Expense expense in evt.Expenses.Expenses)
                {
                    if (expense.creatorCode == part.Code)
                    {
                        string[] s = new string[2];
                        s[0] = expense.description;
                        s[1] = expense.sum.ToString();
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
                                s[1] = expense.sum.ToString();
                                DepenseBeneficie.Add(s);
                            }
                        }
                    }
                }

                cptCell = 0;
                foreach (String[] valeur in DepenseBeneficie)
                {
                    foreach (string info in valeur)
                    {
                        PdfPCell cell;
                        if (cptCell % 2 == 0)
                        {
                            cell = new PdfPCell(new Phrase(info));

                        }
                        else
                        {
                            cell = new PdfPCell(new Phrase(info + " €"));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;

                        }
                        cptCell++;
                        cell.BackgroundColor = gris;
                        cell.Padding = 7;
                        cell.BorderColorBottom = BaseColor.BLACK;
                        tabBeneficiaire.AddCell(cell);

                    }
                }

                doc.Add(tabBeneficiaire);

                doc.Close();
                Process.Start(@"cmd.exe ", @"/c " + outFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void addCellToTab(string str,Font f,BaseColor c,PdfPTable t)
        {
            PdfPCell cell1 = new PdfPCell(new Phrase(str, f));
            cell1.BackgroundColor = c;
            cell1.Padding = 5;
            cell1.BorderColor = c;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            t.AddCell(cell1);
        }
    }
}
