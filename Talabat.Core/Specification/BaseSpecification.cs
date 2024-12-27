using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification
{
    public class BaseSpecification<TClass> : ISpecification<TClass> where TClass : BaseEntity
    {
        public Expression<Func<TClass, bool>>? Criteria { get ; set ; }
        public List<Expression<Func<TClass, object>>> Includes { get; set ; } =new List<Expression<Func<TClass, object>>> ();

        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<TClass, bool>> ExpressionCriteria)
        {
            Criteria = ExpressionCriteria;  
        }
    }
}
