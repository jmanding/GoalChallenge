using GoalChallenge.Domain.Events.Base;
using GoalChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
