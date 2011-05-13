using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Code.Data;
using MetaProfiler.Areas.Manage.Models.Entities;
using MetaProfiler.Areas.Manage.Models;
using MongoDB;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
using System.Threading;
using MongoDB.Bson;

namespace MetaProfiler.Areas.Manage.Controllers
{
    public class CharacterizationController : MongoDbController
    {
        [MongoDbActionFilter]
        public ActionResult Index()
        {
            IEnumerable<Characterization> characterizations = Database.GetCollection<Characterization>("Characterization")
                .FindAll()
                .ToList();

            return View(characterizations);
        }

        [MongoDbActionFilter]
        public ActionResult Create()
        {
            return View(new EditCharacterization
                {
                    PropertyNames = GetPropertyNames()
                });
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Create(Characterization characterization)
        {
            MongoCollection<Characterization> collection = Database.GetCollection<Characterization>("Characterization");
            collection.Insert(characterization);

            return RedirectToAction("Index");
        }

        [MongoDbActionFilter]
        public ActionResult Delete(ObjectId id)
        {
            MongoCollection<Characterization> collection = Database.GetCollection<Characterization>("Characterization");

            collection.Remove(Query.EQ("_id", id));

            return RedirectToAction("Index");
        }

        [MongoDbActionFilter]
        public ActionResult Edit(ObjectId id)
        {
            var characterization = Database.GetCollection<Characterization>("Characterization")
                .FindOneById(id);
            
            return View(new EditCharacterization
            {
                PropertyNames = GetPropertyNames(),
                Characterization = characterization 
            });
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Edit(Characterization characterization)
        {
            MongoCollection<Characterization> collection = Database.GetCollection<Characterization>("Characterization");

            collection.Save(characterization);

            return RedirectToAction("Index");
        }

        private IEnumerable<string> GetPropertyNames()
        {
            IEnumerable<string> propertyNames = Database.GetCollection<ProfileProperty>("ProfileProperty")
                .FindAll()
                .Select(x => x.Description)
                .ToList();
            return propertyNames;
        }

        [MongoDbActionFilter]
        public ActionResult NewClause()
        {
            ViewData["PropertyNames"] = GetPropertyNames();
            return PartialView("Clause", new Clause());
        }

        [MongoDbActionFilter]
        public ActionResult RunQuery(IEnumerable<Clause> query)
        {
            QueryComplete mongoQuery = new QueryTranslator()
                .Translate(query);

            MongoCollection<Profile> collection = Database.GetCollection<Profile>("Profile");
            IEnumerable<Profile> profiles = collection.Find(mongoQuery)
                .ToList();

            return PartialView("SearchResults", profiles);
        }
    }
}
