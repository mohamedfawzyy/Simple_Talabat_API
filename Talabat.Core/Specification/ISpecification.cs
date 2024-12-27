using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification
{
    public interface ISpecification<TClass> where TClass : BaseEntity
    {
        public Expression<Func<TClass, bool>>? Criteria { get; set; }
        public List<Expression<Func<TClass,object>>> Includes { get; set; }
    }
}
