﻿using Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Product : IModificationHistory
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
