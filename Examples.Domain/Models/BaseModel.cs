using Examples.Data.Entities;
using System;

namespace Examples.Domain.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public string CreatedByUser { get; set; }
        
        public DateTime DateCreated { get; set; }

        public string ModifiedByUser { get; set; }

        public DateTime DateLastModified { get; set; }

        protected BaseModel(IEntity entity)
        {
            this.Id = entity.Id;
            this.CreatedByUser = entity.CreatedByUser;
            this.DateCreated = entity.DateCreated.ToLocalTime();
            this.ModifiedByUser = entity.ModifiedByUser;
            this.DateLastModified = entity.DateLastModified.ToLocalTime();
        }
    }
}
