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
using LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule;
using LocadoraDeVeículos.Aplicacao.LocacaoModule;
using LocadoraDeVeículos.Aplicacao.AutomovelModule;
using LocadoraDeVeículos.Aplicacao.PessoaFisicaModule;
using LocadoraDeVeículos.Aplicacao.FuncionarioModule;
using LocadoraDeVeículos.Infra.SQL.TaxasEServicosModule;
using LocadoraDeVeículos.Infra.SQL.LocacaoModule;
using LocadoraDeVeículos.Infra.SQL.AutomovelModule;
using LocadoraDeVeículos.Infra.SQL.GrupoAutomovelModule;
using LocadoraDeVeículos.Infra.SQL.FuncionarioModule;
using LocadoraDeVeículos.Infra.SQL.PessoaFisicaModule;
using LocadoraDeVeículos.Aplicacao.TaxaEServicoModule;
using LocadoraDeVeículos.Aplicacao.RequisicaoEmailModule;
using LocadoraDeVeículos.Infra.SQL.RequisicaoEmailModule;
using LocadoraDeVeículos.Infra.SQL.CupomModule;
using LocadoraDeVeículos.Infra.PDF.PDFModule;
using LocadoraDeVeiculos.Infra.ORM.TaxaEServicoModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.AutomovelModule;

namespace LocadoraDeVeiculos.Tests.LocacaoModule
{
    [TestClass]
    public class TaxaEServicoUsadoDaoTest
    {
        TaxaEServicoAppService controladorTaxasEServicos;

        LocacaoAppService controladorLocacao;
        GrupoAutomovelAppService ctrlGrupo;
        AutomovelAppService ctrlAutomovel;
        FuncionarioAppService ctrlFuncionario;
        PessoaFisicaAppService ctrlCondutor;
        DBLocadoraContext db;

        GrupoAutomovel grupo;
        Automovel automovel = null;
        Funcionario funcionario = null;
        PessoaFisica condutor = null;

        public TaxaEServicoUsadoDaoTest()
        {
            EmailAppService.GetInstance(new RequisicaoEmailDao());

            this.controladorTaxasEServicos = new(new TaxasEServicosDao());
            this.controladorLocacao = new(
                    new LocacaoDao(),
                    new TaxasEServicosUsadosDao(),
                    new CupomDao(),
                    new GeradorPDF(),
                    EmailAppService.GetInstance());
            this.ctrlAutomovel = new(new AutomovelDao(), new FotosAutomovelDao());
            this.ctrlGrupo = new(new GrupoAutomovelDao(), null);
            //this.ctrlFuncionario = new(new FuncionarioDao());
            this.ctrlCondutor = new(new PessoaFisicaDao());

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

            db.SaveChanges();

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

            db.SaveChanges();

            Locacao novaLocacao = GerarLocacao();

            controladorLocacao.Editar(locacao.Id, novaLocacao);

            db.SaveChanges();

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

            db.SaveChanges();

            Locacao locacao = GerarLocacao(taxa1, taxa2, taxa3);

            controladorLocacao.InserirNovo(locacao);

            db.SaveChanges();

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

            db.SaveChanges();

            Locacao locacao = GerarLocacao(taxa1, taxa2, taxa3);

            controladorLocacao.InserirNovo(locacao);

            db.SaveChanges();

            Locacao novaLocacao = GerarLocacao();

            controladorLocacao.Editar(locacao.Id, novaLocacao);

            db.SaveChanges();

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

            db.SaveChanges();

            Locacao locacao = GerarLocacao(taxa1);

            controladorLocacao.InserirNovo(locacao);

            db.SaveChanges();

            Locacao novaLocacao = GerarLocacao(taxa2);

            controladorLocacao.Editar(locacao.Id, novaLocacao);

            db.SaveChanges();

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

            db.SaveChanges();

            Locacao locacao = GerarLocacao(taxa1, taxa2, taxa3);

            controladorLocacao.InserirNovo(locacao);

            db.SaveChanges();

            Locacao novaLocacao = GerarLocacao(taxa2, taxa3, taxa4);

            controladorLocacao.Editar(locacao.Id, novaLocacao);

            db.SaveChanges();

            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.id);

            locacaoEncontrada.TaxasEServicos.Should().HaveCount(3);
        }

        private Automovel CriarAutomovel(GrupoAutomovel grupo)
        {
            var automovel = new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);
            ctrlAutomovel.InserirNovo(automovel);
            db.SaveChanges();
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
            db.SaveChanges();
            return novoGrupo;
        }
        private Funcionario CriarFuncionario()
        {
            var funcionario = new Funcionario("Pedro", new DateTime(2020, 01, 01), 5000,
                            "senha");
            ctrlFuncionario.InserirNovo(funcionario);
            db.SaveChanges();
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
