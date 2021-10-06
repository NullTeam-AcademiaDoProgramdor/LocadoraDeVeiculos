using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ParceiroModule
{
    public class ParceiroORMDao : ORMDAOBase<Parceiro>
    {
        public ParceiroORMDao(DBLocadoraContext db) : base(db)
        {
        }
    }
}
