﻿using Core.Context.EntityInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Model
{
    public class ProductCategory : IModificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }


        public int? ParentCategoryId { get; set; }
        public virtual ProductCategory ParentCategory { get; set; }


        #region IModificationHistory 

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        #endregion
    }
}
