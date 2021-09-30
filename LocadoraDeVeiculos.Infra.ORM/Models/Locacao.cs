using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class Locacao
    {
        public Locacao()
        {
            TaxasEservicosUsada = new HashSet<TaxasEservicosUsada>();
        }

        public int Id { get; set; }
        public int Condutor { get; set; }
        public int Automovel { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataDevolucaoEsperada { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public double Caucao { get; set; }
        public int Funcionario { get; set; }
        public int? KmRegistrada { get; set; }
        public int? KmAutomovelFinal { get; set; }
        public int? PorcentagemFinalCombustivel { get; set; }
        public int PlanoSelecionado { get; set; }
        public int? Cupom { get; set; }

        public virtual Automovel AutomovelNavigation { get; set; }
        public virtual PessoaFisica CondutorNavigation { get; set; }
        public virtual Cupom CupomNavigation { get; set; }
        public virtual Funcionario FuncionarioNavigation { get; set; }
        public virtual ICollection<TaxasEservicosUsada> TaxasEservicosUsada { get; set; }
    }
}
