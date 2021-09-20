using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.RelatorioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using LocadoraDeVeiculos.Infra.Configuracoes;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;

namespace LocadoraDeVeiculos.Tests.RelatorioModule
{
    [TestClass]
    public class RelatorioTest
    {
        [TestMethod]
        public void DeveCalcular_parcial_planoDiario()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 10),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231", 
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 0);


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().BeNull();
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull(); 
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().BeNull();
            relatorio.ValorParaAbastecer.Should().BeNull();

            relatorio.TotalAPagar.Should().Be(60);
        }

        [TestMethod]
        public void DeveCalcular_total_planoDiario()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 10),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 150, 0, 200, 100, DateTime.Now.AddDays(5));


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().Be(50);
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().Be(500);
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(560);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().Be(0);
            relatorio.ValorParaAbastecer.Should().Be(0);

            relatorio.TotalAPagar.Should().Be(560);
        }


        [TestMethod]
        public void DeveCalcular_parcial_planoKmControlado()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 100),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 1);


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().BeNull();
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().BeNull();
            relatorio.ValorParaAbastecer.Should().BeNull();

            relatorio.TotalAPagar.Should().Be(60);
        }

        [TestMethod]
        public void DeveCalcular_total_planoKmControlado()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 100),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 100, 100, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 150, 1, 800, 100, DateTime.Now.AddDays(5));


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().Be(700);
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().Be(1000);
            relatorio.SubTotalPlanos.Should().Be(1060);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().Be(0);
            relatorio.ValorParaAbastecer.Should().Be(0);

            relatorio.TotalAPagar.Should().Be(1060);
        }

        [TestMethod]
        public void DeveCalcular_parcial_planoLivre()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
               new PlanoDiarioStruct(10, 10),
               new PlanoKmControladoStruct(10, 10, 10),
               new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 2);


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().BeNull();
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().BeNull();
            relatorio.ValorParaAbastecer.Should().BeNull();

            relatorio.TotalAPagar.Should().Be(60);
        }

        [TestMethod]
        public void DeveCalcular_total_planoLivre()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 10),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 150, 2, 200, 100, DateTime.Now.AddDays(5));


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().Be(50);
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().Be(0);
            relatorio.ValorParaAbastecer.Should().Be(0);

            relatorio.TotalAPagar.Should().Be(60);
        }

        [TestMethod]
        public void DeveCalcular_gasolina_APagar()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 10),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 150, 2, 200, 50, DateTime.Now.AddDays(5));

            Configuracao.PrecoGasolina = 10;


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().Be(50);
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().Be(50);
            relatorio.ValorParaAbastecer.Should().Be(500);

            relatorio.TotalAPagar.Should().Be(560);
        }

        [TestMethod]
        public void DeveCalcular_diesel_APagar()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 10),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Diesel, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 150, 2, 200, 50, DateTime.Now.AddDays(5));

            Configuracao.PrecoDiesel = 100;


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().Be(50);
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().Be(50);
            relatorio.ValorParaAbastecer.Should().Be(5000);

            relatorio.TotalAPagar.Should().Be(5060);
        }

        [TestMethod]
        public void DeveCalcular_gas_APagar()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 10),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Gas, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 150, 2, 200, 50, DateTime.Now.AddDays(5));

            Configuracao.PrecoGas = 1000;


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().Be(50);
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().Be(50);
            relatorio.ValorParaAbastecer.Should().Be(50000);

            relatorio.TotalAPagar.Should().Be(50060);
        }

        [TestMethod]
        public void DeveCalcular_alcool_APagar()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 10),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Alcool, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 150, 2, 200, 50, DateTime.Now.AddDays(5));

            Configuracao.PrecoAlcool = 10000;


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().Be(50);
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(0);
            relatorio.SubTotalAdicionaisFixos.Should().Be(0);
            relatorio.LitrosParaEncher.Should().Be(50);
            relatorio.ValorParaAbastecer.Should().Be(500000);

            relatorio.TotalAPagar.Should().Be(500060);
        }

        [TestMethod]
        public void DeveCalcular_taxas_APagar()
        {
            GrupoAutomovel grupo = new GrupoAutomovel("a",
                new PlanoDiarioStruct(10, 10),
                new PlanoKmControladoStruct(10, 10, 10),
                new PlanoKmLivreStruct(10));

            Automovel automovel = new Automovel("T", "T", "T", "T", "T", 2020, 4,
                100, 150, 100, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);

            PessoaFisica pessoaFisica = new PessoaFisica("a", "123", "123", "31231",
                DateTime.Now, "2313", "34423423", null, "aaaaa@gmail.com");

            Funcionario funcionario = new Funcionario("24243", DateTime.Now, 123123, "12312");

            TaxaEServico taxa1 = new TaxaEServico("1", 5, false);
            TaxaEServico taxa2 = new TaxaEServico("2", 5, false);
            TaxaEServico taxa3 = new TaxaEServico("3", 10, true);
            TaxaEServico taxa4 = new TaxaEServico("4", 10, true);

            Locacao locacao = new Locacao(pessoaFisica, automovel, funcionario, DateTime.Now,
                DateTime.Now.AddDays(5), 1000, 150, 2, 200, 50, DateTime.Now.AddDays(5),
                new TaxaEServico[] { taxa1, taxa2, taxa3, taxa4});

            Configuracao.PrecoGasolina = 10;


            Relatorio relatorio = new Relatorio(locacao);

            relatorio.DiasAlugados.Should().Be(6);
            relatorio.KmsAlugados.Should().Be(50);
            relatorio.TaxaDiariaTotal.Should().Be(60);
            relatorio.TaxaKmTotal.Should().BeNull();
            relatorio.TaxaKmExtrapoladadaTotal.Should().BeNull();
            relatorio.SubTotalPlanos.Should().Be(60);
            relatorio.SubTotalAdicionaisDia.Should().Be(60);
            relatorio.SubTotalAdicionaisFixos.Should().Be(20);
            relatorio.LitrosParaEncher.Should().Be(50);
            relatorio.ValorParaAbastecer.Should().Be(500);

            relatorio.TotalAPagar.Should().Be(640);
        }

    }
}
