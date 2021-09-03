using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Dominio.RelatorioModule;
using System;
using System.Collections;
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

        public GeradorPdf()
        {

        }

        public void GerarPdf(Relatorio relatorio)
        {
            this.relatorio = relatorio;
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(3, 2, 3, 2);
            doc.AddCreationDate();

            string caminho = @"..\..\..\Arquivos\relatorio.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc,
                new FileStream(caminho, FileMode.Create));

            doc.Open();

            PdfPTable tabela = new PdfPTable(2);

            Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 15);

            List<Paragraph> paragrafos = new List<Paragraph>();

            paragrafos.Add(new Paragraph("Plano: ", fonte));
            paragrafos.Add(new Paragraph("Dias Alugados: ", fonte));
            paragrafos.Add(new Paragraph("Kms Alugados: ", fonte));
            paragrafos.Add(new Paragraph("Taxa Diária total: R$", fonte));
            paragrafos.Add(new Paragraph("Taxa de Quilometragem total: R$", fonte));
            paragrafos.Add(new Paragraph("Taxa de Quilometragem Extrapolada Total: R$", fonte));
            paragrafos.Add(new Paragraph("Subtotal dos planos: R$", fonte));
            paragrafos.Add(new Paragraph("Subtotal dos adicionais por dia: R$", fonte));
            paragrafos.Add(new Paragraph("Subtotal dos adicionais fixos: R$", fonte));
            paragrafos.Add(new Paragraph("Tipo de combustível: ", fonte));
            paragrafos.Add(new Paragraph("Litros para encher: ", fonte));
            paragrafos.Add(new Paragraph("Valor para abastecer: R$", fonte));
            paragrafos.Add(new Paragraph("Valor descontado com cupom: R$", fonte));
            paragrafos.Add(new Paragraph("Total a pagar: R$", fonte));

            CriarCelulasPDF(tabela, paragrafos);


            doc.Add(tabela);
            doc.Close();
        }


        private void AdicionarPropriedades(string propriedade, PdfPTable tabela, PdfPCell celulaPrincipal)
        {
            tabela.AddCell(celulaPrincipal);
            Phrase frase = new Phrase(propriedade);
            var celula = new PdfPCell(frase);
            tabela.AddCell(celula);
        }

        public void CriarCelulasPDF(PdfPTable tabela, List<Paragraph> paragrafos)
        {
            List<string> listaPropriedades = new List<string>()
            {
                {relatorio.Plano },
                {relatorio.DiasAlugados.ToString() },
                {relatorio.KmsAlugados.ToString() },
                {relatorio.TaxaDiariaTotal.ToString() },
                {relatorio.TaxaKmTotal.ToString() },
                {relatorio.TaxaKmExtrapoladadaTotal.ToString() },
                {relatorio.SubTotalPlanos.ToString() },
                {relatorio.SubTotalAdicionaisDia.ToString() },
                {relatorio.SubTotalAdicionaisFixos.ToString() },
                {relatorio.TipoCombustivel },
                {relatorio.LitrosParaEncher.ToString()},
                {relatorio.ValorParaAbastecer.ToString()},
                {relatorio.ValorDecontadoCupom.ToString()},
                {relatorio.TotalAPagar.ToString()}
            };


            for (int i = 0; i < paragrafos.Count; i++)
            {
                Paragraph item = paragrafos[i];
                var celula = new PdfPCell();
                celula.AddElement(item);

                AdicionarPropriedades(listaPropriedades[i], tabela, celula);
            }


        }

    }
}
