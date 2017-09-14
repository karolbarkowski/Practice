using Core.Context;
using Products.Model;
using Products.Model.Views;
using System.Data.Entity;

namespace Products.Context
{
    public class ProductsContext : BaseDbContext
    {
        // tables
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        //read only views
        public DbSet<ProductData> ProductDataView { get; private set; }

        public ProductsContext() : base()
        {

        }

        public ProductsContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ignore views in migration snapshots
            modelBuilder.Ignore<ProductData>();
            
            //apply fluent api descriptions to refine generated database
            modelBuilder.Configurations.Add(new ProductsContextDescription.ProductMap());
            modelBuilder.Configurations.Add(new ProductsContextDescription.ProductCategoryMap());
            modelBuilder.Configurations.Add(new ProductsContextDescription.ProductDataMap());
        }
    }
}
