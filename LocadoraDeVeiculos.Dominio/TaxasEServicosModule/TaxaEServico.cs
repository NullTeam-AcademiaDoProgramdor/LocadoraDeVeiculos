using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.Shared;

namespace LocadoraDeVeiculos.Dominio.TaxasEServicosModule
{
    public class TaxaEServico : EntidadeBase
    {

        string nome;
        double preco;
        bool ehFixo;

        public TaxaEServico(string nome, double preco, bool ehFixo)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.EhFixo = ehFixo;
        }

        public TaxaEServico()
        {

        }

        public string Nome { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }
        public bool EhFixo { get => ehFixo; set => ehFixo = value; }
        public virtual List<Locacao> Locacoes { get ; set; }


        public override bool Equals(object obj)
        {
            return obj is TaxaEServico servicos &&
                   Id == servicos.Id &&
                   nome == servicos.nome &&
                   preco == servicos.preco &&
                   ehFixo == servicos.ehFixo &&
                   Nome == servicos.Nome &&
                   Preco == servicos.Preco &&
                   EhFixo == servicos.EhFixo;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao += " O campo Nome é obrigatório";

            if (VerificaSeNomeEhNumero(Nome))
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    " O campo Nome está inválido";

            if (preco <= 0)
                resultadoValidacao +=
                    QuebraDeLinha(resultadoValidacao) +
                    " O campo Preço está inválido";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override int GetHashCode()
        {
            int hashCode = 1695060689;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(Preco);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(EhFixo);
            return hashCode;
        }

        private bool VerificaSeNomeEhNumero(string nome)
        {
            bool verificador = true;

            try
            {
                double nomeDouble = Convert.ToDouble(nome);
            }
            catch (Exception)
            {
                return verificador = false;
            }

            return verificador;
        }



    }
}
