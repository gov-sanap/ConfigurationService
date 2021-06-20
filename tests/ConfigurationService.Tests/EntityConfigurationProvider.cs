using ConfigurationService.Data;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using ConfigurationService.Common.Contracts;
using Microsoft.Extensions.Configuration;

namespace ConfigurationService.Tests
{
    public class EntityConfigurationProvider
    {
        private readonly Mock<IEntityFieldsProvider> _moqFieldsProvider = new Mock<IEntityFieldsProvider>();
        private readonly Mock<IDataProvider> _moqDataProvider = new Mock<IDataProvider>();
        private readonly Mock<IConfiguration> _moqConfiguration = new Mock<IConfiguration>();
        [Fact]
        public void Test1()
        {
            var serviceName = "";
            var entityName = "";
            List<string> fields = new List<string> { "", "" };
            _moqFieldsProvider.Setup(x => x.GetFieldNamesAsync(serviceName, entityName).Result).Returns(fields);
            _moqFieldsProvider.Setup(x => x.GetFieldNamesAsync(serviceName, entityName).Result).Returns(fields);
            var provider = new DataProvider();
            provider.GetEntityConfiguration("sad", new List<string> { "safa" });
        }
    }
}
