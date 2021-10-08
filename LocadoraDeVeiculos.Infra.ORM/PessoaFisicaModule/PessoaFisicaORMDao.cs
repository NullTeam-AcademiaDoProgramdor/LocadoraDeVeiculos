using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.PessoaFisicaModule
{
    public class PessoaFisicaORMDao : ORMDAOBase<PessoaFisica>
    {
        public PessoaFisicaORMDao(DBLocadoraContext db) : base(db)
        {
        }

    }
}
