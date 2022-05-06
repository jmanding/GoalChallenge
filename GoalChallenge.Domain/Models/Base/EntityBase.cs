using System;

namespace GoalChallenge.Domain
{
	public class EntityBase
    {
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

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
