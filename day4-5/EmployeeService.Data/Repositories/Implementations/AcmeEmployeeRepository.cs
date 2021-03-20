using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeService.Data.Repositories.Interfaces;
using EmployeeService.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data.Repositories.Implementations
{
    public class AcmeEmployeeRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly EmployeeContext context;

        public AcmeEmployeeRepository(EmployeeContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
           
            return await context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await context.Set<T>().FindAsync(keyValues, cancellationToken);
        }
    }
}
