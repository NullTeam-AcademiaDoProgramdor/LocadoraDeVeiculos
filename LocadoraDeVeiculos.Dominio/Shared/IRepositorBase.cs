using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Shared
{
    public interface IRepositorBase<T> where T : EntidadeBase
    {
        bool InserirNovo(T registro);
        bool Editar(int id, T registro);
        bool Existe(int id);
        bool Excluir(int id);
        List<T> SelecionarTodos();
        T SelecionarPorId(int id);
    }
}
