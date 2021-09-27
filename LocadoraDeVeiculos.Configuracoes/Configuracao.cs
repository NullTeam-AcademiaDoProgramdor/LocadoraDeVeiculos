using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Infra.Log;

namespace LocadoraDeVeiculos.Infra.Configuracoes
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

                {"abreNoSabado", "false" },
                {"abreNoDomingo", "false" },
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
                double preco = Convert.ToDouble(appConfigControler.Ler("precoGasolina"));
                Serilog.Log.Information($"Lendo o preço da gasolina, valor lido: {preco}");
                return preco;
            }
            set
            {
                Serilog.Log.Information($"Setando o preço da gasolina: {value}");
                appConfigControler.Setar("precoGasolina", value);
            }
        }

        public static double PrecoGas
        {
            get
            {
                double preco = Convert.ToDouble(appConfigControler.Ler("precoGas"));
                Serilog.Log.Information($"Lendo o preço do gas, valor lido: {preco}");
                return preco;
            }
            set
            {
                Serilog.Log.Information($"Setando o preço do gas: {value}");
                appConfigControler.Setar("precoGas", value);
            }
        }

        public static double PrecoDiesel
        {
            get
            {
                double preco = Convert.ToDouble(appConfigControler.Ler("precoDieses"));
                Serilog.Log.Information($"Lendo o preço do diesel, valor lido: {preco}");
                return preco;
            }
            set
            {
                Serilog.Log.Information($"Setando o preço do diesel: {value}");
                appConfigControler.Setar("precoDieses", value);
            }
        }

        public static double PrecoAlcool
        {
            get
            {
                double preco = Convert.ToDouble(appConfigControler.Ler("precoAlcool"));
                Serilog.Log.Information($"Lendo o preço do alcool, valor lido: {preco}");
                return preco;
            }
            set
            {
                Serilog.Log.Information($"Setando o preço do alcool: {value}");
                appConfigControler.Setar("precoAlcool", value);
            }
        }

        public static TimeSpan HoraAbertura
        {
            get
            {
                TimeSpan hora = TimeSpan.Parse(appConfigControler.Ler("horaAbertura"));
                Serilog.Log.Information($"Lendo a hora de abertura, valor lido: {hora}");
                return hora;
            }
            set
            {
                Serilog.Log.Information($"Setando a hora de abertura: {value}");
                appConfigControler.Setar("horaAbertura", value);
            }
        }

        public static TimeSpan HoraFechamento
        {
            get
            {
                TimeSpan hora = TimeSpan.Parse(appConfigControler.Ler("horaFechamento"));
                Serilog.Log.Information($"Lendo a hora de fechamento, valor lido: {hora}");
                return hora;
            }
            set
            {
                Serilog.Log.Information($"Setando a hora de fechamento: {value}");
                appConfigControler.Setar("horaFechamento", value);
            }
        }

        public static bool AbreNoSabado
        {
            get
            {
                bool valor = Convert.ToBoolean(appConfigControler.Ler("abreNoSabado"));
                Serilog.Log.Information($"Lendo abre no sabado, valor lido: {valor}");
                return valor;
            }
            set
            {
                Serilog.Log.Information($"Setando abre no sabado: {value}");
                appConfigControler.Setar("abreNoSabado", value);
            }
        }

        public static bool AbreNoDomingo
        {
            get
            {
                bool valor = Convert.ToBoolean(appConfigControler.Ler("abreNoDomingo"));
                Serilog.Log.Information($"Lendo abre no domingo, valor lido: {valor}");
                return valor;
            }
            set
            {
                Serilog.Log.Information($"Setando abre no domingo: {value}");
                appConfigControler.Setar("abreNoDomingo", value);
            }
        }
    }
}
