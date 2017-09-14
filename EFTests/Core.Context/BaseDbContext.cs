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


            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditLog && e.State == EntityState.Modified)
                .ToList())
            {
                var entityName = entry.Entity.GetType().Name;
                var primaryKey = GetPrimaryKeyValue(entry);

                foreach (var propName in entry.OriginalValues.PropertyNames)
                {
                    //TODO: make use of "typeof(IModificationHistory).GetMembers()" here
                    if (propName == "DateCrated" || propName == "DateModified")
                        continue;

                    var originalValue = entry.OriginalValues[propName] != null ? entry.OriginalValues[propName].ToString() : "";
                    var currentValue = entry.CurrentValues[propName] != null ? entry.CurrentValues[propName].ToString() : "";
                    if (originalValue != currentValue)
                    {
                        ChangeLog log = new ChangeLog()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            PropertyName = propName,
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
