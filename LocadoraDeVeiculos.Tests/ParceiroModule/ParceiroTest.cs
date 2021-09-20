using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.ParceiroModule
{
    [TestClass]
    public class ParceiroTest
    {
        [TestMethod]
        public void DeveCriar_Parceiro()
        {
            Parceiro parceiro = new("Josue");

            parceiro.Nome.Should().Be("Josue");
        }

        [TestMethod]
        public void DeveValidar_NomeVazio()
        {
            Parceiro parceiro = new("");

            var resultado = parceiro.Validar();

            resultado.Should().Be("O campo 'nome' não pode estar vazio.");
        }

        [TestMethod]
        public void DeveValidar_Nome()
        {
            Parceiro parceiro = new("Josue");

            var resultado = parceiro.Validar();

            resultado.Should().Be("ESTA_VALIDO");
        }

    }
}
