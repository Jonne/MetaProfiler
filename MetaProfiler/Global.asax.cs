using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MetaProfiler.Areas.Manage.Models;
using MetaProfiler.Code;
using MetaProfiler.Areas.Manage.Models.Entities;
using MongoDB;

namespace MetaProfiler
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
    "Manage default", // Route name
    "Manage/{controller}/{action}/{id}" // URL with parameters
    );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ModelBinders.Binders.Add(typeof(ProfileProperty), new ProfilePropertyModelBinder());
            ModelBinders.Binders.Add(typeof(Document), new DocumentModelBinder());

            RegisterRoutes(RouteTable.Routes);
        }
    }
}