using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Domain.Events
{
    public class CatalogCreated : INotification
    {
        public string Name { get; set; }
        public CatalogCreated(string name)
        {
            Name = name;
        }
    }
}
