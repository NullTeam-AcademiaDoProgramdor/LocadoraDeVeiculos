using FluentAssertions;
using LocadoraDeVeiculos.Controladores.CupomModule;
using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.CupomModule
{
    [TestClass]
    public class ControladorCupomTest
    {
        private Parceiro parceiro;
        private ControladorParceiro controladorParceiro;
        private ControladorCupom controlador = null;

        public ControladorCupomTest()
        {
            parceiro = new Parceiro("Pedro");
            controladorParceiro = new ControladorParceiro();
            controlador = new ControladorCupom();
        }

        [TestCleanup]
        public void LimparTabelas()
        {
            Db.Update(@"DELETE FROM CUPOM");
            Db.Update(@"DELETE FROM PARCEIRO");
        }

        [TestMethod]
        public void DeveInserirUmCupom()
        {
            var novoCupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);

            controladorParceiro.InserirNovo(parceiro);
            controlador.InserirNovo(novoCupom);

            var cupomEncontrado = controlador.SelecionarPorId(novoCupom.Id);
            cupomEncontrado.Should().Be(novoCupom);
        }


    }
}
