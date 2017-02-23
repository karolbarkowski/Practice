namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class history2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Products", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Users", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductCategories", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
