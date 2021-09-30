using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class Parceiro
    {
        public Parceiro()
        {
            Cupoms = new HashSet<Cupom>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cupom> Cupoms { get; set; }
    }
}
