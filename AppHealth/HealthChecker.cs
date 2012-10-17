using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var statuses = new List<HealthCheckableStatus>();

            var healthCheckables = GetHealthCheckables();
            foreach (var healthCheckable in healthCheckables)
            {
                var hc = (IHealthCheckable)Activator.CreateInstance(healthCheckable);
                statuses.Add(new HealthCheckableStatus(healthCheckable.Name, hc.IsUp()));
            }
            return statuses;
        }
    }
}
