using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleNetArch.Domain.Models;
using SampleNetArch.Infraestructure.EF.Configurations;

namespace SampleNetArch.Infraestructure.EF
{
    public class EFContext : DbContext
    {
        private readonly IMediator _mediator;

        public DbSet<Item>? Items { get; set; }
        public DbSet<Inventory>? Inventorys { get; set; }

        public EFContext(DbContextOptions<EFContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemEntityTypeConfiguration).Assembly);
        }
    }
}
