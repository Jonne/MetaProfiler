using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using MetaProfiler.Code.PropertyTypes;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Areas.Manage.Models
{
    public class AddPropertyCollection
    {
        public IEnumerable<SelectListItem> AvailablePropertyTypes { get; set; }
        public PropertyCollection PropertyCollection { get; set; }
    }


}
