using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MetaProfiler.Code.PropertyTypes
{
    public class ListSettings : PropertyTypeDetails
    {
        public IList<ListOption> Options { get; set; }
        public ListType Type { get; set; }
    }

    public enum ListType
    {
        Dropdownlist,
        ListBox
    }

    public class ListOption
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
