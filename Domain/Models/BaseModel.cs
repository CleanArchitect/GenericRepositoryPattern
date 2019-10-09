using Domain.Entities;

namespace Domain.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        protected BaseModel(IEntity entity)
        {
            Id = entity.Id;
        }
    }
}
