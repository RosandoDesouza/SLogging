using SLogging.Core;
using System;

namespace SLogging.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var logDetails = GetSLogDetails("Starting Application", null);
            SLogger.WriteDiagnostic(logDetails);

            try
            {
                var ex = new Exception("Something bad has happend!");
                ex.Data.Add("input param", "nothing to see here");

                throw ex;
            }
            catch(Exception ex)
            {
                logDetails = GetSLogDetails("", ex);
                SLogger.WriteError(logDetails);
            }

            logDetails = GetSLogDetails("Used SLogging.Console application", null);
            SLogger.WriteUsage(logDetails);

            logDetails = GetSLogDetails("Stoping Application", null);
            SLogger.WriteDiagnostic(logDetails);
        }

        private static SLogDetails GetSLogDetails(string message, Exception exception)
        {
            return new SLogDetails()
            {
                Product = "SLogging",
                Location = "SLogging.Console",
                Layer = "Console App",
                Username = Environment.UserName,
                HostName = Environment.MachineName,
                Message = message,
                Exception = exception
            };
        }
    }
}
