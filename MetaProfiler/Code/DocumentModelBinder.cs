using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB;

namespace MetaProfiler.Code
{
    public class DocumentModelBinder : IModelBinder
    {
        #region IModelBinder Members

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Document document = new Document();

            foreach (string key in controllerContext.HttpContext.Request.Form.AllKeys)
            {
                string value = controllerContext.HttpContext.Request.Form[key];

                document.Add(key, value);
            }

            return document;
        }

        #endregion
    }
}
