using Modules.Catalogs.Domain;
using Modules.Catalogs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Infrastructure
{
    public class CatalogRepository : ICatalogRepository
    {
        public CatalogDbContext _context { get; set; }
        public CatalogRepository(CatalogDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public async Task<bool> AddCatalogAsync(Catalog catalog)
        {
            await _context.Catalogs.AddAsync(catalog);
            return true;
        }
    }
}
