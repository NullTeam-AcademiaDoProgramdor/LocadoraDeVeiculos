using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class GrupoAutomovel
    {
        public GrupoAutomovel()
        {
            Automovels = new HashSet<Automovel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double PlanoDiarioPrecoDia { get; set; }
        public double PlanoDiarioPrecoKm { get; set; }
        public double PlanoKmControladoPrecoDia { get; set; }
        public double PlanoKmControladoPrecoKmExtrapolado { get; set; }
        public double PlanoKmControladoKmDisponiveis { get; set; }
        public double PlanoKmLivrePrecoDia { get; set; }

        public virtual ICollection<Automovel> Automovels { get; set; }
    }
}
