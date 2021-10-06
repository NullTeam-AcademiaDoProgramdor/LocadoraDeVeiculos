using FluentAssertions;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeículos.Infra.Shared;
using LocadoraDeVeículos.Infra.SQL.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.ParceiroModule
{
    [TestClass]
    public class ParceiroDaoTest
    {
        RepositorBase<Parceiro> controlador = null;

        public ParceiroDaoTest()
        {
            controlador = new ParceiroORMDao();
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [TBParceiro]");
        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            Parceiro novoParceiro = new("Josue");

            controlador.InserirNovo(novoParceiro);

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(novoParceiro.id);

            parceiroEncontrado.Should().Be(novoParceiro);
        }

        [TestMethod]
        public void DeveEditar_UmParceiro()
        {
            Parceiro parceiro = new("Josue");

            controlador.InserirNovo(parceiro);

            Parceiro novoParceiro = new("Jose");

            controlador.Editar(parceiro.Id, novoParceiro);

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(novoParceiro);
        }

        [TestMethod]
        public void DeveExcluir_UmParceiro()
        {
            Parceiro parceiro = new("Josue");

            controlador.InserirNovo(parceiro);

            controlador.Excluir(parceiro.Id);

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_Parceiro_porId()
        {

            Parceiro parceiro = new("Josue");

            controlador.InserirNovo(parceiro);

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(parceiro);
        }

        [TestMethod]
        public void DeveSelecionar_TodosParceiros()
        {
            Parceiro parceiro1 = new("Josue");

            controlador.InserirNovo(parceiro1);

            Parceiro parceiro2 = new("Jose");

            controlador.InserirNovo(parceiro2);

            Parceiro parceiro3 = new("Joberson");

            controlador.InserirNovo(parceiro3);

            Parceiro parceiro4 = new("Joao");

            controlador.InserirNovo(parceiro4);

            var parceiros = controlador.SelecionarTodos();

            parceiros.Should().HaveCount(4);
        }
    }
}
