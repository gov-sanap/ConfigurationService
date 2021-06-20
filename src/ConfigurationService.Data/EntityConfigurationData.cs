using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationService.Data
{
    public class EntityConfigurationData
    {
        [Key]
        public Guid Id { get; set; }
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        public bool IsRequired { get; set; }
        public int MaxLength { get; set; }
        public string FieldSource { get; set; }
    }
}
