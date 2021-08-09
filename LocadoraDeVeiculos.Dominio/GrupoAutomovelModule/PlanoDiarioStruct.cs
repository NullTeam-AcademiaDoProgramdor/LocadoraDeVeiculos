using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.GrupoAutomovelModule
{
    public struct PlanoDiarioStruct
    {
        public float PrecoDia { get; }
        public float PrecoKm { get; }

        public PlanoDiarioStruct(float precoDia, float precoKm)
        {
            PrecoDia = precoDia;
            PrecoKm = precoKm;
        }
    }
}
