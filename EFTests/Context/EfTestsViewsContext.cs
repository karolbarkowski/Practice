using Models.Views;
using System.Data.Entity;

namespace Context
{
    public class EfTestsViewsContext : DbContext
    {
        public DbSet<ProductData> ProductDataView { get; set; }


        public EfTestsViewsContext() : base("EFTests")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //apply fluent api descriptions to refine generated database
            modelBuilder.Configurations.Add(new EfTestsViewsContextDescription.ProductDataMap());
        }
    }
}
