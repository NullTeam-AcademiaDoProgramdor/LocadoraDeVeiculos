using FluentAssertions;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        public void DeveInserir_PessoaFisicaComPessoaJuridica()
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

        [TestMethod]
        public void DeveEditar_PessoaFisica()
        {
            //arrange
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null);
            controlador.InserirNovo(pessoaFisica);

            string telefone = "(49)000000111";

            PessoaFisica novaPessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), telefone, "Lagi", null);
            //action
            controlador.Editar(pessoaFisica.Id, novaPessoaFisica);

            //assert
            PessoaFisica pessoaFisicaEncontrada = controlador.SelecionarPorId(pessoaFisica.Id);
            pessoaFisicaEncontrada.Should().Be(novaPessoaFisica);
        }

        [TestMethod]
        public void DeveSelecionar_PessoaFisica_PorId()
        {
            //arrange
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null);
            controlador.InserirNovo(pessoaFisica);

            //action
            PessoaFisica pessoaFisicaEncontrada = controlador.SelecionarPorId(pessoaFisica.Id);

            //assert
            pessoaFisicaEncontrada.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodasPessoasFisicas()
        {
            //arrange
            var pessoasFisicas = new List<PessoaFisica>
            {
                new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null),

                new PessoaFisica("João", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null),

                new PessoaFisica("Biel", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null),

                new PessoaFisica("Ju", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null)
            };

            foreach (var c in pessoasFisicas)
                controlador.InserirNovo(c);

            //action
            var pessoasFisicasEncotradas = controlador.SelecionarTodos();

            //assert
            pessoasFisicasEncotradas.Should().HaveCount(4);
        }

        [TestMethod]
        public void DeveExcluir_UmaPessoaFisica()
        {
            //arrange            
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null);

            controlador.InserirNovo(pessoaFisica);

            //action            
            controlador.Excluir(pessoaFisica.Id);

            //assert
            PessoaFisica pessoaFisicaEncontrada = controlador.SelecionarPorId(pessoaFisica.Id);
            pessoaFisicaEncontrada.Should().BeNull();
        }
    }
}
