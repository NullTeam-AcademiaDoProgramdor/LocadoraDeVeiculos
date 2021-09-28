using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Serilog.Exceptions;

namespace LocadoraDeVeiculos.Infra.Log
{
    public static class Log
    {
        private const LogEventLevel LOG_OFF = ((LogEventLevel)1 + (int)LogEventLevel.Fatal);
        private static LoggingLevelSwitch levelSwitch = new();

        public static void ConfigurarLog()
        {
            if (LogEstaAtivado())
            {
                bool logDetalhado = LerSeLogEstaDetalhado();
                SetDetalharLog(logDetalhado);
            } else
                levelSwitch.MinimumLevel = LOG_OFF;


            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.WithExceptionDetails()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
        }
        public static void SetDetalharLog(bool ativo)
        {
            if (!LogEstaAtivado())
                return;

            if (ativo)
                levelSwitch.MinimumLevel = LogEventLevel.Debug;
            else
                levelSwitch.MinimumLevel = LogEventLevel.Error;
        }

        private static bool LerSeLogEstaDetalhado() 
            => Convert.ToBoolean(ConfigurationManager.AppSettings["logDetalhado"]);

        private static bool LogEstaAtivado()
            => Convert.ToBoolean(ConfigurationManager.AppSettings["ativarLog"]);
    }
}
