using GoalChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.UnitTest.Inventories.Builder
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
