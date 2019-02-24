using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace SLogging.Core
{
    public class PerformanceTracker
    {
        private readonly Stopwatch _stopwatch;
        private readonly SLogDetails _logDetails;

        public PerformanceTracker(string name, 
            string userId, string username,
            string location, string product,
            string layer)
        {
            _stopwatch = Stopwatch.StartNew();

            _logDetails = new SLogDetails()
            {
                Message = name,
                UserId = userId,
                Username = username,
                Product = product,
                Layer = layer,
                Location = location,
                HostName = Environment.MachineName
            };

            var beginTime = DateTime.UtcNow;
            _logDetails.AdditionalInfo = new Dictionary<string, object>()
            {
                { "Started", beginTime.ToString(CultureInfo.InvariantCulture) }
            };
        }

        public PerformanceTracker(string name,
            string userId, string username,
            string location, string product, string layer, 
            Dictionary<string, object> perforamceParams)
            : this(name, userId, username, location, product, layer)
        {
            foreach(var item in perforamceParams)
            {
                _logDetails.AdditionalInfo.Add($"input-{item.Key}", item.Value);
            }
        }

        public void Stop()
        {
            _stopwatch.Stop();
            _logDetails.ElapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            SLogger.WritePerformance(_logDetails);
        }
    }
}
