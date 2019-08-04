using System;

namespace Examples.Domain.UseCases
{
    public abstract class BaseModel
    {
        public int? Id { get; set; }

        public string CreatedByUser { get; set; }
        
        public DateTime DateCreated { get; set; }

        public string ModifiedByUser { get; set; }

        public DateTime? DateLastModified { get; set; }

        protected BaseModel(IEntity entity)
        {
            Id = entity.Id;
            CreatedByUser = entity.CreatedBy;
            DateCreated = entity.DateCreated.ToLocalTime();
            ModifiedByUser = entity.ModifiedBy;
            DateLastModified = entity.DateModified?.ToLocalTime();
        }
    }
}
