using SampleNetArch.Domain.Models;
using System;
using System.Collections.Generic;

namespace SampleNetArch.UnitTest.Items.Builder
{
    public class ItemBuilder
    {
        public List<Item> ItemTestList { get; set; } = new List<Item>();
        public Item Item { get; set; } = new Item();

        public ItemBuilder(string name, DateTime expirationDate, int type)
        {
            Item = new Item()
            {
                Name = name,
                ExpirationDate = expirationDate,
                Type = type
            };
        }

        public ItemBuilder()
        {
            ItemTestList.Add(new Item() { Name = "ItemTest1", ExpirationDate = DateTime.UtcNow.AddDays(10), Type = 1 });
            ItemTestList.Add(new Item() { Name = "ItemTest2", ExpirationDate = DateTime.UtcNow.AddDays(10), Type = 1 });
            ItemTestList.Add(new Item() { Name = "ItemTest3", ExpirationDate = DateTime.UtcNow.AddDays(10), Type = 1 });
        }
    }
}
