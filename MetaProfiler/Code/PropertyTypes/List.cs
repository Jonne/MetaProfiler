using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaProfiler.Code.PropertyTypes
{
    public class List : IPropertyType
    {
        public string Name { get { return "Lijst"; } }
        public Type Settings { get { return typeof(ListSettings); } }
    }
}
