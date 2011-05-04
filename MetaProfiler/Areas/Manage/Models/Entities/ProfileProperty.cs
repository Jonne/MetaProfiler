using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetaProfiler.Code.PropertyTypes;
using System.ComponentModel;

namespace MetaProfiler.Areas.Manage.Models.Entities
{
    public class ProfileProperty
    {
        [DisplayName("Beschrijving")]
        public string Description { get; set; }

        [DisplayName("Soort eigenschap")]
        public string PropertyType { get; set; }

        public PropertyTypeDetails Details { get; set; }
    }
}
