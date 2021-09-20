using FluentAssertions;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.TaxaEServicoModule
{
    [TestClass]
    public class TaxaEServicoTest
    {
        [TestMethod]
        public void DeveCriar_Taxa()
        {
            TaxaEServico taxa = new ("GPS", 10, true);

            taxa.Nome.Should().Be("GPS");
            taxa.Preco.Should().Be(10);
            taxa.EhFixo.Should().Be(true);
        }

        [TestMethod]
        public void DeveRetornar_TaxaValida()
        {
            TaxaEServico taxa = new("GPS", 10, true);

            var resultado = taxa.Validar();

            resultado.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Nome()
        {
            TaxaEServico taxa = new("", 10, true);

            var resultado = taxa.Validar();

            resultado.Should().Be(" O campo nome está inválido");
        }
    }
}
