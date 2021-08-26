using FluentAssertions;
using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Tests.ParceiroModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorParceiroTest
    {
        ControladorParceiro controlador;

        public ControladorParceiroTest()
        {
            controlador = new ControladorParceiro();
            Db.Update("DELETE FROM [PARCEIRO]");
        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Matheus");

            //action
            controlador.InserirNovo(parceiro);

            //assert
            Parceiro parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(parceiro);
        }

        [TestMethod]
        public void DeveEditar_UmParceiro()
        {
            //arrange
            Parceiro parceiro = new Parceiro("Matheus");
            controlador.InserirNovo(parceiro);

            Parceiro novoParceiro = new Parceiro("Biel");

            //action
            controlador.Editar(parceiro.Id, novoParceiro);

            //assert
            Parceiro parceiroEncontrada = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrada.Should().Be(novoParceiro);
        }

        [TestMethod]
        public void DeveExcluir_UmaPessoaJuridica()
        {
            //arrange            
            Parceiro parceiro = new Parceiro("Matheus");
            controlador.InserirNovo(parceiro);

            //action            
            controlador.Excluir(parceiro.Id);

            //assert
            Parceiro parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarTodos_Parceiros()
        {
            //arrange
            var parceiros = new List<Parceiro>
            {
                new Parceiro("Matheus"),

                new Parceiro("Biel"),

                new Parceiro("Math")
            };

            foreach (var c in parceiros)
                controlador.InserirNovo(c);


            //action
            var ParceirosEncotradas = controlador.SelecionarTodos();

            //assert
            ParceirosEncotradas.Should().HaveCount(3);
        }
    }
}
