namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catparent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "ParentCategoryId", c => c.Int());
            CreateIndex("dbo.ProductCategories", "ParentCategoryId");
            AddForeignKey("dbo.ProductCategories", "ParentCategoryId", "dbo.ProductCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "ParentCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.ProductCategories", new[] { "ParentCategoryId" });
            DropColumn("dbo.ProductCategories", "ParentCategoryId");
        }
    }
}
