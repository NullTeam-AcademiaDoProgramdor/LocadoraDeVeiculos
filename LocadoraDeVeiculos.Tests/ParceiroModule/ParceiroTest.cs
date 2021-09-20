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


    }
}
