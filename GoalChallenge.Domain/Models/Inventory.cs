using GoalChallenge.Common;
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
        public List<Item> Items { get; set; } = new List<Item>();

        public void AddItem(Item newItem) 
        {
            Tools.ArgumentNull(newItem);

            Items.Add(newItem);

            //var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
            //Events.Add(newItemAddedEvent);
        }

        //public void UpdateName(string newName)
        //{
        //    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        //}

    }
}
