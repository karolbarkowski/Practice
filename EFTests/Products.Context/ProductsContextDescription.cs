using Products.Model;
using Products.Model.Views;
using System.Data.Entity.ModelConfiguration;

namespace Products.Context
{
    class ProductsContextDescription
    {
        public class ProductMap : EntityTypeConfiguration<Product>
        {
            public ProductMap()
            {
                HasKey(t => t.Id);
                Property(p => p.Name).HasMaxLength(50).IsRequired();
                Property(p => p.Price).IsRequired();
            }
        }

        public class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
        {
            public ProductCategoryMap()
            {
                HasKey(t => t.Id);
                Property(p => p.Name).HasMaxLength(50).IsRequired();
            }
        }

        public class ProductDataMap : EntityTypeConfiguration<ProductData>
        {
            public ProductDataMap()
            {
                ToTable("ProductsWithCategories");
            }
        }
    }
}
