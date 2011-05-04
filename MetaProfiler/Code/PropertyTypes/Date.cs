using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaProfiler.Code.PropertyTypes
{
    public class Date : IPropertyType
    {
        public string Name
        {
            get { return "Datum"; }
        }

        public Type Settings
        {
            get { return typeof(DateSettings); }
        }
    }
}
