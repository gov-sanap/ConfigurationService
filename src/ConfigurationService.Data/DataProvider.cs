using ConfigurationService.Common.Contracts;
using ConfigurationService.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationService.Data
{
    public class DataProvider : IDataProvider
    {
        public EntityConfiguration GetEntityConfiguration(string entityName, List<string> fieldName)
        {
            try
            {
                using (var ctx = new EntityConfigurationContext())
                {
                    //ctx.Database.ExecuteSqlCommand("Select * from ");
                    var entityConfigurationData = new EntityConfigurationData() { Id = Guid.NewGuid(), EntityName = "something", FieldName = "firlsd", FieldSource = "source1", IsRequired = true, MaxLength = 120 };

                    ctx.EntityConfigurations.Add(entityConfigurationData);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            throw new NotImplementedException();
        }

        public bool SaveEntityConfiguration(EntityConfiguration entityConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}
