using Core.Context.EntityInterfaces;
using System;
using System.Collections.Generic;

namespace Products.Model
{
    public class Product : IModificationHistory, IAuditLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //not a virtual method to aovid eager loading
        public List<ProductCategory> Categories { get; set; }


        #region IModificationHistory 

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        #endregion
    }
}
