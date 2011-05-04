using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaProfiler.Code.PropertyTypes
{
    public class Number : IPropertyType
    {
        public string Name { get { return "Getal"; } }
        public Type Settings { get { return typeof(NumberSettings); } }
    }
}
