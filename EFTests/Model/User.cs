using Models.Interfaces;
using System;

namespace Models
{
    public class User : IModificationHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool IsActive { get; set; }


        #region IModificationHistory 

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        #endregion
    }
}
