using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Code
{
    public class ProfileModelBinder : IModelBinder
    {
        #region IModelBinder Members

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Profile profile = new Profile
            {
                Properties = new Dictionary<string, string>()
            };

            foreach (string key in controllerContext.HttpContext.Request.Form.AllKeys)
            {
                string value = controllerContext.HttpContext.Request.Form[key];

                if (string.Compare(key, "Name", true) == 0)
                {
                    profile.Name = value;
                }
                else
                {
                    profile.Properties.Add(key, value);
                }
            }

            return profile;
        }

        #endregion
    }
}
