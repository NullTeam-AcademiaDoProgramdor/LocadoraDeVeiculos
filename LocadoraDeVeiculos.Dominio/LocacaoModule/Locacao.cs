using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public class Locacao : EntidadeBase, IEquatable<Locacao>
    {

        public Locacao(PessoaFisica condutor, Automovel automovel, Funcionario funcionario, DateTime dataSaida,
            DateTime dataDevolucaoEsperada, int caucao, int planoSelecionado, TaxaEServico[] taxaEServicos = null, Cupom cupom = null)
        {
            this.Condutor = condutor;
            this.Automovel = automovel;
            this.Funcionario = funcionario;
            this.DataSaida = dataSaida;
            this.DataDevolucaoEsperada = dataDevolucaoEsperada;
            this.Caucao = caucao;
            this.PlanoSelecionado = planoSelecionado;
            this.DataDevolucao = null;
            this.KmAutomovelFinal = null;
            this.PorcentagemFinalCombustivel = null;
            this.Situacao = "Pendente";
            this.Cupom = cupom;

            if (taxaEServicos == null)
                this.TaxasEServicos = new List<TaxaEServico>();
            else
                this.TaxasEServicos = taxaEServicos.ToList();
        }

        public Locacao(PessoaFisica condutor, Automovel automovel, Funcionario funcionario, DateTime dataSaida,
            DateTime dataDevolucaoEsperada, int caucao, int kmAutomovelIncial, int planoSelecionado,
             int kmAutomovelFinal, int porcentagemFinalCombustivel, DateTime dataDevolucao, TaxaEServico[] taxasEServicos = null, Cupom cupom = null)
        {
            Condutor = condutor;
            Automovel = automovel;
            Funcionario = funcionario;
            DataSaida = dataSaida;
            DataDevolucaoEsperada = dataDevolucaoEsperada;
            DataDevolucao = dataDevolucao;
            PlanoSelecionado = planoSelecionado;
            Caucao = caucao;
            KmAutomovelIncial = kmAutomovelIncial;
            KmAutomovelFinal = kmAutomovelFinal;
            PorcentagemFinalCombustivel = porcentagemFinalCombustivel;
            this.Situacao = ((DateTime)this.DataDevolucao).ToString("dd/MM/yyyy");
            this.Cupom = cupom;

            if (taxasEServicos == null)
                this.TaxasEServicos = new List<TaxaEServico>();
            else
                this.TaxasEServicos = taxasEServicos.ToList();
        }

        public Locacao()
        {
            this.TaxasEServicos = new List<TaxaEServico>();
        }

        public virtual Cupom Cupom { get; set; }
        public virtual PessoaFisica Condutor { get; set; }
        public virtual Automovel Automovel { get; set; }
        public virtual Funcionario Funcionario { get; }
        public DateTime DataSaida { get; }
        public DateTime DataDevolucaoEsperada { get; }
        public DateTime? DataDevolucao { get; }
        public int PlanoSelecionado { get; }
        public virtual List<TaxaEServico> TaxasEServicos { get; set; }
        public int Caucao { get; }
        public string Situacao { get; }
        public int KmAutomovelIncial { get; }
        public int? KmAutomovelFinal { get; set; }
        public int? PorcentagemFinalCombustivel { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Locacao);
        }

        public bool Equals(Locacao other)
        {
            return other != null &&
                   id == other.id &&
                   Id == other.Id &&
                   EqualityComparer<PessoaFisica>.Default.Equals(Condutor, other.Condutor) &&
                   EqualityComparer<Automovel>.Default.Equals(Automovel, other.Automovel) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, other.Funcionario) &&
                   EqualityComparer<Cupom>.Default.Equals(Cupom, other.Cupom) &&
                   DataSaida == other.DataSaida &&
                   DataDevolucaoEsperada == other.DataDevolucaoEsperada &&
                   DataDevolucao == other.DataDevolucao &&
                   PlanoSelecionado == other.PlanoSelecionado &&
                   //EqualityComparer<TaxaEServico[]>.Default.Equals(TaxasEServicos, other.TaxasEServicos) &&
                   Caucao == other.Caucao &&
                   KmAutomovelIncial == other.KmAutomovelIncial &&
                   KmAutomovelFinal == other.KmAutomovelFinal &&
                   PorcentagemFinalCombustivel == other.PorcentagemFinalCombustivel;
        }

        public override int GetHashCode()
        {
            int hashCode = -725128496;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<PessoaFisica>.Default.GetHashCode(Condutor);
            hashCode = hashCode * -1521134295 + EqualityComparer<Automovel>.Default.GetHashCode(Automovel);
            hashCode = hashCode * -1521134295 + EqualityComparer<Funcionario>.Default.GetHashCode(Funcionario);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cupom>.Default.GetHashCode(Cupom);
            hashCode = hashCode * -1521134295 + DataSaida.GetHashCode();
            hashCode = hashCode * -1521134295 + DataDevolucaoEsperada.GetHashCode();
            hashCode = hashCode * -1521134295 + DataDevolucao.GetHashCode();
            hashCode = hashCode * -1521134295 + PlanoSelecionado.GetHashCode();
            //hashCode = hashCode * -1521134295 + EqualityComparer<TaxaEServico[]>.Default.GetHashCode(TaxasEServicos);
            hashCode = hashCode * -1521134295 + Caucao.GetHashCode();
            hashCode = hashCode * -1521134295 + KmAutomovelIncial.GetHashCode();
            hashCode = hashCode * -1521134295 + KmAutomovelFinal.GetHashCode();
            hashCode = hashCode * -1521134295 + PorcentagemFinalCombustivel.GetHashCode();
            return hashCode;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (Condutor == null)
                resultadoValidacao = "Selecione um condutor";

            if (Automovel == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um automóvel";

            if (Caucao <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O valor de caução não pode ser menor ou igual a 0";


            if (DataDevolucaoEsperada <= DataSaida)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A data de devolução esperada não pode ser menor ou igual que a data de saída";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public virtual string ValidarDevolucao()
        {
            string resultadoValidacao = "";
            if (KmAutomovelFinal == 0)
                resultadoValidacao = "A quilometragem final não pode ser nula";

            if (KmAutomovelFinal < Automovel.KmRegistrada)
                resultadoValidacao = "O campo km final não pode ser menor que a inicial";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}