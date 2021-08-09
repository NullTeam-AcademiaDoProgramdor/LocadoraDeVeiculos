using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace LocadoraDeVeiculos.Tests.GrupoAutomovelModule
{
    [TestClass]
    public class GrupoAutomovelTest
    {
        [TestMethod]
        [TestCategory("Dominio")]
        public void DeveCriar_GrupoAutomovel()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            grupoAutomovel.Nome.Should().Be("Economicos");

            grupoAutomovel.PlanoDiario.PrecoDia.Should().Be(150);
            grupoAutomovel.PlanoDiario.PrecoKm.Should().Be(5);

            grupoAutomovel.PlanoKmControlado.PrecoDia.Should().Be(100);
            grupoAutomovel.PlanoKmControlado.PrecoKmExtrapolado.Should().Be(15);
            grupoAutomovel.PlanoKmControlado.KmDisponiveis.Should().Be(100);

            grupoAutomovel.PlanoKmLivre.PrecoDia.Should().Be(300);
        }

        [TestMethod]
        public void DeveRetornar_GrupoAutomovelValido()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            var resultado = grupoAutomovel.Validar();

            resultado.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_Nome()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            var resultado = grupoAutomovel.Validar();

            resultado.Should().Be("O campo nome é obrigatorio");
        }

        [TestMethod]
        public void DeveValidar_PlanoDiario_PrecoDia()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(0, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            var resultado = grupoAutomovel.Validar();

            resultado.Should().Be("O campo Preco Dia do Plano Diario não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_PlanoDiario_PrecoKm()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 0),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            var resultado = grupoAutomovel.Validar();

            resultado.Should().Be("O campo Preco Km do Plano Diario não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_PlanoKmControlado_PrecoDia()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(0, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            var resultado = grupoAutomovel.Validar();

            resultado.Should().Be("O campo Preco Dia do Plano Km Controlado não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_PlanoKmControlado_PrecokmExtrapolado()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 0, 100),
                new PlanoKmLivreStruct(300)
            );

            var resultado = grupoAutomovel.Validar();

            resultado.Should().Be("O campo Preco Km Extrapolado do Plano Km Controlado não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_PlanoKmControlado_KmDisponiveis()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 0),
                new PlanoKmLivreStruct(300)
            );

            var resultado = grupoAutomovel.Validar();

            resultado.Should().Be("O campo Km Disponivel do Plano Km Controlado não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_PlanoKmLivre_PrecoDia()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(0)
            );

            var resultado = grupoAutomovel.Validar();

            resultado.Should().Be("O campo Preco Dia do Plano Km Livre não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidar_QuebraDeLinha_Nome_PlanoDiarioPrecoDia()
        {
            GrupoAutomovel grupoAutomovel = new GrupoAutomovel(
                "",
                new PlanoDiarioStruct(0, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(200)
            );

            var resultado = grupoAutomovel.Validar();

            var resultadoEsperado =
                "O campo nome é obrigatorio"
                + Environment.NewLine
                + "O campo Preco Dia do Plano Diario não pode ser 0 ou negativo";

            resultado.Should().Be(resultadoEsperado);
        }
    }
}
