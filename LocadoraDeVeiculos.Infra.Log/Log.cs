using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace LocadoraDeVeiculos.Infra.Log
{
    public static class Log
    {

        private static LoggingLevelSwitch levelSwitch = new();

        public static void ConfigurarLog()
        {

            bool logDetalhado = LerSeLogEstaDetalhado();
            SetDetalharLog(logDetalhado);

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
        }
        public static void SetDetalharLog(bool ativo)
        {
            if (ativo)
                levelSwitch.MinimumLevel = LogEventLevel.Debug;
            else
                levelSwitch.MinimumLevel = LogEventLevel.Error;
        }

        private static bool LerSeLogEstaDetalhado() 
            => Convert.ToBoolean(ConfigurationManager.AppSettings["logDetalhado"]);

    }
}
