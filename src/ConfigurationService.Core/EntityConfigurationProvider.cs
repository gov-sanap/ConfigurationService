
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConfigurationService.Common.Models;
using ConfigurationService.Common.Contracts;

namespace ConfigurationService.Core
{
    public class EntityConfigurationProvider : IEntityConfigurationProvider
    {
        private IEntityFieldsProvider _entityFieldProvider;
        private IDataProvider _dataProvider;
        public EntityConfigurationProvider(IEntityFieldsProvider entityFieldProvider, IDataProvider dataProvider)
        {
            _entityFieldProvider = entityFieldProvider;
            _dataProvider = dataProvider;
        }
        public async Task<EntityConfiguration> GetEntityConfigurationAsync(string entityName)
        {
            EntityConfiguration entityConfiguration = null;
            try
            {
                var entityDefaultFields = await _entityFieldProvider.GetFieldNamesAsync("service1", entityName);
                var entityCustomFields = await _entityFieldProvider.GetFieldNamesAsync("service2", entityName);

                var allEntityFields = entityDefaultFields.Concat(entityCustomFields).ToList();

                entityConfiguration = _dataProvider.GetEntityConfiguration(entityName, allEntityFields);
            }
            catch(Exception ex)
            {
                //Log Exception
            }
            return entityConfiguration;
        }
        public async Task<bool> SaveEntityConfigurationAsync(EntityConfiguration entityConfiguration)
        {
            bool status = false;
            try
            {
                status = _dataProvider.SaveEntityConfiguration(entityConfiguration);
            }
            catch(Exception ex)
            {
                //Log Exception
            }
            return status;
        }
    }
}
