using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using System.Web.Mvc;

namespace MetaProfiler.Code.Data
{
    public class MongoDbController : Controller
    {
        public IMongoDatabase Database { get; set; }
        public IMongo Mongo { get; set; }
    }
}
    