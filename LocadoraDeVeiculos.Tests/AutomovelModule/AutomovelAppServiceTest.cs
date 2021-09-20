﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeículos.Infra.SQL.AutomovelModule;
using LocadoraDeVeículos.Aplicacao.AutomovelModule;
using System.Drawing;

namespace LocadoraDeVeiculos.Tests.AutomovelModule
{
    [TestClass]
    public class AutomovelAppServiceTest
    {
        [TestMethod]
        public void DeveInserir_NovoAutomovel()
        {
            Mock<Automovel> automovelMock = new("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, CriarGrupo());

            automovelMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<AutomovelDao> automovelDaoMock = new();
            Mock<FotosAutomovelDao> automovelFotosDaoMock = new();

            AutomovelAppService automovelAppService = 
                new(automovelDaoMock.Object, automovelFotosDaoMock.Object);

            automovelAppService.InserirNovo(automovelMock.Object);

            automovelMock.Verify(x => x.Validar());
            automovelDaoMock.Verify(x => x.InserirNovo(It.IsAny<Automovel>()));
            automovelFotosDaoMock.Verify(x => x.Modificar(It.IsAny<Image[]>(), It.IsAny<int>()));

        }

        [TestMethod]
        public void NaoDeveInserir_SeNaoEstaValido()
        {
            Mock<Automovel> automovelMock = new("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
               2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
               DirecaoEnum.Mecanica, CriarGrupo());

            automovelMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<AutomovelDao> automovelDaoMock = new();
            Mock<FotosAutomovelDao> automovelFotosDaoMock = new();

            AutomovelAppService automovelAppService =
                new(automovelDaoMock.Object, automovelFotosDaoMock.Object);

            automovelAppService.InserirNovo(automovelMock.Object);

            automovelMock.Verify(x => x.Validar());
            automovelDaoMock.Verify(x => x.InserirNovo(It.IsAny<Automovel>()), Times.Never);
            automovelFotosDaoMock.Verify(x => x.Modificar(It.IsAny<Image[]>(), It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void DeveEditar_Automovel()
        {
            Mock<Automovel> automovelMock = new("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, CriarGrupo());

            automovelMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<AutomovelDao> automovelDaoMock = new();
            Mock<FotosAutomovelDao> automovelFotosDaoMock = new();

            AutomovelAppService automovelAppService =
                new(automovelDaoMock.Object, automovelFotosDaoMock.Object);

            automovelAppService.Editar(0, automovelMock.Object);

            automovelMock.Verify(x => x.Validar());
            automovelDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<Automovel>()));
            automovelFotosDaoMock.Verify(x => x.Modificar(It.IsAny<Image[]>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void DeveEditar_KmRegistradaAutomovel()
        {
            Mock<Automovel> automovelMock = new("Gol", "Ford", "Branco", "ABCD123", "12YG2J31G23H123",
                2020, 4, 100, 0, 30, TipoCombustivelEnum.Gasolina, CambioEnum.Manual,
                DirecaoEnum.Mecanica, CriarGrupo());

            automovelMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<AutomovelDao> automovelDaoMock = new();
            Mock<FotosAutomovelDao> automovelFotosDaoMock = new();

            AutomovelAppService automovelAppService =
                new(automovelDaoMock.Object, automovelFotosDaoMock.Object);

            automovelAppService.EditarKmRegistrada(It.IsAny<int>(), automovelMock.Object);

            automovelMock.Verify(x => x.Validar());
            automovelDaoMock.Verify(x => x.EditarKmRegistrada(It.IsAny<int>(), It.IsAny<Automovel>()));
        }

        private GrupoAutomovel CriarGrupo()
        {
            GrupoAutomovel novoGrupo = new GrupoAutomovel(
                "Economicos",
                new PlanoDiarioStruct(150, 5),
                new PlanoKmControladoStruct(100, 15, 100),
                new PlanoKmLivreStruct(300)
            );

            return novoGrupo;
        }
    }
}
