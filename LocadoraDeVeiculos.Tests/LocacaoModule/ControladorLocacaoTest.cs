using FluentAssertions;
using LocadoraDeVeiculos.Controladores.AutomovelModule;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.GrupoAutomovelModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
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

        [TestMethod]
        public void DeveInserir_Locacao()
        {
            //arrange
            Locacao locacao = new Locacao(condutor, automovel, funcionario,
                DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000, 1);


            //action
            controladorLocacao.InserirNovo(locacao);

            //assert
            var locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveEditar_PessoaFisica()
        {
            //arrange
            Locacao locacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000, 1);
            controladorLocacao.InserirNovo(locacao);

            Locacao novaLocacao = new Locacao(condutor, automovel, funcionario
                , DateTime.Today, DateTime.Today.AddDays(2), 1000, 50000, 1);
            controladorLocacao.InserirNovo(locacao);
            //action
            controladorLocacao.Editar(locacao.Id, novaLocacao);

            //assert
            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().Be(novaLocacao);
        }

        [TestMethod]
        public void DeveSelecionar_PessoaFisica_PorId()
        {
            //arrange
            Locacao locacao = new Locacao(condutor, automovel, funcionario,
                DateTime.Today, DateTime.Today.AddDays(1), 1000, 50000, 1);
            controladorLocacao.InserirNovo(locacao);

            //action
            Locacao locacaoEncontrada = controladorLocacao.SelecionarPorId(locacao.Id);

            //assert
            locacaoEncontrada.Should().NotBeNull();
        }

        private Automovel CriarAutomovel(GrupoAutomovel grupo)
        {
            var automovel = new Automovel("Gol", "Ford", "Branco", "ABCD123",
                            "12YG2J31G23H123",
                            2020, 4, 100, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
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
