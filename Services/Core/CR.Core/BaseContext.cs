using CR.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CR.Core
{
    public abstract class BaseContext : DbContext
    {  
        public BaseContext(DbContextOptions options) : base(options)
        {
     
        }

        public override int SaveChanges()
        {
            UpdateEntities();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateEntities()
        {
            IEnumerator<EntityEntry<Entity>> enumrator = ChangeTracker.Entries<Entity>().GetEnumerator();
            while (enumrator.MoveNext())
            {
                EntityEntry<Entity> item = enumrator.Current;
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.Now;
                        item.Entity.CreatedBy = 1;
                        break;
                    case EntityState.Modified:
                        item.Entity.UpdatedDate = DateTime.Now;
                        item.Entity.UpdatedBy = 1;
                        break;
                }
            }
        }

    }
}
