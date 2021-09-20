using FluentAssertions;
using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
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
        ParceiroDao controlador = null;

        public ParceiroDaoTest()
        {
            controlador = new();
        }

        [TestCleanup()]
        public void LimparTeste()
        {
            Db.Update("DELETE FROM [Parceiro]");
        }

        [TestMethod]
        public void DeveInserir_Parceiro()
        {
            Parceiro novoParceiro = new("Josue");

            controlador.InserirNovo(novoParceiro);

            Parceiro parceiroEncontrado = controlador.SelecionarPorId(novoParceiro.id);

            parceiroEncontrado.Should().Be(novoParceiro);
        }
    }
}
