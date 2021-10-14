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
    public class LocacaoORMDao : ORMDAOBase<Locacao>, IRepositorLocacaoBase
    {

        public LocacaoORMDao(DBLocadoraContext db) : base(db)
        {
        }

        public virtual bool Devolver(int id, Locacao locacao)
        {
            return this.Editar(id,locacao);
        }

    }
}
