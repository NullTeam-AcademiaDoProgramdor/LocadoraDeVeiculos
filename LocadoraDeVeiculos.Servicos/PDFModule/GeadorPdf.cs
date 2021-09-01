using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Dominio.RelatorioModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LocadoraDeVeiculos.Servicos.PDFModule
{
    public class GeradorPdf
    {
        Relatorio relatorio = null;

        public GeradorPdf(Relatorio relatorio)
        {
            this.relatorio = relatorio;
        }

        public void GerarPdf()
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(3, 2, 3, 2);
            doc.AddCreationDate();

            string caminho = @"C:\...\...\" + "\\RelatorioLocacao.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc,
                new FileStream(caminho, FileMode.Create));

            doc.Open();

            PdfPTable table = new PdfPTable(3);           

            Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 22);

            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, fonte);

            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;

            doc.Add(paragrafo);

            doc.Close();
        }
    }
}
