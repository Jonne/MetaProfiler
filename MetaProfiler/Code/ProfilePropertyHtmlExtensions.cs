using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using MetaProfiler.Areas.Manage.Models.Entities;
using MetaProfiler.Code.PropertyTypes;
using MetaProfiler.Areas.Manage.Models;

namespace MetaProfiler.Code
{
    public static class ProfilePropertyHtmlExtensions
    {
        public static void RenderEditorFor(this HtmlHelper htmlHelper, ProfileProperty property)
        {
            RenderEditorFor(htmlHelper, property, null);
        }

        public static void RenderEditorFor(this HtmlHelper htmlHelper, ProfileProperty property, string value)
        {
            htmlHelper.RenderPartial(property.PropertyType, new PropertyValue
            {
                Property = property,
                Value = value
            });
        }

        public static void RenderDesignerFor(this HtmlHelper htmlHelper, ProfileProperty property)
        {
            IPropertyType propertyType = new PropertyTypeResolver().ResolveAll()
   .Single(x => x.Name == property.PropertyType);

            htmlHelper.RenderPartial(propertyType.Settings.Name, property.Details);
        }
    }
}
