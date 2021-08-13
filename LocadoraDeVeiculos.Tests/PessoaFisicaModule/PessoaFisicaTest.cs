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
        public void DeveCriar_PessoaFisica()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02", "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", pessoaJuridica);

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
        public void DeveRetornar_PessoaFisicaValida()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02", "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", pessoaJuridica);

            //assert
            pessoaFisica.Validar().Should().Be("ESTA_VALIDO");
        }

        [TestMethod]
        public void DeveValidar_PessoaFisicaComCamposNulos()
        {
            //action
            PessoaFisica pessoaFisica = new PessoaFisica(null, null, null, null, DateTime.MinValue, null, null, null);

            //assert
            string resultadoValidacao = "";

            resultadoValidacao = "O campo 'nome' não pode estar vazio."
                + Environment.NewLine
                + "O campo 'CPF' não pode estar vazio."
                + Environment.NewLine
                + "O campo 'RG' não pode estar vazio."
                + Environment.NewLine
                + "O campo 'CNH' não pode estar vazio."
                + Environment.NewLine
                + "O campo 'Telefone' não pode estar vazio."
                + Environment.NewLine
                + "O campo 'Endereço' não pode estar vazio."
                + Environment.NewLine
                + "O campo 'data de vencimento' não pode estar vazio.";
            pessoaFisica.Validar().Should().Be(resultadoValidacao);
        }

        [TestMethod]
        public void DeveValidar_CPFInvalido()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.-02", "12.098.098-02", "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", pessoaJuridica);

            //assert
            pessoaFisica.Validar().Should().Be("CPF inválido.");
        }
        [TestMethod]
        public void DeveValidar_RGInvalido()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "8.098-02", "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", pessoaJuridica);

            //assert
            pessoaFisica.Validar().Should().Be("RG inválido.");
        }
        [TestMethod]
        public void DeveValidar_CNHInvalido()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.128.098-02", "1789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", pessoaJuridica);

            //assert
            pessoaFisica.Validar().Should().Be("CNH inválida.");
        }
        [TestMethod]
        public void DeveValidar_DataVencimentoCNHInvalido()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.128.098-02", "172121891231", new DateTime(2020, 02, 20), "(49)000000000", "Lagi", pessoaJuridica);

            //assert
            pessoaFisica.Validar().Should().Be("A data de vencimento da CNH não pode ser aceita.");
        }
        
        [TestMethod]
        public void DeveValidar_TelefoneInvalido()
        {
            //arange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");
            //action
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.128.098-02", "172121891231", new DateTime(2022, 02, 20), "(49)000", "Lagi", pessoaJuridica);

            //assert
            pessoaFisica.Validar().Should().Be("Número de telefone muito pequeno.");
        }
    }
}
