using iText.Kernel.Pdf;
using LocadoraDeVeiculos.Dominio.RelatorioModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font;

namespace LocadoraDeVeiculos.Servicos.PDFModule
{
    public class GeradorPdf
    {
        Relatorio relatorio = null;

        public GeradorPdf()
        {

        }

        public string GerarPdf(Relatorio relatorio)
        {
            this.relatorio = relatorio;
            string nomeArquivo = GerarNomeUnico();

            string caminho = $"..\\..\\..\\..\\Arquivos\\{nomeArquivo}";

            using (PdfWriter writer = new PdfWriter(caminho, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDoc = new PdfDocument(writer);

                Document doc = new Document(pdfDoc, PageSize.A4);

                doc.SetMargins(25f, 25f, 25f, 25f);

                List<Paragraph> paragrafos = new List<Paragraph>();

                GerarParagrafos(relatorio, doc);

                doc.Close();

            }

            return nomeArquivo;
        }

        private string GerarNomeUnico()
        {
            return $"relatorio-{DateTime.Now:yyyyMMddHHmmssFFFF}.pdf";
        }

        private static void GerarParagrafos(Relatorio relatorio, Document doc)
        {
            string nome = relatorio.locacao.Condutor.PessoaJuridica == null ?
                relatorio.locacao.Condutor.ToString() : relatorio.locacao.Condutor.PessoaJuridica.ToString();

            string documentoLocatario = relatorio.locacao.Condutor.PessoaJuridica == null ?
                relatorio.locacao.Condutor.CPF : relatorio.locacao.Condutor.PessoaJuridica.Cnpj;

            string valorCupom = (relatorio.CupomEstaValido == false) ? "Nenhum cupom aplicado" : "R$" + relatorio.ValorDecontadoCupom.ToString();

            PdfFont fonte = PdfFontFactory.CreateFont(FontConstants.HELVETICA_BOLD);

            doc.Add(new Paragraph("\n   Locadora Null Team").SetTextAlignment(TextAlignment.CENTER)
                                .SetBold().SetFontSize(20));
            doc.Add(new Paragraph("\n\n- Nome do Locatário/Empresa: " + nome));
            doc.Add(new Paragraph("- Documento do Locatário/Empresa: " + documentoLocatario));
            doc.Add(new Paragraph("\n- Plano: " + relatorio.Plano));
            doc.Add(new Paragraph("\n- Dias Alugados: " + relatorio.DiasAlugados.ToString()));
            doc.Add(new Paragraph("\n- Kms Alugados: " + relatorio.KmsAlugados.ToString()));
            doc.Add(new Paragraph("\n- Taxa Diária total: R$" + relatorio.TaxaDiariaTotal.ToString()));
            doc.Add(new Paragraph("\n- Taxa de Quilometragem total: R$" + relatorio.TaxaKmTotal.ToString()));
            doc.Add(new Paragraph("\n- Taxa de Quilometragem Extrapolada Total: R$" + relatorio.TaxaKmExtrapoladadaTotal.ToString()));
            doc.Add(new Paragraph("\n- Subtotal dos planos: R$" + relatorio.SubTotalPlanos.ToString()));
            doc.Add(new Paragraph("\n- Subtotal dos adicionais por dia: R$" + relatorio.SubTotalAdicionaisDia.ToString()));
            doc.Add(new Paragraph("\n- Subtotal dos adicionais fixos: R$" + relatorio.SubTotalAdicionaisFixos.ToString()));
            doc.Add(new Paragraph("\n- Tipo de combustível: " + relatorio.TipoCombustivel));
            doc.Add(new Paragraph("\n- Litros para encher: " + relatorio.LitrosParaEncher));
            doc.Add(new Paragraph("\n- Valor para abastecer: R$" + relatorio.ValorParaAbastecer.ToString()));
            doc.Add(new Paragraph("\n- Valor descontado com cupom: " + valorCupom));
            doc.Add(new Paragraph("\n- Total a pagar: R$" + relatorio.TotalAPagar.ToString()).SetBold().SetFont(fonte).SetFontSize(15));
        }
        

    }
}