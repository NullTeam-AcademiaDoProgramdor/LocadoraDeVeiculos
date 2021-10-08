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
        private string mensagem;
        private string emailDestino;
        private string[] arquivos;

        public string Mensagem { get => mensagem; set => mensagem = value; }
        public string EmailDestino { get => emailDestino; set => emailDestino = value; }
        public string[] Arquivos { get => arquivos; set => arquivos = value; }

        public RequisicaoEmail(string mensagem, string emailDestino, string[] arquivos)
        {
            this.Mensagem = mensagem;
            this.EmailDestino = emailDestino;
            this.Arquivos = arquivos;
        }

        public RequisicaoEmail()
        {

        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Mensagem))
                resultadoValidacao += "O campo 'mensagem' nao pode ficar vazio";

            if (string.IsNullOrEmpty(EmailDestino))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao)
                    + "O campo 'emailDestino' nao pode ficar vazio";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}