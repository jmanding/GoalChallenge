using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleNetArch.Domain.Models;
using SampleNetArch.Domain.Models.Base;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any());

            var domainEvents = entitiesWithEvents.SelectMany(e => e.Events).ToList();

            entitiesWithEvents.ToList().ForEach(entity => entity.Events.Clear());

            var task = domainEvents.Select(async (domainEvent) =>
            {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            });

            await Task.WhenAll(task);

            return result;
        }
    }
}
