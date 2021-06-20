using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationService.Common.Models
{
    public class Field
    {
        public string FieldName { get; set; }
        public bool IsRequired { get; set; }
        public int MaxLength { get; set; }
        public string FieldSource { get; set; }
    }
}
