using ConfigurationService.Data;
using System;
using System.Collections.Generic;
using Xunit;

namespace ConfigurationService.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            DataProvider.GetEntityConfiguration("sad", new List<string> { "safa" });
        }
    }
}
