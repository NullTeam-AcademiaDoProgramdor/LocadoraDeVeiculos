using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace LocadoraDeVeiculos.Tests.AutomovelModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorAutomovelTest
    {
        ControladorAutomovel controlador = null;
        ControladorGrupoAutomovel controladorGrupoAutomovel = null;

        public ControladorAutomovelTest()
        {
            controlador = new ControladorAutomovel();
            controladorGrupoAutomovel = new ControladorGrupoAutomovel();
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [FotoAutomovel]");
            Db.Update("DELETE FROM [Automovel]");
            Db.Update("DELETE FROM [GrupoAutomovel]");
        }

        [TestMethod]
        public void DeveInserir_Automovel()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel novoAutomovel = 
                new Automovel("Gol", "Ford", "Branco", "Preto", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(novoAutomovel);

            Automovel automovelEncontrado = 
                controlador.SelecionarPorId(novoAutomovel.Id);

            automovelEncontrado.Should().Be(novoAutomovel);
        }

        [TestMethod]
        public void DeveEditar_UmAutomovel()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "Preto", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(automovel);

            GrupoAutomovel novoGrupo = CriarGrupo();
            Automovel novoAutomovel =
                new Automovel("GolT", "FordT", "BrancoT", "PretoT", "12YG2J31G23H123T",
                2019, 2, 150, 20, TipoCombustivelEnum.Alcool, CambioEnum.Automatico,
                DirecaoEnum.Eletrica, novoGrupo);

            controlador.Editar(automovel.Id, novoAutomovel);

            Automovel automovelEncontrado = controlador.SelecionarPorId(automovel.Id);
            automovelEncontrado.Should().Be(novoAutomovel);
        }

        [TestMethod]
        public void DeveExcluir_UmAutomovel()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "Preto", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(automovel);

            controlador.Excluir(automovel.Id);

            Automovel automovelEncontrado = controlador.SelecionarPorId(automovel.Id);
            automovelEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Automovel_porId()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "Preto", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            controlador.InserirNovo(automovel);

            Automovel automovelEncontrado = controlador.SelecionarPorId(automovel.Id);
            automovelEncontrado.Should().Be(automovel);
        }

        [TestMethod]
        public void DeveSelecionar_TodosAutomoveis()
        {
            GrupoAutomovel grupo1 = CriarGrupo();
            GrupoAutomovel grupo2 = CriarGrupo();

            Automovel automovel1 =
                new Automovel("Gol1", "Ford", "Branco", "Preto", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo1);
            controlador.InserirNovo(automovel1);

            Automovel automovel2 =
                new Automovel("Gol2", "Ford", "Branco", "Preto", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo2);
            controlador.InserirNovo(automovel2);

            Automovel automovel3 =
                new Automovel("Gol3", "Ford", "Branco", "Preto", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo1);
            controlador.InserirNovo(automovel3);

            Automovel automovel4 =
                new Automovel("Gol4", "Ford", "Branco", "Preto", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo2);
            controlador.InserirNovo(automovel4);

            var automoveis = controlador.SelecionarTodos();

            automoveis.Should().HaveCount(4);
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

            return novoGrupo;
        }
    }
}
