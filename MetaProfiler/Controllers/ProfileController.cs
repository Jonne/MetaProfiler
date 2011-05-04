using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Areas.Manage.Models.Entities;
using MongoDB;
using MetaProfiler.Code.PropertyTypes;
using MongoDB.Configuration;
using MetaProfiler.Code.Data;

namespace MetaProfiler.Controllers
{
    public class ProfileController : MongoDbController
    {
        IEnumerable<ProfileProperty> properties;

        [MongoDbActionFilter]
        public ActionResult Create()
        {
            properties = Database.GetCollection<ProfileProperty>()
                .FindAll().Documents.ToList();

            return View(properties);
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Create(Document document)
        {
            Database.GetCollection("Profiles")
                .Insert(document);
            
            return new EmptyResult();
        }
    }
}
