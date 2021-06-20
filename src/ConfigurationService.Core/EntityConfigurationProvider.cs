
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConfigurationService.Common.Models;
using ConfigurationService.Common.Contracts;

namespace ConfigurationService.Core
{
    public class EntityConfigurationProvider
    {
        private IEntityFieldProvider _entityFieldProvider;
        private IDataProvider _dataProvider;
        public EntityConfigurationProvider(IEntityFieldProvider entityFieldProvider, IDataProvider dataProvider)
        {
            _entityFieldProvider = entityFieldProvider;
            _dataProvider = dataProvider;
        }
        public async Task<EntityConfiguration> GetEntityConfigurationAsync(string entityName)
        {
            //throw new NotImplementedException();
            var entityDefaultFields = await _entityFieldProvider.GetFieldNamesAsync("service1", entityName);
            var entityCustomFields = await _entityFieldProvider.GetFieldNamesAsync("service2", entityName);

            var allEntityFields = entityDefaultFields.Concat(entityCustomFields).ToList();

            var entityConfiguration = _dataProvider.GetEntityConfiguration(entityName, allEntityFields);
            return entityConfiguration;
        }
        public async Task<bool> SaveEntityConfigurationAsync(EntityConfiguration entityConfiguration)
        {
            bool status = _dataProvider.SaveEntityConfiguration(entityConfiguration);
            return status;
        }
    }
}
