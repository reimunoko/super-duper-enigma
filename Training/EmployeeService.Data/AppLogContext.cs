
using System;
using System.Threading;
using System.Threading.Tasks;
using EmployeeService.Data.Configuration;
using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data
{
    public class AppLogContext : DbContext
    {
        public AppLogContext(DbContextOptions<AppLogContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogConfig());
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("CreatedDate").IsRequired(false);                
            }
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            DateTime timestamp = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries())
            {
                if ((entry.State == EntityState.Added)
                    && !entry.Metadata.IsOwned())
                {
                    entry.Property("CreatedDate").CurrentValue = timestamp;                  
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Log> Logs { get; set; }

    }
}
