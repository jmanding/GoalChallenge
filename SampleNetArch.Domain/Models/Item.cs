namespace GoalChallenge.Domain.Models
{
    public class Item : EntityBase, IEquatable<Item>
    {
        public string? Name { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(10);
        public int Type { get; set; }
        public Guid InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; } = new Inventory();

        public override bool Equals(object obj)
        {
            if(obj == null) return false;
            return Equals(obj as Item);
        }

        public bool Equals(Item other)
        {
            if (Name == null) return false;
            return other != null &&
                   Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            if (Name == null) return 0;
            return 2108858624 + Name.GetHashCode();
        }
    }
}
