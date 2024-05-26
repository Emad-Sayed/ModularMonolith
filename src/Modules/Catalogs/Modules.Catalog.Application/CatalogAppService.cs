using Modules.Catalogs.Application.Commands;
using Modules.Catalogs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Application
{
    public class CatalogAppService
    {
        private readonly CatalogDomainService catalogDomainService;
        public CatalogAppService(CatalogDomainService catalogDomainService)
        {
            this.catalogDomainService = catalogDomainService;
        }
        public async Task<Catalog> AddCatalog(CreateCatalogCommand command)
        {
            return await catalogDomainService.AddCatalog(command.Name);
        }
    }
}
