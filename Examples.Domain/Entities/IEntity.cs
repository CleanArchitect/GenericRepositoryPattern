using System;

namespace Examples.Domain
{
    public interface IEntity
    {
        int? Id { get; set; }

        string CreatedBy { get; set; }
        
        DateTime DateCreated { get; set; }

        string ModifiedBy { get; set; }

        DateTime? DateModified { get; set; }
    }
}
