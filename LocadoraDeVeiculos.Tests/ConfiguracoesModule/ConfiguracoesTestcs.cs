using LocadoraDeVeiculos.Configuracoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Tests.ConfiguracoesModule
{
    /// <summary>
    /// Summary description for ConfiguracoesTestcs
    /// </summary>
    [TestClass]
    public class ConfiguracoesTestcs
    {
        [TestMethod]
        public void DeveInserir_PrecoGasolina()
        {
            //arrange
            Configuracao.PrecoGasolina = 12.00;

            //action
            double preco = Configuracao.PrecoGasolina;

            //assert
            preco.Should().Be(12.00);
        }

        [TestMethod]
        public void DeveInserir_PrecoGas()
        {
            //arrange
            Configuracao.PrecoGas = 12.00;

            //action
            double preco = Configuracao.PrecoGas;

            //assert
            preco.Should().Be(12.00);
        }

        [TestMethod]
        public void DeveInserir_PrecoDiesel()
        {
            //arrange
            Configuracao.PrecoDiesel = 12.00;

            //action
            double preco = Configuracao.PrecoDiesel;

            //assert
            preco.Should().Be(12.00);
        }

        [TestMethod]
        public void DeveInserir_PrecoAlcool()
        {
            //arrange
            Configuracao.PrecoAlcool = 12.00;

            //action
            double preco = Configuracao.PrecoAlcool;

            //assert
            preco.Should().Be(12.00);
        }
    }
}
