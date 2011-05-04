using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Areas.Manage.Models
{
    public class PropertyValue
    {
        public ProfileProperty Property { get; set; }
        public string Value { get; set; }
    }
}
