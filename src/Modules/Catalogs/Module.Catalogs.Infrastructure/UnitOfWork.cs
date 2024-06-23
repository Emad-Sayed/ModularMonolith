using Module.Shared.Application.Intefaces.UnitOfWork;
using Modules.Catalogs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public CatalogDbContext _context { get; set; }

        public UnitOfWork(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveEntitiesAsync(cancellationToken);
            return true;
        }
        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
