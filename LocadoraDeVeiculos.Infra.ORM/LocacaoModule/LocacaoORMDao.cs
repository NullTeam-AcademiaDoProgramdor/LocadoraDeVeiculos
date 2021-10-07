using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.LocacaoModule
{
    public class LocacaoORMDao : ORMDAOBase<Locacao>
    {
        public LocacaoORMDao(DBLocadoraContext db) : base(db)
        {
        }
    }
}
