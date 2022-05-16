using SampleNetArch.Domain.Events.Base;
using SampleNetArch.Domain.Models;

namespace SampleNetArch.Domain.Events
{
    public class ItemAddInInventoryDomainEvent : BaseDomainEvent
    {
        public Item Item { get; set; }


        public ItemAddInInventoryDomainEvent(Item item)
        {
            Item = item;
        }
    }
}
