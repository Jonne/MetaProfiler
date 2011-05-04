using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Code.Data;
using MetaProfiler.Areas.Manage.Models.Entities;
using MongoDB;
using MetaProfiler.Areas.Manage.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace MetaProfiler.Areas.Manage.Controllers
{
    public class ProfileController : MongoDbController
    {
        //
        // GET: /Manage/Profile/
        [MongoDbActionFilter]
        public ActionResult Index()
        {
            IEnumerable<Profile> profiles = Database.GetCollection<Profile>("Profile")
                .FindAll()
                .ToList();

            return View(profiles);
        }

        //
        // GET: /Manage/Profile/
        [MongoDbActionFilter]
        public ActionResult Create()
        {
            IEnumerable<ProfileProperty> properties = Database.GetCollection<ProfileProperty>("ProfileProperty")
                .FindAll()
                .ToList();

            return View(new EditProfile
            {
                Properties = properties
            });
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Create(Profile profile)
        {
            MongoCollection<Profile> collection = Database.GetCollection<Profile>("Profile");

            collection.Insert(profile);

            return RedirectToAction("Index");
        }

        [MongoDbActionFilter]
        public ActionResult Edit(ObjectId id)
        {
            IEnumerable<ProfileProperty> properties = Database.GetCollection<ProfileProperty>("ProfileProperty")
                .FindAll()
                .ToList();

            Profile profile = Database.GetCollection<Profile>("Profile")
                .FindOneById(id);

            return View(new EditProfile
            {
                Properties = properties,
                Profile = profile
            });
        }

        [MongoDbActionFilter]
        public ActionResult Delete(ObjectId id)
        {
            MongoCollection<Profile> collection = Database.GetCollection<Profile>("Profile");
            collection.Remove(Query.EQ("_id", id));

            return RedirectToAction("Index");
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Edit(Profile profile)
        {
            MongoCollection<Profile> collection = Database.GetCollection<Profile>("Profile");

            collection.Save(profile);

            return RedirectToAction("Index");
        }
    }
}
