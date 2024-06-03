using MediatR;
using Module.Shared.Application.Cache.Intefaces;
using Modules.Catalogs.Application.Commands.AddCatalog;
using Modules.Catalogs.Application.Dtos;
using Modules.Catalogs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Application.Queries.GetCatalogQuery
{
    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQuery, CatalogDto>
    {
        public readonly ICatalogRepository _rep;
        public readonly IBussinessDistributedCache<Catalog> _cache;

        public GetCatalogQueryHandler(IBussinessDistributedCache<Catalog> cache, ICatalogRepository rep)
        {
            _cache = cache;
            _rep = rep;
        }

        public async Task<CatalogDto> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
        {
            Catalog catalogItem;
            catalogItem = await _cache.GetItemAsync(request.Id.ToString());

            if (catalogItem == null)
            {
                catalogItem = await _rep.GetCatalogAggregateRootAsync(request.Id);
            }

            if (catalogItem == null)
                throw new Exception(""); //TODO handle bussiness Exceptions


            return new CatalogDto { Id = catalogItem.Id, Name = catalogItem.Name };
        }
    }
}
