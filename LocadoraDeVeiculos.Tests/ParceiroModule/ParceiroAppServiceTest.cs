using LocadoraDeVeículos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
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
        [TestMethod]
        public void DeveInserir_NovoParceiro()
        {
            Mock<Parceiro> parceiroMock = new("Josue");

            parceiroMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<ParceiroDao> parceiroDaoMock = new();

            ParceiroAppService parceiroAppService = new(parceiroDaoMock.Object);

            parceiroAppService.InserirNovo(parceiroMock.Object);

            parceiroMock.Verify(x => x.Validar());
            parceiroDaoMock.Verify(x => x.InserirNovo(It.IsAny<Parceiro>()));
        }

        [TestMethod]
        public void NaoDeveInserir_SeNaoEstaValido()
        {
            Mock<Parceiro> parceiroMock = new("");

            parceiroMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<ParceiroDao> parceiroDaoMock = new();

            ParceiroAppService parceiroAppService = new(parceiroDaoMock.Object);

            parceiroAppService.InserirNovo(parceiroMock.Object);

            parceiroMock.Verify(x => x.Validar());
            parceiroDaoMock.Verify(x => x.InserirNovo(It.IsAny<Parceiro>()), Times.Never);
        }
    }
}
