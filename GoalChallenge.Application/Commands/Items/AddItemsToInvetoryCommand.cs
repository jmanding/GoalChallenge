using GoalChallenge.Common.Models;
using MediatR;

namespace GoalChallenge.Application.Commands.Items
{
    public class AddItemsToInvetoryCommand : IRequest
    {
        public InventoryInput InventoryInput { get; set; }

        public AddItemsToInvetoryCommand(InventoryInput inventoryInput)
        {
            InventoryInput = inventoryInput;
        }
    }
}
