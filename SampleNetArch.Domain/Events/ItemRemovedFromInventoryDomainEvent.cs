using GoalChallenge.Domain.Events.Base;
using GoalChallenge.Domain.Models;

namespace GoalChallenge.Domain.Events
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
