using GoalChallenge.Application.Services.Items.Interfaces;
using GoalChallenge.Common;
using GoalChallenge.Common.Models;
using GoalChallenge.Domain.Models;
using GoalChallenge.Infrastructure.Data.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Application.Services.Items
{
    public class ItemsService : IItemsService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public ItemsService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
        }

        public async Task AddItemsToInventory(InventoryInput inventoryInput)
        {
            List<Item> itemsInput = new List<Item>();
            inventoryInput.Items.ForEach(item => itemsInput.Add(new Item() { Name = item.Name, ExpirationDate = item.ExpirationDate, Type = item.Type }));

            var inventoryExist = _inventoryRepository.GetInventoryByName(inventoryInput.Name);

            if (inventoryExist != null)
            {
                //var res1 = Tools.ExceptionLists(itemsInput, inventoryExist.Items);
                //var res2 = Tools.ExceptionLists(inventoryExist.Items, itemsInput);

                Tools.ExceptionLists(itemsInput, inventoryExist.Items).ForEach(item => inventoryExist.AddItem(item));
                Tools.ExceptionLists(inventoryExist.Items, itemsInput).ForEach(item => inventoryExist.RemoveItem(item));

                await _inventoryRepository.AddItemsToExistInventory(inventoryExist);
            }
            else
            {
                Inventory inventory = new Inventory()
                {
                    Name = inventoryInput.Name,
                    Description = inventoryInput.Description
                };

                itemsInput.ForEach(item => inventory.AddItem(item));

                await _inventoryRepository.AddItemsToInventory(inventory);
            }
        }

        public async Task RemoveItemFromInventoryByName(string name)
        {
            Tools.ArgumentNull(name);

            var inventories = _inventoryRepository.GetAllItemsFromInventory();

            Item itemRemoved;
            bool itemNoExist = true;

            foreach (var inventory in inventories)
            {
                itemRemoved = inventory.Items.Where(x => x.Name == name).FirstOrDefault();

                if (itemRemoved != null)
                {
                    inventory.RemoveItem(itemRemoved);
                    itemNoExist = false;
                }
            }

            if(itemNoExist)
            {
                throw new Exception($@"Item no exist with Name ""{name}""");
            }

            
            
            await _inventoryRepository.UpdateInventories(inventories);
        }
    }
}
