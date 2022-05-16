namespace SampleNetArch.Common.Models
{
    public class InventoryInput
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual List<ItemInput> Items { get; set; } = new List<ItemInput>();
    }
}
