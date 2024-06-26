﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Domain
{
    public interface ICatalogRepository
    {
        Task<bool> AddCatalogAsync(Catalog catalog);
        Task<Catalog> GetCatalogAggregateRootAsync(Guid id);
    }
}
