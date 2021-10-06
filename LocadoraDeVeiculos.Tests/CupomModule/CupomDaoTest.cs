using FluentAssertions;
using LocadoraDeVeiculos.Controladores.CupomModule;
using LocadoraDeVeiculos.Controladores.ParceiroModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.ORM.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeículos.Infra.SQL.CupomModule;
using LocadoraDeVeículos.Infra.SQL.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.CupomModule
{
    [TestClass]
    public class CupomDaoTest
    {
        private Parceiro parceiro;
        private IRepositorBase<Parceiro> controladorParceiro;
        private IRepositorCupomBase controlador = null;

        private DBLocadoraContext db;

        public CupomDaoTest()
        {
            parceiro = new Parceiro("Pedro");

            this.db = new();

            controladorParceiro = new ParceiroORMDao(db);
            controlador = new CupomORMDao(db);
        }

        [TestCleanup]
        public void LimparTabelas()
        {
            Db.Update(@"DELETE FROM TBCUPOM");
            Db.Update(@"DELETE FROM TBPARCEIRO");
        }

        [TestMethod]
        public void DeveInserirUmCupom()
        {
            var novoCupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);
            controladorParceiro.InserirNovo(parceiro);

            controlador.InserirNovo(novoCupom);
            db.SaveChanges();

            var cupomEncontrado = controlador.SelecionarPorId(novoCupom.Id);
            cupomEncontrado.Should().Be(novoCupom);
        }

        [TestMethod]
        public void DeveEditarUmCupom()
        {
            var cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);
            controladorParceiro.InserirNovo(parceiro);
            controlador.InserirNovo(cupom);
            db.SaveChanges();

            Cupom novoCupom = new Cupom("VinteOff", parceiro, "Porcentagem", 20, 2000, DateTime.Today, 3);
            controlador.Editar(cupom.Id, novoCupom);
            db.SaveChanges();

            Cupom cupomEncontrado = controlador.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().Be(novoCupom);
        }

        [TestMethod]
        public void DeveExcluirUmCupom()
        {
            var cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);
            controladorParceiro.InserirNovo(parceiro);
            controlador.InserirNovo(cupom);
            db.SaveChanges();

            controlador.Excluir(cupom.Id);
            db.SaveChanges();

            Cupom cupomEncontrado = controlador.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarCupomPorId()
        {
            var cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);
            controladorParceiro.InserirNovo(parceiro);
            controlador.InserirNovo(cupom);
            db.SaveChanges();

            Cupom cupomEncontrado = controlador.SelecionarPorId(cupom.Id);

            cupomEncontrado.Should().Be(cupom);
        }
        
        [TestMethod]
        public void DeveSelecionarCupomPorCodigo()
        {
            var cupom = new Cupom("DezOff", parceiro, "Porcentagem", 10, 1000, DateTime.Today, 1);
            controladorParceiro.InserirNovo(parceiro);
            controlador.InserirNovo(cupom);

            db.SaveChanges();

            Cupom cupomEncontrado = controlador.SelecionarPorCodigo(cupom.Codigo);

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

            db.SaveChanges();

            var cupons = controlador.SelecionarTodos();

            cupons.Should().HaveCount(2);
        }
    }
}
