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
            appConfigControler = new AppConfigControler(camposIniciais);
        }

        public static double PrecoGasolina 
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoGasolina"));
            }
            set
            {
                appConfigControler.Setar("precoGasolina", value);
            }
        }

        public static double PrecoGas 
        {
            get 
            {
                return Convert.ToDouble(appConfigControler.Ler("precoGas"));
            }
            set 
            {
                appConfigControler.Setar("precoGas", value);
            }
        }

        public static double PrecoDiesel
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoDieses"));
            }
            set
            {
                appConfigControler.Setar("precoDieses", value);
            }
        }

        public static double PrecoAlcool
        {
            get
            {
                return Convert.ToDouble(appConfigControler.Ler("precoAlcool"));
            }
            set
            {
                appConfigControler.Setar("precoAlcool", value);
            }
        }

        public static TimeSpan HoraAbertura
        {
            get
            {
                return TimeSpan.Parse(appConfigControler.Ler("horaAbertura"));
            }
            set
            {
                appConfigControler.Setar("horaAbertura", value);
            }
        }

        public static TimeSpan HoraFechamento
        {
            get
            {
                return TimeSpan.Parse(appConfigControler.Ler("horaFechamento"));
            }
            set
            {
                appConfigControler.Setar("horaFechamento", value);
            }
        }

        public static bool AbreNoSabado
        {
            get
            {
                return Convert.ToBoolean(appConfigControler.Ler("abreNoSabado"));
            }
            set
            {
                appConfigControler.Setar("abreNoSabado", value);
            }
        }

        public static bool AbreNoDomingo
        {
            get
            {
                return Convert.ToBoolean(appConfigControler.Ler("abreNoSabado"));
            }
            set
            {
                appConfigControler.Setar("abreNoSabado", value);
            }
        }
    }
}
