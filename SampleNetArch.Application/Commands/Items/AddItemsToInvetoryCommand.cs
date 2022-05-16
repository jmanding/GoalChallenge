using MediatR;
using SampleNetArch.Common.Models;

namespace SampleNetArch.Application.Commands.Items
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
