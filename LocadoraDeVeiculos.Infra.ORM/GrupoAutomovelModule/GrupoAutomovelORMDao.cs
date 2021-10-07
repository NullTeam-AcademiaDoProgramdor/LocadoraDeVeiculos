using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.GrupoAutomovelModule
{
    public class GrupoAutomovelORMDao : ORMDAOBase<GrupoAutomovel>
    {
        public GrupoAutomovelORMDao(DBLocadoraContext db) : base(db)
        {
        }
    }
}
