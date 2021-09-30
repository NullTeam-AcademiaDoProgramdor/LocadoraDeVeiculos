using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class Cupom
    {
        public Cupom()
        {
            Locacaos = new HashSet<Locacao>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Parceiro { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public double ValorMinimo { get; set; }
        public DateTime DataVencimento { get; set; }
        public int QtdUsos { get; set; }

        public virtual Parceiro ParceiroNavigation { get; set; }
        public virtual ICollection<Locacao> Locacaos { get; set; }
    }
}
