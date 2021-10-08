using LocadoraDeVeículos.Aplicacao.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.PessoaFisicaModule;
using LocadoraDeVeículos.Infra.SQL.PessoaFisicaModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Tests.PessoaFisicaModule
{
    [TestClass]
    public class PessoaFisicaAppServiceTest
    {
        DBLocadoraContext db;

        public PessoaFisicaAppServiceTest()
        {
            db = new();
        }

        [TestMethod]
        public void DeveInserir_NovaPessoaFisica()
        {
            Mock<PessoaFisica> pessoaFisicaMock = new("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com");

            pessoaFisicaMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<PessoaFisicaORMDao> pessoaFisicaDaoMock = new(db);

            PessoaFisicaAppService pessoaFisicaAppService = 
                new(pessoaFisicaDaoMock.Object, db); ;

            pessoaFisicaAppService.InserirNovo(pessoaFisicaMock.Object);

            pessoaFisicaMock.Verify(x => x.Validar());
            pessoaFisicaDaoMock.Verify(x => x.InserirNovo(It.IsAny<PessoaFisica>()));
        }

        [TestMethod]
        public void NaoDeveInserir_NovaPessoaFisica()
        {
            Mock<PessoaFisica> pessoaFisicaMock = new("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com");

            pessoaFisicaMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<PessoaFisicaORMDao> pessoaFisicaDaoMock = new(db);

            PessoaFisicaAppService pessoaFisicaAppService =
                new(pessoaFisicaDaoMock.Object, db);

            pessoaFisicaAppService.InserirNovo(pessoaFisicaMock.Object);

            pessoaFisicaMock.Verify(x => x.Validar());
            pessoaFisicaDaoMock.Verify(x => x.InserirNovo(It.IsAny<PessoaFisica>()), Times.Never);
        }

        [TestMethod]
        public void DeveEditar_PessoaFisica()
        {
            Mock<PessoaFisica> pessoaFisicaMock = new("Matheus", "123.456.789-02", "12.098.098-02",
                "123456789123", new DateTime(2022, 02, 20), "(49)000000000", "Lagi", null, "aaaaa@gmail.com");

            pessoaFisicaMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<PessoaFisicaORMDao> pessoaFisicaDaoMock = new(db);

            PessoaFisicaAppService pessoaFisicaAppService =
                new(pessoaFisicaDaoMock.Object, db);

            pessoaFisicaAppService.Editar(It.IsAny<int>(), pessoaFisicaMock.Object);

            pessoaFisicaMock.Verify(x => x.Validar());
            pessoaFisicaDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<PessoaFisica>()));
        }
    }
}
