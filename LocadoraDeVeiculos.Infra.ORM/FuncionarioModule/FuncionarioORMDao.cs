using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;

namespace LocadoraDeVeiculos.Infra.ORM.FuncionarioModule
{
    public class FuncionarioORMDao : ORMDAOBase<Funcionario>, IRepositorFuncionarioBase
    {
        public FuncionarioORMDao(DBLocadoraContext db) : base(db)
        { 

        }

        public Funcionario SelecionarPorNomeESenha(string nome, string senha)
        {
            return db.Funcionarios.Where(x => x.Nome == nome && x.Senha == senha).FirstOrDefault();
        }
    }
}
