using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaProfiler.Areas.Manage.Models.Entities
{
    public class Clause
    {
        public AndOr AndOr { get; set; }
        public string PropertyName { get; set; }
        public Operator Operator { get; set; }
        public string Value { get; set; }
    }

    public enum AndOr
    {
        And,
        Or
    }

    public enum Operator    
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan
    }
}
