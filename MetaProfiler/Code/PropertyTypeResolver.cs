using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using MetaProfiler.Code.PropertyTypes;

namespace MetaProfiler.Code
{
    public class PropertyTypeResolver
    {
        public IEnumerable<IPropertyType> ResolveAll()
        {
            var assembly = Assembly.GetAssembly(typeof(IPropertyType));
            return assembly.GetTypes()
                .Where(x => typeof(IPropertyType).IsAssignableFrom(x) && x != typeof(IPropertyType))
                .Select(y => (IPropertyType)Activator.CreateInstance(y));
        }
    }
}
