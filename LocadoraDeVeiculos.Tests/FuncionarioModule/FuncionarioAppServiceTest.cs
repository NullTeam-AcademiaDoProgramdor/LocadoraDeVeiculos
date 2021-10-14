using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeículos.Aplicacao.FuncionarioModule;
using LocadoraDeVeículos.Infra.SQL.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.Models;

namespace LocadoraDeVeiculos.Tests.FuncionarioModule
{
    [TestClass]
    public class FuncionarioAppServiceTest
    {
        DBLocadoraContext db;

        public FuncionarioAppServiceTest()
        {
            db = new();
        }

        [TestMethod]
        public void DeveInserir_NovoFuncionario()
        {
            Mock<Funcionario> funcionarioMock = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");

            funcionarioMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<FuncionarioORMDao> funcionarioDaoMock = new(db);

            FuncionarioAppService funcionarioAppService = new(funcionarioDaoMock.Object, db);

            funcionarioAppService.InserirNovo(funcionarioMock.Object);

            funcionarioMock.Verify(x => x.Validar());
            funcionarioDaoMock.Verify(x => x.InserirNovo(It.IsAny<Funcionario>()));

        }

        [TestMethod]
        public void NaoDeveInserir_NovoFuncionario()
        {
            Mock<Funcionario> funcionarioMock = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");

            funcionarioMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<FuncionarioORMDao> funcionarioDaoMock = new(db);

            FuncionarioAppService funcionarioAppService = new(funcionarioDaoMock.Object, db);

            funcionarioAppService.InserirNovo(funcionarioMock.Object);

            funcionarioMock.Verify(x => x.Validar());
            funcionarioDaoMock.Verify(x => x.InserirNovo(It.IsAny<Funcionario>()), Times.Never);

        }

        [TestMethod]
        public void DeveEditar_Funcionario()
        {
            Mock<Funcionario> funcionarioMock = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");

            funcionarioMock.Setup(x => x.Validar()).Returns("ESTA_VALIDO");

            Mock<FuncionarioORMDao> funcionarioDaoMock = new(db);

            FuncionarioAppService funcionarioAppService = new(funcionarioDaoMock.Object, db);

            funcionarioAppService.Editar(funcionarioMock.Object.Id, funcionarioMock.Object);

            funcionarioMock.Verify(x => x.Validar());
            funcionarioDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<Funcionario>()));
        }

        [TestMethod]
        public void NaoDeveEditar_Funcionario()
        {
            Mock<Funcionario> funcionarioMock = new("Pedro", new DateTime(2020, 01, 01), 1000, "password");

            funcionarioMock.Setup(x => x.Validar()).Returns("NAO_ESTA_VALIDO");

            Mock<FuncionarioORMDao> funcionarioDaoMock = new(db);

            FuncionarioAppService funcionarioAppService = new(funcionarioDaoMock.Object, db);

            funcionarioAppService.Editar(funcionarioMock.Object.Id, funcionarioMock.Object);

            funcionarioMock.Verify(x => x.Validar());
            funcionarioDaoMock.Verify(x => x.Editar(It.IsAny<int>(), It.IsAny<Funcionario>()), Times.Never);

        }


    }
}