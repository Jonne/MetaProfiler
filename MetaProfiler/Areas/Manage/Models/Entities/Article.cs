using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using MongoDB.Bson;

namespace MetaProfiler.Areas.Manage.Models.Entities
{
    public class Article
    {
        public ObjectId Id { get; set; }

        [DisplayName("Naam")]
        public string Name { get; set; }

        [DisplayName("Inhoud")]
        public string Body { get; set; }
        
        [DisplayName("Profielschetsen")]
        public IEnumerable<string> CharacterizationNames { get; set; }
    }
}
