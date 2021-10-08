using LocadoraDeVeículos.Aplicacao.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.PessoaJuridicaModule;
using LocadoraDeVeículos.Infra.SQL.PessoaJuridicaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.PessoaJuridicaModule
{
    [TestClass]
    public class PessoaJuridiaAppServiceTest
    {
        DBLocadoraContext dbContext = null;
        public PessoaJuridiaAppServiceTest()
        {
            dbContext = new();
        }

        [TestMethod]
        public void DeveInserir_NovaPessoaJuridica()
        {
            Mock<PessoaJuridica> pessoaJuridicaMock = new("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");

            pessoaJuridicaMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<PessoaJuridicaORMDao> pessoaJuridicaDaoMock = new(dbContext);

            PessoaJuridicaAppService pessoaJuridicaAppService =
                new(pessoaJuridicaDaoMock.Object, dbContext);

            pessoaJuridicaAppService.InserirNovo(pessoaJuridicaMock.Object);

            pessoaJuridicaMock.Verify(x => x.Validar());
            pessoaJuridicaDaoMock.Verify(x => x.InserirNovo(It.IsAny<PessoaJuridica>()));

        }

        [TestMethod]
        public void NaoDeveInserir_NovaPessoaJuridica()
        {
            Mock<PessoaJuridica> pessoaJuridicaMock = new("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");

            pessoaJuridicaMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<PessoaJuridicaORMDao> pessoaJuridicaDaoMock = new(dbContext);

            PessoaJuridicaAppService pessoaJuridicaAppService =
                new(pessoaJuridicaDaoMock.Object, dbContext);

            pessoaJuridicaAppService.InserirNovo(pessoaJuridicaMock.Object);

            pessoaJuridicaMock.Verify(x => x.Validar());
            pessoaJuridicaDaoMock.Verify(x => x.InserirNovo(It.IsAny<PessoaJuridica>()), Times.Never);

        }

        [TestMethod]
        public void DeveEditar_PessoaJuridica()
        {
            Mock<PessoaJuridica> pessoaJuridicaMock = new("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");

            pessoaJuridicaMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<PessoaJuridicaORMDao> pessoaJuridicaDaoMock = new(dbContext);

            PessoaJuridicaAppService pessoaJuridicaAppService =
                new(pessoaJuridicaDaoMock.Object, dbContext);

            pessoaJuridicaAppService.Editar(pessoaJuridicaMock.Object.Id, pessoaJuridicaMock.Object);

            pessoaJuridicaMock.Verify(x => x.Validar());
            pessoaJuridicaDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<PessoaJuridica>()));

        }

        [TestMethod]
        public void NaoDeveEditar_PessoaJuridica()
        {
            Mock<PessoaJuridica> pessoaJuridicaMock = new("Matheus", "22.000.000/0001-00", "(49)000000000", "Lagi", "aaaa@gmail.com");

            pessoaJuridicaMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<PessoaJuridicaORMDao> pessoaJuridicaDaoMock = new(dbContext);

            PessoaJuridicaAppService pessoaJuridicaAppService =
                new(pessoaJuridicaDaoMock.Object, dbContext);

            pessoaJuridicaAppService.Editar(pessoaJuridicaMock.Object.Id, pessoaJuridicaMock.Object);

            pessoaJuridicaMock.Verify(x => x.Validar());
            pessoaJuridicaDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<PessoaJuridica>()), Times.Never);

        }
    }
}
