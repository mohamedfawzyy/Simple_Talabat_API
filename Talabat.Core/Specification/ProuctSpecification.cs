using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specification
{
    public class ProuctSpecification : BaseSpecification<Product>
    {
        public ProuctSpecification(int ID):base(P=>P.ID == ID) 
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
        public ProuctSpecification() :base(){

            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
