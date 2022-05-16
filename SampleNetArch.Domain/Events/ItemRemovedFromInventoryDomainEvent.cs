using SampleNetArch.Domain.Events.Base;
using SampleNetArch.Domain.Models;

namespace SampleNetArch.Domain.Events
{
    public class ItemRemovedFromInventoryDomainEvent : BaseDomainEvent
    {
        public Item Item { get; set; }
        public string InventoryName { get; set; }


        public ItemRemovedFromInventoryDomainEvent(Item item, string inventoryName)
        {
            Item = item;
            InventoryName = inventoryName;
        }
    }
}
