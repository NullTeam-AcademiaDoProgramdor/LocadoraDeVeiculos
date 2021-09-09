using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace LocadoraDeVeiculos.Tests.AutomovelModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class AutomovelTest
    {
        [TestMethod]
        public void DeveCriar_Automovel()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0,30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            automovel.Modelo.Should().Be("Gol");
            automovel.Marca.Should().Be("Ford");
            automovel.Cor.Should().Be("Branco");
            automovel.Placa.Should().Be("ABCD123");
            automovel.Chassi.Should().Be("12YG2J31G23H123");

            automovel.Ano.Should().Be(2020);
            automovel.Portas.Should().Be(4);
            automovel.CapacidadeTanque.Should().Be(100);
            automovel.TamanhoPortaMalas.Should().Be(30);

            automovel.TipoCombustivel.Should().Be(TipoCombustivelEnum.Gasolina);
            automovel.Cambio.Should().Be(CambioEnum.Manual);
            automovel.Direcao.Should().Be(DirecaoEnum.Mecanica);

            automovel.Grupo.Should().Be(grupo);
        }

        [TestMethod]
        public void DeveRetornar_AutomovelValido()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Modelo()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0,30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("O campo Modelo é obrigatorio");
        }

        [TestMethod]
        public void DeveValidar_Marca()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", null, "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("O campo Marca é obrigatorio");
        }

        [TestMethod]
        public void DeveValidar_Cor()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", null, "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("O campo Cor é obrigatorio");
        }

        [TestMethod]
        public void DeveValidar_Placa()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", null, "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("O campo Placa é obrigatorio");
        }

        [TestMethod]
        public void DeveValidar_Chassi()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", null,
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("O campo Chassi é obrigatorio");
        }

        [TestMethod]
        public void DeveValidar_AnoMuitoAntigo()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                1874, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be($"O Ano informado é muito antigo, você pode inserir carros de {PegarAnoFuturoValido()} até 1900");
        }

        [TestMethod]
        public void DeveValidar_AnoMuitoNovo()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2025, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be($"O ano informado é muito futuro, você pode inserir carros de {PegarAnoFuturoValido()} até 1900");
        }

        [TestMethod]
        public void DeveValidar_NumeroDePortas()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 0, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("O Numero de portas não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_CapacidadeDoTanque()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 0, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("A capacidade do tanque não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_TamanhoPortaMalas()
        {
            GrupoAutomovel grupo = CriarGrupo();
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 0, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            var resultado = automovel.Validar();

            resultado.Should().Be("O tamanho do porta malas não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_Grupo()
        {
            Automovel automovel =
                new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, null);

            var resultado = automovel.Validar();

            resultado.Should().Be("O Automovel obrigatoriamente precisa fazer parte de um Grupo");
        }

        private int PegarAnoFuturoValido()
        {
            return DateTime.Now.AddYears(1).Year;
        }

        private GrupoAutomovel CriarGrupo()
        {
            GrupoAutomovel novoGrupo = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            return novoGrupo;
        }
    }
}
