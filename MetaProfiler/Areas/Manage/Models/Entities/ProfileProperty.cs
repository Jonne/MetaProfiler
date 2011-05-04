using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetaProfiler.Code.PropertyTypes;
using System.ComponentModel;
using MongoDB.Bson;

namespace MetaProfiler.Areas.Manage.Models.Entities
{
    public class ProfileProperty
    {
        public ObjectId Id { get; set; }

        [DisplayName("Beschrijving")]
        public string Description { get; set; }

        [DisplayName("Soort eigenschap")]
        public string PropertyType { get; set; }

        public PropertyTypeDetails Details { get; set; }
    }
}
