using GoalChallenge.Infrastructure.Data.Repositories.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Commands.Items
{
    public class AddItemToInvetoryCommandHandler : AsyncRequestHandler<AddItemToInvetoryCommand>
    {
        private readonly IInventoryRepository _inventoryRepository;

        public AddItemToInvetoryCommandHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
        }

        protected override async Task Handle(AddItemToInvetoryCommand command, CancellationToken cancellationToken)
        {
            await _inventoryRepository.AddItemsToInventory(command.Inventory);
        }
    }
}
