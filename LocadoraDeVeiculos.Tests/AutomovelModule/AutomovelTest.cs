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
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
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
