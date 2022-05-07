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


        public void AddItem(Item newItem) 
        {
            Tools.ArgumentNull(newItem);

            Items.Add(newItem);
            Events.Add(new ItemAddInInventoryDomainEvent(newItem));
        }

        public void RemoveItem(Item item)
        {
            Tools.ArgumentNull(item);

            Items.Remove(item);
            Events.Add(new ItemRemovedFromInventoryDomainEvent(item, Name));
        }

        

    }
}
