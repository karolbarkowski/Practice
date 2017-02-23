using Context;
using Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace EFTestsConsoleApp
{
    class Program
    {
        private static void CheckLoading(EfTestsContext context)
        {
            Product pDefault = context.Products.Find(1);
            //categories are not set as virtual so no eager loading occurs, we need to load them separately
            context.Entry(pDefault).Collection(c => c.Categories).Load();

            //or include them in query (System.Data.Entity reference for that lambda in Include() to work)
            Product pWithCategories = context.Products.Include(p => p.Categories).FirstOrDefaultAsync().Result;



            //IMPORTANT PERFORMANCE NOTES

            //1. AsNoTracking keeps EF from creating state tracking object which is faster when you don't need to track state
            //(like when you return data from api or controllers)
            Product pFaster = context.Products.AsNoTracking().First();    
        }

        private static void CheckInsert(EfTestsContext context)
        {
            context.ProductCategories.Add(new ProductCategory()
            {
                Name = "PC1"
            });

            context.SaveChanges();
        }

        static void Main(string[] args)
        {
            using (EfTestsContext context = new EfTestsContext())
            {
                context.Database.Log = Console.WriteLine;

                //CheckInsert(context);
                //CheckLoading(context);

                Console.ReadLine();
            }
        }
    }
}
