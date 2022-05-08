using GoalChallenge.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Domain.Models
{
    public class Item : EntityBase, IEquatable<Item>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(10);
        public int Type { get; set; }
        public Guid InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; } = new Inventory();

        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        public bool Equals(Item other)
        {
            return other != null &&
                   Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return 2108858624 + Name.GetHashCode();
        }
    }
}
