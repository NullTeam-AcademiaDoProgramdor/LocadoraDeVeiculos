using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.Shared
{
    public interface ICadastravel<T> where T : EntidadeBase
    {
        public string InserirNovo(T registro);
        public string Editar(int id, T registro);
        public bool Existe(int id);
        public bool Excluir(int id);
        public List<T> SelecionarTodos();
        public T SelecionarPorId(int id);
    }
}
