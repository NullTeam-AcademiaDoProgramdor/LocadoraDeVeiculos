using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class TaxaEservico
    {
        public TaxaEservico()
        {
            TaxasEservicosUsada = new HashSet<TaxasEservicosUsada>();
        }

        public int Id { get; set; }
        public bool EhFixo { get; set; }
        public double Preco { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<TaxasEservicosUsada> TaxasEservicosUsada { get; set; }
    }
}
