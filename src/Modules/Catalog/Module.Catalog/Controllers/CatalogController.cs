using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modules.Catalogs.Application;
using Modules.Catalogs.Application.Commands;


namespace Module.Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController
    {
        public CatalogAppService _catalogAppService { get; set; }

        public CatalogController(CatalogAppService catalogAppService)
        {
            _catalogAppService = catalogAppService;
        }

        [HttpPost]
        public async Task<bool> CreateCatalog(CreateCatalogCommand command)
        {
            await _catalogAppService.AddCatalog(command);
            return true;
        }
    }

}
