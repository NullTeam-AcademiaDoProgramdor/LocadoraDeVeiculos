using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.Shared
{
    public abstract class RepositorBase<T> where T : EntidadeBase
    {
        public abstract bool InserirNovo(T registro);
        public abstract bool Editar(int id, T registro);
        public abstract bool Existe(int id);
        public abstract bool Excluir(int id);
        public abstract List<T> SelecionarTodos();
        public abstract T SelecionarPorId(int id);
        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
    }
}
