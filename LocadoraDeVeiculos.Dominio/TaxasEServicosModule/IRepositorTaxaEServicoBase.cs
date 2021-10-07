using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.TaxasEServicosModule
{
    public interface IRepositorTaxaEServicoBase : IRepositorBase<TaxaEServico>
    {
        TaxaEServico SelecionarPorNome(string nome);
    }
}
