using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfigurationService.Data
{
    public class EntityConfigurationContext : DbContext
    {
        public EntityConfigurationContext() : base("name=EntityConfigurationDB")
        {
            Database.SetInitializer<EntityConfigurationContext>(new CreateDatabaseIfNotExists<EntityConfigurationContext>());

        }

        public DbSet<EntityConfigurationData> EntityConfigurations { get; set; }
    }
}