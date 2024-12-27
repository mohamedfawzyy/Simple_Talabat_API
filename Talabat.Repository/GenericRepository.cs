using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specification;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<TClass> : IGenericRepository<TClass> where TClass : BaseEntity
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext )//ASK CLR TO Create object from Store Context implicity 
        {
            this._storeContext = storeContext;
        }
        public async Task<IEnumerable<TClass>> GetAllAsync()
        {
            ///if(typeof(TClass) ==  typeof(Product))
            ///    return (IEnumerable<TClass>) await this._storeContext.Set<Product>().Include(p=>p.Brand).Include(p=>p.Category).ToListAsync();
            return await this._storeContext.Set<TClass>().ToListAsync();
        }

        public async Task<TClass?> GetByIdAsync(int id)
        {
           ///if (typeof(TClass) == typeof(Product))
           ///    return await this._storeContext.Set<Product>().Include(P => P.Brand).Include(P => P.Category).FirstOrDefaultAsync() as TClass;
            return await this._storeContext.Set<TClass>().FindAsync(id);
        }


        public async Task<IEnumerable<TClass>> GetAllWithSpecsAsync(ISpecification<TClass> specs) { 
            
            return await SpecificationEvaluator<TClass>.GetQuery(_storeContext.Set<TClass>(), specs).ToListAsync();
        }

        public async Task<TClass?> GetByIdWithSpecsAsync(ISpecification<TClass> specs)
        {
            return await SpecificationEvaluator<TClass>.GetQuery(_storeContext.Set<TClass>(), specs).FirstOrDefaultAsync();
        }
    }
}
