using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Areas.Manage.Models
{
    public class AddProperty
    {
        public IEnumerable<SelectListItem> AvailablePropertyTypes { get; set; }
        public ProfileProperty NewProperty { get; set; }
    }
}
