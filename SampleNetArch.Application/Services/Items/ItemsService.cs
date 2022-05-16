using SampleNetArch.Common.Exceptions;
using SampleNetArch.Domain.Events;
using MediatR;
using SampleNetArch.Application.Services.Items.Interfaces;
using SampleNetArch.Common;
using SampleNetArch.Common.Models;
using SampleNetArch.Domain.Models;
using SampleNetArch.Infrastructure.Data.Repositories.Items;

namespace SampleNetArch.Application.Services.Items
{
    internal class ItemsService : IItemsService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMediator _mediator;

        public ItemsService(IInventoryRepository inventoryRepository, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
        }

        public async Task<dynamic> GetAllItems()
        {
            return await _inventoryRepository.GetAllItemsFromInventory();
        }

        public async Task AddItemsToInventory(InventoryInput inventoryInput)
        {
            List<Item> itemsInput = new List<Item>();
            inventoryInput.Items.ForEach(item => itemsInput.Add(new Item() { Name = item.Name, ExpirationDate = item.ExpirationDate, Type = item.Type }));

            var inventory = await _inventoryRepository.GetInventoryByName(inventoryInput.Name);

            if (inventory != null)
            {
                Tools.ExceptionLists(itemsInput, inventory.Items).ForEach(item => inventory.AddItem(item));
                Tools.ExceptionLists(inventory.Items, itemsInput).ForEach(item => inventory.RemoveItem(item));

                await _inventoryRepository.AddItemsToExistInventory(inventory);
            }
            else
            {
                inventory = new Inventory()
                {
                    Name = inventoryInput.Name,
                    Description = inventoryInput.Description
                };

                itemsInput.ForEach(item => inventory.AddItem(item));

                await _inventoryRepository.AddItemsToInventory(inventory);
            }

            //foreach (var domainEvent in inventory.Events)
            //{
            //    await _mediator.Publish(domainEvent);
            //}
        }

        public async Task RemoveItemFromInventoryByName(string name)
        {
            Tools.ArgumentNull(name, nameof(name));

            var inventories = await _inventoryRepository.GetAllItemsFromInventory();

            Item? itemRemoved;
            bool itemNoExist = true;

            foreach (var inventory in inventories)
            {
                itemRemoved = inventory.Items.FirstOrDefault(x => x.Name == name);

                if (itemRemoved != null)
                {
                    inventory.RemoveItem(itemRemoved);
                    itemNoExist = false;
                }
            }

            if (itemNoExist)
            {
                throw new NoDataException($@"Item no exist with Name ""{name}""");
            }

            await _inventoryRepository.UpdateInventories(inventories);

            //foreach (var inventory in inventories)
            //{
            //    foreach (var domainEvent in inventory.Events)
            //    {
            //        await _mediator.Publish(domainEvent);

            //    }
            //}
        }
    }
}
