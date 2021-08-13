using FluentAssertions;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraDeVeiculos.Tests.PessoaFisicaModule
{
    [TestClass]
    [TestCategory("Dominio")]
    public class PessoaFisicaTest
    {
        [TestMethod]
        public void DeveCriar_PessoaJuridica()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02","12.098.098-02", "123456789123", new DateTime(2022, 02,20), "(49)000000000", "Lagi", pessoaJuridica);

            //assert
            pessoaFisica.Nome.Should().Be("Matheus");
            pessoaFisica.CPF.Should().Be("123.456.789-02");
            pessoaFisica.RG.Should().Be("12.098.098-02");
            pessoaFisica.CNH.Should().Be("123456789123");
            pessoaFisica.Telefone.Should().Be("(49)000000000");
            pessoaFisica.Endereco.Should().Be("Lagi");
            pessoaFisica.PessoaJuridica.Should().Be(pessoaJuridica);
            pessoaFisica.VencimentoCNH.Should().Be(new DateTime(2022, 02, 20));
        }

        [TestMethod]
        public void DeveRetornar_PessoaJuridicaValida()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02", "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", pessoaJuridica);

            //assert
            pessoaFisica.Validar().Should().Be("ESTA_VALIDO");
        }
    }
}
