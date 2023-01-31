using System.ComponentModel.DataAnnotations;

namespace Nutcache.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            Id = id;
        }

        [Key]
        public Guid Id { get; protected set; }
    }
}
