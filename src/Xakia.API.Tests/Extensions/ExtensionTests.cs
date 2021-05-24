using System;
using Xakia.API.Client.Services.Matters.Queries;
using Xunit;
using Xakia.API.Client.Helpers;

namespace Xakia.API.Tests
{
    public class ExtensionTests
    {
        private MattersQueryParams _mattersQueryParams;

        public ExtensionTests()
        {
            _mattersQueryParams = new MattersQueryParams
            {
                Cancelled = true,
                Completed = true,
                Search = "Search for me",
                PageNo = 1,
                PageSize = 10
            };
        }


        [Fact]
        public void CreateKeyValuePairs()
        {
            var keyValues = _mattersQueryParams.ToKeyValue();
            Assert.NotNull(keyValues);
            Assert.Equal(5, keyValues.Count);
         
        }


        [Fact]
        public void CreateMattersQueryString()
        {
            var keyValues = _mattersQueryParams.ToKeyValue();
            var queryString = keyValues.CreateQueryString();

            Assert.NotNull(queryString);
        }


        [Fact]
        public void CreateMattersQueryStringEncodedCorrectly()
        {
            _mattersQueryParams.Search = "Search for $me & %you";
            var keyValues = _mattersQueryParams.ToKeyValue();
            var queryString = keyValues.CreateQueryString();

            Assert.NotNull(queryString);
            Assert.DoesNotContain(_mattersQueryParams.Search, queryString);
        }
    }
}
