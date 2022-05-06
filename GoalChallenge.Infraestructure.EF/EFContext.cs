using GoalChallenge.Domain.Models;
using GoalChallenge.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalChallenge.Infrastructure.EF
{
    public class EFContext : DbContext, IDisposable
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemEntityTypeConfiguration).Assembly);
        }
    }
}
