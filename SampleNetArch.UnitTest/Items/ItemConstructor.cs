using SampleNetArch.UnitTest.Items.Builder;
using System;
using Xunit;

namespace SampleNetArch.UnitTest.Items
{
    public class ItemConstructor
    {
        private string _testItemName = "Item Test Name1";
        private DateTime _testItemExpirationDate = DateTime.UtcNow.AddDays(1);
        private int _testItemType = 5;

        private ItemBuilder _itemBuilder;


        public ItemConstructor()
        {
            _itemBuilder = new ItemBuilder(_testItemName, _testItemExpirationDate, _testItemType);
        }

        [Fact]
        public void InitializesParameters()
        {
            Assert.Equal(_testItemName, _itemBuilder.Item.Name);
            Assert.Equal(_testItemExpirationDate, _itemBuilder.Item.ExpirationDate);
            Assert.Equal(_testItemType, _itemBuilder.Item.Type);
        }

        [Fact]
        public void InitializesEntityBase()
        {
            Assert.IsType<Guid>(_itemBuilder.Item.Id);
            Assert.NotEqual(_itemBuilder.Item.Id, Guid.Empty);
            Assert.NotEqual(_itemBuilder.Item.CreationDate, DateTime.MinValue);
            Assert.NotEqual(_itemBuilder.Item.ModificationDate, DateTime.MinValue);
        }

    }
}
