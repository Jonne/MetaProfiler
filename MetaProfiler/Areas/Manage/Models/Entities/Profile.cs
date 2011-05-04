using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MetaProfiler.Areas.Manage.Models.Entities
{
    public class Profile
    {
        [DisplayName("Naam")]
        public string Name { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
