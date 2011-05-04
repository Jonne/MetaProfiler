using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MetaProfiler.Areas.Manage.Models.Entities
{
    public class PropertyCollection
    {
        [Description("Naam")]
        public string Name { get; set; }
        public IList<ProfileProperty> Properties { get; set; }
    }
}
