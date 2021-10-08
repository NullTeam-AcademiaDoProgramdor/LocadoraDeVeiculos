using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeículos.Infra.SQL.RequisicaoEmailModule;
using LocadoraDeVeículos.Infra.SQL.LocacaoModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeículos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Servicos.PDFModule;
using LocadoraDeVeículos.Infra.SQL.CupomModule;
using LocadoraDeVeículos.Infra.PDF.PDFModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.RelatorioModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.RequisicaoEmailModule;

namespace LocadoraDeVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoAppServiceTest
    {

        public LocacaoAppServiceTest()
        {
        }

        [TestMethod]
        public void DeveInserir_NovaLocacao()
        {
            Mock<Locacao> locacaoMock = new();

            locacaoMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<LocacaoDao> locacaoDaoMock = new();
            Mock<TaxasEServicosUsadosDao> taxasEServicoUsadosMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object, 
                taxasEServicoUsadosMock.Object,
                null, 
                null,
                null);

            locacaoAppService.InserirNovo(locacaoMock.Object);

            locacaoMock.Verify(x => x.Validar());

            locacaoDaoMock.Verify(x => x.InserirNovo(It.IsAny<Locacao>()));
            taxasEServicoUsadosMock.Verify(x => x.Modificar(It.IsAny<List<TaxaEServico>>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void NaoDeveInserir_SeNaoEstaValido()
        {
            Mock<Locacao> locacaoMock = new();

            locacaoMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<LocacaoDao> locacaoDaoMock = new();
            Mock<TaxasEServicosUsadosDao> taxasEServicoUsadosMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,
                taxasEServicoUsadosMock.Object,
                null,
                null,
                null);

            locacaoAppService.InserirNovo(locacaoMock.Object);

            locacaoMock.Verify(x => x.Validar());
            locacaoDaoMock.Verify(x => x.InserirNovo(It.IsAny<Locacao>()), Times.Never);
            taxasEServicoUsadosMock.Verify(x => x.Modificar(It.IsAny<List<TaxaEServico>>(), It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void DeveDevolver_Locacao_SemCupom()
        {
            Mock<Locacao> locacaoMock = new();
            locacaoMock.Object.Condutor = CriarCondutor();

            locacaoMock.Setup(x => x.ValidarDevolucao()).Returns("ESTA_VALIDO");

            Mock<LocacaoDao> locacaoDaoMock = new();
            Mock<TaxasEServicosUsadosDao> taxasEServicoUsadosMock = new();

            Mock<CupomDao> cupomDaoMock = new();
            Mock<GeradorPDF> geradorPdfMock = new();

            Mock<IEmailAppService> emailAppServiceMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object, 
                taxasEServicoUsadosMock.Object,
                cupomDaoMock.Object,
                geradorPdfMock.Object,
                emailAppServiceMock.Object);

            locacaoAppService.Devolver(It.IsAny<int>(), locacaoMock.Object, false);

            locacaoMock.Verify(x => x.ValidarDevolucao());

            cupomDaoMock.Verify(x => x.EditarQtdUsos(It.IsAny<Cupom>()), Times.Never);
            locacaoDaoMock.Verify(x => x.Devolver(It.IsAny<int>(), It.IsAny<Locacao>()));

            geradorPdfMock.Verify(x => x.GerarPdf(It.IsAny<Relatorio>()));
            emailAppServiceMock.Verify(x => x.AdicionarEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()));

        }

        [TestMethod]
        public void NaoDeveDevolver_Locacao_SemCupom()
        {
            Mock<Locacao> locacaoMock = new();
            locacaoMock.Object.Condutor = CriarCondutor();

            locacaoMock.Setup(x => x.ValidarDevolucao()).Returns("NAO_ESTA_VALIDO");

            Mock<LocacaoDao> locacaoDaoMock = new();
            Mock<TaxasEServicosUsadosDao> taxasEServicoUsadosMock = new();

            Mock<CupomDao> cupomDaoMock = new();
            Mock<GeradorPDF> geradorPdfMock = new();

            Mock<IEmailAppService> emailAppServiceMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,
                taxasEServicoUsadosMock.Object,
                cupomDaoMock.Object,
                geradorPdfMock.Object,
                emailAppServiceMock.Object);

            locacaoAppService.Devolver(It.IsAny<int>(), locacaoMock.Object, false);

            locacaoMock.Verify(x => x.ValidarDevolucao());

            cupomDaoMock.Verify(x => x.EditarQtdUsos(It.IsAny<Cupom>()), Times.Never);
            locacaoDaoMock.Verify(x => x.Devolver(It.IsAny<int>(), It.IsAny<Locacao>()), Times.Never);

            geradorPdfMock.Verify(x => x.GerarPdf(It.IsAny<Relatorio>()), Times.Never);
            emailAppServiceMock.Verify(x => x.AdicionarEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Never);

        }

        [TestMethod]
        public void DeveDevolver_Locacao_ComCupom()
        {
            Mock<Locacao> locacaoMock = new();
            locacaoMock.Object.Condutor = CriarCondutor();
            locacaoMock.Object.Cupom = CriarCupom();

            locacaoMock.Setup(x => x.ValidarDevolucao()).Returns("ESTA_VALIDO");

            Mock<LocacaoDao> locacaoDaoMock = new();
            Mock<TaxasEServicosUsadosDao> taxasEServicoUsadosMock = new();

            Mock<CupomDao> cupomDaoMock = new();
            Mock<GeradorPDF> geradorPdfMock = new();


            Mock<IEmailAppService> emailAppServiceMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,
                taxasEServicoUsadosMock.Object,
                cupomDaoMock.Object,
                geradorPdfMock.Object,
                emailAppServiceMock.Object);

            locacaoAppService.Devolver(It.IsAny<int>(), locacaoMock.Object, true);

            locacaoMock.Verify(x => x.ValidarDevolucao());

            cupomDaoMock.Verify(x => x.EditarQtdUsos(It.IsAny<Cupom>()));
            locacaoDaoMock.Verify(x => x.Devolver(It.IsAny<int>(), It.IsAny<Locacao>()));

            geradorPdfMock.Verify(x => x.GerarPdf(It.IsAny<Relatorio>()));
            emailAppServiceMock.Verify(x => x.AdicionarEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()));

        }

        [TestMethod]
        public void DeveEditar_Locacao()
        {
            Mock<Locacao> locacaoMock = new();

            locacaoMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<LocacaoDao> locacaoDaoMock = new();
            Mock<TaxasEServicosUsadosDao> taxasEServicoUsadosMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,
                taxasEServicoUsadosMock.Object,
                null,
                null,
                null);

            locacaoAppService.Editar(It.IsAny<int>(), locacaoMock.Object);

            locacaoMock.Verify(x => x.Validar());

            locacaoDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<Locacao>()));
            taxasEServicoUsadosMock.Verify(x => x.Modificar(It.IsAny<List<TaxaEServico>>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void DeveEditar_LocacaoKmRegistrada()
        {
            Mock<Locacao> locacaoMock = new();

            locacaoMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<LocacaoDao> locacaoDaoMock = new();
            Mock<TaxasEServicosUsadosDao> taxasEServicoUsadosMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,
                taxasEServicoUsadosMock.Object,
                null,
                null,
                null);

            locacaoAppService.EditarKmRegistrada(locacaoMock.Object);

            locacaoMock.Verify(x => x.Validar());

            locacaoDaoMock.Verify(x => x.EditarKmRegistrada(It.IsAny<Locacao>()));
        }

        private static Cupom CriarCupom()
        {
            return new Cupom("123", new Parceiro("Jose"), "porcentagem", 100, 10, DateTime.Now, 10);
        }

     
        private PessoaFisica CriarCondutor()
        {
            PessoaFisica condutor = new PessoaFisica("Matheus", "123.456.789-02",
                "12.098.098-02", "123456789123", new DateTime(2022, 02, 20),
                "(49)000000000", "Lagi", null, "aaaaa@gmail.com");
            return condutor;
        }
    }
}
