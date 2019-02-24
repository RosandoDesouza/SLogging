using System;
using System.Collections.Generic;

namespace SLogging.Core
{
    public class SLogDetails
    {
        public SLogDetails()
        {
            Timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp { get; }

        public string Message { get; set; }

        //Where
        public string Product { get; set; }

        public string Layer { get; set; }

        public string Location { get; set; }

        public string HostName { get; set; }

        //Who
        public string UserId { get; set; }

        public string Username { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        //Everything Else
        public long? ElapsedMilliseconds { get; set; } //Only for performance entries

        public Exception Exception { get; set; } //The exception for error logging

        public string CorrelationId { get; set; } //Exception shielding from server to client

        public Dictionary<string, object> AdditionalInfo { get; set; } //Catch-All for anything else
    }
}
