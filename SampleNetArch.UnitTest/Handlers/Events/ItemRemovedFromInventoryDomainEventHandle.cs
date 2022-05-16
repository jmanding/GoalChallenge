using System;
using GoalChallenge.Domain.Models;
using Moq;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using SampleNetArch.Domain.Events;

namespace SampleNetArch.UnitTest.Handlers.Events
{
    public class ItemRemovedFromInventoryDomainEventHandle
    {
        private ItemRemovedFromInventoryDomainEventHandler _handler;
        private Mock<Serilog.ILogger> _loggerMock;


        public ItemRemovedFromInventoryDomainEventHandle()
        {
            _loggerMock = new Mock<Serilog.ILogger>();
            _handler = new ItemRemovedFromInventoryDomainEventHandler(_loggerMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task RemoveItemsToInventoryNotificationHandle()
        {
            await _handler.Handle(new ItemRemovedFromInventoryDomainEvent(new Item(), "Inventory1"), CancellationToken.None);

            _loggerMock.Verify(logger => logger.Information(It.IsAny<string>()));
        }
    }
}
