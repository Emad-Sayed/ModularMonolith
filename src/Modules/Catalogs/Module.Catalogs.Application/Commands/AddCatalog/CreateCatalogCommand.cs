using MediatR;
using Module.Shared.Application.Intefaces.UnitOfWork;
using Modules.Catalogs.Application.Dtos;
using Modules.Catalogs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Application.Commands.AddCatalog
{
    public record CreateCatalogCommand : IRequest<CatalogDto> , IUnitOfWorkCommand
    {
        public CreateCatalogCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
