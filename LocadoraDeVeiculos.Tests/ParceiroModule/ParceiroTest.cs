using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.ParceiroModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class ParceiroTest
    {
        [TestMethod]
        public void DeveCriar_Parceiro()
        {
            Parceiro parceiro = new Parceiro("Matheus");

            parceiro.Nome.Should().Be("Matheus");
            parceiro.Validar().Should().Be("ESTA_VALIDO");
        }
        
        [TestMethod]
        public void DeveValidae_NomeParceiro()
        {
            Parceiro parceiro = new Parceiro(null);

            parceiro.Validar().Should().Be("O campo 'nome' não pode estar vazio.");
        }
    }
}
