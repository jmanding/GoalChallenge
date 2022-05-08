using GoalChallenge.Domain.Events;
using GoalChallenge.Domain.Models;
using GoalChallenge.UnitTest.Inventories.Builder;
using GoalChallenge.UnitTest.Items.Builder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalChallenge.UnitTest.Handlers
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
