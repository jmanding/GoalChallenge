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
            Tools.ArgumentNull(inventory);
            _efContext.Add(inventory);
            await _efContext.SaveChangesAsync();
        }

        public List<Inventory> GetAllItemsFromInventory()
        {
            return _efContext.Inventorys.ToList();
        }
    }
}
