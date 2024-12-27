using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specification;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<TClass> where TClass :BaseEntity
    {
        public Task<TClass?> GetByIdAsync(int id);

        public Task<IEnumerable<TClass>> GetAllAsync();

        public Task<TClass?> GetByIdWithSpecsAsync(ISpecification<TClass> specs);

        public Task<IEnumerable<TClass>> GetAllWithSpecsAsync(ISpecification<TClass> specs);
    }
}
