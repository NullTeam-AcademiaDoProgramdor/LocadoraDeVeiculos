using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.AutomovelModule
{
    public class Automovel : EntidadeBase
    {
        public string Modelo { get; }

        public string Marca { get; }

        public string Cor { get; }
        
        public string Placa { get; }

        public string Chassi { get; }

        public int Ano { get; }

        public int NPortas { get; }

        public int CapacidadeTanque { get; }

        public int TamanhoPortaMalas { get; }

        public TipoCombustivelEnum TipoCombustivel { get; }

        public GrupoAutomovel Grupo { get; }


        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
