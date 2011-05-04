using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaProfiler.Code.PropertyTypes
{
    public class BooleanSettings : PropertyTypeDetails
    {
        public string TrueText
        {
            get;
            set;
        }

        public string FalseText
        {
            get;
            set;
        }
    }
}
