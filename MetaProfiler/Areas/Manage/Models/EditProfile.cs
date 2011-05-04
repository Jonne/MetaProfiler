using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Areas.Manage.Models
{
    public class EditProfile
    {
        public Profile Profile { get; set; }
        public IEnumerable<ProfileProperty> Properties { get; set; }
    }
}
