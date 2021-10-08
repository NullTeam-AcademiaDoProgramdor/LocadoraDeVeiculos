using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IRepositorLocacaoBase : IRepositorBase<Locacao>
    {
        bool Devolver(int id, Locacao locacao);

        //bool EditarKmRegistrada(Locacao locacao);

    }
}
