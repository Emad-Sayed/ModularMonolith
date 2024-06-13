using Microsoft.EntityFrameworkCore;
using Modules.Catalogs.Domain;

namespace Modules.Catalogs.Infrastructure
{
    public class CatalogRepository : ICatalogRepository
    {
        public CatalogDbContext _context { get; set; }
        public CatalogRepository(CatalogDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCatalogAsync(Catalog catalog)
        {
            await _context.Catalogs.AddAsync(catalog);
            return true;
        }

        public async Task<Catalog> GetCatalogAggregateRootAsync(Guid id)
        {
            return await _context.Catalogs.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
