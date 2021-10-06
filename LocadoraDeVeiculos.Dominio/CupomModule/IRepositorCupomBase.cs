using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.CupomModule
{
    public interface IRepositorCupomBase : IRepositorBase<Cupom>
    {
        public abstract bool EditarQtdUsos(Cupom cupom);

        public abstract Cupom SelecionarPorCodigo(string codigo);

        public abstract List<Cupom> SelecionarValidos();
    }
}
