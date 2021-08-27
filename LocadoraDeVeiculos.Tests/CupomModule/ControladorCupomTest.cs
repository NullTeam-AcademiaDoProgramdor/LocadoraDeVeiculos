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

        [TestMethod]
        public void DeveEditarUmCupom()
        {
            var cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);
            controladorParceiro.InserirNovo(parceiro);
            controlador.InserirNovo(cupom);

            Cupom novoCupom = new Cupom("VinteOff", parceiro, "Porcentagem", 20, 2000, DateTime.Today, 3);
            controlador.Editar(cupom.Id, novoCupom);

            Cupom cupomEncontrado = controlador.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().Be(novoCupom);
        }

        [TestMethod]
        public void DeveExcluirUmCupom()
        {
            var cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);
            controladorParceiro.InserirNovo(parceiro);
            controlador.InserirNovo(cupom);
            
            controlador.Excluir(cupom.Id);

            Cupom cupomEncontrado = controlador.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarCupomPorId()
        {
            var cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);
            controladorParceiro.InserirNovo(parceiro);
            controlador.InserirNovo(cupom);

            Cupom cupomEncontrado = controlador.SelecionarPorId(cupom.Id);

            cupomEncontrado.Should().Be(cupom);
        }

        [TestMethod]
        public void DeveSelecionarTodosCupons()
        {
            controladorParceiro.InserirNovo(parceiro);

            var cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);            
            controlador.InserirNovo(cupom);

            var novoCupom = new Cupom("VinteOff", parceiro, "Porcentagem", 20, 2000, DateTime.Today,  1);
            controlador.InserirNovo(novoCupom);

            var cupons = controlador.SelecionarTodos();

            cupons.Should().HaveCount(2);
        }
    }
}
