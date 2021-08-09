using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.GrupoAutomovelModule
{
    public struct PlanoKmControladoStruct
    {
        public float PrecoDia { get; }
        public float PrecoKmExtrapolado { get; }
        public float KmDisponiveis { get; }

        public PlanoKmControladoStruct(float precoDia, float precoKmExtrapolado, float kmDisponiveis)
        {
            PrecoDia = precoDia;
            PrecoKmExtrapolado = precoKmExtrapolado;
            KmDisponiveis = kmDisponiveis;
        }
    }
}
