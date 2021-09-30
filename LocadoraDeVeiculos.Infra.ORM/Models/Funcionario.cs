using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Locacaos = new HashSet<Locacao>();
        }

        public string Nome { get; set; }
        public DateTime DataDeEntrada { get; set; }
        public double Salario { get; set; }
        public string Senha { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Locacao> Locacaos { get; set; }
    }
}
