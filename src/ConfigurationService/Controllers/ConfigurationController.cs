using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationService.Common.Contracts;
using ConfigurationService.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        IEntityConfigurationProvider _entityConfigurationProvider;
        public ConfigurationController(IEntityConfigurationProvider entityConfigurationProvider)
        {
            _entityConfigurationProvider = entityConfigurationProvider;
        }

        // GET: api/Configuration/Product
        [HttpGet("{entityName}", Name = "Get")]
        public async Task<IActionResult> GetAsync(string entityName)
        {
            var entityConfiguration = await _entityConfigurationProvider.GetEntityConfigurationAsync(entityName);

            return Ok(entityConfiguration);
        }

        // POST: api/Configuration
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EntityConfiguration entityConfiguration)
        {
            var status = await _entityConfigurationProvider.SaveEntityConfigurationAsync(entityConfiguration);

            return Ok(entityConfiguration);
        }
    }
}
