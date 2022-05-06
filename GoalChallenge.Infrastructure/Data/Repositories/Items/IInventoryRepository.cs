using GoalChallenge.Domain.Models;

namespace GoalChallenge.Infrastructure.Data.Repositories.Items
{
    public interface IInventoryRepository
    {
        Task AddItemsToInventory(Inventory inventory);
        List<Inventory> GetAllItemsFromInventory();
    }
}