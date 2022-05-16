using SampleNetArch.UnitTest.Inventories.Builder;
using SampleNetArch.UnitTest.Items.Builder;
using System;
using Xunit;

namespace SampleNetArch.UnitTest.Items
{
    public class Item_AddItems
    {
        private InventoryBuilder _inventoryBuilder = new InventoryBuilder("Inventory1");
        private ItemBuilder _itemBuilder = new ItemBuilder();

        [Fact]
        public void AddItemsToInventory()
        {
            _itemBuilder.ItemTestList.ForEach(item => _inventoryBuilder.Inventory.AddItem(item));

            _itemBuilder.ItemTestList.ForEach(item => Assert.Contains(item, _inventoryBuilder.Inventory.Items));
        }

        [Fact]
        public void ThrowsExceptionGivenNullNewItem()
        {
            Action action = () => _inventoryBuilder.Inventory.AddItem(null);
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("addItem", ex.ParamName);
        }
    }
}