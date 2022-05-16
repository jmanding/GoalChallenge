using SampleNetArch.Common.Models;
using SampleNetArch.Domain.Models;

namespace SampleNetArch.Application.Services.Items.Interfaces
{
    public interface IItemsService
    {
        Task<List<Inventory>> GetAllItems();
        Task AddItemsToInventory(InventoryInput inventoryInput);
        Task RemoveItemFromInventoryByName(string name);
    }
}
