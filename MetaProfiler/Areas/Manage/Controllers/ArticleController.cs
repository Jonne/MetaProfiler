using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Areas.Manage.Models.Entities;
using MetaProfiler.Areas.Manage.Models;
using MetaProfiler.Code.Data;
using MongoDB.Driver;

namespace MetaProfiler.Areas.Manage.Controllers
{
    public class ArticleController : MongoDbController
    {
        //
        // GET: /Manage/Article/
        [MongoDbActionFilter]
        public ActionResult Index()
        {
            IEnumerable<Article> articles = Database.GetCollection<Article>("Article")
                .FindAll()
                .ToList();

            return View(articles);
        }

        [MongoDbActionFilter]
        public ActionResult Create()
        {
            IEnumerable<string> characterizationNames = Database.GetCollection<Characterization>("Characterization")
                .FindAll()
                .Select(x => x.Name)
                .ToList();

            return View(new EditArticle
            {
                Article = new Article(),
                CharacterizationNames = characterizationNames
            });
        }

        [HttpPost]
        [MongoDbActionFilter]
        [ValidateInput(false)]
        public ActionResult Create(Article article)
        {
            MongoCollection<Article> collection = Database.GetCollection<Article>("Article");
            collection.Insert(article);

            return RedirectToAction("Index");
        }
    }
}
