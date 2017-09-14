using Core.Context.Entities;
using Core.Context.EntityInterfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Core.Context
{
    public class BaseDbContext : DbContext
    {
        public virtual DbSet<ChangeLog> ChangeLogs { get; set; }


        public BaseDbContext() : base()
        {

        }

        public BaseDbContext(string connectionString) : base(connectionString)
        {

        }

        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }


        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            //take all newly added entries and fill in DateCreated
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory && e.State == EntityState.Added)
                .Select(e => e.Entity as IModificationHistory))
            {
                history.DateCreated = DateTime.Now;
            }

            //take all updated entries and fill in DateModified
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory && e.State == EntityState.Modified)
                .Select(e => e.Entity as IModificationHistory))
            {
                history.DateModified = DateTime.Now;
            }


            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditLog && e.State == EntityState.Modified)
                .ToList())
            {
                var entityName = history.Entity.GetType().Name;
                var primaryKey = GetPrimaryKeyValue(history);

                foreach (var prop in history.OriginalValues.PropertyNames)
                {
                    var originalValue = history.OriginalValues[prop].ToString();
                    var currentValue = history.CurrentValues[prop].ToString();
                    if (originalValue != currentValue)
                    {
                        ChangeLog log = new ChangeLog()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            PropertyName = prop,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            DateChanged = now
                        };

                        ChangeLogs.Add(log);
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
