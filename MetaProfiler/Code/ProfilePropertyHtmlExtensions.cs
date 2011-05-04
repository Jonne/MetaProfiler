using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Code
{
    public static class ProfilePropertyHtmlExtensions
    {
        public static void RenderEditorFor(this HtmlHelper htmlHelper, ProfileProperty property)
        {
            htmlHelper.RenderPartial(property.PropertyType, property);
        }
    }
}
