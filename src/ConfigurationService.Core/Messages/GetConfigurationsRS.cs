using ConfigurationService.Common.Models;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationService.Core.Messages
{
    public class GetConfigurationsRS
    {
        public List<EntityConfiguration> Configurations { get; } = new List<EntityConfiguration>(); 
    }
}
