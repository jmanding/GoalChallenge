using GoalChallenge.Common;
using GoalChallenge.Domain.Models;
using GoalChallenge.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Infrastructure.Data.Repositories.Items
{
    

    public class InventoryRepository : IInventoryRepository
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

        public Inventory? GetInventoryByName(string name)
        {
            return _efContext.Inventorys.FirstOrDefault(x => x.Name == name);
        }
        public List<Inventory> GetAllItemsFromInventory()
        {
            var res = _efContext.Inventorys.ToList();
            return res;
        }

        public Item GetItemByName(string name)
        {
            return _efContext.Items.Where(item => item.Name == name).Single();
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
