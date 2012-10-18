using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AppHealth
{
    public class HealthChecker
    {
        public IEnumerable<Type> GetHealthCheckables()
        {
            var type = typeof(IHealthCheckable);
            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);
            return types;
        }

        public List<HealthCheckableStatus> GetStatus()
        {
            var stopWatch = new Stopwatch();
            var statuses = new List<HealthCheckableStatus>();

            var healthCheckables = GetHealthCheckables();
            foreach (var healthCheckable in healthCheckables)
            {
                var hc = (IHealthCheckable)Activator.CreateInstance(healthCheckable);
                stopWatch.Reset();
                stopWatch.Start();
                var isUp = hc.IsUp();
                stopWatch.Stop();
                statuses.Add(new HealthCheckableStatus(healthCheckable.Name, isUp, stopWatch.ElapsedMilliseconds));
            }
            return statuses;
        }
    }
}
