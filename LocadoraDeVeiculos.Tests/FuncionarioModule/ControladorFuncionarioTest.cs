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
    }
}
