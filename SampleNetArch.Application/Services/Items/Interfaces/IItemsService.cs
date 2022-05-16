using SampleNetArch.Common.Models;
using SampleNetArch.Domain.Models;

namespace SampleNetArch.Application.Services.Items.Interfaces
{
    public interface IItemsService
    {
        Task<dynamic> GetAllItems();
        Task AddItemsToInventory(InventoryInput inventoryInput);
        Task RemoveItemFromInventoryByName(string name);
    }
}
