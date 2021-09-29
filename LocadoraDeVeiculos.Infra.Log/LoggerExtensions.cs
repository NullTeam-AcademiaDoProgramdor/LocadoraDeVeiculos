using Serilog;
using System.IO;
using System.Runtime.CompilerServices;

namespace LocadoraDeVeiculos.Infra.Log
{
    public static class LoggerExtensions
    {
        public static ILogger Aqui(this ILogger logger,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return logger
                .ForContext("MemberName", memberName)
                .ForContext("ClassName", Path.GetFileNameWithoutExtension(sourceFilePath))
                .ForContext("LineNumber", sourceLineNumber);
        }

        public static void FuncionalidadeUsada(this ILogger logger)
        {
            logger.Information("Funcionalidade Usada");
        }
    }
}