using GoalChallenge.UnitTest.Inventories.Builder;
using GoalChallenge.UnitTest.Items.Builder;
using System;
using System.Linq;
using Xunit;

namespace GoalChallenge.UnitTest.Items
{
    public class Item_RemoveItems
    {
        private readonly InventoryBuilder _inventoryBuilder = new InventoryBuilder("Inventory1");
        private readonly ItemBuilder _itemBuilder = new ItemBuilder();

        [Fact]
        public void RemoveItemsToInventory()
        {
            _itemBuilder.ItemTestList.ForEach(item => _inventoryBuilder.Inventory.AddItem(item));

            _inventoryBuilder.Inventory.RemoveItem(_itemBuilder.ItemTestList.First());
            _inventoryBuilder.Inventory.RemoveItem(_itemBuilder.ItemTestList.Last());

            Assert.DoesNotContain(_itemBuilder.ItemTestList.First(), _inventoryBuilder.Inventory.Items);
            Assert.DoesNotContain(_itemBuilder.ItemTestList.Last(), _inventoryBuilder.Inventory.Items);
        }

        [Fact]
        public void ThrowsExceptionGivenNullRemoveItem()
        {
            Action action = () => _inventoryBuilder.Inventory.RemoveItem(null);
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("removeItem", ex.ParamName);
        }
    }
}
