using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Controladores.Shared;
using FluentAssertions;

namespace LocadoraDeVeiculos.Tests.TaxaEServicoModule.Teste_de_Controlador
{
    [TestClass]
    public class ControladorTaxasEServicosTest
    {
        ControladorTaxasEServicos controlador = null;

        public ControladorTaxasEServicosTest()
        {
            controlador = new ControladorTaxasEServicos();       
        }

        [TestMethod]
        public void DeveInserirNovoTaxasEServicos()
        {
            TaxaEServico novaTaxa = new TaxaEServico("a", 10, true);

            controlador.InserirNovo(novaTaxa);

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(novaTaxa.id);

            taxaEncontrada.Should().Be(novaTaxa);
        }
    }
}
