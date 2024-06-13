using MediatR;
using Modules.Catalogs.Application.Dtos;

namespace Modules.Catalogs.Application.Queries.GetCatalogQuery
{
    public class GetCatalogQuery : IRequest<CatalogDto>
    {
        public GetCatalogQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}