using System.Collections;
using AppHealth;

namespace SampleApp.AppHealth
{
    public class SmokeTest : IHealthCheckable
    {
        public bool IsUp()
        {
            return true;
        }
    }
}