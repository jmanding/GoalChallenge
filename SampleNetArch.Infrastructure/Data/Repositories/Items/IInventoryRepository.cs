using SampleNetArch.Domain.Models;

namespace SampleNetArch.Infrastructure.Data.Repositories.Items
{
    public interface IInventoryRepository
    {
        Task AddItemsToInventory(Inventory inventory);
        Task AddItemsToExistInventory(Inventory inventory);
        Task<List<Inventory>> GetAllItemsFromInventory();
        Task<Inventory> GetInventoryByName(string name);
        Task<Item> GetItemByName(string name);
        void RemoveItemFromInventory(Item item);
        Task UpdateInventories(List<Inventory> inventories);
    }
}