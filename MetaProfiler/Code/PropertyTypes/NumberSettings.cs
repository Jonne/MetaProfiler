using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaProfiler.Code.PropertyTypes
{
    public enum NumberType
    {
        @int,
        @decimal
    }

    public class NumberSettings : PropertyTypeDetails
    {
        public NumberType Type { get; set; }
        public int Length { get; set; }
    }
}
