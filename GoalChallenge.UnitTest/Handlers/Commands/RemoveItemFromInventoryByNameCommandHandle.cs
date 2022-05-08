using FluentValidation;
using GoalChallenge.Application.Commands.Items;
using GoalChallenge.Application.Services.Items.Interfaces;
using MediatR;
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
    public class RemoveItemFromInventoryByNameCommandHandle
    {
        private readonly IRequestHandler<RemoveItemFromInventoryByNameCommand> _handler;
        private readonly Mock<IItemsService> _itemsServiceMock;
        private readonly Mock<IValidator<RemoveItemFromInventoryByNameCommand>> _validatorMock;

        public RemoveItemFromInventoryByNameCommandHandle()
        {
            _itemsServiceMock = new Mock<IItemsService>();
            _validatorMock = new Mock<IValidator<RemoveItemFromInventoryByNameCommand>>();
            _handler = new RemoveItemFromInventoryByNameCommandHandler(_itemsServiceMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {

            await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));

        }

        [Fact]
        public async Task RemoveItemsToInventoryHandle()
        {
            await _handler.Handle(new RemoveItemFromInventoryByNameCommand("item1"), CancellationToken.None);

            _itemsServiceMock.Verify(service => service.RemoveItemFromInventoryByName(It.IsAny<string>()));
        }
    }
}
