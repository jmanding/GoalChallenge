using GoalChallenge.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Domain.Events
{
    public class ItemRemovedFromInventoryDomainEventHandler : INotificationHandler<ItemRemovedFromInventoryDomainEvent>
    {
        private readonly Serilog.ILogger _logger;

        public ItemRemovedFromInventoryDomainEventHandler(Serilog.ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(ItemRemovedFromInventoryDomainEvent notification, CancellationToken cancellationToken)
        {
            Tools.ArgumentNull(notification);

            _logger.Information($"Inventory {notification.Item.Inventory.Name} -> Item Removed: {notification.Item.Name} ");

            return Task.CompletedTask;
        }
    }
}
