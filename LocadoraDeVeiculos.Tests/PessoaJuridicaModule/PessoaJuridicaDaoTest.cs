using FluentAssertions;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeículos.Infra.SQL.PessoaJuridicaModule;
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
    [TestCategory("Controladores")]
    public class PessoaJuridicaDaoTest
    {
        PessoaJuridicaDao controlador;

        public PessoaJuridicaDaoTest()
        {
            controlador = new PessoaJuridicaDao();
            Db.Update("DELETE FROM [PESSOAJURIDICA]");
        }
        [TestMethod]
        public void DeveInserir_PessoaJuridica()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");

            //action
            controlador.InserirNovo(pessoaJuridica);

            //assert
            PessoaJuridica pessoaJuridicaEncontrada = controlador.SelecionarPorId(pessoaJuridica.Id);
            pessoaJuridicaEncontrada.Should().Be(pessoaJuridica);
        }

        [TestMethod]
        public void DeveEditar_UmaPessoaJuridica()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");
            controlador.InserirNovo(pessoaJuridica);

            PessoaJuridica novaPessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");

            //action
            controlador.Editar(pessoaJuridica.Id, novaPessoaJuridica);

            //assert
            PessoaJuridica pessoaJuridicaEncontrada = controlador.SelecionarPorId(pessoaJuridica.Id);
            pessoaJuridicaEncontrada.Should().Be(novaPessoaJuridica);
        }

        [TestMethod]
        public void DeveExcluir_UmaPessoaJuridica()
        {
            //arrange            
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");
            controlador.InserirNovo(pessoaJuridica);

            //action            
            controlador.Excluir(pessoaJuridica.Id);

            //assert
            PessoaJuridica pessoaJuridicaEncontrada = controlador.SelecionarPorId(pessoaJuridica.Id);
            pessoaJuridicaEncontrada.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_PessoaJuridica_PorId()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");
            controlador.InserirNovo(pessoaJuridica);

            //action
            PessoaJuridica pessoaJuridicaEncontrada = controlador.SelecionarPorId(pessoaJuridica.Id);

            //assert
            pessoaJuridicaEncontrada.Should().Be(pessoaJuridica);
        }
    }
}