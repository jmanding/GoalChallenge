using GoalChallenge.Common;
using GoalChallenge.Domain.Models;
using GoalChallenge.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace GoalChallenge.Infrastructure.Data.Repositories.Items
{


    internal class InventoryRepository : IInventoryRepository
    {
        private readonly EFContext _efContext;

        public InventoryRepository(EFContext efContext)
        {
            _efContext = efContext ?? throw new ArgumentNullException(nameof(efContext));
        }

        public async Task AddItemsToInventory(Inventory inventory)
        {
            Tools.ArgumentNull(inventory, nameof(inventory));
            _efContext.Add(inventory);
            await _efContext.SaveChangesAsync();
        }

        public async Task AddItemsToExistInventory(Inventory inventory)
        {
            Tools.ArgumentNull(inventory, nameof(inventory));
            _efContext.Inventorys.Update(inventory);
            await _efContext.SaveChangesAsync();
        }

        public async Task<Inventory> GetInventoryByName(string name)
        {
            return await _efContext.Inventorys.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<List<Inventory>> GetAllItemsFromInventory()
        {
            return await _efContext.Inventorys.ToListAsync();
            
        }

        public async Task<Item> GetItemByName(string name)
        {
            return await _efContext.Items.Where(item => item.Name == name).SingleAsync();
        }

        public void RemoveItemFromInventory(Item item)
        {
            Tools.ArgumentNull(item, nameof(item));
            _efContext.Items.Remove(item);
        }

        public async Task UpdateInventories(List<Inventory> inventories)
        {
            Tools.ArgumentNull(inventories, nameof(inventories));
            _efContext.Inventorys.UpdateRange(inventories);
            await _efContext.SaveChangesAsync();

        }
    }
}
