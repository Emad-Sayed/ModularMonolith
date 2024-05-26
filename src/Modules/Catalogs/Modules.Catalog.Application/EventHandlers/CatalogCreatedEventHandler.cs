using MediatR;
using Modules.Catalogs.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Catalogs.Application.EventHandlers
{
    public class CatalogCreatedEventHandler : INotificationHandler<CatalogCreated>
    {

        public CatalogCreatedEventHandler()
        {
        }

        public async Task Handle(CatalogCreated notification, CancellationToken cancellationToken)
        {
        }
    }
}