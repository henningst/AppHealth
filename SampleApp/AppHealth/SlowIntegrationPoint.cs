using System;
using System.Threading;
using AppHealth;

namespace SampleApp.AppHealth
{
    public class SlowIntegrationPoint : IHealthCheckable
    {
        public bool IsUp()
        {
            var random = new Random();
            Thread.Sleep(random.Next(400, 800));
            return true;
        }
    }
}