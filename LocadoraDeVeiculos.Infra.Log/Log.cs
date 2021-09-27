using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace LocadoraDeVeiculos.Infra.Log
{
    public static class Log
    {
        public static void ConfigurarLog()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
        }
    }
}
