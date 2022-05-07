using GoalChallenge.Domain.Models;

namespace GoalChallenge.Infrastructure.Data.Repositories.Items
{
    public interface IInventoryRepository
    {
        Task AddItemsToInventory(Inventory inventory);
        Task AddItemsToExistInventory(Inventory inventory);
        List<Inventory> GetAllItemsFromInventory();
        Inventory? GetInventoryByName(string name);
        Item GetItemByName(string name);
        void RemoveItemFromInventory(Item item);
        Task UpdateInventories(List<Inventory> inventories);
    }
}