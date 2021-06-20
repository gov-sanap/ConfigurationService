using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationService.Common.Contracts
{
    public interface IEntityFieldProvider
    {
        Task<List<string>> GetFieldNamesAsync(string serviceName, string entityName);
    }
}
