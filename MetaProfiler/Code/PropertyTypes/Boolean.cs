using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaProfiler.Code.PropertyTypes
{
    public class Boolean : IPropertyType
    {
        #region IPropertyType Members

        public string Name
        {
            get { return "JaNee"; }
        }

        public Type Settings
        {
            get { return typeof(BooleanSettings); }
        }

        #endregion
    }
}
