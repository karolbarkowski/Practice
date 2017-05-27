using Models.Views;
using System.Data.Entity.ModelConfiguration;

namespace Context
{
    /// <summary>
    /// Fluent api model descriptions
    /// </summary>
    public class EfTestsViewsContextDescription
    {
        public class ProductDataMap : EntityTypeConfiguration<ProductData>
        {
            public ProductDataMap()
            {
                ToTable("ProductsWithCategories");
            }
        }
    }
}
