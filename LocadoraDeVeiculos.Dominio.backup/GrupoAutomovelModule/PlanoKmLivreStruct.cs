using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.GrupoAutomovelModule
{
    public struct PlanoKmLivreStruct
    {
        public double PrecoDia { get; }

        public PlanoKmLivreStruct(double precoDia)
        {
            PrecoDia = precoDia;
        }
    }
}