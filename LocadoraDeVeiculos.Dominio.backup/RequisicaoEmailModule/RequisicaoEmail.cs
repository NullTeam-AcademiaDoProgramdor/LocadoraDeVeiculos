using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.RequisicaoEmailModule
{
    public class RequisicaoEmail : EntidadeBase
    {
        public string mensagem;
        public string emailDestino;
        public string[] arquivos;

        public RequisicaoEmail(string mensagem, string emailDestino, string[] arquivos)
        {
            this.mensagem = mensagem;
            this.emailDestino = emailDestino;
            this.arquivos = arquivos;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(mensagem))
                resultadoValidacao += "O campo 'mensagem' nao pode ficar vazio";

            if (string.IsNullOrEmpty(emailDestino))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao)
                    + "O campo 'emailDestino' nao pode ficar vazio";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
