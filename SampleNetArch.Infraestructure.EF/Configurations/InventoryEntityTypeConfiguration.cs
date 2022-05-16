using GoalChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalChallenge.Infrastructure.EF.Configurations
{
    public class InventoryEntityTypeConfiguration : EntityBaseTypeConfiguration<Inventory>
    {
        public override void Configure(EntityTypeBuilder<Inventory> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
