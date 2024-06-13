using MediatR;
using Modules.Catalogs.Domain.Base;
using Modules.Catalogs.Infrastructure;


namespace Modules.Catalogs.Infrastructure
{
    static class MediatorDistributorExtension
    {
        public static async Task DispatchCatalogDomainEventsAsync(this IMediator mediator, CatalogDbContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<AggregateRoot>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}