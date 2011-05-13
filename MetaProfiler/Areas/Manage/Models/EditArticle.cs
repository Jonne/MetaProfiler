using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Areas.Manage.Models
{
    public class EditArticle
    {
        public Article Article { get; set; }
        public IEnumerable<string> CharacterizationNames { get; set; }
    }
}
