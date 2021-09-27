using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace LocadoraDeVeiculos.Infra.Log
{
    public static class Log
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Log()
        {
            // Load configuration
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
