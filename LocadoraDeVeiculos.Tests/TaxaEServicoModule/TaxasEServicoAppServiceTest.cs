﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeículos.Aplicacao.TaxaEServicoModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeículos.Infra.SQL.TaxasEServicosModule;

namespace LocadoraDeVeiculos.Tests.TaxaEServicoModule
{
    [TestClass]
    public class TaxasEServicoAppServiceTest
    {
        [TestMethod]
        public void DeveInserir_NovaTaxaOuServico()
        {
            Mock<TaxaEServico> taxaMock = new("gps", 10, false);

            taxaMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<TaxasEServicosDao> taxasEServicosDaoMock = new();            

            TaxaEServicoAppService taxasEServicosAppService = new(taxasEServicosDaoMock.Object);

            taxasEServicosAppService.InserirNovo(taxaMock.Object);

            taxaMock.Verify(x => x.Validar());
            taxasEServicosDaoMock.Verify(x => x.InserirNovo(It.IsAny<TaxaEServico>()));  
        }

        [TestMethod]
        public void NaoDeveInserir_SeNaoEstaValido()
        {
            Mock<TaxaEServico> taxaMock = new("gps", 10, false);

            taxaMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<TaxasEServicosDao> taxasEServicosDaoMock = new();

            TaxaEServicoAppService taxasEServicosAppService = new(taxasEServicosDaoMock.Object);

            taxasEServicosAppService.InserirNovo(taxaMock.Object);

            taxaMock.Verify(x => x.Validar());
            taxasEServicosDaoMock.Verify(x => x.InserirNovo(It.IsAny<TaxaEServico>()), Times.Never);            
        }

        [TestMethod]
        public void DeveEditar_TaxaOuServico()
        {
            Mock<TaxaEServico> taxaMock = new("gps", 10, false);

            taxaMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<TaxasEServicosDao> taxasEServicosDaoMock = new();

            TaxaEServicoAppService taxasEServicosAppService = new(taxasEServicosDaoMock.Object);

            taxasEServicosAppService.Editar(0, taxaMock.Object);

            taxaMock.Verify(x => x.Validar());
            taxasEServicosDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<TaxaEServico>()));           
        }

    }
}
