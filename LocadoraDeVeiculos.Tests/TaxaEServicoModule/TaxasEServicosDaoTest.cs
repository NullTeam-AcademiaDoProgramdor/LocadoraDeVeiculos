using FluentAssertions;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeículos.Infra.SQL.TaxasEServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.TaxaEServicoModule
{
    [TestClass]
    public class TaxasEServicosDaoTest
    {
        TaxasEServicosDao controlador = null;        

        public TaxasEServicosDaoTest()
        {
            controlador = new();            
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [TaxaEServico]");            
        }

        [TestMethod]
        public void DeveInserir_Taxa()
        {
            TaxaEServico novaTaxa = new("gps", 10, true);

            controlador.InserirNovo(novaTaxa);

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(novaTaxa.id);

            taxaEncontrada.Should().Be(novaTaxa);
        }

        [TestMethod]
        public void DeveEditar_UmaTaxa()
        {
            TaxaEServico taxa = new("gps", 10, true);

            controlador.InserirNovo(taxa);

            TaxaEServico novaTaxa = new("GPS", 20, false);

            controlador.Editar(taxa.Id, novaTaxa);

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(taxa.Id);
            taxaEncontrada.Should().Be(novaTaxa);
        }

        [TestMethod]
        public void DeveExcluir_UmaTaxa()
        {
            TaxaEServico taxa = new("gps", 10, true);

            controlador.InserirNovo(taxa);

            controlador.Excluir(taxa.Id);

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(taxa.Id);
            taxaEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Taxa_porId()
        {

            TaxaEServico taxa = new("gps", 10, true);

            controlador.InserirNovo(taxa);

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(taxa.Id);
            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void DeveSelecionar_TodasTaxas()
        {
            TaxaEServico taxa1 = new("gps", 10, true);

            controlador.InserirNovo(taxa1);

            TaxaEServico taxa2 = new("gps", 10, true);

            controlador.InserirNovo(taxa2);

            TaxaEServico taxa3 = new("gps", 10, true);

            controlador.InserirNovo(taxa3);

            TaxaEServico taxa4 = new("gps", 10, true);

            controlador.InserirNovo(taxa4);

            var automoveis = controlador.SelecionarTodos();

            automoveis.Should().HaveCount(4);
        }

    }
}
