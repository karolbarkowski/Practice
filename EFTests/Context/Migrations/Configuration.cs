namespace Context.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EfTestsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EfTestsContext context)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Models.ProductCategory pc = context.ProductCategories.Add(new Models.ProductCategory()
            //    {
            //        Name = "Category_" + i.ToString()
            //    });

            //    pc.Products = new List<Models.Product>();

            //    for (int j = 0; j < 10; j++)
            //    {
            //        pc.Products.Add(new Models.Product()
            //        {
            //            Name = string.Format("Product_{0}_{1}", i, j),
            //            Price = j * 10
            //        });
            //    }
            //}
        }
    }
}
