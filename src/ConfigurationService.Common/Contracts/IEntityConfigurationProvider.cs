using ConfigurationService.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationService.Common.Contracts
{
    public interface IEntityConfigurationProvider
    {
        Task<EntityConfiguration> GetEntityConfigurationAsync(string entityName);
        Task<bool> SaveEntityConfigurationAsync(EntityConfiguration entityConfiguration);
    }
}
