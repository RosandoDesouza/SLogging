using Serilog;
using Serilog.Events;
using SLogging.Core.Sink.SQlite;

namespace SLogging.Core
{
    public static class SLogger
    {
        private static readonly ILogger _performanceLogger;
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;

        static SLogger()
        {
            _performanceLogger = new LoggerConfiguration()
                .WriteTo.Async(x => x.File(path: "perf.txt"))
                .CreateLogger();

            _usageLogger = new LoggerConfiguration()
                .WriteTo.Async(x => x.File(path: "usage.txt"))
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()
                .WriteTo.Async(x => x.File(path: "error.txt"))
                .WriteTo.Async(x => x.SQLite("Log.db"))
                .CreateLogger();

            _diagnosticLogger = new LoggerConfiguration()
                .WriteTo.Async(x => x.File(path: "diagnostic.txt"))
                .CreateLogger();
        }

        public static void WritePerformance(SLogDetails performanceLogDetails)
        {
            _performanceLogger.Write(LogEventLevel.Information, "{@SLogDetails}", performanceLogDetails);
        }

        public static void WriteUsage(SLogDetails usageLogDetails)
        {
            _usageLogger.Write(LogEventLevel.Information, "{@SLogDetails}", usageLogDetails);
        }

        public static void WriteError(SLogDetails errorLogDetails)
        {
            _errorLogger.Write(LogEventLevel.Error, "{@SLogDetails}", errorLogDetails);
        }

        public static void WriteDiagnostic(SLogDetails diagnosticLogDetails)
        {
            _diagnosticLogger.Write(LogEventLevel.Information, "{@SLogDetails}", diagnosticLogDetails);
        }
    }
}
