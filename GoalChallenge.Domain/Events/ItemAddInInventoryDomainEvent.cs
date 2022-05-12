using GoalChallenge.Domain.Events.Base;
using GoalChallenge.Domain.Models;

namespace GoalChallenge.Domain.Events
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
