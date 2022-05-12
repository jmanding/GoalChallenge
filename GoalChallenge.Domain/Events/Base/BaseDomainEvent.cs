using MediatR;

namespace GoalChallenge.Domain.Events.Base
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime CreateDate = DateTime.UtcNow;
    }
}
