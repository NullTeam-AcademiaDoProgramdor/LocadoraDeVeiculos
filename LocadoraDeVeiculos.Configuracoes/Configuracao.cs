using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Configuracoes
{
    public static class Configuracao
    {
        public static double PrecoGasolina { get; set; }

        public static double PrecoGas { get; set; }

        public static double PrecoDiesel { get; set; }
        public static double PrecoAlcool { get; set; }

        public static TimeSpan HoraAbertura { get; set; }
        public static TimeSpan HoraFechamento { get; set; }

        public static bool AbreNoSabado { get; set; }
        public static bool AbreNoDomingo { get; set; }
    }
}
