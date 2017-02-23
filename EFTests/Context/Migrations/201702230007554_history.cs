namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class history : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductCategories", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "CreatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "DateModified");
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Products", "DateModified");
            DropColumn("dbo.Products", "DateCreated");
            DropColumn("dbo.ProductCategories", "DateModified");
            DropColumn("dbo.ProductCategories", "DateCreated");
        }
    }
}
