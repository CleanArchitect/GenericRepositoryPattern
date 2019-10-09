using System;

namespace Domain.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Uuid { get; private set; }

        public int Id { get; set; }

        public string CreatedBy { get; set; }
        
        public DateTime DateCreated { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }

        protected Entity()
        {
            Uuid = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
}
