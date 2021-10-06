using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.CupomModule
{
    public class CupomORMDao : ORMDAOBase<Cupom>, IRepositorCupomBase
    {
        public bool EditarQtdUsos(Cupom cupom)
        {
            throw new NotImplementedException();
        }

        public Cupom SelecionarPorCodigo(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Cupom> SelecionarValidos()
        {
            throw new NotImplementedException();
        }
    }
}
