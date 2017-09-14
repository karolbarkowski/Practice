namespace Products.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productData : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE VIEW [dbo].[ProductsWithCategories]
            AS SELECT dbo.Products.Name, dbo.Products.Price, dbo.ProductCategories.Name AS CategoryName, dbo.Products.Id
            FROM dbo.ProductCategories INNER JOIN
            dbo.ProductProductCategories ON dbo.ProductCategories.Id = dbo.ProductProductCategories.ProductCategory_Id INNER JOIN
            dbo.Products ON dbo.ProductProductCategories.Product_Id = dbo.Products.Id");
        }
        
        public override void Down()
        {
        }
    }
}
