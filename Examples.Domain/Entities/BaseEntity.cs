using System;

namespace Examples.Domain
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Uuid { get; protected set; }

        public int? Id { get; set; }

        public string CreatedBy { get; set; }
        
        public DateTime DateCreated { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }

        protected BaseEntity()
        {
            Uuid = Guid.NewGuid();
        }
    }
}
