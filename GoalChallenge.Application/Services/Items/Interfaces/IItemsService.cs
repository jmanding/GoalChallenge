using GoalChallenge.Common.Models;
using GoalChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Services.Items.Interfaces
{
    public interface IItemsService
    {
        Task AddItemsToInventory(InventoryInput inventoryInput);
        Task RemoveItemFromInventoryByName(string name);
    }
}
