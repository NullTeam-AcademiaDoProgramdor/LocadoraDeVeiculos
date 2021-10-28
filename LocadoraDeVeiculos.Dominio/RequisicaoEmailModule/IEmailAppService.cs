using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.RequisicaoEmailModule
{
    public interface IEmailAppService
    {
        public void AdicionarEmail(string mensagem, string emailDestino,
            params string[] pdfs);

        public bool Excluir(int id);

        public bool ExisteAlgum();

        public ConcurrentBag<RequisicaoEmail> SelecionarTodos();
    }
}
