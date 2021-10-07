using LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.GrupoAutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeículos.Infra.SQL.GrupoAutomovelModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.GrupoAutomovelModule
{
    [TestClass]
    public class GrupoAutomovelAppServiceTest
    {
        private PlanoDiarioStruct planoDiario;
        private PlanoKmControladoStruct planoKmControlado;
        private PlanoKmLivreStruct planoKmLivre;

        private DBLocadoraContext db;

        public GrupoAutomovelAppServiceTest()
        {
            planoDiario = gerarPlanoDiario();
            planoKmControlado = gerarPlanoKmControlado();
            planoKmLivre = gerarPlanoKmLivre();

            this.db = new();
        }

        [TestMethod]
        public void DeveInserir_NovoGrupoDeAutomovel()
        {
            Mock<GrupoAutomovel> grupoAutomovelMock = new("Economico", planoDiario, planoKmControlado, planoKmLivre);

            grupoAutomovelMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<GrupoAutomovelORMDao> grupoAutomovelDaoMock = new(db);
            GrupoAutomovelAppService grupoAutomovelAppService = new(grupoAutomovelDaoMock.Object, db);

            grupoAutomovelAppService.InserirNovo(grupoAutomovelMock.Object);

            grupoAutomovelMock.Verify(x => x.Validar());
            grupoAutomovelDaoMock.Verify(x => x.InserirNovo(It.IsAny<GrupoAutomovel>()));
        }

        [TestMethod]
        public void NaoDeveInserir_SeEstaInvalido()
        {
            Mock<GrupoAutomovel> grupoAutomovelMock = new("Economico", planoDiario, planoKmControlado, planoKmLivre);

            grupoAutomovelMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<GrupoAutomovelORMDao> grupoAutomovelDaoMock = new(db);
            GrupoAutomovelAppService grupoAutomovelAppService = new(grupoAutomovelDaoMock.Object, db);

            grupoAutomovelAppService.InserirNovo(grupoAutomovelMock.Object);

            grupoAutomovelMock.Verify(x => x.Validar());
            grupoAutomovelDaoMock.Verify(x => x.InserirNovo(It.IsAny<GrupoAutomovel>()), Times.Never);
        }

        [TestMethod]
        public void DeveEditar_GrupoDeAutomovel()
        {
            Mock<GrupoAutomovel> grupoAutomovelMock = new("Economico", planoDiario, planoKmControlado, planoKmLivre);

            grupoAutomovelMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<GrupoAutomovelORMDao> grupoAutomovelDaoMock = new(db);
            GrupoAutomovelAppService grupoAutomovelAppService = new(grupoAutomovelDaoMock.Object, db);

            grupoAutomovelAppService.Editar(grupoAutomovelMock.Object.Id, grupoAutomovelMock.Object);

            grupoAutomovelMock.Verify(x => x.Validar());
            grupoAutomovelDaoMock.Verify(x => x.Editar(It.IsAny<int>(),It.IsAny<GrupoAutomovel>()));
        }
        
        [TestMethod]
        public void NaoDeveEditar_GrupoDeAutomovel()
        {
            Mock<GrupoAutomovel> grupoAutomovelMock = new("Economico", planoDiario, planoKmControlado, planoKmLivre);

            grupoAutomovelMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<GrupoAutomovelORMDao> grupoAutomovelDaoMock = new(db);
            GrupoAutomovelAppService grupoAutomovelAppService = new(grupoAutomovelDaoMock.Object, db);

            grupoAutomovelAppService.Editar(grupoAutomovelMock.Object.Id, grupoAutomovelMock.Object);

            grupoAutomovelMock.Verify(x => x.Validar());
            grupoAutomovelDaoMock.Verify(x => x.Editar(It.IsAny<int>(),It.IsAny<GrupoAutomovel>()), Times.Never);
        }

        private PlanoDiarioStruct gerarPlanoDiario()
        {
            return new PlanoDiarioStruct(10, 10);
        }
        private PlanoKmLivreStruct gerarPlanoKmLivre()
        {
            return new PlanoKmLivreStruct(50);
        }

        private PlanoKmControladoStruct gerarPlanoKmControlado()
        {
            return new PlanoKmControladoStruct(10, 10, 50);
        }
    }
}
