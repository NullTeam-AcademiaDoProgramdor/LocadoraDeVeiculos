using FluentAssertions;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.TaxaEServicoModule;
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
        IRepositorTaxaEServicoBase controlador = null;
        DBLocadoraContext db = null;

        public TaxasEServicosDaoTest()
        {
            db = new();
            controlador = new TaxaEServicoORMDao(db);              
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [TBTaxaEServico]");            
        }

        [TestMethod]
        public void DeveInserir_Taxa()
        {
            TaxaEServico novaTaxa = new("gps", 10, true);

            controlador.InserirNovo(novaTaxa);
            db.SaveChanges();

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(novaTaxa.id);

            taxaEncontrada.Should().Be(novaTaxa);
        }

        [TestMethod]
        public void DeveEditar_UmaTaxa()
        {
            TaxaEServico taxa = new("gps", 10, true);

            controlador.InserirNovo(taxa);
            db.SaveChanges();

            TaxaEServico novaTaxa = new("GPS", 20, false);

            controlador.Editar(taxa.Id, novaTaxa);
            db.SaveChanges();

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(taxa.Id);
            taxaEncontrada.Should().Be(novaTaxa);
        }

        [TestMethod]
        public void DeveExcluir_UmaTaxa()
        {
            TaxaEServico taxa = new("gps", 10, true);

            controlador.InserirNovo(taxa);
            db.SaveChanges();

            controlador.Excluir(taxa.Id);
            db.SaveChanges();

            TaxaEServico taxaEncontrada = controlador.SelecionarPorId(taxa.Id);
            taxaEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Taxa_porId()
        {

            TaxaEServico taxa = new("gps", 10, true);

            controlador.InserirNovo(taxa);
            db.SaveChanges();

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
            db.SaveChanges();

            var taxas = controlador.SelecionarTodos();

            taxas.Should().HaveCount(4);
        }

    }
}
