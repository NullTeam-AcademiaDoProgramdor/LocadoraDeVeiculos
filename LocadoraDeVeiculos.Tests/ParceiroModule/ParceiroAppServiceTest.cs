using LocadoraDeVeículos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeículos.Infra.SQL.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.ParceiroModule
{
    [TestClass]
    public class ParceiroAppServiceTest
    {

        private DBLocadoraContext db;

        public ParceiroAppServiceTest()
        {
            this.db = new();
        }

        [TestMethod]
        public void DeveInserir_NovoParceiro()
        {
            Mock<Parceiro> parceiroMock = new("Josue");

            parceiroMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<ParceiroORMDao> parceiroDaoMock = new(db);

            ParceiroAppService parceiroAppService = new(parceiroDaoMock.Object, db);

            parceiroAppService.InserirNovo(parceiroMock.Object);

            parceiroMock.Verify(x => x.Validar());
            parceiroDaoMock.Verify(x => x.InserirNovo(It.IsAny<Parceiro>()));
        }

        [TestMethod]
        public void NaoDeveInserir_SeNaoEstaValido()
        {
            Mock<Parceiro> parceiroMock = new("");

            parceiroMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<ParceiroORMDao> parceiroDaoMock = new(db);

            ParceiroAppService parceiroAppService = new(parceiroDaoMock.Object, db);

            parceiroAppService.InserirNovo(parceiroMock.Object);

            parceiroMock.Verify(x => x.Validar());
            parceiroDaoMock.Verify(x => x.InserirNovo(It.IsAny<Parceiro>()), Times.Never);
        }

        [TestMethod]
        public void DeveEditar_Parceiro()
        {
            Mock<Parceiro> parceiroMock = new("Josue");

            parceiroMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<ParceiroORMDao> parceiroDaoMock = new(db);

            ParceiroAppService parceiroAppService = new(parceiroDaoMock.Object, db);

            parceiroAppService.Editar(0, parceiroMock.Object);

            parceiroMock.Verify(x => x.Validar());
            parceiroDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<Parceiro>()));
        }
    }
}
