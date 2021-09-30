using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class Automovel
    {
        public Automovel()
        {
            FotoAutomovels = new HashSet<FotoAutomovel>();
            Locacaos = new HashSet<Locacao>();
        }

        public int Id { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string TipoCombustivel { get; set; }
        public double CapacidadeTanque { get; set; }
        public int Ano { get; set; }
        public double CapacidadePortaMalas { get; set; }
        public int NPortas { get; set; }
        public string Cambio { get; set; }
        public int Grupo { get; set; }
        public string Direcao { get; set; }
        public int? KmRegistrada { get; set; }

        public virtual GrupoAutomovel GrupoNavigation { get; set; }
        public virtual ICollection<FotoAutomovel> FotoAutomovels { get; set; }
        public virtual ICollection<Locacao> Locacaos { get; set; }
    }
}
