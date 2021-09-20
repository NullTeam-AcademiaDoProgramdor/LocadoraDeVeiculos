using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.CupomModule
{
    [TestClass]
    public class CupomAppServiceTest
    {
        private Parceiro parceiro;

        public CupomAppServiceTest()
        {
            parceiro = gerarParceiro();
        }

        private Parceiro gerarParceiro()
        {
            return new Parceiro("Pedro");
        }
    }
}
