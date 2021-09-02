using FluentAssertions;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Tests.PessoaJuridicaModule
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    [TestCategory("Dominio")]
    public class PessoaJuridicaTest
    {
        [TestMethod]
        public void DeveCriar_PessoaJuridica()
        {
            //action
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");

            //assert
            pessoaJuridica.Nome.Should().Be("Matheus");
            pessoaJuridica.Cnpj.Should().Be("22.000.000/0001-00");
            pessoaJuridica.Telefone.Should().Be("(49)000000000");
            pessoaJuridica.Endereco.Should().Be("Lagi");
        }

        [TestMethod]
        public void DeveRetornar_PessoaJuridicaValida()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)00000-0000", "Lagi", "aaaa@gmail.com");
            
            //action
            var resultado = pessoaJuridica.Validar();

            //assert
            resultado.Should().Be("ESTA_VALIDO");
        }
        [TestMethod]
        public void DeveValidar_CampoNomeNulo()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica(null, "22.000.000/0001-00", "(49)00000-0000", "Lagi", "aaaa@gmail.com");

            //action
            var resultado = pessoaJuridica.Validar();

            //assert
            resultado.Should().Be("O campo 'nome' não pode estar vazio.");
        }

        [TestMethod]
        public void DeveValidar_CampoCNPJNulo()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Math", null, "(49)00000-0000", "Lagi", "aaaa@gmail.com");

            //action
            var resultado = pessoaJuridica.Validar();

            //assert
            resultado.Should().Be("O campo 'CNPJ' não pode estar vazio.");
        }
        
        [TestMethod]
        public void DeveValidar_CampoEnderecoNulo()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Math", "22.000.000/0001-00", "(49)00000-0000", null, "aaaa@gmail.com");

            //action
            var resultado = pessoaJuridica.Validar();

            //assert
            resultado.Should().Be("O campo 'endereço' não pode estar vazio.");
        }
        
        [TestMethod]
        public void DeveValidar_CampoTelefoneNulo()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Math", "22.000.000/0001-00", null, "Lagi", "aaaa@gmail.com");

            //action
            var resultado = pessoaJuridica.Validar();

            //assert
            resultado.Should().Be("O campo 'telefone' não pode estar vazio.");
        }


        [TestMethod]
        public void DeveValidar_Telefone()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "000", "Lagi", "aaaa@gmail.com");

            //action
            var resultado = pessoaJuridica.Validar();

            //assert
            resultado.Should().Be("Número de telefone muito pequeno.");
        }
        [TestMethod]
        public void DeveValidar_CNPJ()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "00200", "(49)00000-0000", "Lagi", "aaaa@gmail.com");

            //action
            var resultado = pessoaJuridica.Validar();

            //assert
            resultado.Should().Be("Número de CNPJ inválido.");
        }
        [TestMethod]
        public void DeveValidar_QuebraDeLinha_Telefone_CNPJ()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "00200", "9000", "Lagi", "aaaa@gmail.com");

            //action
            var resultado = pessoaJuridica.Validar();

            //assert
            var resultadoEsperado =
                "Número de telefone muito pequeno."
                + Environment.NewLine
                + "Número de CNPJ inválido.";

            resultado.Should().Be(resultadoEsperado);
        }
    }
}
