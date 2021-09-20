using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LocadoraDeVeiculos.Infra.Configuracoes;
namespace LocadoraDeVeiculos.Tests.ConfiguracoesModule
{
    [TestClass]
    public class ConfiguracoesTest
    {
        [TestMethod]
        public void DeveSetar_precoGasolina()
        {
            double precoGasolina = 5.45;

            Configuracao.PrecoGasolina = precoGasolina;

            var precoGasolinaRecuperado = Configuracao.PrecoGasolina;

            precoGasolinaRecuperado.Should().Be(precoGasolina);
        }

        [TestMethod]
        public void DeveSetar_precoAlcool()
        {
            double precoAlcool = 4.45;

            Configuracao.PrecoAlcool = precoAlcool;

            var precoAlcoolRecuperado = Configuracao.PrecoAlcool;

            precoAlcoolRecuperado.Should().Be(precoAlcool);
        }

        [TestMethod]
        public void DeveSetar_precoDiesel()
        {
            double precoDiesel = 3.45;

            Configuracao.PrecoDiesel = precoDiesel;

            var precoDieselRecuperado = Configuracao.PrecoDiesel;

            precoDieselRecuperado.Should().Be(precoDiesel);
        }

        [TestMethod]
        public void DeveSetar_precoGas()
        {
            double precoGas = 2.45;

            Configuracao.PrecoGas = precoGas;

            var precoGasRecuperado = Configuracao.PrecoGas;

            precoGasRecuperado.Should().Be(precoGas);
        }

        [TestMethod]
        public void DeveSetar_horaAbertura()
        {
            TimeSpan horaAbertura = new TimeSpan(8, 30, 15);

            Configuracao.HoraAbertura = horaAbertura;

            var horaAberturaRecuperada = Configuracao.HoraAbertura;

            horaAberturaRecuperada.Should().Be(horaAbertura);
        }

        [TestMethod]
        public void DeveSetar_horaFechamento()
        {
            TimeSpan horaFechamento = new TimeSpan(17, 35, 40);

            Configuracao.HoraFechamento = horaFechamento;

            var horaFechamentoRecuperada = Configuracao.HoraFechamento;

            horaFechamentoRecuperada.Should().Be(horaFechamento);
        }

        [TestMethod]
        public void DeveSetar_abreNoSabado()
        {
            bool abreNoSabado = true;

            Configuracao.AbreNoSabado = abreNoSabado;

            var abreNoSabadoRecuperado = Configuracao.AbreNoSabado;

            abreNoSabadoRecuperado.Should().Be(abreNoSabado);
        }
        
        [TestMethod]
        public void DeveSetar_NaoAbreNoSabado()
        {
            bool abreNoSabado = false;

            Configuracao.AbreNoSabado = abreNoSabado;

            var abreNoSabadoRecuperado = Configuracao.AbreNoSabado;

            abreNoSabadoRecuperado.Should().Be(abreNoSabado);
        }

        [TestMethod]
        public void DeveSetar_NaoAbreNoDomingo()
        {
            bool abreNoDomingo = false;

            Configuracao.AbreNoDomingo = abreNoDomingo;

            var abreNoDomingoRecuperado = Configuracao.AbreNoDomingo;

            abreNoDomingoRecuperado.Should().Be(abreNoDomingo);
        }
    }
}
