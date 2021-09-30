using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class TaxasEservicosUsada
    {
        public int Id { get; set; }
        public int TaxaEservico { get; set; }
        public int Locacao { get; set; }

        public virtual Locacao LocacaoNavigation { get; set; }
        public virtual TaxaEservico TaxaEservicoNavigation { get; set; }
    }
}
