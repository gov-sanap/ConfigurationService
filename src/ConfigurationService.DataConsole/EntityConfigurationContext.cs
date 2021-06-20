using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConfigurationService.DataConsole
{
    public class EntityConfigurationContext : DbContext
    {
        public EntityConfigurationContext() : base("name=EntityConfigurationDB")
        {
            Database.SetInitializer<EntityConfigurationContext>(new CreateDatabaseIfNotExists<EntityConfigurationContext>());

        }
        //public EntityConfigurationContext(DbContextOptions<EntityConfigurationContext> options) : base(options)
        //{

        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //ServiceLocator
        //        //IConfigurationRoot configuration = new ConfigurationBuilder()
        //        //   .SetBasePath(Directory.GetCurrentDirectory())
        //        //   .AddJsonFile("appsettings.json")
        //        //   .Build();
        //        //var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
        //        var connectionString = "Data Source=.;Initial Catalog=EntityConfiguration;Integrated Security=true";
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}

        public DbSet<EntityConfigurationData> EntityConfigurations { get; set; }
    }
}