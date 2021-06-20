using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using ConfigurationService.Common.Contracts;

namespace ConfigurationService.Core.Providers
{
    public class EntityFieldsProvider : IEntityFieldsProvider
    {
        private IConfiguration _configuration;
        public EntityFieldsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async System.Threading.Tasks.Task<List<string>> GetFieldNamesAsync(string serviceName, string entityName)
        {
            var url = _configuration.GetSection("externalServices").GetSection(serviceName).Value;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<string>>(apiResponse);
                }
            }
        }
    }
}
