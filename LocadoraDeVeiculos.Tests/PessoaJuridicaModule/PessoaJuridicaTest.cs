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
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi");

            //assert
            pessoaJuridica.Nome.Should().Be("Matheus");
            pessoaJuridica.Cnpj.Should().Be("22.000.000/0001-00");
            pessoaJuridica.Telefone.Should().Be("(49)000000000");
            pessoaJuridica.Endereco.Should().Be("Lagi");
        }
    }
}
