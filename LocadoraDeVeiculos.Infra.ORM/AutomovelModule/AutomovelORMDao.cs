using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.AutomovelModule
{
    public class AutomovelORMDao : ORMDAOBase<Automovel>, IRepositorAutomovelBase
    {
        public AutomovelORMDao(DBLocadoraContext db) : base(db)
        {
        }

        public virtual bool EditarKmRegistrada(int id, Automovel registro)
        {
            return this.Editar(id, registro);
        }

        public List<Automovel> SelecionarAutomoveisDisponiveis()
        {
            //Precisa da locação :(
            throw new NotImplementedException();
        }
    }
}
