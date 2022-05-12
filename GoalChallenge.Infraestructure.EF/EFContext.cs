using GoalChallenge.Domain;
using GoalChallenge.Domain.Models;
using GoalChallenge.Infrastructure.EF.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoalChallenge.Infrastructure.EF
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

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events;
                
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }

                entity.Events.Clear();
            }

            return result;
        }
    }
}
