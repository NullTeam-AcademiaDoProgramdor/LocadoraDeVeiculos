using LocadoraDeVeiculos.Dominio.AutomovelModule;
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
    public class Locacao : EntidadeBase
    {
        public Locacao(PessoaFisica condutor, Automovel automovel, Funcionario funcionario, DateTime dataSaida, DateTime dataDevolucaoEsperada, int caucao, int kmAutomovelIncial, TaxaEServico[] taxaEServicos)
        {
            this.Condutor = condutor;
            this.Automovel = automovel;
            this.Funcionario = funcionario;
            this.DataSaida = dataSaida;
            this.DataDevolucaoEsperada = dataDevolucaoEsperada;
            this.Caucao = caucao;
            this.KmAutomovelIncial = kmAutomovelIncial;
            this.DataDevolucao = null;
            this.KmAutomovelFinal = null;
            this.PorcentagemFinalCombustivel = null;

            if (taxaEServicos == null)
                this.TaxasEServicos = new TaxaEServico[0];
            else
                this.TaxasEServicos = taxaEServicos;
        }

        public PessoaFisica Condutor { get; }
        public Automovel Automovel { get; }
        public Funcionario Funcionario { get; }
        public DateTime DataSaida { get; }
        public DateTime DataDevolucaoEsperada { get; }
        public DateTime? DataDevolucao { get; }
        public int PlanoSelecionado { get; }
        public TaxaEServico[] TaxasEServicos { get; }
        public int Caucao { get; }      
        public int KmAutomovelIncial { get; }      
        public int? KmAutomovelFinal { get; }      
        public int? PorcentagemFinalCombustivel { get; } 



        public override string Validar()
        {
            string resultadoValidacao = "";

            if (Condutor == null)
                resultadoValidacao = "Selecione um condutor";
            
            if (Automovel == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um automóvel";

            if(Caucao <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O valor de caução não pode ser menor ou igual a 0";

            if (KmAutomovelIncial <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Insira um valor válido para a quilometragem inicial";

            if(DataDevolucaoEsperada <= DataSaida)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A data de devolução esperada não pode ser menor ou igual que a data de saída";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
