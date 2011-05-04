using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Code.Data;
using MetaProfiler.Areas.Manage.Models.Entities;
using MongoDB;
using MetaProfiler.Areas.Manage.Models;

namespace MetaProfiler.Areas.Manage.Controllers
{
    public class ProfileController : MongoDbController
    {
        //
        // GET: /Manage/Profile/
        [MongoDbActionFilter]
        public ActionResult Index()
        {
            IEnumerable<Profile> profiles = Database.GetCollection<Profile>()
                .FindAll()
                .Documents
                .ToList();

            return View(profiles);
        }

        //
        // GET: /Manage/Profile/
        [MongoDbActionFilter]
        public ActionResult Create()
        {
            IEnumerable<ProfileProperty> properties = Database.GetCollection<ProfileProperty>()
                .FindAll()
                .Documents
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
            IMongoCollection<Profile> collection = Database.GetCollection<Profile>();

            collection.Insert(profile);

            return RedirectToAction("Index");
        }

        [MongoDbActionFilter]
        public ActionResult Edit(string name)
        {
            IEnumerable<ProfileProperty> properties = Database.GetCollection<ProfileProperty>()
                .FindAll()
                .Documents
                .ToList();

            Profile profile = Database.GetCollection<Profile>()
                .FindOne(new { Name = name });

            return View(new EditProfile
            {
                Properties = properties,
                Profile = profile
            });
        }

        [MongoDbActionFilter]
        public ActionResult Delete(string name)
        {
            IMongoCollection<Profile> collection = Database.GetCollection<Profile>();

            collection.Remove(new { Name = name });

            return RedirectToAction("Index");
        }

        [HttpPost]
        [MongoDbActionFilter]
        public ActionResult Edit(Profile profile)
        {
            IMongoCollection<Profile> collection = Database.GetCollection<Profile>();

            collection.Update(profile, new { Name = profile.Name });

            return RedirectToAction("Index");
        }
    }
}
