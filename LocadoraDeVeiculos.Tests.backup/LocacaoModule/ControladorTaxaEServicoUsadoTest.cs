using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Controladores.TaxasEServicosModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace LocadoraDeVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class ControladorTaxaEServicoUsadoTest
    {
        ControladorTaxasEServicos controladorTaxasEServicos;
        ControladorLocacao controladorLocacao;
        ControladorGrupoAutomovel ctrlGrupo;
        ControladorAutomovel ctrlAutomovel;
        ControladorFuncionario ctrlFuncionario;
        ControladorPessoaFisica ctrlCondutor;
        GrupoAutomovel grupo;
        Automovel automovel = null;
        Funcionario funcionario = null;
        PessoaFisica condutor = null;

        public ControladorTaxaEServicoUsadoTest()
        {
            this.controladorTaxasEServicos = new ControladorTaxasEServicos();
            this.controladorLocacao = new ControladorLocacao();
            this.ctrlAutomovel = new ControladorAutomovel();
            this.ctrlGrupo = new ControladorGrupoAutomovel();
            this.ctrlFuncionario = new ControladorFuncionario();
            this.ctrlCondutor = new ControladorPessoaFisica();

            grupo = CriarGrupo();
            automovel = CriarAutomovel(grupo);
            funcionario = CriarFuncionario();
            condutor = CriarCondutor();
        }

        [TestCleanup()]
        public void LimparTestes()
        {
            Db.Update("DELETE FROM [TaxasEServicosUsadas]");
            Db.Update("DELETE FROM [TAXAESERVICO]");
            Db.Update("DELETE FROM [LOCACAO]");
            Db.Update("DELETE FROM [PESSOAFISICA]");
            Db.Update("DELETE FROM [AUTOMOVEL]");
            Db.Update("DELETE FROM [GRUPOAUTOMOVEL]");
            Db.Update("DELETE FROM [FUNCIONARIO]");
        }

        [TestMethod]
        public void DeveInserir_UmaTaxa()
        {
            TaxaEServico taxa1 = new TaxaEServico("teste1", 12, false);
            controladorTaxasEServicos.InserirNovo(taxa1);

            Locacao locacao = GerarLocacao(taxa1);

            controladorLocacao.InserirNovo(locacao);

            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.id);

            locacaoEncontrada.TaxasEServicos.Should().HaveCount(1);
        }

        [TestMethod]
        public void DeveExcluir_UmaTaxa()
        {
            TaxaEServico taxa1 = new TaxaEServico("teste1", 12, false);
            controladorTaxasEServicos.InserirNovo(taxa1);

            Locacao locacao = GerarLocacao(taxa1);

            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = GerarLocacao();

            controladorLocacao.Editar(locacao.Id, novaLocacao);

            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.id);

            locacaoEncontrada.TaxasEServicos.Should().HaveCount(0);
        }

        [TestMethod]
        public void DeveInserir_VariasTaxa()
        {
            TaxaEServico taxa1 = new TaxaEServico("teste1", 12, false);
            TaxaEServico taxa2 = new TaxaEServico("teste2", 12, false);
            TaxaEServico taxa3 = new TaxaEServico("teste3", 12, false);

            controladorTaxasEServicos.InserirNovo(taxa1);
            controladorTaxasEServicos.InserirNovo(taxa2);
            controladorTaxasEServicos.InserirNovo(taxa3);

            Locacao locacao = GerarLocacao(taxa1, taxa2, taxa3);

            controladorLocacao.InserirNovo(locacao);

            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.id);

            locacaoEncontrada.TaxasEServicos.Should().HaveCount(3);
        }

        [TestMethod]
        public void DeveExcluir_VariasTaxa()
        {
            TaxaEServico taxa1 = new TaxaEServico("teste1", 12, false);
            TaxaEServico taxa2 = new TaxaEServico("teste2", 12, false);
            TaxaEServico taxa3 = new TaxaEServico("teste3", 12, false);

            controladorTaxasEServicos.InserirNovo(taxa1);
            controladorTaxasEServicos.InserirNovo(taxa2);
            controladorTaxasEServicos.InserirNovo(taxa3);

            Locacao locacao = GerarLocacao(taxa1, taxa2, taxa3);

            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = GerarLocacao();

            controladorLocacao.Editar(locacao.Id, novaLocacao);

            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.id);

            locacaoEncontrada.TaxasEServicos.Should().HaveCount(0);
        }

        [TestMethod]
        public void DeveModificar_UmaTaxa()
        {
            TaxaEServico taxa1 = new TaxaEServico("teste1", 12, false);
            TaxaEServico taxa2 = new TaxaEServico("teste2", 12, false);

            controladorTaxasEServicos.InserirNovo(taxa1);
            controladorTaxasEServicos.InserirNovo(taxa2);

            Locacao locacao = GerarLocacao(taxa1);

            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = GerarLocacao(taxa2);

            controladorLocacao.Editar(locacao.Id, novaLocacao);

            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.id);

            locacaoEncontrada.TaxasEServicos.Should().HaveCount(1);
        }

        [TestMethod]
        public void DeveModificar_VariasTaxa()
        {
            TaxaEServico taxa1 = new TaxaEServico("teste1", 12, false);
            TaxaEServico taxa2 = new TaxaEServico("teste2", 12, false);
            TaxaEServico taxa3 = new TaxaEServico("teste3", 12, false);
            TaxaEServico taxa4 = new TaxaEServico("teste4", 12, false);

            controladorTaxasEServicos.InserirNovo(taxa1);
            controladorTaxasEServicos.InserirNovo(taxa2);
            controladorTaxasEServicos.InserirNovo(taxa3);
            controladorTaxasEServicos.InserirNovo(taxa4);

            Locacao locacao = GerarLocacao(taxa1, taxa2, taxa3);

            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = GerarLocacao(taxa2, taxa3, taxa4);

            controladorLocacao.Editar(locacao.Id, novaLocacao);

            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.id);

            locacaoEncontrada.TaxasEServicos.Should().HaveCount(3);
        }

        private Automovel CriarAutomovel(GrupoAutomovel grupo)
        {
            var automovel = new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);
            ctrlAutomovel.InserirNovo(automovel);
            return automovel;

        }

        private Locacao GerarLocacao(params TaxaEServico[] taxas) 
        {
            Locacao locacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(1), 1000, 1, taxas);

            return locacao;
        }

        private GrupoAutomovel CriarGrupo()
        {
            GrupoAutomovel novoGrupo = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );
            ctrlGrupo.InserirNovo(novoGrupo);
            return novoGrupo;
        }
        private Funcionario CriarFuncionario()
        {
            var funcionario = new Funcionario("Pedro", new DateTime(2020, 01, 01), 5000,
                            "senha");
            ctrlFuncionario.InserirNovo(funcionario);
            return funcionario;
        }
        private PessoaFisica CriarCondutor()
        {
            PessoaFisica condutor = new PessoaFisica("Matheus", "123.456.789-02",
                "12.098.098-02", "123456789123", new DateTime(2022, 02, 20),
                "(49)000000000", "Lagi", null, "aaaaa@gmail.com");
            ctrlCondutor.InserirNovo(condutor);
            return condutor;
        }
    }
}
