using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationService.Common.Models
{
    public class EntityConfiguration
    {
        public string EntityName { get; set; }
        public List<Field> Fields { get; } = new List<Field>();
    }
}
