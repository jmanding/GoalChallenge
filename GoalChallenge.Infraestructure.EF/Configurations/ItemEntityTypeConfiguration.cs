using GoalChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalChallenge.Infrastructure.EF.Configurations
{
    public class ItemEntityTypeConfiguration : EntityBaseTypeConfiguration<Item>
    {
        public override void Configure(EntityTypeBuilder<Item> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Inventory)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.InventoryId);
        }
    }
}
