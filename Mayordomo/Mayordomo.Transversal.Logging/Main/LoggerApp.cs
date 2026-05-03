using NLog;
using NLog.Config;
using NLog.Targets;

namespace Mayordomo.Transversal.Logging.Main
{
    public static class LoggerApp
    {
        public static void ConfigureNLog(string connectionStrings)
        {
            var config = new LoggingConfiguration();

            // Ruta personalizada
            var logDirectory = Path.Combine(AppContext.BaseDirectory, "logs");

            // Crear carpeta si no existe
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Target archivo
            var fileTarget = new FileTarget("logfile")
            {
                FileName = Path.Combine(logDirectory, "${shortdate}.log"),
                Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}|${exception:format=tostring}"
            };

            // Target base de datos
            var dbTarget = new DatabaseTarget("database")
            {
                ConnectionString = connectionStrings,
                CommandText = @"INSERT INTO dbo.LogError(Id, DateLog, Level, Logger, Message, Exception) VALUES(NEWID(),@DateLog, @Level, @Logger, @Message, @Exception);"
            };

            dbTarget.Parameters.Add(new DatabaseParameterInfo("@DateLog", "${longdate}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Level", "${level}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Logger", "${logger}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Message", "${message}"));
            dbTarget.Parameters.Add(new DatabaseParameterInfo("@Exception", "${exception:format=tostring}"));

            // Reglas para excluir Microsoft.* y System.* (sin targets, Final = true)
            var excludeMicrosoftDb = new LoggingRule("Microsoft.*", LogLevel.Trace, LogLevel.Fatal, dbTarget);
            excludeMicrosoftDb.Targets.Clear();
            excludeMicrosoftDb.Final = true;
            config.LoggingRules.Add(excludeMicrosoftDb);

            var excludeSystemDb = new LoggingRule("System.*", LogLevel.Trace, LogLevel.Fatal, dbTarget);
            excludeSystemDb.Targets.Clear();
            excludeSystemDb.Final = true;
            config.LoggingRules.Add(excludeSystemDb);

            var excludeMicrosoftFile = new LoggingRule("Microsoft.*", LogLevel.Trace, LogLevel.Fatal, fileTarget);
            excludeMicrosoftFile.Targets.Clear();
            excludeMicrosoftFile.Final = true;
            config.LoggingRules.Add(excludeMicrosoftFile);

            var excludeSystemFile = new LoggingRule("System.*", LogLevel.Trace, LogLevel.Fatal, fileTarget);
            excludeSystemFile.Targets.Clear();
            excludeSystemFile.Final = true;
            config.LoggingRules.Add(excludeSystemFile);
            // Reglas para excluir Microsoft.* y System.* (sin targets, Final = true)


            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, LogLevel.Error, fileTarget));
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Warn, LogLevel.Fatal, dbTarget));

            // Aplicar configuración
            LogManager.Configuration = config;
        }
    }
}
