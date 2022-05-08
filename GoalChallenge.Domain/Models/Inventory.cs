using GoalChallenge.Common;
using GoalChallenge.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Domain.Models
{
    public class Inventory : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual List<Item> Items { get; set; } = new List<Item>();


        public void AddItem(Item addItem) 
        {
            Tools.ArgumentNull(addItem, nameof(addItem));

            Items.Add(addItem);
            Events.Add(new ItemAddInInventoryDomainEvent(addItem));
        }

        public void RemoveItem(Item removeItem)
        {
            Tools.ArgumentNull(removeItem, nameof(removeItem));

            Items.Remove(removeItem);
            Events.Add(new ItemRemovedFromInventoryDomainEvent(removeItem, Name));
        }

        

    }
}
