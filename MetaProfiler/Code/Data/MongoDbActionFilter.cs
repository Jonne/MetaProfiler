using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB;
using MetaProfiler.Code.PropertyTypes;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

namespace MetaProfiler.Code.Data
{
    public class MongoDbActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var mongoController = filterContext.Controller as MongoDbController;

            if (mongoController == null)
                return;

            var mongo = MongoServer.Create();

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
