using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using LocadoraDeVeículos.Infra.SQL.GrupoAutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.ORM.GrupoAutomovelModule;

namespace LocadoraDeVeiculos.Tests.GrupoAutomovelModule
{
   
    [TestClass]
    [TestCategory("Controladores")]
    public class GrupoAutomovelDaoTest
    {
        IRepositorBase<GrupoAutomovel> controlador = null;
        DBLocadoraContext db;

        public GrupoAutomovelDaoTest()
        {
            this.db = new();
            controlador = new GrupoAutomovelORMDao(db);
        }
        
        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [TBGrupoAutomovel]");
        }

        [TestMethod]
        public void DeveInserir_GrupoAutomovel()
        {
            GrupoAutomovel novoGrupo = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            controlador.InserirNovo(novoGrupo);
            db.SaveChanges();

            GrupoAutomovel grupoEncontrado = controlador.SelecionarPorId(novoGrupo.id);
            grupoEncontrado.Should().Be(novoGrupo);
        }

        [TestMethod]
        public void DeveEditar_UmGrupoAutomovel()
        {
            GrupoAutomovel grupo = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );
            controlador.InserirNovo(grupo);
            db.SaveChanges();

            GrupoAutomovel novoGrupo = new GrupoAutomovel(
                "SUV",
                new PlanoDiarioStruct(200, 10),
                new PlanoKmControladoStruct(150, 20, 150),
                new PlanoKmLivreStruct(500)
            );

            controlador.Editar(grupo.id, novoGrupo);
            db.SaveChanges();

            GrupoAutomovel grupoEncontrado = controlador.SelecionarPorId(grupo.id);
            grupoEncontrado.Should().Be(novoGrupo);
        }

        [TestMethod]
        public void DeveExcluir_UmGrupoAutomovel()
        {
            GrupoAutomovel grupo = new GrupoAutomovel(
               "Economicos",
               new PlanoDiarioStruct(150, 5),
               new PlanoKmControladoStruct(100, 15, 100),
               new PlanoKmLivreStruct(300)
            );
            controlador.InserirNovo(grupo);
            db.SaveChanges();

            controlador.Excluir(grupo.id);
            db.SaveChanges();

            GrupoAutomovel grupoEncontrado = controlador.SelecionarPorId(grupo.id);
            grupoEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_GrupoAutomovel_porId()
        {
            GrupoAutomovel grupo = new GrupoAutomovel(
              "Economicos",
              new PlanoDiarioStruct(150, 5),
              new PlanoKmControladoStruct(100, 15, 100),
              new PlanoKmLivreStruct(300)
            );
            controlador.InserirNovo(grupo);
            db.SaveChanges();

            GrupoAutomovel grupoEncontrado = controlador.SelecionarPorId(grupo.id);
            grupoEncontrado.Should().Be(grupo);
        }

        [TestMethod]
        public void DeveSelecionar_TodosGruposAutomovel()
        {
            GrupoAutomovel g1 = new GrupoAutomovel(
              "Economicos",
              new PlanoDiarioStruct(150, 5),
              new PlanoKmControladoStruct(100, 15, 100),
              new PlanoKmLivreStruct(300)
            );
            controlador.InserirNovo(g1);

            GrupoAutomovel g2 = new GrupoAutomovel(
              "SUV",
              new PlanoDiarioStruct(150, 5),
              new PlanoKmControladoStruct(100, 15, 100),
              new PlanoKmLivreStruct(500)
            );
            controlador.InserirNovo(g2);

            GrupoAutomovel g3 = new GrupoAutomovel(
              "Luxo",
              new PlanoDiarioStruct(500, 5),
              new PlanoKmControladoStruct(100, 15, 100),
              new PlanoKmLivreStruct(1000)
            );
            controlador.InserirNovo(g3);
            db.SaveChanges();

            var grupos = controlador.SelecionarTodos();

            grupos.Should().HaveCount(3);
        }
    }
}
