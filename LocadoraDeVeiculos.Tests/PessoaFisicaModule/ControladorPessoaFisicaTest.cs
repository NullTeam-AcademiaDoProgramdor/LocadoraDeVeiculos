using FluentAssertions;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.PessoaFisicaModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class ControladorPessoaFisicaTest
    {
        ControladorPessoaFisica controlador;
        ControladorPessoaJuridica controladorPJuridica;

        public ControladorPessoaFisicaTest()
        {
            controlador = new ControladorPessoaFisica();
            controladorPJuridica = new ControladorPessoaJuridica();
            Db.Update("DELETE FROM [PESSOAFISICA]");
            Db.Update("DELETE FROM [PESSOAJURIDICA]");
        }

        [TestMethod]
        public void DeveInserir_PessoaFisica()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            controladorPJuridica.InserirNovo(pessoaJuridica);

            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", pessoaJuridica);

            //action
            controlador.InserirNovo(pessoaFisica);

            //assert
            var pessoaFisicaEncontrada = controlador.SelecionarPorId(pessoaFisica.Id);
            pessoaFisicaEncontrada.Should().Be(pessoaFisica);
        }
    }
}
