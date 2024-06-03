using MediatR;
using Module.Shared.Application.Cache.Intefaces;
using Modules.Catalogs.Application.Dtos;
using Modules.Catalogs.Domain;

namespace Modules.Catalogs.Application.Commands.AddCatalog
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, CatalogDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly CatalogDomainService _catalogDomainService;
        public readonly IBussinessDistributedCache<Catalog> _cache;

        public CreateCatalogCommandHandler(CatalogDomainService catalogDomainService,
            IUnitOfWork uow,
            IBussinessDistributedCache<Catalog> cache)
        {
            _catalogDomainService = catalogDomainService;
            _uow = uow;
            _cache = cache;
        }
        public async Task<CatalogDto> Handle(CreateCatalogCommand request,
            CancellationToken cancellationToken)
        {
            var catalog = await _catalogDomainService.AddCatalogAsync(request.Name);
            await _uow.SaveEntitiesAsync();
            await _cache.SetItemAsync(catalog.Id.ToString(), catalog);
            return new CatalogDto { Id = catalog.Id, Name = catalog.Name };
        }
    }
}
