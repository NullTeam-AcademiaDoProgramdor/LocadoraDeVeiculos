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
        ControladorFuncionario controlador = null;

        public FuncionarioTest()
        {
            controlador = new ControladorFuncionario();
            Db.Update(@"DELETE FROM FUNCIONARIO");
        }

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
    }
}
