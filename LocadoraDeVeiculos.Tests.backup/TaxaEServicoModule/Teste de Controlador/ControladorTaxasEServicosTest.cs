using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Controladores.Shared;
using FluentAssertions;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Tests.TaxaEServicoModule.Teste_de_Controlador
{
    [TestClass]
    public class ControladorTaxasEServicosTest
    {
        ControladorTaxasEServicos controlador = null;

        public ControladorTaxasEServicosTest()
        {
            controlador = new ControladorTaxasEServicos();       
        }

        [TestMethod]
        public void DeveInserirNovoTaxasEServicos()
        {
            TaxaEServico novaTaxa = new TaxaEServico("a", 10, true);

            controlador.InserirNovo(novaTaxa);

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(novaTaxa.id);

            taxaEncontrada.Should().Be(novaTaxa);
        }

        [TestMethod]
        public void DeveEditar_UmaTaxa()
        {

            TaxaEServico novaTaxa = new TaxaEServico("a", 10, true);
            controlador.InserirNovo(novaTaxa);

            TaxaEServico outraTaxa = new TaxaEServico("b", 20, true);
            controlador.InserirNovo(novaTaxa);

            TaxaEServico novoServico = new TaxaEServico("lavacao", 50, false);
            controlador.InserirNovo(novoServico);
            
            controlador.Editar(novaTaxa.Id, outraTaxa);
            
            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(novaTaxa.Id);
            taxaEncontrada.Should().Be(outraTaxa);
        }

        [TestMethod]
        public void DeveEditar_UmServico()
        {

            TaxaEServico novaTaxa = new TaxaEServico("a", 10, true);
            controlador.InserirNovo(novaTaxa);

            TaxaEServico outraTaxa = new TaxaEServico("b", 20, true);
            controlador.InserirNovo(novaTaxa);

            TaxaEServico novoServico = new TaxaEServico("lavacao", 50, false);
            controlador.InserirNovo(novoServico);

            TaxaEServico outroServico = new TaxaEServico("lavacao", 50, false);
            controlador.InserirNovo(novoServico);

            controlador.Editar(novoServico.Id, outroServico);

            TaxaEServico servicoEncontrado = controlador.SelecionarPorId(novoServico.Id);
            servicoEncontrado.Should().Be(novoServico);
        }

        [TestMethod]
        public void DeveExcluir_UmaTaxa()
        {
            TaxaEServico novaTaxa = new TaxaEServico("a", 10, true);
            controlador.InserirNovo(novaTaxa);
                      
            controlador.Excluir(novaTaxa.Id);

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(novaTaxa.Id);
            taxaEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Taxa_PorId()
        {
            TaxaEServico novaTaxa = new TaxaEServico("a", 10, true);
            controlador.InserirNovo(novaTaxa);

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(novaTaxa.Id);

            taxaEncontrada.Should().Be(novaTaxa);
        }

        [TestMethod]
        public void DeveSelecionar_Todas_Taxas()
        {
            TaxaEServico novaTaxa = new TaxaEServico("a", 10, true);
            controlador.InserirNovo(novaTaxa);

            TaxaEServico outraTaxa = new TaxaEServico("b", 20, true);
            controlador.InserirNovo(outraTaxa);

            TaxaEServico maisUmaTaxa = new TaxaEServico("C", 30, false);
            controlador.InserirNovo(maisUmaTaxa);

            List<TaxaEServico> taxasParaVerificar = new List<TaxaEServico>();
            taxasParaVerificar.Add(novaTaxa);
            taxasParaVerificar.Add(outraTaxa);
            taxasParaVerificar.Add(maisUmaTaxa);

            List<TaxaEServico> taxasSelecionadas = controlador.SelecionarTodos();   

            Assert.AreEqual(taxasSelecionadas.ToString(), taxasParaVerificar.ToString());
        }
    }
}
