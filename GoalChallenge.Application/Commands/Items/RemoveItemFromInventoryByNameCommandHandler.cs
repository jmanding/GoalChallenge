using FluentValidation;
using GoalChallenge.Application.Services.Items.Interfaces;
using GoalChallenge.Common;
using GoalChallenge.Infrastructure.Data.Repositories.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Commands.Items
{
    public class RemoveItemFromInventoryByNameCommandHandler : AsyncRequestHandler<RemoveItemFromInventoryByNameCommand>
    {
        private readonly IItemsService _itemsService;
        private readonly IValidator<RemoveItemFromInventoryByNameCommand> _validator;

        public RemoveItemFromInventoryByNameCommandHandler(IItemsService itemsService, IValidator<RemoveItemFromInventoryByNameCommand> validator)
        {
            _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        protected override async Task Handle(RemoveItemFromInventoryByNameCommand command, CancellationToken cancellationToken)
        {
            Tools.ArgumentNull(command, nameof(command));
            _validator.Validate(command).Result();

            await _itemsService.RemoveItemFromInventoryByName(command.Name);
        }
    }
}
