using GoalChallenge.Application.Services.Items.Interfaces;
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

        public RemoveItemFromInventoryByNameCommandHandler(IItemsService itemsService)
        {
            _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
        }

        protected override async Task Handle(RemoveItemFromInventoryByNameCommand command, CancellationToken cancellationToken)
        {
            await _itemsService.RemoveItemFromInventoryByName(command.Name);
        }
    }
}
