using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeículos.Infra.SQL.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.ParceiroModule
{
    [TestClass]
    public class ParceiroDaoTest
    {
        IRepositorBase<Parceiro> controlador = null;
        private DBLocadoraContext db;

        public ParceiroDaoTest()
        {
            this.db = new();
            controlador = new ParceiroORMDao(db);
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [TBParceiro]");
        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            Parceiro novoParceiro = new("Josue");

            controlador.InserirNovo(novoParceiro);
            db.SaveChanges();

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(novoParceiro.id);

            parceiroEncontrado.Should().Be(novoParceiro);
        }

        [TestMethod]
        public void DeveEditar_UmParceiro()
        {
            Parceiro parceiro = new("Josue");

            controlador.InserirNovo(parceiro);
            db.SaveChanges();

            Parceiro novoParceiro = new("Jose");

            controlador.Editar(parceiro.Id, novoParceiro);
            db.SaveChanges();

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(novoParceiro);
        }

        [TestMethod]
        public void DeveExcluir_UmParceiro()
        {
            Parceiro parceiro = new("Josue");

            controlador.InserirNovo(parceiro);
            db.SaveChanges();

            controlador.Excluir(parceiro.Id);
            db.SaveChanges();

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Parceiro_porId()
        {

            Parceiro parceiro = new("Josue");

            controlador.InserirNovo(parceiro);
            db.SaveChanges();

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(parceiro);
        }

        [TestMethod]
        public void DeveSelecionar_TodosParceiros()
        {
            Parceiro parceiro1 = new("Josue");

            controlador.InserirNovo(parceiro1);

            Parceiro parceiro2 = new("Jose");

            controlador.InserirNovo(parceiro2);

            Parceiro parceiro3 = new("Joberson");

            controlador.InserirNovo(parceiro3);

            Parceiro parceiro4 = new("Joao");

            controlador.InserirNovo(parceiro4);

            db.SaveChanges();

            var parceiros = controlador.SelecionarTodos();

            parceiros.Should().HaveCount(4);
        }
    }
}
