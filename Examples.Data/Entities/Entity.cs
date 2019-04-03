using System;

namespace Examples.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        string CreatedByUser { get; set; }
        
        DateTime DateCreated { get; set; }

        string ModifiedByUser { get; set; }

        DateTime DateLastModified { get; set; }
    }

    public abstract class Entity : IEntity
    {
        public Guid Uuid { get; protected set; }

        public int Id { get; set; }

        public string CreatedByUser { get; set; }
        
        public DateTime DateCreated { get; set; }

        public string ModifiedByUser { get; set; }

        public DateTime DateLastModified { get; set; }

        protected Entity()
        {
            Uuid = Guid.NewGuid();
        }
    }
}
