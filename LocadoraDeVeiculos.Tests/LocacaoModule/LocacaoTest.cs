using FluentAssertions;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoTest
    {
        Automovel automovel = null;
        Funcionario funcionario = null;
        PessoaFisica condutor = null;

        public LocacaoTest()
        {
            GrupoAutomovel grupo = CriarGrupo();
            automovel = new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);
            funcionario = new Funcionario("Pedro", new DateTime(2020,01,01), 5000, "senha");
            condutor = new PessoaFisica("Pedro","12365498710","1321654","9876543216497", new DateTime(2027,10,10), "9874654321","rua lages", null);
        }

        [TestMethod]
        public void DeveValidarCondutor()
        {
            Locacao locacao = new Locacao(null, automovel, funcionario, DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000);

            string resultadoValidacao = locacao.Validar();

            resultadoValidacao.Should().Be("Selecione um condutor");
        }

        [TestMethod]
        public void DeveValidarAutomovel()
        {
            Locacao locacao = new Locacao(condutor, null, funcionario, DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000);

            string resultadoValidacao = locacao.Validar();

            resultadoValidacao.Should().Be("Selecione um automóvel");
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
