using FluentValidation;
using GoalChallenge.Application.Commands.Items;
using GoalChallenge.Application.Services.Items.Interfaces;
using GoalChallenge.Common.Models;
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
    public class AddItemsToInvetoryCommandHandle
    {
        private readonly IRequestHandler<AddItemsToInvetoryCommand> _handler;
        private readonly Mock<IItemsService> _itemsServiceMock;
        private readonly Mock<IValidator<AddItemsToInvetoryCommand>> _validatorMock;

        public AddItemsToInvetoryCommandHandle()
        {
            _itemsServiceMock = new Mock<IItemsService>();
            _validatorMock = new Mock<IValidator<AddItemsToInvetoryCommand>>();
            _handler = new AddItemsToInvetoryCommandHandler(_itemsServiceMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task AddItemsToInventoryHandle()
        {
            await _handler.Handle(new AddItemsToInvetoryCommand(new Common.Models.InventoryInput()), CancellationToken.None);

            _itemsServiceMock.Verify(service => service.AddItemsToInventory(It.IsAny<InventoryInput>()));
        }
    }
}
