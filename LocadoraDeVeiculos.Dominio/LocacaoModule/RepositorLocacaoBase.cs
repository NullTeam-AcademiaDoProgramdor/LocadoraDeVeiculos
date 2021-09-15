using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public abstract class RepositorLocacaoBase : IRepositor<Locacao>
    {
        public abstract bool Devolver(int id, Locacao locacao);

        public abstract bool EditarKmRegistrada(Locacao locacao);

    }
}
