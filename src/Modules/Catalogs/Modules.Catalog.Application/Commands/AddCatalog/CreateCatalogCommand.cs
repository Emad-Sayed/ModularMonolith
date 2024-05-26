using MediatR;
using Modules.Catalogs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Application.Commands.AddCatalog
{
    public record CreateCatalogCommand : IRequest<Catalog>
    {
        public CreateCatalogCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
