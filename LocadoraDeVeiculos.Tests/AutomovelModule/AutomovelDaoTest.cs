using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LocadoraDeVeículos.Infra.SQL.AutomovelModule;
using LocadoraDeVeículos.Infra.SQL.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.AutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.GrupoAutomovelModule;

namespace LocadoraDeVeiculos.Tests.AutomovelModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class AutomovelDaoTest
    {
        DBLocadoraContext db;
        IRepositorAutomovelBase controlador = null;
        IRepositorBase<GrupoAutomovel> controladorGrupoAutomovel = null;

        public AutomovelDaoTest()
        {
            this.db = new();
            controlador = new AutomovelORMDao(db);
            controladorGrupoAutomovel = new GrupoAutomovelORMDao(db);
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [TBFoto]");
            Db.Update("DELETE FROM [TBAutomovel]");
            Db.Update("DELETE FROM [TBGrupoAutomovel]");
        }

        [TestMethod]
        public void DeveInserir_Automovel()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel novoAutomovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(novoAutomovel);
            db.SaveChanges();

            Automovel automovelEncontrado = controlador.SelecionarPorId(novoAutomovel.id);

            automovelEncontrado.Should().Be(novoAutomovel);
        }

        [TestMethod]
        public void DeveEditar_UmAutomovel()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(automovel);
            db.SaveChanges();

            GrupoAutomovel novoGrupo = CriarGrupo();
            Automovel novoAutomovel =
                new Automovel("GolT", "FordT", "BrancoT", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, novoGrupo);

            controlador.Editar(automovel.Id, novoAutomovel);
            db.SaveChanges();

            Automovel automovelEncontrado = controlador.SelecionarPorId(automovel.Id);
            automovelEncontrado.Should().Be(novoAutomovel);
        }

        [TestMethod]
        public void DeveExcluir_UmAutomovel()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(automovel);
            db.SaveChanges();

            controlador.Excluir(automovel.Id);
            db.SaveChanges();

            Automovel automovelEncontrado = controlador.SelecionarPorId(automovel.Id);
            automovelEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Automovel_porId()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(automovel);
            db.SaveChanges();

            Automovel automovelEncontrado = controlador.SelecionarPorId(automovel.Id);
            automovelEncontrado.Should().Be(automovel);
        }

        [TestMethod]
        public void DeveSelecionar_TodosAutomoveis()
        {
            GrupoAutomovel grupo1 = CriarGrupo();
            GrupoAutomovel grupo2 = CriarGrupo();

            Automovel automovel1 =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo1);
            controlador.InserirNovo(automovel1);

            Automovel automovel2 =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo2);
            controlador.InserirNovo(automovel2);

            Automovel automovel3 =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo1);
            controlador.InserirNovo(automovel3);

            Automovel automovel4 =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo2);
            controlador.InserirNovo(automovel4);

            db.SaveChanges();

            var automoveis = controlador.SelecionarTodos();

            automoveis.Should().HaveCount(4);
        }

        [TestMethod]
        public void DeveEditar_KmRegistrada()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(automovel);
            db.SaveChanges();

            Automovel novoAutomovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 150, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.EditarKmRegistrada(automovel.id, novoAutomovel);
            db.SaveChanges();

            Automovel automovelEditado = controlador.SelecionarPorId(automovel.id);
            automovelEditado.Should().Be(novoAutomovel);
        }

        private GrupoAutomovel CriarGrupo()
        {
            GrupoAutomovel novoGrupo = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            controladorGrupoAutomovel.InserirNovo(novoGrupo);
            db.SaveChanges();

            return novoGrupo;
        }
    }
}
