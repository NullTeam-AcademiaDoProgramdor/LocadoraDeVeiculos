using System;
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
    }
}
