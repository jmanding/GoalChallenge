using SampleNetArch.Domain.Events.Base;

namespace SampleNetArch.Domain.Models.Base
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();


        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
        }

        public EntityBase(bool initialize)
        {
            if (!initialize) return;

            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow.Date;
            ModificationDate = DateTime.UtcNow.Date;
        }


    }
}
