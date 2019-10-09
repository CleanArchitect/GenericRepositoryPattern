using System;

namespace Domain.Entities
{
    public interface IEntity
    {
        int Id { get; }
        string CreatedBy { get; }
        DateTime DateCreated { get; }
        string ModifiedBy { get; }
        DateTime? DateModified { get; }
    }
}
