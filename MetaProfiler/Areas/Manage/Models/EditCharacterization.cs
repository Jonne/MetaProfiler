using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Areas.Manage.Models
{
    public class EditCharacterization
    {
        public Characterization Characterization { get; set; }

        public IEnumerable<string> PropertyNames { get; set; }
    }
}
