using Products.Context;
using Products.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EFTestsConsoleApp
{
    class Program
    {
        private static void CheckLazyEagerLoading(ProductsContext context)
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

        private static void CheckInsert(ProductsContext context)
        {
            var newPC = new ProductCategory()
            {
                Name = "Category 1"
            };

            var newProd = new Product()
            {
                Name = "Product 1",
                Price = 100,
                Categories = new List<ProductCategory>() { newPC }
            };

            context.Entry(newPC).State = EntityState.Added;
            context.Entry(newProd).State = EntityState.Added;

            context.SaveChanges();
        }


        static void Main(string[] args)
        {
            //// Inicjalizacja kernela
            //IKernel ninjectKernel = new StandardKernel();
            //// Bindowanie
            //ninjectKernel.Bind<ILogger>().To<ConsoleLogger>();

            //MainApp mainApp = new MainApp(ninjectKernel.Get<ILogger>());
            //mainApp.Run();
            //// Czekamy na klawisz
            //Console.ReadKey();




            using (ProductsContext context = new ProductsContext("EFTests"))
            {
                #region Log definition
                //these are some logs we can use out fo the box
                //context.Database.Log = message => Debug.Write(message);
                //context.Database.Log = message => Trace.Write(message);
                context.Database.Log = Console.WriteLine;
                #endregion

                #region Custom Trace/Debug listeners definition
                //ConsoleTraceListener myWriter = new ConsoleTraceListener();
                ///Trace.Listeners.Add(myWriter);
                #endregion

                var p = context.Products.First();
                p.Name += "X";
                context.SaveChanges();

                //CheckInsert(context);
                //CheckLazyEagerLoading(context);


                //TODO: instead of writing up DTO classes, we could add some views to db, add them to context and query against these views
                //      - how to do views in code first?



                Console.ReadLine();
            }
        }
    }
}
