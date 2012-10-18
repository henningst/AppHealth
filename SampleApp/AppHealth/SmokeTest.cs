using System;
using System.Collections;
using System.Threading;
using AppHealth;

namespace SampleApp.AppHealth
{
    public class SmokeTest : IHealthCheckable
    {
        public bool IsUp()
        {
            var random = new Random();
            Thread.Sleep(random.Next(10, 100));
            return true;
        }
    }
}