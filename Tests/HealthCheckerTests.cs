using System;
using System.Linq;
using System.Threading;
using AppHealth;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class HealthCheckerTests
    {
        public HealthChecker _healthChecker;

        [SetUp]
        public void SetUp()
        {
            _healthChecker = new HealthChecker();
        }

        [Test]
        public void Should_find_all_health_checkables()
        {
            var types = _healthChecker.GetHealthCheckables();
            var classNameToFind = typeof (ValidHealthCheckable).Name;
            var type = types.SingleOrDefault(x=>x.Name.Equals(classNameToFind));
            Assert.That(type, Is.Not.Null, string.Format("Couldn't find {0} in the list of IHealthCheckables.", classNameToFind));
        }

        [Test]
        public void Should_not_find_classes_that_are_not_health_checkable()
        {
            var types = _healthChecker.GetHealthCheckables();
            var classNameToFind = typeof(InvalidHealthCheckable).Name;
            var type = types.SingleOrDefault(x => x.Name.Equals(classNameToFind));
            Assert.That(type, Is.Null, string.Format("{0} is not a HelthCheckable and should not be found!", classNameToFind));
        }

        [Test]
        public void Should_list_all_health_checkable_statuses()
        {
            var statuses = _healthChecker.GetStatus();
            foreach (var status in statuses)
            {
                Console.WriteLine(status);
            }
            Assert.That(statuses, Is.Not.Null);
        }

        public class ValidHealthCheckable : IHealthCheckable
        {
            public bool IsUp()
            {
                return true;
            }
        }

        public class NodeThatIsDown : IHealthCheckable
        {
            public bool IsUp()
            {
                return false;
            }
        }

        public class SlowNode : IHealthCheckable
        {
            public bool IsUp()
            {
                Thread.Sleep(100);
                return true;
            }
        }

        public class InvalidHealthCheckable
        {
            // This one should not be picked up by the health checker!
        }
    }
}
