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
            throw new NotImplementedException();
        }
    }
}
