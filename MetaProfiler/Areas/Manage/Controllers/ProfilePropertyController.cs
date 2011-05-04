using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Areas.Manage.Models;
using MongoDB;
using MetaProfiler.Areas.Manage.Models.Entities;
using MetaProfiler.Code;
using MetaProfiler.Code.PropertyTypes;
using System.IO;

using MetaProfiler.Code.Data;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MetaProfiler.Areas.Manage.Controllers
{
    public class ProfilePropertyController : MongoDbController
    {
        //
        // GET: /Manage/ProfileProperty/
        [MongoDbActionFilter()]
        public ActionResult Index()
        {
            IEnumerable<ProfileProperty> properties = Database.GetCollection<ProfileProperty>("ProfileProperty")
                    .FindAll()
                    .ToList();
            
            return View(properties);
        }

        public ActionResult Create()
        {
            var model = new AddProperty()
            {
                AvailablePropertyTypes = new PropertyTypeResolver().ResolveAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Name
                }),
                NewProperty = new ProfileProperty(),
            };

            return View(model);
        }

        [MongoDbActionFilter]
        public ActionResult Delete(ObjectId id)
        {
            var collection = Database.GetCollection<ProfileProperty>("ProfileProperty");
            collection.Remove(Query.EQ("_id", id));
            
            return RedirectToAction("Index");
        }

        [MongoDbActionFilter]
        public ActionResult Edit(ObjectId id)
        {
            var collection = Database.GetCollection<ProfileProperty>("ProfileProperty");

            ProfileProperty property = collection.FindOneById(id);

            return View(property);
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Edit(ProfileProperty profileProperty)
        {
            var collection = Database.GetCollection<ProfileProperty>("ProfileProperty");

            collection.Save(profileProperty);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Create(AddProperty property)
        {
            MongoCollection<ProfileProperty> mongoCollection = Database.GetCollection<ProfileProperty>("ProfileProperty");

            mongoCollection.Insert(property.NewProperty);

            return RedirectToAction("Index");
        }

        public ActionResult RenderDetails(string name)
        {
            IPropertyType propertyType = new PropertyTypeResolver().ResolveAll()
            .Single(x => x.Name == name);   

            return PartialView(propertyType.Settings.Name);
        }
    }
}
