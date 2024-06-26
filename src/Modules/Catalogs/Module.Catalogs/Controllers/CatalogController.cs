﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modules.Catalogs.Application;
using Modules.Catalogs.Application.Commands.AddCatalog;
using Modules.Catalogs.Application.Dtos;
using Modules.Catalogs.Application.Queries.GetCatalogQuery;


namespace Module.Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController
    {
        public IMediator _mediatR { get; set; }

        public CatalogController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost]
        public async Task<CatalogDto> CreateCatalog(CatalogDto command)
        {
            var createdCatalog = await _mediatR.Send(new CreateCatalogCommand(command.Name));
            return createdCatalog;
        }
        [HttpGet]
        public async Task<CatalogDto> GetCatalog([FromQuery] Guid id)
        {
            var selectedCatalog = await _mediatR.Send(new GetCatalogQuery(id));
            return selectedCatalog;
        }
    }

}
