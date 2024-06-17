using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CatalogCreatedEventHandler> _logger;
        public CatalogCreatedEventHandler(ILogger<CatalogCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(CatalogCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("catalog created event handler executed for catalog {name}", notification.Name);
        }
    }
}