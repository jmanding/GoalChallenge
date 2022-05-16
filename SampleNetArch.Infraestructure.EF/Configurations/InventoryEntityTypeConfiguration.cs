using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleNetArch.Domain.Models;
using SampleNetArch.Infraestructure.EF.Configurations.Base;

namespace SampleNetArch.Infraestructure.EF.Configurations
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
