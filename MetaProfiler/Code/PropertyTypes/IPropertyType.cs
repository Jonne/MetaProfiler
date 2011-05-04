using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaProfiler.Code.PropertyTypes
{
    public interface IPropertyType
    {
        string Name { get; }
        Type Settings { get; }
    }
}
