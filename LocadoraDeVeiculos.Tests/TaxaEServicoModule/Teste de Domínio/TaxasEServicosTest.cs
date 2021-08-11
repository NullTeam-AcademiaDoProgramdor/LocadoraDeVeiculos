using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using FluentAssertions;

namespace LocadoraDeVeiculos.Tests.TaxaEServicoModule.Teste_de_Domínio
{
    [TestClass]
    public class TaxasEServicosTest
    {
        

        [TestMethod]
        public void TesteDeValidacaoNome()
        {
            TaxaEServico taxa = new TaxaEServico("lavação", 50, true);

            Assert.AreEqual(taxa.Validar(), "ESTA_VALIDO");     
        }

        [TestMethod]
        public void TesteDeValidacaoPreco()
        {
            TaxaEServico taxa = new TaxaEServico("lavação", 50, true);

            Assert.AreEqual(taxa.Validar(), "ESTA_VALIDO");
        }

        [TestMethod]
        public void TesteDeValidacaoEhFixo()
        {
            TaxaEServico taxa = new TaxaEServico("lavação", 50, true);

            Assert.AreEqual(taxa.Validar(), "ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveRetornarNomeInvalido()
        {
            TaxaEServico taxa = new TaxaEServico("10", 50, true);

            Assert.AreEqual(taxa.Validar(), " O campo nome está inválido");
        }

        

    }
}
