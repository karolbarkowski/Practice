using Models;
using System.Data.Entity.ModelConfiguration;

namespace Context
{
    /// <summary>
    /// Fluent api model descriptions
    /// </summary>
    public class EfTestsContextDescription
    {
        public class UserMap : EntityTypeConfiguration<User>
        {
            public UserMap()
            {
                HasKey(t => t.Id);
                Property(p => p.Email).HasMaxLength(250).IsRequired();
                Property(p => p.Login).HasMaxLength(50).IsRequired();
            }
        }
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
    }
}
