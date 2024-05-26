using MediatR;
using Modules.Catalogs.Domain;

namespace Modules.Catalogs.Application.Commands.AddCatalog
{
    public class CreateCatalogEventHandler : IRequestHandler<CreateCatalogCommand, Catalog>
    {
        private readonly IUnitOfWork _uow;
        private readonly CatalogDomainService _catalogDomainService;
        public CreateCatalogEventHandler(CatalogDomainService catalogDomainService,
            IUnitOfWork uow)
        {
            _catalogDomainService = catalogDomainService;
            _uow = uow;
        }
        public async Task<Catalog> Handle(CreateCatalogCommand request,
            CancellationToken cancellationToken)
        {
            var catalog = await _catalogDomainService.AddCatalogAsync(request.Name);
            await _uow.SaveEntitiesAsync();
            return catalog;
        }
    }
}
