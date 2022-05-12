﻿using FluentValidation;
using GoalChallenge.Application.Services.Items.Interfaces;
using GoalChallenge.Common;
using MediatR;

namespace GoalChallenge.Application.Commands.Items
{
    public class AddItemsToInvetoryCommandHandler : AsyncRequestHandler<AddItemsToInvetoryCommand>
    {
        private readonly IItemsService _itemsService;
        private readonly IValidator<AddItemsToInvetoryCommand> _validator;

        public AddItemsToInvetoryCommandHandler(IItemsService itemsService, IValidator<AddItemsToInvetoryCommand> validator)
        {
            _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        protected override async Task Handle(AddItemsToInvetoryCommand command, CancellationToken cancellationToken)
        {
            Tools.ArgumentNull(command, nameof(command));
            _validator.Validate(command).Result();
            
            await _itemsService.AddItemsToInventory(command.InventoryInput);
        }
    }
}
