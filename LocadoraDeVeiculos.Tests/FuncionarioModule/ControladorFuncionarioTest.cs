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
    }
}
