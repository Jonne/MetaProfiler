using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;

namespace MetaProfiler.Code.Data
{
    public class MongoDbController : Controller
    {
        public MongoDatabase Database { get; set; }
        public MongoServer Mongo { get; set; }
    }
}
    