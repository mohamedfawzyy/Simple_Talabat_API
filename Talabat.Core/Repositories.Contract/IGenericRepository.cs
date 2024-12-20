using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<TClass> where TClass :BaseEntity
    {
        public Task<TClass?> GetByIdAsync(int id);

        public Task<IEnumerable<TClass>> GetAllAsync();
    }
}
