using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Domain
{
    public class CatalogDomainService
    {
        public ICatalogRepository _catalogRepository { get; set; }
        public CatalogDomainService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }
        public async Task<Catalog> AddCatalog(string name)
        {
            var id = Guid.NewGuid();
            var catalog = new Catalog(id, name);
            await _catalogRepository.AddCatalogAsync(catalog);
            await _catalogRepository.UnitOfWork.SaveEntitiesAsync();
            return catalog;
        }
    }
}
