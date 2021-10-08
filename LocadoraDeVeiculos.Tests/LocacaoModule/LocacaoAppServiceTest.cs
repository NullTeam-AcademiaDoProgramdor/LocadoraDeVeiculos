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
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.AutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.CupomModule;

namespace LocadoraDeVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoAppServiceTest
    {
        private readonly DBLocadoraContext db;

        public LocacaoAppServiceTest(DBLocadoraContext db)
        {
            this.db = db;
        }

        [TestMethod]
        public void DeveInserir_NovaLocacao()
        {
            Mock<Locacao> locacaoMock = new();

            locacaoMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<LocacaoORMDao> locacaoDaoMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,  
                null,
                null, 
                null,
                null,
                db);

            locacaoAppService.InserirNovo(locacaoMock.Object);

            locacaoMock.Verify(x => x.Validar());

            locacaoDaoMock.Verify(x => x.InserirNovo(It.IsAny<Locacao>()));
        }

        [TestMethod]
        public void NaoDeveInserir_SeNaoEstaValido()
        {
            Mock<Locacao> locacaoMock = new();

            locacaoMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<LocacaoORMDao> locacaoDaoMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,                
                null,
                null,
                null,
                null,
                db);

            locacaoAppService.InserirNovo(locacaoMock.Object);

            locacaoMock.Verify(x => x.Validar());
            locacaoDaoMock.Verify(x => x.InserirNovo(It.IsAny<Locacao>()), Times.Never);
        }

        [TestMethod]
        public void DeveDevolver_Locacao_SemCupom()
        {
            Mock<Locacao> locacaoMock = new();
            locacaoMock.Object.Condutor = CriarCondutor();

            locacaoMock.Setup(x => x.ValidarDevolucao()).Returns("ESTA_VALIDO");

            Mock<LocacaoORMDao> locacaoDaoMock = new();

            Mock<CupomORMDao> cupomDaoMock = new();
            Mock<GeradorPDF> geradorPdfMock = new();
            Mock<AutomovelORMDao> automovelDao = new();

            Mock<IEmailAppService> emailAppServiceMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object, 
                cupomDaoMock.Object,
                automovelDao.Object,
                geradorPdfMock.Object,
                emailAppServiceMock.Object,
                db);

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

            Mock<LocacaoORMDao> locacaoDaoMock = new();

            Mock<CupomORMDao> cupomDaoMock = new();
            Mock<GeradorPDF> geradorPdfMock = new();
            Mock<AutomovelORMDao> automovelDao = new();

            Mock<IEmailAppService> emailAppServiceMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,
                cupomDaoMock.Object,
                automovelDao.Object,
                geradorPdfMock.Object,
                emailAppServiceMock.Object,
                db);

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

            Mock<LocacaoORMDao> locacaoDaoMock = new();

            Mock<CupomORMDao> cupomDaoMock = new();
            Mock<GeradorPDF> geradorPdfMock = new();
            Mock<AutomovelORMDao> automovelDao = new();

            Mock<IEmailAppService> emailAppServiceMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,
                cupomDaoMock.Object,
                automovelDao.Object,
                geradorPdfMock.Object,
                emailAppServiceMock.Object,
                db);

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

            Mock<LocacaoORMDao> locacaoDaoMock = new();

            LocacaoAppService locacaoAppService = new(
                locacaoDaoMock.Object,
                null,
                null,
                null,
                null,
                db);

            locacaoAppService.Editar(It.IsAny<int>(), locacaoMock.Object);

            locacaoMock.Verify(x => x.Validar());

            locacaoDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<Locacao>()));
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
