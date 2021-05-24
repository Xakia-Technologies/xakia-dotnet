using NodaTime;
using System;
using Xakia.API.Client.Helpers;
using Xunit;

namespace Xakia.API.Tests
{
    public class JsonExtensionTests
    {
        [Fact]
        public void TestNodaTimeDeserialisation()
        {
            var json = "{ 'instant': '2020-10-20T04:55:03.070816Z' }";
            var sut = json.FromJson<JsonTest>();

            Assert.IsType<Instant>(sut.Instant);
            Assert.Equal(sut.Instant.ToDateTimeUtc().Date, DateTime.Parse("2020-10-20T04:55:03.070816Z").Date);
        }
    }

    public class JsonTest
    {
        public Instant Instant { get; set; }
    }
}
