using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Domain.Events.Base
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime CreateDate = DateTime.UtcNow;
    }
}
