using LocadoraDeVeículos.Aplicacao.CupomModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeículos.Infra.SQL.CupomModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace LocadoraDeVeiculos.Tests.CupomModule
{
    [TestClass]
    public class CupomAppServiceTest
    {
        private Parceiro parceiro;
        private DBLocadoraContext db;

        public CupomAppServiceTest()
        {
            parceiro = gerarParceiro();
            this.db = new();
        }

        [TestMethod]
        public void DeveInserir_Cupom()
        {
            Mock<Cupom> CupomMock = new("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);

            CupomMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<CupomORMDao> CupomDaoMock = new(db);

            CupomAppService cupomAppService =
                new(CupomDaoMock.Object, db);

            cupomAppService.InserirNovo(CupomMock.Object);

            CupomMock.Verify(x => x.Validar());
            CupomDaoMock.Verify(x => x.InserirNovo(It.IsAny<Cupom>()));
        }

        [TestMethod]
        public void NaoDeveInserir_Cupom()
        {
            Mock<Cupom> CupomMock = new("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);

            CupomMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<CupomORMDao> CupomDaoMock = new(db);
            
            CupomAppService cupomAppService =
                new(CupomDaoMock.Object, db);

            cupomAppService.InserirNovo(CupomMock.Object);

            CupomMock.Verify(x => x.Validar());
            CupomDaoMock.Verify(x => x.InserirNovo(It.IsAny<Cupom>()), Times.Never);
        }
        
        [TestMethod]
        public void DeveEditar_Cupom()
        {
            Mock<Cupom> CupomMock = new("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);

            CupomMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<CupomORMDao> CupomDaoMock = new(db);

            CupomAppService cupomAppService =
                new(CupomDaoMock.Object, db);

            cupomAppService.Editar(CupomMock.Object.Id, CupomMock.Object);

            CupomMock.Verify(x => x.Validar());
            CupomDaoMock.Verify(x => x.Editar(It.IsAny<int>(),It.IsAny<Cupom>()));
        }


        [TestMethod]
        public void NaoDeveEditar_Cupom()
        {
            Mock<Cupom> CupomMock = new("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);

            CupomMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<CupomORMDao> CupomDaoMock = new(db);

            CupomAppService cupomAppService =
                new(CupomDaoMock.Object, db);

            cupomAppService.Editar(CupomMock.Object.Id, CupomMock.Object);

            CupomMock.Verify(x => x.Validar());
            CupomDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<Cupom>()), Times.Never);
        }

        private Parceiro gerarParceiro()
        {
            return new Parceiro("Pedro");
        }
    }
}
