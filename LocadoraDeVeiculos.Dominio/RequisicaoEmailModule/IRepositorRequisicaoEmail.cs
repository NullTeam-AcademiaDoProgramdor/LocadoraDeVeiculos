using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.RequisicaoEmailModule
{
    public interface IRepositorRequisicaoEmail
    {
        public bool Excluir(int id);

        public bool ExisteAlgum();

        public bool InserirNovo(RequisicaoEmail registro);

        public List<RequisicaoEmail> SelecionarTodos();
    }
}
