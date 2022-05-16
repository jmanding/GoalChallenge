using SampleNetArch.Domain.Models;
using Moq;
using SampleNetArch.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SampleNetArch.UnitTest.Handlers.Events
{
    public class ItemAddInInventoryDomainEventHandle
    {
        private ItemAddInInventoryDomainEventHandler _handler;
        private Mock<Serilog.ILogger> _loggerMock;


        public ItemAddInInventoryDomainEventHandle()
        {
            _loggerMock = new Mock<Serilog.ILogger>();
            _handler = new ItemAddInInventoryDomainEventHandler(_loggerMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task AddItemsToInventoryNotificationHandle()
        {
            await _handler.Handle(new ItemAddInInventoryDomainEvent(new Item()), CancellationToken.None);

            _loggerMock.Verify(logger => logger.Information(It.IsAny<string>()));
        }
    }
}
