using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using MongoDB.Bson;

namespace MetaProfiler.Areas.Manage.Models.Entities
{
    public class Characterization
    {
        public ObjectId Id { get; set; }

        [DisplayName("Naam")]
        public string Name { get; set; }

        public IList<Clause> Clauses { get; set; }      
    }
}
