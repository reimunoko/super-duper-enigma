using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Data;

namespace EmployeeService.Data.Repositories.Implementations
{
    public class BaseLogRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppLogContext context;

        public BaseLogRepository(AppLogContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public Task<T> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
