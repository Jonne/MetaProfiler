using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Configuration;
using MongoDB;
using MetaProfiler.Code.PropertyTypes;

namespace MetaProfiler.Code.Data
{
    public class MongoDbActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var mongoController = filterContext.Controller as MongoDbController;

            if (mongoController == null)
                return;

            // Todo: configuratie hoort hier niet
            var config = new MongoConfigurationBuilder();
            config.ConnectionString(x => x.Database = "test");

            config.Mapping(mapping =>
            {
                mapping.DefaultProfile(profile =>
                {
                    profile.SubClassesAre(y => y.IsSubclassOf(typeof(PropertyTypeDetails)));
                });
                mapping.Map<NumberSettings>();
                mapping.Map<ListSettings>();
                mapping.Map<DateSettings>();
            });

            var mongo = new Mongo(config.BuildConfiguration());
            mongo.Connect();

            var database = mongo.GetDatabase("MetaProfiler");

            mongoController.Mongo = mongo;
            mongoController.Database = database;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var mongoController = filterContext.Controller as MongoDbController;

            if (mongoController == null)
                return;

            var mongo = mongoController.Mongo;
            if (mongo == null)
                return;

            mongo.Disconnect();
        }
    }
}
