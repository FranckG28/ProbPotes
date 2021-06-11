using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProbPotes.models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ProbPotes.services
{
    class GeneratePDF
    {
        public Boolean PDFEvent(EventClass evt)
        {
            // TODO: Exporter tous les participants à SelectedEvent en PDF :)
            //MessageBox.Show(Path.Combine(Environment.CurrentDirectory,"\\..\\..\\BilanPDF\\Bilan_.pdf"));
            try
            {
                string outFile = Environment.CurrentDirectory + @"\\..\\..\\BilanPDF\\BILAN_" + evt.Title + ".pdf";
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
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Boolean PDFParticipant(Participant part)
        {
            return false;
        }
    }
}
