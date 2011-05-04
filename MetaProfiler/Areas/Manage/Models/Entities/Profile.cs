using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using MongoDB.Bson;

namespace MetaProfiler.Areas.Manage.Models.Entities
{
    public class Profile
    {
        public ObjectId Id { get; set; }

        [DisplayName("Naam")]
        public string Name { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
