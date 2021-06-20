using ConfigurationService.Data;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConfigurationService.Tests
{
    public class EntityConfigurationProvider
    {
        [Fact]
        public void Test1()
        {
            var provider = new DataProvider();
            provider.GetEntityConfiguration("sad", new List<string> { "safa" });
        }
    }
}
