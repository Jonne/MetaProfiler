using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Code;
using MetaProfiler.Areas.Manage.Models;
using MetaProfiler.Code.PropertyTypes;
using System.Net.Mime;
using System.IO;
using MongoDB;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Areas.Manage.Controllers
{
    public class PropertyCollectionController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<PropertyCollection> collections;

            using (var mongo = new Mongo())
            {
                mongo.Connect();

                var database = mongo.GetDatabase("MetaProfiler");
                collections = database.GetCollection<PropertyCollection>()
                    .FindAll().Documents.ToList();

                mongo.Disconnect();
            }

            return View("Index", collections);
        }

        //
        // GET: /Manage/PropertyCollection/

        public ActionResult Create()
        {
            var model = new AddPropertyCollection
            {
                AvailablePropertyTypes = new PropertyTypeResolver().ResolveAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Name
                })
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddPropertyCollection addPropertyCollection)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddPropertyCollection addPropertyCollection)
        {
            return View();
        }

        public ActionResult AddProperty(int index)
        {
            var model = new AddProperty()
            {
                AvailablePropertyTypes = new PropertyTypeResolver().ResolveAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Name
                }),
                NewProperty = new ProfileProperty()
            };
            return PartialView(model);
        }

        public ActionResult RenderDetails(string name, int index)
        {
            IPropertyType propertyType = new PropertyTypeResolver().ResolveAll()
                .Single(x => x.Name == name);

            var htmlHelper = new HtmlHelper(new ViewContext(ControllerContext, new WebFormView("omg"), new ViewDataDictionary(), new TempDataDictionary(), new StringWriter()), new ViewPage());

            return new ContentResult { Content = System.Web.Mvc.Html.EditorExtensions.Editor(htmlHelper, "PropertyCollection.Properties[" + index + "].Details", propertyType.Settings.Name).ToHtmlString() };
        }
    }
}
