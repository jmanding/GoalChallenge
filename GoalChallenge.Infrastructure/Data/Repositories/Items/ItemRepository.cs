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
    

    public class ItemRepository : IItemRepository
    {
        private readonly EFContext _efContext;

        public ItemRepository(EFContext efContext)
        {
            _efContext = efContext ?? throw new ArgumentNullException(nameof(efContext));
        }

        public async Task AddItem(Item item)
        {
            Tools.ArgumentNull(item);
            _efContext.Add(item);
            await _efContext.SaveChangesAsync();
        }

        public List<Item> GetAllItems()
        {
            return _efContext.Items.ToList();
        }
    }
}
