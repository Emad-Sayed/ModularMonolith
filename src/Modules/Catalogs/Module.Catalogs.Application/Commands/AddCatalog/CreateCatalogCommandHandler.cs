using MediatR;
using Module.Shared.Application.Cache.Intefaces;
using Modules.Catalogs.Application.Dtos;
using Modules.Catalogs.Domain;

namespace Modules.Catalogs.Application.Commands.AddCatalog
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, CatalogDto>
    {
        private readonly CatalogDomainService _catalogDomainService;
        public readonly IBussinessDistributedCache _cache;

        public CreateCatalogCommandHandler(CatalogDomainService catalogDomainService,
            IBussinessDistributedCache cache)
        {
            _catalogDomainService = catalogDomainService;
            _cache = cache;
        }
        public async Task<CatalogDto> Handle(CreateCatalogCommand request,
            CancellationToken cancellationToken)
        {
            var catalog = await _catalogDomainService.AddCatalogAsync(request.Name);
            await _cache.SetItemAsync(catalog.Id.ToString(), catalog);
            return new CatalogDto { Id = catalog.Id, Name = catalog.Name };
        }
    }
}
