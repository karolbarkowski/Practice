namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodcat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Product_Id" });
            CreateTable(
                "dbo.ProductProductCategories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        ProductCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.ProductCategory_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductCategory_Id);
            
            DropColumn("dbo.ProductCategories", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategories", "Product_Id", c => c.Int());
            DropForeignKey("dbo.ProductProductCategories", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductProductCategories", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductProductCategories", new[] { "ProductCategory_Id" });
            DropIndex("dbo.ProductProductCategories", new[] { "Product_Id" });
            DropTable("dbo.ProductProductCategories");
            CreateIndex("dbo.ProductCategories", "Product_Id");
            AddForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products", "Id");
        }
    }
}
