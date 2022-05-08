using GoalChallenge.Domain.Models;
using GoalChallenge.Infrastructure.Data.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Queries
{
    public class ItemQuery : IItemQuery
    {
        private readonly IInventoryRepository _itemRepository;

        public ItemQuery(IInventoryRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        public List<Inventory> GetAllItems()
        {
            return _itemRepository.GetAllItemsFromInventory();
        }
    }
}
