using GoalChallenge.UnitTest.Inventories.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GoalChallenge.UnitTest.Inventories
{
    public class InventoryConstructor
    {
        private string _testNameInventory = "Test Name 1";
        private InventoryBuilder _inventoryBuilder;

        public InventoryConstructor()
        {
            _inventoryBuilder = new InventoryBuilder(_testNameInventory);
        }

        [Fact]
        public void InitializesName()
        {
            Assert.Equal(_testNameInventory, _inventoryBuilder.Inventory.Name);
        }

        [Fact]
        public void InitializesItemListEmptyList()
        {
            Assert.NotNull(_inventoryBuilder.Inventory.Items);
        }

        [Fact]
        public void InitializesEntityBase()
        {
            Assert.IsType<Guid>(_inventoryBuilder.Inventory.Id);
            Assert.NotEqual(_inventoryBuilder.Inventory.Id, Guid.Empty);
            Assert.NotEqual(_inventoryBuilder.Inventory.CreationDate, DateTime.MinValue);
            Assert.NotEqual(_inventoryBuilder.Inventory.ModificationDate, DateTime.MinValue);
        }

    }
}
