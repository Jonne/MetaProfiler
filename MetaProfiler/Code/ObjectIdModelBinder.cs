using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.Web.Mvc;

namespace MetaProfiler.Code
{
public class ObjectIdModelBinder : DefaultModelBinder
{
    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (result == null)
        {
            return ObjectId.Empty;
        }
        return ObjectId.Parse((string)result.ConvertTo(typeof(string)));
    }
}
}
