using System;

namespace Models.Interfaces
{
    public interface IModificationHistory
    {
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}
