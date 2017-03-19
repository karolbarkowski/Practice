﻿using Context;
using Models;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace EFTestsConsoleApp
{
    class Program
    {
        private static void CheckLazyEagerLoading(EfTestsContext context)
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

                CheckInsert(context);
                //CheckLazyEagerLoading(context);


                //TODO: instead of writing up DTO classes, we could add some views to db, add them to context and query against these views
                //      - how to do views in code first?



                Console.ReadLine();
            }
        }
    }
}