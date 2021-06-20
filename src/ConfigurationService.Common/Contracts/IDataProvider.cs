using ConfigurationService.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationService.Common.Contracts
{
    public interface IDataProvider
    {
        EntityConfiguration GetEntityConfiguration(string entityName, List<string> fieldName);
        bool SaveEntityConfiguration(EntityConfiguration entityConfiguration);
    }
}
