using FluentAssertions;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.CupomModule
{
    [TestClass]
    public class CupomTest
    {
        private Parceiro parceiro;
        public CupomTest()
        {
            parceiro = new Parceiro("Pedro");
        }

        [TestMethod]
        public void DeveRetornarCupomValido()
        {
            Cupom cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidarCodigo()
        {
            Cupom cupom = new Cupom(null, parceiro, "Porcentagem", 10, 1000, DateTime.Today);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("O campo código não pode estar vazio");
        }
    }
}
