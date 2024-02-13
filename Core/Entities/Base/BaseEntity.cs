using Core.Entities.Base.Interfaces;

namespace Core.Entities
{
    public class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }
    }
}
