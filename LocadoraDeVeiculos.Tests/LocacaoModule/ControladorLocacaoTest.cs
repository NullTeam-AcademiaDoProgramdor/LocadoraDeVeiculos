using FluentAssertions;
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Tests.LocacaoModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorLocacaoTest
    {
        ControladorLocacao controladorLocacao;
        ControladorGrupoAutomovel ctrlGrupo;
        ControladorAutomovel ctrlAutomovel;
        ControladorFuncionario ctrlFuncionario;
        ControladorPessoaFisica ctrlCondutor;
        GrupoAutomovel grupo;
        Automovel automovel = null;
        Funcionario funcionario = null;
        PessoaFisica condutor = null;

        public ControladorLocacaoTest()
        {
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
            Db.Update("DELETE FROM [LOCACAO]");
            Db.Update("DELETE FROM [PESSOAFISICA]");
            Db.Update("DELETE FROM [AUTOMOVEL]");
            Db.Update("DELETE FROM [GRUPOAUTOMOVEL]");
            Db.Update("DELETE FROM [FUNCIONARIO]");
        }

        [TestMethod]
        public void DeveInserir_Locacao()
        {
            //arrange
            Locacao locacao = new Locacao(condutor, automovel, funcionario,
                DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000);


            //action
            controladorLocacao.InserirNovo(locacao);

            //assert
            var locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveEditar_Locacao()
        {
            //arrange
            Locacao locacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000);
            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(2), 1000, 50000);
        
            //action
            controladorLocacao.Editar(locacao.Id, novaLocacao);

            //assert
            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().Be(novaLocacao);
        }


        [TestMethod]
        public void DeveDevolver_Locacao()
        {
            //arrange
            Locacao locacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000);
            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000, 1, 600000, 10, DateTime.Today.AddDays(1));


            //action
            controladorLocacao.Devolver(locacao.Id, novaLocacao);

            //assert
            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().Be(novaLocacao);
        }

        [TestMethod]
        public void DeveEditar_KmRegistrada()
        {
            Locacao locacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000);
            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000, 1, 100, 10, DateTime.Today.AddDays(1));

            controladorLocacao.Devolver(locacao.id, novaLocacao);  

            controladorLocacao.EditarKmRegistrada(novaLocacao);           

            Automovel automovelEncontrado = ctrlAutomovel.SelecionarPorId(automovel.id);          

            automovelEncontrado.KmRegistrada.Should().Be(100);
        }


        [TestMethod]
        public void DeveSelecionar_Locacao_PorId()
        {
            //arrange
            Locacao locacao = new Locacao(condutor, automovel, funcionario,
                DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000);
            controladorLocacao.InserirNovo(locacao);

            //action
            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);

            //assert
            locacaoEncontrada.Should().NotBeNull();
        }


        [TestMethod]
        public void DeveSelecionar_TodasLocacoes()
        {
            //arrange
            var locacoes = new List<Locacao>
            {
                new Locacao(condutor, automovel, funcionario,
                    DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000),


                new Locacao(condutor, automovel, funcionario,
                    DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000),

            };

            foreach (var loc in locacoes)
                controladorLocacao.InserirNovo(loc);

            //action
            var locacoesEncontradas = controladorLocacao.SelecionarTodos();

            //assert
            locacoesEncontradas.Should().HaveCount(2);
        }

        [TestMethod]
        public void DeveExcluir_UmaLocacao()
        {
            //arrange            
            Locacao locacao = new Locacao(condutor, automovel, funcionario,
                    DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000);

            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000, 1, 600000, 10, DateTime.Today.AddDays(1));

            controladorLocacao.Devolver(locacao.Id, novaLocacao);

            //action            
            controladorLocacao.Excluir(locacao.Id);

            //assert
            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().BeNull();
        }

        private Automovel CriarAutomovel(GrupoAutomovel grupo)
        {
            var automovel = new Automovel("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, grupo);
            ctrlAutomovel.InserirNovo(automovel);
            return automovel;
            
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
                "(49)000000000", "Lagi", null);
            ctrlCondutor.InserirNovo(condutor);
            return condutor;
        }
    }
}
