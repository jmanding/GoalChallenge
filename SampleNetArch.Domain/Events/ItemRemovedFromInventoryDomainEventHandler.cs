using MediatR;
using SampleNetArch.Common;

namespace SampleNetArch.Domain.Events
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
            Tools.ArgumentNull(notification, nameof(notification));

            _logger.Information($"Inventory {notification.InventoryName} -> Item Removed: {notification.Item.Name} ");

            return Task.CompletedTask;
        }
    }
}
