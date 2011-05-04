﻿using System;
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
using MongoDB.Configuration;
using MetaProfiler.Code.Data;

namespace MetaProfiler.Areas.Manage.Controllers
{
    public class ProfilePropertyController : MongoDbController
    {
        //
        // GET: /Manage/ProfileProperty/
        [MongoDbActionFilter()]
        public ActionResult Index()
        {
            IEnumerable<ProfileProperty> properties = Database.GetCollection<ProfileProperty>()
                    .FindAll()
                    .Documents
                    .ToList();
            
            return View(properties);
        }

        public ActionResult Add()
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
        public ActionResult Delete(string description)
        {
            var collection = Database.GetCollection<ProfileProperty>();
            collection.Remove(new Document("Description", description));
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Add(AddProperty property)
        {
            IMongoCollection<ProfileProperty> mongoCollection = Database.GetCollection<ProfileProperty>();

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
