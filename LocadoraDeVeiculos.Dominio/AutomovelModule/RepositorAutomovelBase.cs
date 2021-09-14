using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.AutomovelModule
{
    public abstract class RepositorAutomovelBase : IRepositor<Automovel>
    {
        public abstract bool EditarKmRegistrada(int id, Automovel registro);
        public abstract List<Automovel> SelecionarAutomoveisDisponiveis();
    }
}
