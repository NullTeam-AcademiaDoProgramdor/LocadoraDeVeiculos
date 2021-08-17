using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public class Locacao : EntidadeBase
    {
        public Locacao(PessoaFisica condutor, Automovel automovel, Funcionario funcionario, DateTime dataSaida, DateTime dataDevolucaoEsperada, int caucao, int kmAutomovelIncial)
        {
            this.condutor = condutor;
            this.automovel = automovel;
            this.funcionario = funcionario;
            this.dataSaida = dataSaida;
            this.dataDevolucaoEsperada = dataDevolucaoEsperada;
            this.caucao = caucao;
            this.kmAutomovelIncial = kmAutomovelIncial;
            this.dataDevolucao = null;
            this.kmAutomovelFinal = null;
            this.porcentagemFinalCombustivel = null;
        }

        public PessoaFisica condutor { get; }
        public Automovel automovel { get; }
        public Funcionario funcionario { get; }
        public DateTime dataSaida { get; }
        public DateTime dataDevolucaoEsperada { get; }
        public DateTime? dataDevolucao { get; }
        public int caucao { get; }      
        public int kmAutomovelIncial { get; }      
        public int? kmAutomovelFinal { get; }      
        public int? porcentagemFinalCombustivel { get; } 


        public override string Validar()
        {
            string resultadoValidacao = "";

            if (condutor == null)
                resultadoValidacao = "Selecione um condutor";
            
            if (automovel == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um automóvel";

            if(caucao <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O valor de caução não pode ser menor ou igual a 0";

            if (kmAutomovelIncial <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Insira um valor válido para a quilometragem inicial";

            if(dataDevolucaoEsperada <= dataSaida)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A data de devolução esperada não pode ser menor ou igual que a data de saída";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}
