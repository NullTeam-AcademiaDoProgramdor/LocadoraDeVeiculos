using LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
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
        public GrupoAutomovelAppServiceTest()
        {
            planoDiario = gerarPlanoDiario();
            planoKmControlado = gerarPlanoKmControlado();
            planoKmLivre = gerarPlanoKmLivre();
        }

        [TestMethod]
        public void DeveInserir_NovoGrupoDeAutomovel()
        {
            Mock<GrupoAutomovel> grupoAutomovelMock = new("Economico", planoDiario, planoKmControlado, planoKmLivre);

            grupoAutomovelMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<GrupoAutomovelDao> grupoAutomovelDaoMock = new();
            GrupoAutomovelAppService grupoAutomovelAppService = new(grupoAutomovelDaoMock.Object);

            grupoAutomovelAppService.InserirNovo(grupoAutomovelMock.Object);

            grupoAutomovelMock.Verify(x => x.Validar());
            grupoAutomovelDaoMock.Verify(x => x.InserirNovo(It.IsAny<GrupoAutomovel>()));

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
