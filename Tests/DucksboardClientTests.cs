using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DucksboardClient;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DucksboardClientTests
    {
        [Test]
        public void Should_post_requests_to_ducksboard()
        {
            var client = new Client();
            var result = client.Push("83518", new {value = 50});
            Console.WriteLine(result);
        }
    }
}
