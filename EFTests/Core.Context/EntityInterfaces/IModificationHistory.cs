using System;

namespace Core.Context.EntityInterfaces
{
    public interface IModificationHistory
    {
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}
