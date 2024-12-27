using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Repository
{
    internal static class SpecificationEvaluator<TClass> where TClass : BaseEntity
    {
        public static IQueryable<TClass> GetQuery(IQueryable<TClass> BaseQuery , ISpecification<TClass> Specs) { 
            
            var Query=BaseQuery;
            if (Specs.Criteria is not null) {
                Query = Query.Where(Specs.Criteria);    
            }
            Query = Specs.Includes.Aggregate(Query, (CurrnetQuery, includeExpression) => CurrnetQuery.Include(includeExpression));

            return Query;    
        }
    }
}
