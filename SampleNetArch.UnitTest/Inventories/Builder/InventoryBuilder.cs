using SampleNetArch.Domain.Models;

namespace SampleNetArch.UnitTest.Inventories.Builder
{
    public class InventoryBuilder
    {
        public Inventory Inventory { get; set; }

        public InventoryBuilder(string name)
        {
            Inventory = new Inventory()
            {
                Name = name,
                Description = "Description Inventory 1"
            };
        }
    }
}
