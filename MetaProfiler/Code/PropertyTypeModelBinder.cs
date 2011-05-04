using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MetaProfiler.Areas.Manage.Models;
using MetaProfiler.Code.PropertyTypes;
using System.ComponentModel;
using MetaProfiler.Areas.Manage.Models.Entities;

namespace MetaProfiler.Code
{
    public class ProfilePropertyModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor.PropertyType == typeof(PropertyTypeDetails))
            {
                return;
            }

            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var propertyType = (ProfileProperty)base.BindModel(controllerContext, bindingContext);

            IPropertyType type = new PropertyTypeResolver().ResolveAll()
                .Single(x => x.Name == propertyType.PropertyType);

            var modelMetadata = bindingContext.PropertyMetadata["Details"];

            propertyType.Details = (PropertyTypeDetails)base.BindModel(controllerContext, new ModelBindingContext(bindingContext)
            {
                ModelMetadata = new ModelMetadata(ModelMetadataProviders.Current, modelMetadata.ContainerType, null, type.Settings, modelMetadata.PropertyName),
                ModelName = string.Empty
            });

            return propertyType;
        }
    }
}
