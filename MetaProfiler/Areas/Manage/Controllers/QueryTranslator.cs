using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Builders;
using MetaProfiler.Areas.Manage.Models.Entities;
using MongoDB.Bson;

namespace MetaProfiler.Areas.Manage.Controllers
{
    public class QueryTranslator
    {
        public QueryComplete Translate(IEnumerable<Clause> clauses)
        {
            QueryComplete mongoQuery = null;

            foreach (Clause clause in clauses)
            {
                var @operator = TranslateOperator(clause.Operator);
                
                QueryComplete clauseMongoQuery = @operator("Properties." + clause.PropertyName, clause.Value);

                if (mongoQuery == null)
                {
                    mongoQuery = clauseMongoQuery;
                }
                else
                {
                    if (clause.AndOr == AndOr.And)
                    {
                        mongoQuery = Query.And(mongoQuery, clauseMongoQuery);
                    }
                    else
                    {
                        mongoQuery = Query.Or(mongoQuery, clauseMongoQuery);
                    }
                }
            }
            return mongoQuery;
        }

        private static Func<string, BsonValue, QueryComplete> TranslateOperator(Operator @operator)
        {
            switch (@operator)
            {
                case Operator.Equals:
                    return Query.EQ;
                case Operator.NotEquals:
                    return Query.NE;
                case Operator.GreaterThan:
                    return Query.GT;
                case Operator.LessThan:
                    return Query.LT;
                default:
                    throw new InvalidOperationException("Unknown operator: " + @operator);
            }
        }
    }
}
