using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Catalogs.Domain;
using Modules.Catalogs.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Infrastructure
{
    public class CatalogDbContext : DbContext
    {
        private readonly IMediator _mediator;
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public DbSet<Catalog> Catalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            await _mediator.DispatchCatalogDomainEventsAsync(this);


            foreach (var entry in ChangeTracker.Entries<AggregateRoot>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "";
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "";
                        entry.Entity.LastModifiedAt = DateTime.UtcNow;
                        break;
                }
            }

            await base.SaveChangesAsync(cancellationToken);

            await _mediator.DispatchCatalogIntegrationEventsAsync(this);


            return true;
        }
    }
}
