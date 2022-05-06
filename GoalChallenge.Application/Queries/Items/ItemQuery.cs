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
        private readonly IItemRepository _itemRepository;

        public ItemQuery(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        public List<Item> GetAllItems()
        {
            return _itemRepository.GetAllItems();
        }
    }
}
