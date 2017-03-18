using Models;
using Models.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace Context
{
    public class EfTestsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        public EfTestsContext() : base("EFTests")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //apply fluent api descriptions to refine generated database
            modelBuilder.Configurations.Add(new EfTestsContextDescription.UserMap());
            modelBuilder.Configurations.Add(new EfTestsContextDescription.ProductMap());
            modelBuilder.Configurations.Add(new EfTestsContextDescription.ProductCategoryMap());
        }


        //we can override SaveChanges to fill in all the fields that are common to IModificationHistory interface
        public override int SaveChanges()
        {
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

            return base.SaveChanges();

        }
    }
}
