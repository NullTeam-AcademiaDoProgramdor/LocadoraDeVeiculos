using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;


namespace LocadoraDeVeiculos.Tests.FuncionarioModule
{
    [TestClass]
    public class ControladorFuncionarioTest
    {
        ControladorFuncionario controlador = null;

        public ControladorFuncionarioTest()
        {
            controlador = new ControladorFuncionario();
            Db.Update(@"DELETE FROM FUNCIONARIO");
        }

        [TestMethod]
        public void DeveInserirFuncionario()
        {
            var novoFuncionario = new Funcionario("Pedro", new DateTime(2020,01,01), 1000, "password");

            controlador.InserirNovo(novoFuncionario);

            var funcionarioEncontrado = controlador.SelecionarPorId(novoFuncionario.Id);
            funcionarioEncontrado.Should().Be(novoFuncionario);
        }

        [TestMethod]
        public void DeveAtualizarFuncionario()
        {
            var funcionario = new Funcionario("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(funcionario);
            var novoFuncionario = new Funcionario("João", new DateTime(2021, 02, 02), 5000, "p4ssw0rd");

            controlador.Editar(funcionario.Id, novoFuncionario);

            var funcionarioAtualizado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Should().Be(novoFuncionario);
        }

        [TestMethod]
        public void DeveExcluirFuncionario()
        {
            var funcionario = new Funcionario("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(funcionario);

            controlador.Excluir(funcionario.Id);

            var funcionarioExcluido = controlador.SelecionarPorId(funcionario.Id);
            funcionarioExcluido.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarFuncionarioPorId()
        {
            var funcionario = new Funcionario("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(funcionario);

            var funcionarioEncontrado = controlador.SelecionarPorId(funcionario.Id);

            funcionarioEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionarFuncionarioPorNomeESenha()
        {
            var funcionario = new Funcionario("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(funcionario);

            var funcionarioEncontrado = controlador.SelecionarPorNomeESenha(funcionario.Nome, funcionario.Senha);

            funcionarioEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionarTodosFuncionarios()
        {
            var f1 = new Funcionario("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(f1);

            var f2 = new Funcionario("João", new DateTime(2021, 02, 03), 5000, "senha");
            controlador.InserirNovo(f2);

            var f3 = new Funcionario("Eduardo", new DateTime(2021, 05, 08), 7000, "palavra passe");
            controlador.InserirNovo(f3);

            var funcionarios = controlador.SelecionarTodos();

            funcionarios.Should().HaveCount(3);
            funcionarios[0].Nome.Should().Be("Pedro");
            funcionarios[1].Nome.Should().Be("João");
            funcionarios[2].Nome.Should().Be("Eduardo");
        }
    }
}
