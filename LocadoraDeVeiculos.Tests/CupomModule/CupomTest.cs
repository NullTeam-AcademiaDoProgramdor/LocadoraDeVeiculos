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
            Cupom cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidarCodigo()
        {
            Cupom cupom = new Cupom(null, parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("O campo código não pode estar vazio");
        }

        [TestMethod]
        public void DeveValidarParceiro()
        {
            Cupom cupom = new Cupom("DezOff", null, "Porcentagem", 10, 1000, DateTime.Today, 1);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("Selecione um parceiro");
        }

        [TestMethod]
        public void DeveValidarTipo()
        {
            Cupom cupom = new Cupom("DezOff", parceiro, null, 10, 1000, DateTime.Today, 1);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("O campo tipo não pode estar vazio");
        }

        [TestMethod]
        public void DeveValidarValor()
        {
            Cupom cupom = new Cupom("DezOff", parceiro, "porcentagem", 0, 1000, DateTime.Today, 1);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("Insira um valor Válido");
        }

        [TestMethod]
        public void DeveValidarValorMinimo()
        {
            Cupom cupom = new Cupom("DezOff", parceiro, "porcentagem", 10, -1, DateTime.Today, 1);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("Insira um valor mínimo Válido");
        }

        [TestMethod]
        public void DeveValidarDataVencimento()
        {
            Cupom cupom = new Cupom("DezOff", parceiro, "porcentagem", 10, 1000, DateTime.Today.AddDays(-1), 1);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be("A data de vencimento não pode ser no passado");
        }

        [TestMethod]
        public void DeveValidarTodosCampos()
        {
            Cupom cupom = new Cupom(null, null, null, 0, -1, DateTime.Today.AddDays(-1), 1);

            string resultadoValidacao = cupom.Validar();

            resultadoValidacao.Should().Be(
            "O campo código não pode estar vazio" +
            Environment.NewLine +
            "O campo tipo não pode estar vazio" +
            Environment.NewLine +
            "Insira um valor Válido" +
            Environment.NewLine +
            "Insira um valor mínimo Válido" +
            Environment.NewLine +
            "A data de vencimento não pode ser no passado" +
            Environment.NewLine +
            "Selecione um parceiro");
        }
    }
}