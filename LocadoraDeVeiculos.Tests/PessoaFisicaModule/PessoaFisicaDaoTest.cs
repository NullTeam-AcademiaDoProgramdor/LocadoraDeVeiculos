using FluentAssertions;
using LocadoraDeVeiculos.Controladores.PessoaFisicaModule;
using LocadoraDeVeiculos.Controladores.PessoaJuridicaModule;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.PessoaFisicaModule;
using LocadoraDeVeiculos.Infra.ORM.PessoaJuridicaModule;
using LocadoraDeVeículos.Infra.SQL.PessoaFisicaModule;
using LocadoraDeVeículos.Infra.SQL.PessoaJuridicaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Tests.PessoaFisicaModule
{
    [TestClass]
    [TestCategory("Controladores")]
    public class PessoaFisicaDaoTest
    {
        PessoaFisicaORMDao controlador;
        PessoaJuridicaORMDao controladorPJuridica;
        DBLocadoraContext db;

        public PessoaFisicaDaoTest()
        {
            db = new();
            controlador = new(db);
            controladorPJuridica = new(db);
        }

        [TestCleanup]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [TBPessoaFisica]");
            Db.Update("DELETE FROM [TBPessoaJuridica]");

        }

        [TestMethod]
        public void DeveInserir_PessoaFisicaComPessoaJuridica()
        {
            //arrange
            PessoaJuridica pessoaJuridica = new PessoaJuridica("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");
            controladorPJuridica.InserirNovo(pessoaJuridica);
            db.SaveChanges();

            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", pessoaJuridica, "aaaaa@gmail.com");

            //action
            controlador.InserirNovo(pessoaFisica);
            db.SaveChanges();

            //assert
            var pessoaFisicaEncontrada = controlador.SelecionarPorId(pessoaFisica.Id);
            pessoaFisicaEncontrada.Should().Be(pessoaFisica);
        }

        [TestMethod]
        public void DeveEditar_PessoaFisica()
        {
            //arrange
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com");
            controlador.InserirNovo(pessoaFisica);
            db.SaveChanges();

            string telefone = "(49)000000111";

            PessoaFisica novaPessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), telefone, "Lagi", null, "aaaaa@gmail.com");
            //action
            controlador.Editar(pessoaFisica.Id, novaPessoaFisica);
            db.SaveChanges();

            //assert
            PessoaFisica pessoaFisicaEncontrada = controlador.SelecionarPorId(pessoaFisica.Id);
            pessoaFisicaEncontrada.Should().Be(novaPessoaFisica);
        }

        [TestMethod]
        public void DeveSelecionar_PessoaFisica_PorId()
        {
            //arrange
            PessoaFisica pessoaFisica = new PessoaFisica("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com");
            controlador.InserirNovo(pessoaFisica);
            db.SaveChanges();

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
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com"),

                new PessoaFisica("João", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com"),

                new PessoaFisica("Biel", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com"),

                new PessoaFisica("Ju", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com")
            };

            foreach (var c in pessoasFisicas)
                controlador.InserirNovo(c);
            db.SaveChanges();

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
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com");

            controlador.InserirNovo(pessoaFisica);
            db.SaveChanges();

            //action            
            controlador.Excluir(pessoaFisica.Id);
            db.SaveChanges();

            //assert
            PessoaFisica pessoaFisicaEncontrada = controlador.SelecionarPorId(pessoaFisica.Id);
            pessoaFisicaEncontrada.Should().BeNull();
        }
    }
}
