using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class FotoAutomovel
    {
        public int Id { get; set; }
        public byte[] Foto { get; set; }
        public int Automovel { get; set; }

        public virtual Automovel AutomovelNavigation { get; set; }
    }
}
