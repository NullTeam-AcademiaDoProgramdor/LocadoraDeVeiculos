using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.AutomovelModule
{
    public interface IRepositorAutomovelBase : IRepositorBase<Automovel>
    {
        bool EditarKmRegistrada(int id, Automovel registro);
        List<Automovel> SelecionarAutomoveisDisponiveis();
    }
}
