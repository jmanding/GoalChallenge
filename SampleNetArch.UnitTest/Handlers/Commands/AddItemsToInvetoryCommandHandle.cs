using FluentValidation;
using GoalChallenge.Application.Commands.Items;
using MediatR;
using Moq;
using SampleNetArch.Application.Commands.Items;
using SampleNetArch.Application.Services.Items.Interfaces;
using SampleNetArch.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SampleNetArch.UnitTest.Handlers.Commands
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
            await _handler.Handle(new AddItemsToInvetoryCommand(new InventoryInput()), CancellationToken.None);

            _itemsServiceMock.Verify(service => service.AddItemsToInventory(It.IsAny<InventoryInput>()));
        }
    }
}
