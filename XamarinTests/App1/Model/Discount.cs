using Model.Interfaces;
using System;

namespace Model
{
    public class Discount : IModificationHistory
    {
        public decimal Price { get; set; }
        public int Percentage { get; set; }
        public string ProductName { get; set; }

        #region IModificationHistory members

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #endregion
    }
}
