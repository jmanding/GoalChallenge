using GoalChallenge.Domain.Models;

namespace GoalChallenge.Infrastructure.Data.Repositories.Items
{
    public interface IItemRepository
    {
        Task AddItem(Item item);
        List<Item> GetAllItems();
    }
}