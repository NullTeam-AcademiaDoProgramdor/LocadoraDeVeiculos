using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.Models;

namespace LocadoraDeVeiculos.Tests.FuncionarioModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class FuncionarioDaoTest
    {
        IRepositorFuncionarioBase controlador;
        private DBLocadoraContext db;
        public FuncionarioDaoTest()
        {
            db = new();
            controlador = new FuncionarioORMDao(db);
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update(@"DELETE FROM TBLOCACAO");
            Db.Update(@"DELETE FROM TBFUNCIONARIO");
        }

        [TestMethod]
        public void DeveInserirFuncionario()
        {
            Funcionario novoFuncionario = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");

            controlador.InserirNovo(novoFuncionario);
            db.SaveChanges();

            Funcionario funcionarioEncontrado = controlador.SelecionarPorId(novoFuncionario.Id);
            funcionarioEncontrado.Should().Be(novoFuncionario);
        }

        [TestMethod]
        public void DeveEditarFuncionario()
        {
            Funcionario funcionario = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(funcionario);
            db.SaveChanges();
            Funcionario novoFuncionario = new("João", new DateTime(2021, 02, 02), 5000, "p4ssw0rd");

            controlador.Editar(funcionario.Id, novoFuncionario);
            db.SaveChanges();

            Funcionario funcionarioAtualizado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Should().Be(novoFuncionario);
        }

        [TestMethod]
        public void DeveExcluirFuncionario()
        {
            Funcionario funcionario = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");

            controlador.InserirNovo(funcionario);
            db.SaveChanges();

            controlador.Excluir(funcionario.Id);
            db.SaveChanges();

            Funcionario funcionarioExcluido = controlador.SelecionarPorId(funcionario.Id);
            funcionarioExcluido.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarFuncionarioPorId()
        {
            Funcionario funcionario = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(funcionario);
            db.SaveChanges();

            Funcionario funcionarioEncontrado = controlador.SelecionarPorId(funcionario.Id);
            funcionarioEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionarFuncionarioPorNomeESenha()
        {
            Funcionario funcionario = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(funcionario);
            db.SaveChanges();

            Funcionario funcionarioEncontrado = controlador.SelecionarPorNomeESenha(funcionario.Nome, funcionario.Senha);

            funcionarioEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionarTodosFuncionarios()
        {
            Funcionario f1 = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");
            controlador.InserirNovo(f1);

            Funcionario f2 = new("João", new DateTime(2021, 02, 03), 5000, "senha");
            controlador.InserirNovo(f2);

            Funcionario f3 = new("Eduardo", new DateTime(2021, 05, 08), 7000, "palavra passe");
            controlador.InserirNovo(f3);
            db.SaveChanges();

            var funcionarios = controlador.SelecionarTodos();

            funcionarios.Should().HaveCount(3);
            funcionarios[0].Nome.Should().Be("Pedro");
            funcionarios[1].Nome.Should().Be("João");
            funcionarios[2].Nome.Should().Be("Eduardo");
        }
    }
}