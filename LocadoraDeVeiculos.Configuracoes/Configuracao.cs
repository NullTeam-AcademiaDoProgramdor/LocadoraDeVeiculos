using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Configuracoes
{
    public static class Configuracao
    {
        private static readonly Dictionary<string, string> camposIniciais
            = new Dictionary<string, string>()
            {
                {"precoGasolina", "0" },
                {"precoGas", "0" },
                {"precoDieses", "0" },
                {"precoAlcool", "0" },

                {"horaAbertura", new TimeSpan(8, 0, 0).ToString() },
                {"horaFechamento", new TimeSpan(18, 0, 0).ToString() },

                {"abreNoSabado", "0" },
                {"abreNoDomingo", "0" },
            };

        private static AppConfigControler appConfigControler;

        static Configuracao()
        {
            appConfigControler = new AppConfigControler();

            appConfigControler.AdicionarCamposCasoNaoExisntente(camposIniciais);
        }

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
