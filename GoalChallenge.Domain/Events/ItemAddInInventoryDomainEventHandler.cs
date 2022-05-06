using GoalChallenge.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Domain.Events
{
    public class ItemAddInInventoryDomainEventHandler : INotificationHandler<ItemAddInInventoryDomainEvent>
    {
        private readonly Serilog.ILogger _logger;

        public ItemAddInInventoryDomainEventHandler(Serilog.ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(ItemAddInInventoryDomainEvent notification, CancellationToken cancellationToken)
        {
            Tools.ArgumentNull(notification);

            _logger.Information($" Item Added {notification.Item.Name} Expiration date {notification.Item.ExpirationDate} ");

            return Task.CompletedTask;
        }
    }
}
