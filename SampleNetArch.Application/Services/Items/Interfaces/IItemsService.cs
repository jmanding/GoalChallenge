using GoalChallenge.Common.Models;
using GoalChallenge.Domain.Models;

namespace GoalChallenge.Application.Services.Items.Interfaces
{
    public interface IItemsService
    {
        Task<List<Inventory>> GetAllItems();
        Task AddItemsToInventory(InventoryInput inventoryInput);
        Task RemoveItemFromInventoryByName(string name);
    }
}
