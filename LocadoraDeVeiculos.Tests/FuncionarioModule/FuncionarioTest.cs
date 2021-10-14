using FluentAssertions;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.FuncionarioModule
{
    [TestClass]
    public class FuncionarioTest
    {
        [TestMethod]
        public void DeveRetornarFuncionarioValido()
        {
            var funcionario = new Funcionario("Pedro", new DateTime(2020, 01, 01), 1000, "password");

            var resultado = funcionario.Validar();

            resultado.Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidarDataAdmissao()
        {
            var funcionario = new Funcionario("Pedro", DateTime.Today.AddDays(1), 1000, "password");

            var resultado = funcionario.Validar();

            resultado.Should().Be("O campo data de admissão não pode ser no futuro");
        }

        [TestMethod]
        public void DeveValidarNome()
        {
            var funcionario = new Funcionario("", DateTime.Today, 1000, "password");

            var resultado = funcionario.Validar();

            resultado.Should().Be("O campo nome é obrigatório");
        }

        [TestMethod]
        public void DeveValidarNomeAdmin()
        {
            var funcionario = new Funcionario("Admin", DateTime.Today, 1000, "password");

            var resultado = funcionario.Validar();

            resultado.Should().Be("Não é possível cadastrar um funcionário com este nome");
        }

        [TestMethod]
        public void DeveValidarSenha()
        {
            var funcionario = new Funcionario("Pedro", DateTime.Today, 1000, "");

            var resultado = funcionario.Validar();

            resultado.Should().Be("O campo senha é obrigatório");
        }

        [TestMethod]
        public void DeveValidarSalario()
        {
            var funcionario = new Funcionario("Pedro", DateTime.Today, 0, "password");

            var resultado = funcionario.Validar();

            resultado.Should().Be("O campo Salário não pode ser 0 ou negativo");
        }

        [TestMethod]
        public void DeveValidarNome_Senha_Salario()
        {
            var funcionario = new Funcionario("", DateTime.Today, 0, "");

            var resultado = funcionario.Validar();

            resultado.Should().Be("O campo nome é obrigatório" +
                Environment.NewLine +
                "O campo senha é obrigatório" +
                Environment.NewLine +
                "O campo Salário não pode ser 0 ou negativo");
        }

    }
}